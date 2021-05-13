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

        public async Task<List<GameBordDto>> GetAsync()
        {
            var query = await _context.GameBoards.Include(x => x.GamePlayer).ToListAsync();
            List<string> hej = query.Select(x => x.GamePlayer.Select(x => x.Name).ToString()).ToList();

            var gameBordDto = new List<GameBordDto>();
            //var temp = new List<string>();
            for (int i = 0; i < query.Count ; i++)
            {

                gameBordDto.Add(new GameBordDto()
                {
                    //StartTime = query[i].StartTime,
                    //Players =   hej[i]
                    
                });
            }

            return gameBordDto;
        }

        public  Task PostAsync(List<GameBoard> gameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
