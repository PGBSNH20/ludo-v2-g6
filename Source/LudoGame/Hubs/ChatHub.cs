using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoGame.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string gameBordId, string gamePieceId, string gamePlayerId )
        {
            await Clients.All.SendAsync("ReceiveMove", gameBordId, gamePieceId, gamePlayerId);
        }
      
    }
}
