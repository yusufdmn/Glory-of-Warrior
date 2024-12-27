using Gameplay_System.Gameplay_Management;
using Zenject;

namespace Health_System.Strategy
{
    public class PlayerDeathStrategy: IDeathStrategy
    {
        [Inject] private GameplayManager _gameplayManager;
        public void Execute()
        {
            //Player Died. Stop The Game.
            _gameplayManager.OnPlayerDied();
        }
    }
}