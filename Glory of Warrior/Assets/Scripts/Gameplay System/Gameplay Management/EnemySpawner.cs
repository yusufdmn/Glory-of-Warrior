using System.Dynamic;
using System.Threading.Tasks;
using Gameplay_System.Factory;
using Gameplay_System.Helper;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Gameplay_Management
{
    public class EnemySpawner
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly NavMeshPositionGenerator _navMeshPositionGenerator;
        
        [Inject]
        public EnemySpawner(EnemyFactory enemyFactory, NavMeshPositionGenerator navMeshPositionGenerator)
        {
            _enemyFactory = enemyFactory;
            _navMeshPositionGenerator = navMeshPositionGenerator;
        }

        public void SpawnEnemy(EnemyType enemyType, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 randomPosition = _navMeshPositionGenerator.GetRandomNavMeshPosition(Vector3.zero, 30);
                GameObject enemy = _enemyFactory.Create(enemyType); 
                SetPosition(enemy, randomPosition);
            }
        }
        async void SetPosition(GameObject obj, Vector3 position)
        {
            await Task.Delay(500);
            obj.transform.position = position;
        }
    }
}