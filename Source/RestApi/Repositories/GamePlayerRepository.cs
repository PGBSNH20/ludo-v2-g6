using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Repositories.Contracts;
using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories
{
    public class GamePlayerRepository : Repository, IGamePlayerRepository
    {
        public GamePlayerRepository(LudoContext context) : base(context) { }

        public async Task<GamePlayer> GetAsync(Guid guid)
        {
            return await _context.GamePlayers.FirstOrDefaultAsync(x => x.Id == guid);
        }

        public async Task<List<GamePiece>> GetGamePiecesAsync(Guid id)
        {
            var query = await _context.GamePlayers
                .Include(x => x.GamePieces)
                .FirstAsync(x => x.Id == id);

           return query.GamePieces.ToList();
        }

        public int GetDiceRoll()
        {
            return Dice.Roll();
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
            if (player.Color == Color.Blue)
                return 52;
            else if (player.Color == Color.Red)
                return 13;
            else if (player.Color == Color.Green)
                return 26;
            else
                return 39;
        }
    }
}


