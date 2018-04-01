using System.Threading.Tasks;
using Game.ActorModel.Messages;
using Microsoft.AspNetCore.SignalR;
using Akka.Actor;

namespace Game.Web.Models
{
    public class GameHub : Hub
    {
        private readonly GameActorSystem _gameActorSystem;

        public GameHub(GameActorSystem gameActorSystem)
        {
            this._gameActorSystem = gameActorSystem;
        }

        public Task Broadcast(string sender)//, Measurement measurement
        {
            return Clients
                // Do not Broadcast to Caller:
                .AllExcept(new[] { Context.ConnectionId })
                // Broadcast to all connected clients:
                //.InvokeAsync("Broadcast", sender, measurement);
                .SendAsync("Broadcast", sender);//, measurement
        }

        public void JoinGame(string playerName)
        {
            _gameActorSystem
                .SignalRBridge
                .Tell(new JoinGameMessage(playerName));
        }

        public void Attack(string playerName)
        {
            _gameActorSystem
                .SignalRBridge
                .Tell(new AttackPlayerMessage(playerName));
        }
    }
}
