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

        public async Task CreateGameBoard(List<GamePlayer> gamePlayers)
        {
            foreach (GamePlayer player in gamePlayers)
            {
                player.GamePieces = GamePlayerRepository.CreateGamePieces(player);
            }
            DecideWhoStarts(gamePlayers);
            await Add(new GameBoard { GamePlayer = gamePlayers});
        }

        //Decides who goes first(random)
        public GamePlayer DecideWhoStarts(List<GamePlayer> gamePlayers)
        {
            var startnumber = new Random();
            var start = startnumber.Next(0, gamePlayers.Count);
            gamePlayers[start].IsPlayersTurn = true;
            return gamePlayers[start];
        }

        public async Task<List<GamePlayer>> UpdatePlayerTurn(List<GamePlayer> gamePlayers)
        {
            int count = 0;
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                if (gamePlayers[i].IsPlayersTurn is true && count == 0)
                {
                    if (i == gamePlayers.Count - 1)
                        gamePlayers[0].IsPlayersTurn = true;
                    else
                        gamePlayers[i+1].IsPlayersTurn = true;
                    gamePlayers[i].IsPlayersTurn = false;
                    count++;
                }
            }
            await Save();
            return gamePlayers;
        }
    }
}
