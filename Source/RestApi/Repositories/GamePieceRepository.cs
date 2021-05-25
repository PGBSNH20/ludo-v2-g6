using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Repositories.Contracts;
using RestApi.Services;

namespace RestApi.Repositories
{
    public class GamePieceRepository : Repository, IGamePieceRepository
    {
        public GamePieceRepository(LudoContext context) : base(context)
        {
        }

        private static bool IsCoastClear(int diceRoll, GameBoard gameBoard, GamePiece gamePiece)
        {
            int count = gamePiece.CurrentPosition;

            if (gamePiece.CurrentPosition == 0)
                count = gamePiece.StartingPosition;

            var players = gameBoard.GamePlayer;

            for (int i = 0; i < diceRoll; i++)
            {
                foreach (var p in players)
                {
                    
                        foreach (var piece in p.GamePieces)
                        {
                            if (count == piece.CurrentPosition && piece.StartingPosition != gamePiece.StartingPosition)
                                return false;
                        }
                }
                count++;
            }
            return true;
        }
        public async Task<bool> UpdatePosition(GameBoard gameBoard, GamePiece gamePiece, int diceRoll)
        {
            if (!IsCoastClear(diceRoll, gameBoard, gamePiece) && !gamePiece.IsInGoal)
                return false;

            var updatedPiece = CalculateMovement(gamePiece, diceRoll);

            if (updatedPiece == null)
                return false;

            IsPieceInGoal(updatedPiece);

            SendToNest(gameBoard, updatedPiece);

            await Save();
            return true;
        }
        public GamePiece CalculateMovement(GamePiece gamePiece, int diceRoll)
        {
            if ((gamePiece.StepsTaken + diceRoll) > 58)
            {
                int stepsBack = (gamePiece.StepsTaken + diceRoll) - 58;
                gamePiece.StepsTaken = 58 - stepsBack;
                gamePiece.CurrentPosition = gamePiece.StepsTaken;
            }
            else
            {
                if (gamePiece.CurrentPosition == 0 && (diceRoll == 1 || diceRoll == 6))
                {
                    gamePiece.CurrentPosition = gamePiece.StartingPosition + (diceRoll - 1);
                    gamePiece.StepsTaken = diceRoll - 1;
                }
                else if (gamePiece.CurrentPosition == 0)
                    return null;
                else
                {
                    gamePiece.CurrentPosition = CompleteLap(gamePiece, diceRoll);
                    gamePiece.StepsTaken += diceRoll;
                }
            }
            return gamePiece;
        }
        private static int CompleteLap(GamePiece gamePiece, int diceRoll)
        {
            var gp = gamePiece.CurrentPosition;
            for (int i = 0; i < diceRoll; i++)
            {
                gp++;
                if (gp == gamePiece.StartingPosition && gamePiece.StepsTaken == 52)
                    gp = 54;
                if (gp == 53 && gamePiece.StepsTaken < 52)
                    gp = 1;
            }
            return gp;
        }
        public GamePiece SendToNest(GameBoard gameBoard, GamePiece gamePiece)
        {
            var players = gameBoard.GamePlayer;

            foreach (var p in players)
            {
                if (!p.IsPlayersTurn)
                    foreach (var piece in p.GamePieces)
                    {
                        if (piece.Id != gamePiece.Id)
                            if (gamePiece.CurrentPosition == piece.CurrentPosition && gamePiece.StepsTaken < 53)
                            {
                                piece.CurrentPosition = 0;
                                piece.StepsTaken = 0;
                            }
                    }
            }
            return gamePiece;
        }

        public GamePiece IsPieceInGoal(GamePiece gamePiece)
        {
            if (gamePiece.StepsTaken == 58)
                gamePiece.IsInGoal = true;

            return gamePiece;
        }

        public GamePiece GetGamePiece(GameBoard gameBoard, Guid id)
        {
            var gamePlayers = gameBoard.GamePlayer;
            return gamePlayers.SelectMany(piece => piece.GamePieces).FirstOrDefault(p => p.Id == id);

        }

        public async Task<List<GamePieceDTO>> GetGamePiecesDto(Guid gameBoardId)
        {
            var gameBoardRepository = new GameBoardRepository(_context);
            var gamePlayerRepository = new GamePlayerRepository(_context);
            GameBoard gameBoard = await gameBoardRepository.GetCurrentGameBoardAsync(gameBoardId);
            List<GamePieceDTO> gamePieceDtos = new List<GamePieceDTO>();

            foreach (var gamePlayer in gameBoard.GamePlayer)
            {
                var gamePieces = await gamePlayerRepository.GetGamePiecesAsync(gamePlayer.Id);
                gamePlayer.GamePieces = gamePieces;
            }

            foreach (var gamePlayer in gameBoard.GamePlayer)
            {
                foreach (var piece in gamePlayer.GamePieces)
                {
                    gamePieceDtos.Add(new GamePieceDTO()
                    {
                        Color = gamePlayer.Color.ToString().ToLower(),
                        CurrentPosition = piece.CurrentPosition.ToString(),
                        GameBoardId = gameBoard.Id.ToString(),
                        PieceId = piece.Id.ToString(),
                        GamePlayerId = gamePlayer.Id.ToString()
                    });
                }
            }

            //await Task.Delay(1);
            return gamePieceDtos;
            //return (from player in gameBoard.GamePlayer from piece in player.GamePieces select new GamePieceDTO() {Color = player.Color.ToString(), CurrentPosition = piece.CurrentPosition}).ToList();
        }
    }
}

