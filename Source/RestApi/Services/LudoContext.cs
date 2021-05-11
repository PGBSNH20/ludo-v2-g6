using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class LudoContext : DbContext
    {
        public DbSet<GameBoard> GameBoards { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }

        public LudoContext() { }
        public LudoContext(DbContextOptions<LudoContext> options) : base(options) { }
    }
}
