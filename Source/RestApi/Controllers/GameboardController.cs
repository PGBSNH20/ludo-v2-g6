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

        public GameboardController(IGameBoardRepository gameBoardRepository)
        {
            _gameBoardRepository = gameBoardRepository;
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
        [HttpGet("test")]
        public async Task<IActionResult> GetTest(GameBoard gameBoard, GamePlayer gamePlayer, GamePiece gamePiece, int diceRoll)
        {
            var result = _gamePieceRepository.UpdatePosition(gameBoard, gamePiece, diceRoll);
            result.IsInGoal = _gamePieceRepository.IsPieceInGoal(diceRoll, gamePiece, gamePlayer);
            return Ok(result);
        }
    }
}
