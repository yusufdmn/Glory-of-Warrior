using Gameplay_System.Animation_Management;
using Gameplay_System.Controller;
using Gameplay_System.Gameplay_Management;
using Gameplay_System.Helper;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Initializers.Helper;
using Gameplay_System.Model;
using Gameplay_System.States.Enemy;
using Gameplay_System.States.Player;
using Gameplay_System.View;
using Health_System;
using Health_System.Initializer.Helper;
using Health_System.Strategy;
using Zenject;

namespace Gameplay_System.DI
{
    public class ZenjectGameplayInstaller: MonoInstaller
    {
    public override void InstallBindings()
    {
        BindPlayerComponents();
        BindEnemyComponents();
        BindHealthComponents();
        BindGameplayComponents();
        BindOtherComponents();
    }

    private void BindPlayerComponents()
    {
        Container.Bind<PlayerStates>().AsTransient();
        Container.Bind<AttackState>().AsTransient();
        Container.Bind<IdleState>().AsTransient();
        Container.Bind<RunState>().AsTransient();
        Container.Bind<PlayerMovement>().FromComponentsInHierarchy().AsTransient();
        Container.Bind<PlayerStateMachine>().FromComponentsInHierarchy().AsTransient();
        Container.Bind<PlayerModel>().AsSingle();
        Container.Bind<PlayerController>().AsSingle();
        Container.Bind<PlayerView>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<PlayerAnimationManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputData>().FromComponentsInHierarchy().AsTransient();
    }

    private void BindEnemyComponents()
    {
        Container.Bind<EnemyPatrolState>().AsTransient();
        Container.Bind<EnemyChaseState>().AsTransient();
        Container.Bind<EnemyAttackState>().AsTransient();
        Container.Bind<EnemyIdleState>().AsTransient();
        Container.Bind<EnemyStates>().AsTransient();
        Container.Bind<EnemyModel>().AsTransient();
        Container.Bind<EnemyController>().AsTransient();
        Container.Bind<WarriorDetector>().AsTransient();
        Container.Bind<EnemyDeathStrategy>().AsTransient();
    }

    private void BindHealthComponents()
    {
        Container.Bind<HealthModel>().AsTransient();
        Container.Bind<HealthController>().AsTransient();
        Container.Bind<HealthCalculator>().AsTransient();
        Container.Bind<PlayerDeathStrategy>().AsSingle();
    }

    private void BindGameplayComponents()
    {
        Container.Bind<AttackHandler>().AsSingle();
        Container.Bind<GameplayManager>().AsSingle();
        Container.Bind<GameplayUI>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<GameplayData>().AsSingle();
    }

    private void BindOtherComponents()
    {
        Container.Bind<PowerCalculator>().AsTransient();
    }

    }
}