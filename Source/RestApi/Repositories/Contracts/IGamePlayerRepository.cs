using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories.Contracts
{
    public interface IGamePlayerRepository
    {
        Task<GamePlayer> GetAsync(Guid guid);
        int GetDiceRoll();
        Task<List<GamePiece>> GetGamePiecesAsync(Guid id);
        Task<bool> ValidateGamePlayerAsync(Guid id);

    }
}
