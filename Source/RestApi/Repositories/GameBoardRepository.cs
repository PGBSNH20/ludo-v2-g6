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

        public async Task<List<GameBoardDto>> OngoingGamesAsync()
        {
            var gameBoardDto = new List<GameBoardDto>();
            var tempNames = new List<string>();

            //var test = await _context.GameBoards
            //    .Include(x => x.GamePlayer)
            //    .Select(x => x.GamePlayer
            //    .Where(x => x.GamePieces
            //    .Where(x => x.IsInGoal == true).Count() < 4))
            //    .ToListAsync();
          


            var gameboards = await _context.GameBoards.Include(x => x.GamePlayer).ThenInclude(x=>x.GamePieces).ToListAsync();

            //var hej = gameboards.Select(x=>x.StartTime.Date).Where(x => x.GamePlayer
            //    .Where(x => x.GamePieces
            //    .Where(x => x.IsInGoal == true).Count() < 4)).ToList();

          
            foreach (var gameBoard in gameboards)
            {
                //Gets the names of all the players in the list
                foreach (var player in gameBoard.GamePlayer)
                {
                    tempNames.Add(player.Name);
                }
                gameBoardDto.Add(new GameBoardDto()
                {
                    StartTime = gameBoard.StartTime,
                    Players = tempNames.ToList()
                });

                tempNames.Clear();
            }
            return gameBoardDto;
        }
        public async Task<GameBoard> GetCurrentGameBoardAsync(Guid gameBoardId)
        {
            var result = await _context.GameBoards
                .Include(x => x.GamePlayer)
                    .ThenInclude(x => x.GamePieces)
                        .ThenInclude(x => x.CurrentPosition)
                .Where(x => x.Id == gameBoardId)
                .FirstOrDefaultAsync();
            return result;
        }

        public Task PostAsync(List<GameBoard> gameBoard)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GameBoard>> Get()
        {
            var gameboards = await _context.GameBoards.Include(x => x.GamePlayer).ToListAsync();

            return gameboards;
        }

        public async Task CreatePlayers(List<GamePlayer> gamePlayers)
        {
            //foreach (GamePlayer player in gamePlayers)
            //{
            //    CreateGamePieces(player);
            //}
            //var temp = new List<GamePiece>();

            //for (int i = 0; i < gamePlayers.Count; i++)
            //{
            //    temp.Add(gamePlayers[i].GamePieces[0]);
            //    temp.Add(gamePlayers[i].GamePieces[0]);
            //    temp.Add(gamePlayers[i].GamePieces[0]);
            //    temp.Add(gamePlayers[i].GamePieces[0]);

            //    gamePlayers[i].GamePieces = temp.ToList();

            //    temp.Clear();
            //}

            await Add(new GameBoard { GamePlayer = gamePlayers});
        }

     

        public Task PostAsync(List<GameBoard> gameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
