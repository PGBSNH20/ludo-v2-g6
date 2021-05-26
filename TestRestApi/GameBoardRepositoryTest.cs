using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApi.Models;
using RestApi.Repositories.Contracts;

namespace TestRestApi
{
    class GameBoardRepositoryTest : IGameBoardRepository
    {
        public Task<List<GameBoardDto>> OngoingGamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<GameBoard>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<GameBoard> GetCurrentGameBoardAsync(Guid gameBoardId)
        {
            await Task.Delay(1);

            return gameBoardId.ToString() == "5fcf2bb0-1111-1234-92a4-0359ead79af4" ? new GameBoard()
            {
                IsOnGoing = true
            } : null;
        }

        public Task<GameBoard> CreateGameBoard(List<GamePlayer> gamePlayers)
        {
            throw new NotImplementedException();
        }

        public Task<List<GamePlayer>> UpdatePlayerTurn(List<GamePlayer> gamePlayers)
        {
            throw new NotImplementedException();
        }

        public bool FindWinner(GamePlayer gamePlayer)
        {
            throw new NotImplementedException();
        }

        public Task EndCurrentGameAsync(GameBoard gameBoard)
        {
            throw new NotImplementedException();
        }

        public GamePlayer AnnounceWinner(GameBoard gameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
