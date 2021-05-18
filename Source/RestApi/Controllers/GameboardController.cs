using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameboardController : ControllerBase
    {
        private readonly IGameBoardRepository _gameBoardRepository;
        private readonly IGamePieceRepository _gamePieceRepository;

        public GameboardController(IGameBoardRepository gameBoardRepository, IGamePieceRepository gamePieceRepository)
        {
            _gameBoardRepository = gameBoardRepository;
            _gamePieceRepository = gamePieceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var result = await _gameBoardRepository.OngoingGamesAsync();
            await Task.Delay(1);
            return Ok("Hejsan ifrån databasen");
        }
      
        [HttpPost]
        public async Task<IActionResult> Post(List<GamePlayer> gamePlayers)
        {
            if (gamePlayers.Count < 2)
                return BadRequest("Can't be less then two players");

            await _gameBoardRepository.CreateGameBoard(gamePlayers);

            return Ok(gamePlayers);
        }
        [HttpPost("test")]
        public async Task<IActionResult> GetTest(Guid gameBoardId, Guid gamePieceId, int diceRoll)
        {
            var gameBoard = await _gameBoardRepository.GetCurrentGameBoardAsync(gameBoardId);
            var gamePiece = _gamePieceRepository.GetGamePiece(gameBoard, gamePieceId);
            
            GamePiece gp = await _gamePieceRepository.UpdatePosition(gameBoard, gamePiece, diceRoll);
            return Ok(gp);
        }
    }
}
