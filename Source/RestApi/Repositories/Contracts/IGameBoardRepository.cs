using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories.Contracts
{
    public interface IGameBoardRepository
    {
        Task<List<GameBoardDto>> GetAsync();
        Task PostAsync(List<GameBoard> gameBoard);
        Task Post(List<GamePlayer> gamePlayers); // Post är ett http-anrop, skall heta typ add eller nåt
        Task<List<GameBoard>> Get();

    }
}
