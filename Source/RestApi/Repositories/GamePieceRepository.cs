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

        public GamePiece UpdatePosition(GamePiece gamePiece, int diceRoll)
        {
            gamePiece.CurrentPosition += diceRoll;
            return gamePiece;
            
        }


        //public async Task<bool> IsCoastClear(int diceRoll, GameBoard gameBoard, GamePiece gamePiece)
        //{

        //    var currentGameBoard = GetCurrentGameBoardAsync(gameBoard.Id);
        //    for (int i = 0; i < diceRoll; i++)
        //    {
        //        gamePiece.CurrentPosition++;
        //        foreach(var piece in occupiedPositions)
        //        {
        //            if(gamePiece.CurrentPosition == piece)
        //        }
        //    }
        //}

        public bool IsPieceInGoal(int diceRoll, GamePlayer gamePlayer)
        {
            throw new NotImplementedException();
        }

        public Task Move()
        {
            throw new NotImplementedException();
        }
    }
}

