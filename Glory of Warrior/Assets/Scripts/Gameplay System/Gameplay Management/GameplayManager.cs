using UnityEngine;
using Zenject;

namespace Gameplay_System.Gameplay_Management
{
    public class GameplayManager
    {
        [Inject] private GameplayUI _gameplayUI;
        [Inject] private GameplayData _gameplayData;
        
        public void OnEnemyDied()
        {
            _gameplayData.RemainingEnemies--;
            _gameplayUI.UpdateRemainingEnemies(_gameplayData.RemainingEnemies);
            //Enemy Died. Update UI.
        }
        
        public void OnPlayerDied()
        {
            //Player Died. Stop The Game.
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