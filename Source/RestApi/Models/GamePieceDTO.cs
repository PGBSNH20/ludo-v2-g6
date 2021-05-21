using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class GamePieceDTO
    {
        public string CurrentPosition { get; set; }
        public string Color { get; set; }
        public string PieceId { get; set; }
        public string GameBoardId { get; set; }
    }
}
