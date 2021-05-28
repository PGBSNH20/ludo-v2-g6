using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace RestApi.Services
{
    public class LudoContext : DbContext
    {
        public DbSet<GameBoard> GameBoards { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }

        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        public LudoContext()
        {
        }

        public LudoContext(DbContextOptions<LudoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            //modelBuilder.Entity<GamePiece>().HasData(

            //    new GamePiece { Id = Guid.NewGuid(), Color = Color.Red },
            //    new GamePiece { Id = Guid.NewGuid(), Color = Color.Red },
            //    new GamePiece { Id = Guid.NewGuid(), Color = Color.Red },
            //    new GamePiece { Id = Guid.NewGuid(), Color = Color.Red }

            //);

            //_ = modelBuilder.Entity<GameBoard>().HasData(
            //    new GameBoard
            //    {
            //        Id = Guid.NewGuid(),
            //        GamePlayer = new List<GamePlayer>()
            //        {
            //            new GamePlayer
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Sandra",
            //                GamePieces = new List<GamePiece>()
            //                {
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red},
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red},
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red},
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red}


            //                }

            //            },
            //            new GamePlayer
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Olof",
            //                GamePieces = new List<GamePiece>()
            //                {
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red},
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red},
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red},
            //                    new GamePiece {Id = Guid.NewGuid(), Color = Color.Red}

            //                }
            //            }
            //        }
            //    });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging();
        }

    }
}


