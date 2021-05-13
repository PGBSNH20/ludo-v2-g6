using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Services;

namespace RestApi.Repositories
{
    public class GamePieceRepository : Repository
    {
        public GamePieceRepository(LudoContext context) : base(context) { }
       

    }
}
