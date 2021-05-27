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

        private static readonly Guid _playerGuid1 = new Guid("5fcf2bb0-1111-1234-92a4-0359ead79af4");
        private static readonly Guid _playerGuid2 = new Guid("5fcf2bb0-2222-1234-92a4-0359ead79af4");
        private static readonly Guid _playerGuid3 = new Guid("5fcf2bb0-3333-1234-92a4-0359ead79af4");

        private static readonly Guid _boardGuid1 = new Guid("5fcf2bb0-4444-1234-92a4-0359ead79af4");
        private static readonly Guid _boardGuid2 = new Guid("5fcf2bb0-5555-1234-92a4-0359ead79af4");

        private static readonly Guid _pieceGuid1 = new Guid("5fcf2bb0-6666-1234-92a4-0359ead79af4");
        private static readonly Guid _pieceGuid2 = new Guid("5fcf2bb0-7777-1234-92a4-0359ead79af4");




        private GamePlayer gp1 = new GamePlayer() { Name = "Sandra", Id = _playerGuid1};
        private GamePlayer gp2 = new GamePlayer() { Name = "Randa", Id = _playerGuid2};
        private GamePlayer gp3 = new GamePlayer() { Name = "Joakim", Id = _playerGuid3 };

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
            var gps = new List<GamePlayer> {gp1, gp2, gp3};

            var result = await controller.Post(gps);
            var gb = ((OkObjectResult)result).Value as GameBoard;
            Assert.Equal(4, gb.GamePlayer[1].GamePieces.Count);
        }

        [Fact]
        public async void PostNewGame_OnePlayer_ExpectBadRequest()
        {
            var controller = new GameboardController(_gameBoardRepository, _gamePieceRepository, _gamePlayerRepository);
            var gps = new List<GamePlayer> {gp1};

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
        public async void Move_WinningMove_ExpectException() // TODO
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
            var gb = ((OkObjectResult)result).Value as string;

            Assert.Equal("Randa has won the game!! GZ LOL", ((OkObjectResult)result).Value.ToString());
        }

        //[HttpPost("Move")]
        //public async Task<IActionResult> Get([FromBody] GetMoveRequest gmr)
        //{
        ////    if (!await _gamePlayerRepository.ValidateGamePlayerAsync(Guid.Parse(gmr.GamePlayerId)))
        ////        return BadRequest("This is not your piece!");

        ////    var gameBoard = await _gameBoardRepository.GetCurrentGameBoardAsync(Guid.Parse(gmr.GameBoardId));
        ////    var gamePiece = _gamePieceRepository.GetGamePiece(gameBoard, Guid.Parse(gmr.GamePieceId));

        ////    bool gp = await _gamePieceRepository.UpdatePositionAsync(gameBoard, gamePiece, int.Parse(gmr.DiceRoll));
        ////    if (gp == false)
        ////        return BadRequest("You can't move this piece");

        ////    await _gameBoardRepository.EndCurrentGameAsync(gameBoard);

        ////    var winner = _gameBoardRepository.AnnounceWinner(gameBoard);
        ////    if (winner != null)
        ////        return Ok($"{winner.Name} has won the game!! GZ LOL");

        ////    await _gameBoardRepository.UpdatePlayerTurnAsync(gameBoard.GamePlayer);
        //    var isTurn = gameBoard.GamePlayer.Where(x => x.IsPlayersTurn == true).FirstOrDefault();
        //    return Ok(isTurn.Name);
        //}
    }
}
