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

    }

}


