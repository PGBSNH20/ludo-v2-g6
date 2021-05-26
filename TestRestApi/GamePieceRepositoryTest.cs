using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApi.Models;
using RestApi.Repositories.Contracts;

namespace TestRestApi
{
    class GamePieceRepositoryTest : IGamePieceRepository
    {
        public Task<bool> UpdatePosition(GameBoard gameBoard, GamePiece gamePiece, int diceRoll)
        {
            throw new NotImplementedException();
        }

        public GamePiece IsPieceInGoal(GamePiece gamePiece)
        {
            throw new NotImplementedException();
        }

        public GamePiece SendToNest(GameBoard gameBoard, GamePiece gamePiece)
        {
            throw new NotImplementedException();
        }

        public GamePiece GetGamePiece(GameBoard gameBoard, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GamePieceDTO>> GetGamePiecesDto(Guid gameBoardId)
        {
            throw new NotImplementedException();
        }
    }
}
