using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;

namespace RestApi.Repositories.Contracts
{
    public interface IGamePieceRepository
    {

        bool IsPieceInGoal(int diceRoll, GamePlayer gamePlayer);
        GamePiece UpdatePosition(GamePiece gamePiece, int diceRoll);
        //Task<bool> IsCoastClear(int diceRoll, GameBoard gameBoard, GamePiece gamePiece);
        Task Move();
    }
}
