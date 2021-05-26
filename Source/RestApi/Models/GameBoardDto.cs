using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class GameBoardDto
    {
        public DateTime StartTime { get; set; }
        public List<string> Players { get; set; }
        public string UriId { get; set; }
    }
}
