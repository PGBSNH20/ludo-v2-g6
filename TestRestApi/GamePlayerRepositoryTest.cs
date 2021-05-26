using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApi.Models;
using RestApi.Repositories.Contracts;

namespace TestRestApi
{
    class GamePlayerRepositoryTest : IGamePlayerRepository
    {
        public Task<List<GamePiece>> GetGamePiecesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateGamePlayerAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
