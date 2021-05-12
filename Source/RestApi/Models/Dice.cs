using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public static class Dice
    {
        public static int Roll()
        {
            var roll = new Random();
            return roll.Next(1, 7);
        }
    }
}
