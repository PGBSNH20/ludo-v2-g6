using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories.Contracts
{
    public interface IGameBoardRepository
    {
        Task<List<GameBoardDto>> GetAllGamesAsync();
        Task<List<GameBoard>> Get();
        Task<GameBoard> GetCurrentGameBoardAsync(Guid gameBoardId);
        Task<GameBoard> CreateGameBoardAsync(List<GamePlayer> gamePlayers);
        Task<List<GamePlayer>> UpdatePlayerTurnAsync(List<GamePlayer> gamePlayers);
        bool FindWinner(GamePlayer gamePlayer);
        Task EndCurrentGameAsync(GameBoard gameBoard);
        GamePlayer AnnounceWinner(GameBoard gameBoard);
    }
}
