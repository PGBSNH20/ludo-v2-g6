using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class BoardSquare
    {
        public int Id { get; set; }
        public GamePlayer OccupiedBy { get; set; }
    }
}
