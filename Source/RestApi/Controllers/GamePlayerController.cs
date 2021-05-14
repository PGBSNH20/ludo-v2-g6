using Microsoft.AspNetCore.Mvc;
using RestApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePlayerController : ControllerBase
    {
        private readonly IGamePlayerRepository _gamePlayerRepository;
        public GamePlayerController(IGamePlayerRepository gamePlayerRepository) { _gamePlayerRepository = gamePlayerRepository; }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id, int diceRoll)
        {
            var result = await _gamePlayerRepository.GetGamePiecesAsync(id, diceRoll);
            return Ok(result);
        }
        [HttpGet("RollDice")]
        public ActionResult<int> Get()
        {
            int roll =  _gamePlayerRepository.GetDiceRoll();
            return Ok(roll);
        }
        

    }
}

