using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;
using RestApi.Repositories.Contracts;
using RestApi.Services;

namespace RestApi.Repositories
{
    public class GamePieceRepository : Repository, IGamePieceRepository
    {
        public GamePieceRepository(LudoContext context) : base(context) { }

        public async Task UpdatePlayerPosition(GamePiece gamePiece)
        {

            return;
        }
        public void PieceStartPosition(GamePiece gamePiece)
        {
            if (gamePiece.Color == Color.Blue)
            {
                gamePiece.StartingPosition = 10;
            }
            if (gamePiece.Color == Color.Green)
            {
                gamePiece.StartingPosition = 20;
            }
            if (gamePiece.Color == Color.Yellow)
            {
                gamePiece.StartingPosition = 30;
            }
            if (gamePiece.Color == Color.Red)
            {
                gamePiece.StartingPosition = 40;
            }
        }
            public bool IsCoastClear(int diceRoll, GamePlayer gamePlayer)
            {
                throw new NotImplementedException();
            }

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

