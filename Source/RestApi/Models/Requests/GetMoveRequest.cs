using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models.Requests
{
    public class GetMoveRequest
    {
        public string GameBoardId { get; set; }
        public string GamePieceId { get; set; }
        public string DiceRoll { get; set; }
        public string GamePlayerId { get; set; }
    }
}
