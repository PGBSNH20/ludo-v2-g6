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

        public async Task<List<GamePiece>> GetGamePiecesAsync(Guid id)
        {
            var query = await _context.GamePlayers
                .Include(x => x.GamePieces)
                .FirstAsync(x => x.Id == id);

           return query.GamePieces.ToList();
        }
        public async Task<bool> ValidateGamePlayerAsync(Guid id)
        {
            var result = await _context.GamePlayers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result.IsPlayersTurn)
                return true;
            return false;
        }
    }
}


