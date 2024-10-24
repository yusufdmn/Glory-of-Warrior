using TMPro;
using UnityEngine;

namespace Gameplay_System.Gameplay_Management
{
    public class GameplayUI: MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private TextMeshProUGUI _remainingEnemiesText; 
        //[SerializeField] private TextMeshProUGUI _playerKillsText;
        
        public void ShowGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }
        
        public void ShowWinPanel()
        {
            _winPanel.SetActive(true);
        }
        
        public void UpdateRemainingEnemies(int remainingEnemies)
        {
            _remainingEnemiesText.text = remainingEnemies.ToString();
        }
        /*
        public void UpdatePlayerKills(int playerKills)
        {
            _playerKillsText.text = "Kills: " + playerKills;
        }*/

        
    }
}