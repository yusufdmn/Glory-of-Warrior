using UnityEngine;
using Zenject;

namespace Gameplay_System.Factory
{
    public enum EnemyType
    {
        Male1,
        Male2,
        Male3,
        Female1,
        Female2
    }
    
    public class EnemyFactory: PlaceholderFactory<EnemyType, GameObject>
    {
        
    }
}