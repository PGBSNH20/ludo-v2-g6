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
        private static readonly Guid _playerGuid1 = new("5fcf2bb0-1111-1234-92a4-0359ead79af4");

        public Task<List<GamePiece>> GetGamePiecesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsGamePlayerValidAsync(Guid id)
        {
            await Task.Delay(1);
            if (id == _playerGuid1)
                return true;
            return false;
        }
    }
}
