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
        Task<List<GamePiece>> GetGamePieces(Guid id, int diceRoll);
        int GetDiceRoll();
    }
}
