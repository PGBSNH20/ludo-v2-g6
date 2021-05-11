﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class GameBoard
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public List<GamePlayer> GamePlayer { get; set; }
        public List<BoardSquare> BoardSquares { get; set; }

    }
}
