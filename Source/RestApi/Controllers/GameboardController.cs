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
            var result = await _gameBoardRepository.Get();

            return Ok(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Post(List<GamePlayer> gamePlayers)
        {
            await _gameBoardRepository.Post(gamePlayers);

            return Ok();
        }
    }
}
