using Akka.Actor;
using Game.ActorModel.Actors;
using Game.ActorModel.ExternalSystems;

namespace Game.Web.Models
{
    public class GameActorSystem
    {
        private readonly ActorSystem actorSystem;
        private readonly IGameEventsPusher _gameEventsPusher;

        public IActorRef GameController { get; private set; }
        public IActorRef SignalRBridge { get; private set; }

        public GameActorSystem(ActorSystem actorSystem, IGameEventsPusher gameEventsPusher)
        {
            this._gameEventsPusher = gameEventsPusher;

            this.GameController = actorSystem.ActorOf<GameControllerActor>();
            this.SignalRBridge = actorSystem.ActorOf(
                Props.Create(()=>new SignalRBridgeActor(gameEventsPusher, GameController)), "SignalRBridge");
        }
    }
}
