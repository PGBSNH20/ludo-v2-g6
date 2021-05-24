using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Models.Requests;
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
        private readonly IGamePlayerRepository _gamePlayerRepository;

        public GameboardController(IGameBoardRepository gameBoardRepository, IGamePieceRepository gamePieceRepository, IGamePlayerRepository gamePlayerRepository)
        {
            _gameBoardRepository = gameBoardRepository;
            _gamePieceRepository = gamePieceRepository;
            _gamePlayerRepository = gamePlayerRepository;
        }

        [HttpGet("History")]
        public async Task<IActionResult> Get()
        {
            //var result = await _gameBoardRepository.OngoingGamesAsync();
            await Task.Delay(1);
            return Ok();
        }
        [HttpGet("Game")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _gameBoardRepository.GetCurrentGameBoardAsync(id);
            if (result != null)
                return Ok(result);

            return BadRequest("This game does not exist");
        }
      
        [HttpPost("NewGame")]
        public async Task<IActionResult> Post(List<GamePlayer> gamePlayers)
        {
            if (gamePlayers.Count < 2)
                return BadRequest("Can't be less then two players");

            var gameboard =  await _gameBoardRepository.CreateGameBoard(gamePlayers);

            return Ok(gameboard);
        }
        [HttpPost("Move")]
        public async Task<IActionResult> GetTest([FromBody]GetMoveRequest gmr)
        {
            if (!await _gamePlayerRepository.ValidateGamePlayerAsync(Guid.Parse(gmr.GamePlayerId)))
                return BadRequest("This is not your piece!");
            var gameBoard = await _gameBoardRepository.GetCurrentGameBoardAsync(Guid.Parse(gmr.GameBoardId));
            var gamePiece = _gamePieceRepository.GetGamePiece(gameBoard, Guid.Parse(gmr.GamePieceId));

            bool gp = await _gamePieceRepository.UpdatePosition(gameBoard, gamePiece, int.Parse(gmr.DiceRoll));
            if (gp == false)
                return BadRequest("You can't move this piece");

            await _gameBoardRepository.EndCurrentGameAsync(gameBoard);

            _gameBoardRepository.AnnounceWinner(gameBoard);

            await _gameBoardRepository.UpdatePlayerTurn(gameBoard.GamePlayer);
            var isTurn = gameBoard.GamePlayer.Where(x => x.IsPlayersTurn == true).FirstOrDefault();
            return Ok(isTurn);
        }
    }
}
