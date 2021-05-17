using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories.Contracts
{
    public interface IGameBoardRepository
    {
        Task<List<GameBoardDto>> OngoingGamesAsync();
        Task PostAsync(List<GameBoard> gameBoard);
        Task CreatePlayers(List<GamePlayer> gamePlayers); // CreatePlayers är ett http-anrop, skall heta typ add eller nåt
        Task<List<GameBoard>> Get();

    }
}
