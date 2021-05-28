using System;

namespace RestApi.Models
{
    public class GamePiece
    {
        public Guid Id { get; set; }
        public int StartingPosition { get; set; } = 0;
        public int CurrentPosition { get; set; } = 0;
        public int StepsTaken { get; set; } = 0;
        public bool IsInGoal { get; set; } = false;
    }
}
