using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Controllers;
using RestApi.Models;
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

        private readonly Guid _goodGuid = new Guid("5fcf2bb0-1111-1234-92a4-0359ead79af4");

        private readonly Guid _badGuid = new Guid("5fcf2bb0-2222-1234-92a4-0359ead79af4");

        // GameBoard
        [Fact]
        public async void GetGameBoard_GoodGuid_ExpectGameBoard()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var result = await controller.Get(_goodGuid);
            var gb = ((OkObjectResult) result).Value as GameBoard;
            Assert.Equal(true, gb.IsOnGoing);
        }

        [Fact]
        public async void GetGameBoard_BadGuid_ExpectBadRequestReturn()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var result = await controller.Get(_badGuid);

            Assert.Equal("This game does not exist", ((BadRequestObjectResult)result).Value.ToString());
        }
    }
}
