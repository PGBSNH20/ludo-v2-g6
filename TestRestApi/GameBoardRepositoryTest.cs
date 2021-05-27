using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private static readonly Guid _boardGuid1 = new Guid("5fcf2bb0-4444-1234-92a4-0359ead79af4");
        private static readonly Guid _boardGuid2 = new Guid("5fcf2bb0-5555-1234-92a4-0359ead79af4");

        private GamePlayer gp1 = new GamePlayer() { Name = "Sandra", Id = _playerGuid1 };
        private GamePlayer gp2 = new GamePlayer() { Name = "Randa", Id = _playerGuid2 };
        private GamePlayer gp3 = new GamePlayer() { Name = "Joakim", Id = _playerGuid3 };

        private GameBoard game1 = new GameBoard() {Id = _boardGuid1 };

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
            var gps1 = new List<GamePlayer>() { gp1 };
            var gps2 = new List<GamePlayer>() { gp2 };

            await Task.Delay(1);

            if (gameBoardId == _boardGuid1)
            {
                game1.GamePlayer = gps1;
                return game1;
            }
            if (gameBoardId == _boardGuid2)
            {
                var game2 = new GameBoard() {Id = _boardGuid2, GamePlayer = gps2};
            }

            return null;
        }

        public Task<List<GameBoard>> Get()
        {
            throw new NotImplementedException();
        }
        
        public async Task<GameBoard> CreateGameBoardAsync(List<GamePlayer> gamePlayers)
        {
            await Task.Delay(1);

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

        public async Task<List<GamePlayer>> UpdatePlayerTurnAsync(List<GamePlayer> gamePlayers)
        {
            await Task.Delay(1);
            gamePlayers[0].IsPlayersTurn = true;
            return gamePlayers;
        }

        public bool FindWinner(GamePlayer gamePlayer)
        {
            throw new NotImplementedException();
        }

        public async Task EndCurrentGameAsync(GameBoard gameBoard)
        {
            await Task.Delay(1);
        }

        public GamePlayer AnnounceWinner(GameBoard gameBoard)
        {

            if (gameBoard.Id == _boardGuid2)
                return gp2;
            return null;
        }
    }
}
