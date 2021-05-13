using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class GameBordDto
    {
        public DateTime StartTime { get; set; }
        public List<string> Players { get; set; }
    }
}
