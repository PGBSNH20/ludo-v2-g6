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
    public class GamePieceController : ControllerBase
    {
        private readonly IGamePieceRepository _gamePieceRepository;

        public GamePieceController(IGamePieceRepository gamePieceRepository)
        {
            _gamePieceRepository = gamePieceRepository;
        }

        //[HttpPut]
        //public async Task<IActionResult> Put(GamePiece gamePiece)
        //{
        //    var positionPlayer = await GamePieceRepository.GetAsync(name);
        //    if (spaceTraveller is null)
        //        return BadRequest("You are not parked here!");

        //    var onGoingParking = await _parkingRepository.EndParkingAsync(spaceTraveller);
        //    if (onGoingParking != null)
        //        return Ok($"Cost of parking {onGoingParking.Cost}, have a nice day!");

        //    return BadRequest("You don't have an ongoing parking");
        //}
    }
}
