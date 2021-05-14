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
      
        public GameboardController(IGameBoardRepository gameBoardRepository)
        {
            _gameBoardRepository = gameBoardRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _gameBoardRepository.OngoingGamesAsync();

            return Ok(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Post(List<GamePlayer> gamePlayers)
        {
            if (gamePlayers.Count < 2)
                return BadRequest("Can't be less then two players");

            await _gameBoardRepository.Post(gamePlayers);

            return Ok();
        }
    }
}
