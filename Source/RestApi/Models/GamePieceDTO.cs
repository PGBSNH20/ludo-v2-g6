using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class GamePieceDTO
    {
        public int CurrentPosition { get; set; }
        public string Color { get; set; }
    }
}
