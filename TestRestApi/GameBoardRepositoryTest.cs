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
        private static readonly Guid _playerGuid1 = new Guid("5fcf2bb0-1111-1234-92a4-0359ead79af4");
        private static readonly Guid _playerGuid2 = new Guid("5fcf2bb0-2222-1234-92a4-0359ead79af4");
        private static readonly Guid _playerGuid3 = new Guid("5fcf2bb0-3333-1234-92a4-0359ead79af4");

        private readonly GameBoard game1 = new GameBoard() {Id = _playerGuid1};

        public async Task<List<GameBoardDto>> GetAllGamesAsync()
        {
            var gbDto = new List<GameBoardDto>();

            await Task.Delay(1);

            var gb1 = new GameBoardDto() { Players = new List<string>() { "Sandra", "Randa" } };
            var gb2 = new GameBoardDto() { Players = new List<string>() { "Joakim", "Sofie" } };
            gbDto.Add(gb1);
            gbDto.Add(gb2);

            return gbDto;
        }
        
        public async Task<GameBoard> GetCurrentGameBoardAsync(Guid gameBoardId)
        {
            await Task.Delay(1);

            return gameBoardId == _playerGuid1 ? game1 : null;
        }

        public Task<List<GameBoard>> Get()
        {
            throw new NotImplementedException();
        }
        
        public async Task<GameBoard> CreateGameBoardAsync(List<GamePlayer> gamePlayers)
        {

            foreach (GamePlayer player in gamePlayers)
            {
                var pieces = new List<GamePiece>();

                for (int i = 0; i < 4; i++)
                {
                    var p = new GamePiece() {CurrentPosition = 0, IsInGoal = false, StartingPosition = 13};
                    pieces.Add(p);
                }

                player.GamePieces = pieces;
            }
            gamePlayers[1].IsPlayersTurn = true;
            return new GameBoard { GamePlayer = gamePlayers };
        }

        public Task<List<GamePlayer>> UpdatePlayerTurnAsync(List<GamePlayer> gamePlayers)
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
