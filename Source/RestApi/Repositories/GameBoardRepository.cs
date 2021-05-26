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

            var gameboards = await _context.GameBoards.Include(x => x.GamePlayer).ThenInclude(x => x.GamePieces).ToListAsync();
         
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
            // TODO debuggern varnar för segt anrop
            var result = await _context.GameBoards
                .Include(x => x.GamePlayer)
                .ThenInclude(x => x.GamePieces)
                .Where(x => x.Id == gameBoardId)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<GameBoard>> Get()
        {
            return  await _context.GameBoards.Include(x => x.GamePlayer).ToListAsync();
        }

        public async Task<GameBoard> CreateGameBoard(List<GamePlayer> gamePlayers)
        {
            foreach (GamePlayer player in gamePlayers)
            {
                player.GamePieces = GamePlayerRepository.CreateGamePieces(player);
            }
            DecideWhoStarts(gamePlayers);
            return await Add(new GameBoard { GamePlayer = gamePlayers });
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
            var currentPlayer = gamePlayers.Single(x => x.IsPlayersTurn == true);

            if ((gamePlayers.Count == 4 && currentPlayer.OrderInGame == 3)
                || (gamePlayers.Count == 3 && currentPlayer.OrderInGame == 2)
                || (gamePlayers.Count == 2 && currentPlayer.OrderInGame == 1))
            {
                var nextPlayer = gamePlayers.Single(x => x.OrderInGame == 0);
                nextPlayer.IsPlayersTurn = true;
                currentPlayer.IsPlayersTurn = false;
            }
            else
            {
                var nextPlayer = gamePlayers.Single(x => x.OrderInGame == currentPlayer.OrderInGame + 1);
                nextPlayer.IsPlayersTurn = true;
                currentPlayer.IsPlayersTurn = false;
            }
            await Save();
            return gamePlayers;
        }

        public bool FindWinner(GamePlayer gamePlayer)
        {
            int winCount = 0;
            foreach (var p in gamePlayer.GamePieces)
            {
                if (p.IsInGoal)
                    winCount++;
            }
            if (winCount == 4)
                return true;
            return false;
        }

        public async Task EndCurrentGameAsync(GameBoard gameBoard)
        {
            foreach (var player in gameBoard.GamePlayer)
            {
                if (FindWinner(player))
                {
                    gameBoard.IsOnGoing = false;
                    await Save();
                }
            }
        }

        public GamePlayer AnnounceWinner(GameBoard gameBoard)
        {
            if (!gameBoard.IsOnGoing)
                foreach (var player in gameBoard.GamePlayer)
                {
                    if (player.GamePieces.Count == 4)
                        return player;
                }
            return null;
        }
    }
}
