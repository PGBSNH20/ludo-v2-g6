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
            var player = gameBoard.GamePlayer;
            for (int i = 0; i < diceRoll; i++)
            {
                gamePiece.CurrentPosition++;
                foreach (var p in player)
                {
                    foreach (var piece in p.GamePieces)
                    {
                        if (gamePiece.CurrentPosition == piece.CurrentPosition && p.Color != p.Color)
                            return false;
                    }
                }
            }
            return true;
        }
        public async Task<GamePiece> UpdatePosition(GameBoard gameBoard, GamePiece gamePiece, int diceRoll)
        {
            if (IsCoastClear(diceRoll, gameBoard, gamePiece) && !gamePiece.IsInGoal)
            {
                gamePiece.CurrentPosition += diceRoll;
                gamePiece.StepsTaken += diceRoll;
                SendToNest(gameBoard, gamePiece);
            }
            await Save();
            return gamePiece;
        }

        public GamePiece SendToNest(GameBoard gameBoard, GamePiece gamePiece)
        {
            var player = gameBoard.GamePlayer;
            foreach (var p in player)
            {
                foreach (var piece in p.GamePieces)
                {
                    if (gamePiece.CurrentPosition == piece.CurrentPosition)
                    {
                        piece.CurrentPosition = 0;
                        piece.StepsTaken = 0;
                        return piece;
                    }
                }
            }
            return gamePiece;
        }
        public GamePiece IsPieceInGoal(GamePiece gamePiece)
        {
            if (gamePiece.StepsTaken == 52)
                gamePiece.IsInGoal = true;

            return gamePiece;
        }
        public GamePiece GetGamePiece(GameBoard gameBoard, Guid id)
        {
            var gamePlayers = gameBoard.GamePlayer;
            return gamePlayers.SelectMany(piece => piece.GamePieces).FirstOrDefault(p => p.Id == id);

        }

    }
}

