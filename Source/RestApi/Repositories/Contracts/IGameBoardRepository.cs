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
        Task<List<GameBoard>> Get();
        Task<GameBoard> GetCurrentGameBoardAsync(Guid gameBoardId);
        Task<GameBoard> CreateGameBoard(List<GamePlayer> gamePlayers);
        //GamePiece UpdatePosition(GamePiece gamePiece, int diceRoll);
        Task<List<GamePlayer>> UpdatePlayerTurn(List<GamePlayer> gamePlayers);
        bool FindWinner(GamePlayer gamePlayer);
        Task EndCurrentGameAsync(GameBoard gameBoard);
        GamePlayer AnnounceWinner(GameBoard gameBoard);
    }
}
