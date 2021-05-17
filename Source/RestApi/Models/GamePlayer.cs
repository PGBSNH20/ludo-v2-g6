using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class GamePlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GamePiece> GamePieces { get; set; }

        
        public bool IsPlayersTurn { get; set; } = false;
    }
}
