using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Repositories;
using RestApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class GamePieceController : ControllerBase
    {
        private readonly IGamePieceRepository _gamePieceRepository;

        public GamePieceController(IGamePieceRepository gamePieceRepository)
        {
            _gamePieceRepository = gamePieceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _gamePieceRepository.GetGamePiecesDto(id);
            if (result != null)
                return Ok(result);

            return BadRequest("Invalid Game ID");
        }
    }
}
