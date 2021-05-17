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

        public async Task<List<GamePiece>> GetGamePiecesAsync(Guid id, int diceRoll)
        {
            var query = await _context.GamePlayers
                .Include(x => x.GamePieces)
                .FirstAsync(x => x.Id == id);

            var tempList = query.GamePieces.ToList();
            var pieceList = new List<GamePiece>();

            foreach (var piece in tempList)
            {
                if (diceRoll == 6 || diceRoll == 1 && !piece.IsInGoal)
                    pieceList.Add(piece);
                else if (!piece.IsInGoal && piece.Position > 0)
                    pieceList.Add(piece);
                else
                    continue;
            }
            return pieceList;
        }
        public int GetDiceRoll()
        {
            return Dice.Roll();
        }
    }
}


