using System;

namespace RestApi.Models
{
    public class GamePiece
    {
        public Guid Id { get; set; }
        public Color Color { get; set; }
        public BoardSquare BoardSquare { get; set; } //Får endast vara samma på startposition
        public int StartingPosition { get; set; } 
        public bool IsInGoal { get; set; }
        public bool IsInNest { get; set; }
    }
}