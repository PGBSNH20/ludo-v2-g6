using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Controllers;
using RestApi.Models;
using RestApi.Models.Requests;
using RestApi.Repositories.Contracts;
using Xunit;

namespace TestRestApi
{
    public class UnitTest1
    {
        // Setup
        private readonly IGameBoardRepository _gameBoardRepository = new GameBoardRepositoryTest();
        private readonly IGamePieceRepository _gamePieceRepository = new GamePieceRepositoryTest();
        private readonly IGamePlayerRepository _gamePlayerRepository = new GamePlayerRepositoryTest();

        private static readonly Guid _playerGuid1 = new("5fcf2bb0-1111-1234-92a4-0359ead79af4");
        private static readonly Guid _playerGuid2 = new("5fcf2bb0-2222-1234-92a4-0359ead79af4");
        private static readonly Guid _playerGuid3 = new("5fcf2bb0-3333-1234-92a4-0359ead79af4");

        private static readonly Guid _boardGuid1 = new("5fcf2bb0-4444-1234-92a4-0359ead79af4");
        private static readonly Guid _boardGuid2 = new("5fcf2bb0-5555-1234-92a4-0359ead79af4");

        private static readonly Guid _pieceGuid1 = new("5fcf2bb0-6666-1234-92a4-0359ead79af4");
        private static readonly Guid _pieceGuid2 = new("5fcf2bb0-7777-1234-92a4-0359ead79af4");

        private GamePlayer gp1 = new() { Name = "Sandra", Id = _playerGuid1};
        private GamePlayer gp2 = new() { Name = "Randa", Id = _playerGuid2};
        private GamePlayer gp3 = new() { Name = "Joakim", Id = _playerGuid3 };

        // GameBoard Controller
        [Fact]
        public async void GetGameHistory_GamesExist_ExpectDtos()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var result = await controller.Get();
            var gb = ((OkObjectResult)result).Value as List<GameBoardDto>;
            Assert.Equal("Sandra", gb[0].Players[0]);
        }

        [Fact]
        public async void GetGameBoard_GoodGuid_ExpectGameBoard()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var result = await controller.Get(_boardGuid1);
            var gb = ((OkObjectResult) result).Value as GameBoard;
            Assert.Equal(true, gb.IsOnGoing);
        }

        [Fact]
        public async void GetGameBoard_BadGuid_ExpectBadRequestReturn()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var result = await controller.Get(_playerGuid2);

            Assert.Equal("This game does not exist", ((BadRequestObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void PostNewGame_ThreePlayers_ExpectGameBoard()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var gps = new List<GamePlayer> { gp1, gp2, gp3 };

            var result = await controller.Post(gps);
            var gb = ((OkObjectResult)result).Value as GameBoard;
            Assert.Equal(4, gb.GamePlayer[1].GamePieces.Count);
        }

        [Fact]
        public async void PostNewGame_OnePlayer_ExpectBadRequest()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var gps = new List<GamePlayer> { gp1 };

            var result = await controller.Post(gps);
            Assert.Equal("Can't be less then two players", ((BadRequestObjectResult)result).Value.ToString());
        }
      
        [Fact]
        public async void Move_RegularMove_ExpectPlayerName()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var gmr = new GetMoveRequest()
            {
                DiceRoll = "5",
                GameBoardId = _boardGuid1.ToString(),
                GamePieceId = _pieceGuid1.ToString(),
                GamePlayerId = _playerGuid1.ToString()
            };
           
            var result = await controller.Get(gmr);
            var gb = ((OkObjectResult)result).Value as string;

            Assert.Equal("Sandra", gb);
        }

        [Fact]
        public async void Move_NotMyPiece_ExpectException()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var gmr = new GetMoveRequest()
            {
                DiceRoll = "5",
                GameBoardId = _boardGuid1.ToString(),
                GamePieceId = _pieceGuid1.ToString(),
                GamePlayerId = _playerGuid2.ToString()
            };

            var result = await controller.Get(gmr);
            var gb = ((BadRequestObjectResult)result).Value as string;

            Assert.Equal("This is not your piece!", ((BadRequestObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void Move_NotMovablePiece_ExpectException()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var gmr = new GetMoveRequest()
            {
                DiceRoll = "5",
                GameBoardId = _boardGuid1.ToString(),
                GamePieceId = _pieceGuid2.ToString(),
                GamePlayerId = _playerGuid1.ToString()
            };

            var result = await controller.Get(gmr);
            var gb = ((BadRequestObjectResult)result).Value as string;

            Assert.Equal("You can't move this piece", ((BadRequestObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void Move_WinningMove_ExpectAnnouncement()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var gmr = new GetMoveRequest()
            {
                DiceRoll = "5",
                GameBoardId = _boardGuid2.ToString(),
                GamePieceId = _pieceGuid1.ToString(),
                GamePlayerId = _playerGuid1.ToString()
            };

            var result = await controller.Get(gmr);

            Assert.Equal("Randa has won the game!! GZ LOL", ((OkObjectResult)result).Value.ToString());
        }

        // GamePiece Controller
        [Fact]
        public async void GetGamePiecesDtoAsync_GoodGuid_ExpectOk()
        {
            var controller = new GamePieceController(_gamePieceRepository);

            var result = await controller.Get(_boardGuid1);
            var gb = ((OkObjectResult)result).Value as List<GamePieceDTO>;
            Assert.Equal(_boardGuid1.ToString(), gb[0].GameBoardId);
        }

        [Fact]
        public async void GetGamePiecesDtoAsync_BadGuid_ExpectBadRequest()
        {
            var controller = new GamePieceController(_gamePieceRepository);

            var result = await controller.Get(_boardGuid2);
            Assert.Equal("Invalid Game ID", ((BadRequestObjectResult)result).Value.ToString());
        }
    }
}

