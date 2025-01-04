using System.Dynamic;
using Gameplay_System.Factory;
using Health_System.Strategy;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Gameplay_Management
{
    public class GameplayManager
    {
        private bool _playerAlive = true;
        private GameplayUI _gameplayUI;
        private GameplayData _gameplayData;
        private EnemySpawner _enemySpawner;
        
        [Inject]
        public GameplayManager(GameplayUI gameplayUI, GameplayData gameplayData, EnemySpawner enemySpawner)
        {
            _gameplayUI = gameplayUI;
            _gameplayData = gameplayData;
            _enemySpawner = enemySpawner;
            _gameplayUI.OnStartGame += StartGame;
        }
        
        private void StartGame()
        {
            Debug.Log("Game Started");
            _gameplayUI.UpdateRemainingEnemies(_gameplayData.RemainingEnemies); 
            _enemySpawner.SpawnEnemy(EnemyType.Male1, _gameplayData.RemainingEnemies / 5);
            _enemySpawner.SpawnEnemy(EnemyType.Male2, _gameplayData.RemainingEnemies / 5);
            _enemySpawner.SpawnEnemy(EnemyType.Male3, _gameplayData.RemainingEnemies / 5);
            _enemySpawner.SpawnEnemy(EnemyType.Female1, _gameplayData.RemainingEnemies / 5);
            _enemySpawner.SpawnEnemy(EnemyType.Female2, _gameplayData.RemainingEnemies / 5);
        }
        
        public void OnEnemyDied()
        {
            // Enemy Died. Decrease Remaining Enemies Count.
            _gameplayData.RemainingEnemies--;
            _gameplayUI.UpdateRemainingEnemies(_gameplayData.RemainingEnemies);
            
            if (_gameplayData.RemainingEnemies <= 0 && _playerAlive)
            {
                _gameplayUI.ShowWinPanel();
            }
        }
        
        public void OnPlayerDied()
        {
            //Player Died. Stop The Game.
            _gameplayUI.Invoke(nameof(_gameplayUI.ShowGameOverPanel), 1.5f);
        }
        
        ~GameplayManager()
        {
            _gameplayUI.OnStartGame -= StartGame;
        }

    }
}