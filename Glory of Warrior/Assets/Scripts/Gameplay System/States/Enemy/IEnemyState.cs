using Gameplay_System.Model;

namespace Gameplay_System.States.Enemy
{
    public interface IEnemyState: IState
    {
        void Initialize(EnemyModel model);
    }
}