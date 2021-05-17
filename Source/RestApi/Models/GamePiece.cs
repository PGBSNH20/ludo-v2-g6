using System;

namespace RestApi.Models
{
    public class GamePiece
    {
        public Guid Id { get; set; }
        public Color Color { get; set; }
        //public BoardSquare BoardSquare { get; set; } //Får endast vara samma på startposition
        public int StartingPosition { get; set; } = 0;
        public int CurrentPosition { get; set; } = 0;
        public bool IsInGoal { get; set; } = false;
        //public bool IsInNest { get; set; } = true; Inte nödvänding längre iom CurrentPosition
    }
}
