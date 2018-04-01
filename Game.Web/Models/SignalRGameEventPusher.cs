using System;
using Game.ActorModel.ExternalSystems;
using Microsoft.AspNetCore.SignalR;

namespace Game.Web.Models
{
    public class SignalRGameEventPusher : IGameEventsPusher
    {
        private readonly IHubContext<GameHub> _hubcontext;

        public SignalRGameEventPusher(IHubContext<GameHub> hubcontext)
        {
            this._hubcontext = hubcontext;
        }

        public void PlayerJoined(string playerName, int health)
        {
            _hubcontext.Clients.All.SendAsync("playerJoined", playerName, health);
        }

        public void UpdatePlayerHealth(string playerName, int health)
        {
            _hubcontext.Clients.All.SendAsync("updatePlayerHealth", playerName, health);
        }
    }
}