using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApi.Models;
using RestApi.Repositories.Contracts;

namespace TestRestApi
{
    class GamePlayerRepositoryTest : IGamePlayerRepository
    {
        public Task<List<GamePiece>> GetGamePiecesAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        //[HttpPost("Move")]
        //public async Task<IActionResult> Get([FromBody] GetMoveRequest gmr)
        //{
        //    if (!await _gamePlayerRepository.ValidateGamePlayerAsync(Guid.Parse(gmr.GamePlayerId)))
        //        return BadRequest("This is not your piece!");

        //    var gameBoard = await _gameBoardRepository.GetCurrentGameBoardAsync(Guid.Parse(gmr.GameBoardId));
        //    var gamePiece = _gamePieceRepository.GetGamePiece(gameBoard, Guid.Parse(gmr.GamePieceId));

        //    bool gp = await _gamePieceRepository.UpdatePositionAsync(gameBoard, gamePiece, int.Parse(gmr.DiceRoll));
        //    if (gp == false)
        //        return BadRequest("You can't move this piece");

        //    await _gameBoardRepository.EndCurrentGameAsync(gameBoard);

        //    var winner = _gameBoardRepository.AnnounceWinner(gameBoard);
        //    if (winner != null)
        //        return Ok($"{winner.Name} has won the game!! GZ LOL");

        //    await _gameBoardRepository.UpdatePlayerTurnAsync(gameBoard.GamePlayer);
        //    var isTurn = gameBoard.GamePlayer.Where(x => x.IsPlayersTurn == true).FirstOrDefault();
        //    return Ok(isTurn.Name);
        //}

        //public async Task<bool> ValidateGamePlayerAsync(Guid id)
        //{
        //    var result = await _context.GamePlayers.Where(x => x.Id == id).FirstOrDefaultAsync();
        //    if (result.IsPlayersTurn)
        //        return true;
        //    return false;
        //}
        public async Task<bool> ValidateGamePlayerAsync(Guid id)
        {
            await Task.Delay(1); 
            throw new NotImplementedException();
        }
    }
}
