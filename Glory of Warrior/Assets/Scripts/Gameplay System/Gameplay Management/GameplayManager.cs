using System.Dynamic;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Gameplay_Management
{
    public class GameplayManager
    {
        private bool _playerAlive = true;
        [Inject] private GameplayUI _gameplayUI;
        [Inject] private GameplayData _gameplayData;
        
        public void OnEnemyDied()
        {
            _gameplayData.RemainingEnemies--;
            _gameplayUI.UpdateRemainingEnemies(_gameplayData.RemainingEnemies);
            //Enemy Died. Update UI.
            
            if (_gameplayData.RemainingEnemies <= 0 && _playerAlive)
            {
                _gameplayUI.ShowWinPanel();
            }
        }
        
        public void OnPlayerDied()
        {
            //Player Died. Stop The Game.
            _gameplayUI.Invoke(nameof(_gameplayUI.ShowWinPanel), 1);
//            _gameplayUI.ShowGameOverPanel();
        }
        
        /*
        public void OnPlayerKill()
        {
            _gameplayData.PlayerKills++;
            _gameplayUI.UpdatePlayerKills(_gameplayData.PlayerKills);
            //Player Killed An Enemy. Update UI.
        }*/
    }
}