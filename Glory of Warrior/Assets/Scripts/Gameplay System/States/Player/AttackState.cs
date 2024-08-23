using System.Threading.Tasks;
using Gameplay_System.Model;
using Zenject;

namespace Gameplay_System.States.Player
{
    public class AttackState: IState
    {
        private bool _hasAnimationStarted;
        private const string _attackAnimationName = "Attack";
        [Inject] private PlayerModel _playerModel;
        [Inject] private AnimationManager _animationManager;
        
        public void OnEnter()
        {
            _animationManager.Attack();
            _playerModel.Attack();
            CheckAnimationStartAsync();
        }

        public void UpdateState()
        {
            if(!_hasAnimationStarted)
                return;

            if (_animationManager.GetCurrentState().IsName(_attackAnimationName)) 
                return;
            
            _playerModel.StopAttack();
        }

        public void OnExit()
        {
            _hasAnimationStarted = false;
        }
        
        
        
        private async void CheckAnimationStartAsync()
        {
            while (!_hasAnimationStarted)
            {
                await Task.Delay(10); 

                if (_animationManager.GetCurrentState().IsName("Attack"))
                {
                    _hasAnimationStarted = true;
                }
            }

        }
    }
}