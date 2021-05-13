using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Repositories.Contracts;
using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories
{
    public class GameBoardRepository : Repository, IGameBoardRepository
    {
        public GameBoardRepository(LudoContext context) : base(context) { }

        public async Task<List<GameBoardDto>> GetAsync()
        {
            var gameboards = await _context.GameBoards.Include(x => x.GamePlayer).ToListAsync();

            var gameBoardDto = new List<GameBoardDto>();
            var tempNames = new List<string>();

            foreach (var gameBoard in gameboards)
            {
                foreach (var player in gameBoard.GamePlayer)
                {
                    tempNames.Add(player.Name);
                }
                gameBoardDto.Add(new GameBoardDto()
                {
                    StartTime = gameBoard.StartTime,
                    Players = tempNames
                });
                tempNames.Clear();
            }
            return gameBoardDto;
        }


        public async Task Post(List<GamePlayer> gamePlayers)
        {
            //for (int i = 0; i < gamePlayers.Count; i++)
            //{
            //    gamePlayers[i].GamePieces = new List<GamePiece>() {gp[i], gp[i], gp[i], gp[i]};

            //}
            await Add(new GameBoard { GamePlayer = gamePlayers});
        }

        public Task PostAsync(List<GameBoard> gameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
