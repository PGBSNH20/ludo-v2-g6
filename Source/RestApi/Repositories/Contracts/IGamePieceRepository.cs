using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;

namespace RestApi.Repositories.Contracts
{
    public interface IGamePieceRepository
    {
        bool IsCoastClear(int diceRoll, GameBoard gameBoard, GamePiece gamePiece);
        GamePiece UpdatePosition(GameBoard gameBoard, GamePiece gamePiece, int diceRoll);
        //Task<bool> IsCoastClear(int diceRoll, GameBoard gameBoard, GamePiece gamePiece);
        bool IsPieceInGoal(int diceRoll, GamePiece gamePiece, GamePlayer gamePlayer);
        GamePiece SendToNest(GameBoard gameBoard, GamePiece gamePiece);
    }
}
