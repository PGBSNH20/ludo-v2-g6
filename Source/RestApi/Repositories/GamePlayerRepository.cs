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
        public async Task<bool> IsGamePlayerValidAsync(Guid id)
        {
            var result = await _context.GamePlayers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result.IsPlayersTurn)
                return true;
            return false;
        }
        public static bool IsMoveOutPossible(GameBoard gameBoard, Guid id)
        {
            var currentPlayer = gameBoard.GamePlayer.Single(x => x.Id == id);

            int count = 0;

            foreach (var pieces in currentPlayer.GamePieces)
            {
                if (pieces.CurrentPosition == 0 || pieces.IsInGoal)
                    count++;
            }
            if (count == 4)
                return false;
            return true;
        }
    }
}


