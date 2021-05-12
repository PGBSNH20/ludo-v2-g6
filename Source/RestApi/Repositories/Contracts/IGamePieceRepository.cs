using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;

namespace RestApi.Repositories.Contracts
{
    public interface IGamePieceRepository
    {
        bool IsCoastClear(int diceRoll, GamePlayer gamePlayer);
        bool IsPieceInGoal(int diceRoll, GamePlayer gamePlayer);

        Task Move();
    }
}
