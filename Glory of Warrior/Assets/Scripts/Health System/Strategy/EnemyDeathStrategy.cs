using Gameplay_System.Gameplay_Management;
using Zenject;

namespace Health_System.Strategy
{
    public class EnemyDeathStrategy: IDeathStrategy
    {
        [Inject] private GameplayManager _gameplayManager;
        
        public void Execute()
        {
            _gameplayManager.OnEnemyDied();
            //Enemy Died. Update UI.
        }
    }
}