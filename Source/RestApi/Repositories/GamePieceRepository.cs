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
        public GamePieceRepository(LudoContext context) : base(context)
        {
        }

        public async Task UpdatePlayerPosition(GamePiece gamePiece)
        {

            return;
        }

        public List<GamePiece> CreateGamePieces(GamePlayer player)
        {
            var startPosition = GetStartPosition(player);
            var gamePieces = new List<GamePiece>();

            for (int i = 0; i < 4; i++)
            {
                gamePieces.Add(new GamePiece(){StartingPosition = startPosition});
            }

            return gamePieces;
        }

        public int GetStartPosition(GamePlayer player)
        {
            if (player.Color == Color.Blue)
                return 1;
            else if (player.Color == Color.Green)
                return 11;
            else if(player.Color == Color.Yellow)
                return 21;
            else
                return 31;
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

