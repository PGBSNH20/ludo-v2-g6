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
            var player = gameBoard.GamePlayer;
            for (int i = 0; i < diceRoll; i++)
            {
                count++;
                foreach (var p in player)
                {
                    foreach (var piece in p.GamePieces)
                    {
                        if (count == piece.CurrentPosition && p.Color != p.Color)
                            return false;
                    }
                }
            }
            return true;
        }
        public async Task<bool> UpdatePosition(GameBoard gameBoard, GamePiece gamePiece, int diceRoll)
        {
            if (!IsCoastClear(diceRoll, gameBoard, gamePiece) && !gamePiece.IsInGoal)
                return false;
            if ((gamePiece.StepsTaken + diceRoll) > 58)
            {
                int stepsBack = (gamePiece.StepsTaken + diceRoll) - 58;
                gamePiece.StepsTaken = 58 - stepsBack;
                gamePiece.CurrentPosition = gamePiece.StepsTaken;
            }
            else
            {
                for (int i = 0; i < diceRoll; i++)
                {
                    gamePiece.CurrentPosition++;
                    if (gamePiece.CurrentPosition == gamePiece.StartingPosition && gamePiece.StepsTaken == 52)
                        gamePiece.CurrentPosition = 54;
                    if (gamePiece.CurrentPosition == 53 && gamePiece.StepsTaken < 52)
                        gamePiece.CurrentPosition = 1;
                }
                gamePiece.StepsTaken += diceRoll;
            }

            IsPieceInGoal(gamePiece);

            SendToNest(gameBoard, gamePiece);
            
            await Save();
            return true;
        }
        public GamePiece SendToNest(GameBoard gameBoard, GamePiece gamePiece)
        {
            var player = gameBoard.GamePlayer;
            foreach (var p in player)
            {
                if(!p.IsPlayersTurn)
                foreach (var piece in p.GamePieces)
                {
                    if (gamePiece.CurrentPosition == piece.CurrentPosition && gamePiece.StepsTaken < 52)
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
            GameBoard gameBoard = await gameBoardRepository.GetCurrentGameBoardAsync(gameBoardId);
            var newPieces = new List<GamePieceDTO>();

            foreach (var player in gameBoard.GamePlayer)
            {
                foreach (var piece in player.GamePieces)
                {
                    var n = new GamePieceDTO()
                        {Color = player.Color.ToString(), CurrentPosition = piece.CurrentPosition};
                    newPieces.Add(n);
                }
            }

            return newPieces;
        }
    }
}

