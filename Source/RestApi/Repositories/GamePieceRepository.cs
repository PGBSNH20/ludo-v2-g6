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
        public GamePieceRepository(LudoContext context) : base(context) { }

        public async Task<bool> UpdatePositionAsync(GameBoard gameBoard, GamePiece gamePiece, int diceRoll)
        {
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
            if ((gamePiece.StepsTaken + diceRoll) > 59)
            {
                int stepsBack = (gamePiece.CurrentPosition + diceRoll) - 59;
                gamePiece.CurrentPosition = 59 - stepsBack;
                gamePiece.StepsTaken = gamePiece.CurrentPosition;
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
            if (gamePiece.CurrentPosition == 59)
                gamePiece.IsInGoal = true;
            return gamePiece;
        }

        public GamePiece GetGamePiece(GameBoard gameBoard, Guid id)
        {
            var gamePlayers = gameBoard.GamePlayer;
            return gamePlayers.SelectMany(piece => piece.GamePieces).FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<GamePieceDTO>> GetGamePiecesDtoAsync(Guid gameBoardId)
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
            return gamePieceDtos;
        }

        public static List<GamePiece> CreateGamePieces(GamePlayer player)
        {
            var startPosition = GetStartPosition(player);
            var gamePieces = new List<GamePiece>();

            for (int i = 0; i < 4; i++)
            {
                gamePieces.Add(new GamePiece() { Id = Guid.NewGuid(), StartingPosition = startPosition });
            }

            return gamePieces;
        }

        private static int GetStartPosition(GamePlayer player)
        {
            if (player.Color == Color.Red)
                return 13;
            if (player.Color == Color.Green)
                return 26;
            if (player.Color == Color.Yellow)
                return 39;

            return 52;
        }
    }
}

