using Gameplay_System.Animation_Management;
using Gameplay_System.Controller;
using Gameplay_System.Factory;
using Gameplay_System.Factory.Params;
using Gameplay_System.Gameplay_Management;
using Gameplay_System.Helper;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Initializers;
using Gameplay_System.Initializers.Helper;
using Gameplay_System.Model;
using Gameplay_System.States;
using Gameplay_System.States.Enemy;
using Gameplay_System.States.Player;
using Gameplay_System.View;
using Health_System;
using Health_System.Controller;
using Health_System.Initializer;
using Health_System.Initializer.Helper;
using Health_System.Model;
using Health_System.Strategy;
using Helper;
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
        // Bind each state implementation to the same interface (IState) with identifiers
        Container.Bind<IState>().WithId("IdleState").To<IdleState>().AsTransient();
        Container.Bind<IState>().WithId("AttackState").To<AttackState>().AsTransient();
        Container.Bind<IState>().WithId("RunState").To<RunState>().AsTransient();

        
        // Bind the PlayerStates class
        Container.Bind<PlayerStates>().AsSingle();
        
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
        Container.Bind<IDeathStrategy>().To<EnemyDeathStrategy>().AsTransient().WhenInjectedInto<EnemySystemInitializer>();
    }

    private void BindHealthComponents()
    {
        Container.BindFactory<HealthSystemInitializerParams, HealthSystemInitializer, HealthSystemInitializerFactory>()
            .AsTransient();
        Container.Bind<IHealthModel>().To<HealthModel>().AsTransient();
        Container.Bind<IHealthController>().To<HealthController>().AsTransient();
        Container.Bind<HealthCalculator>().AsTransient();
        Container.Bind<IDeathStrategy>().To<PlayerDeathStrategy>().AsSingle().WhenInjectedInto<PlayerSystemInitializer>();
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
        Container.Bind<BoneStorage>().FromComponentsInHierarchy().AsTransient();
    }

    }
}