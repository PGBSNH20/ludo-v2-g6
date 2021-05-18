﻿using System;
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

        public bool IsCoastClear(int diceRoll, GameBoard gameBoard, GamePiece gamePiece)
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
        public GamePiece UpdatePosition(GameBoard gameBoard, GamePiece gamePiece, int diceRoll)
        {
            if (IsCoastClear(diceRoll, gameBoard, gamePiece) && !gamePiece.IsInGoal)
            {
                gamePiece.CurrentPosition += diceRoll;
                gamePiece.StepsTaken += diceRoll;
                SendToNest(gameBoard, gamePiece);
            }
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

    }
}

