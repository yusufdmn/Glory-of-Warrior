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
using UnityEngine;
using Zenject;

namespace Gameplay_System.DI
{
    public class ZenjectGameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject male1Prefab;
        [SerializeField] private GameObject male2Prefab;
        [SerializeField] private GameObject male3Prefab;
        [SerializeField] private GameObject female1Prefab;
        [SerializeField] private GameObject female2Prefab;

        public override void InstallBindings()
        {
            BindPlayerComponents();
            BindEnemyComponents();
            BindHealthComponents();
            BindGameplayComponents();
            BindOtherComponents();
            BindFactories();
        }

        private void BindPlayerComponents()
        {
            // Bind each state implementation to the IState with identifiers
            Container.Bind<IState>().WithId("IdleState").To<IdleState>().AsTransient();
            Container.Bind<IState>().WithId("AttackState").To<AttackState>().AsTransient();
            Container.Bind<IState>().WithId("RunState").To<RunState>().AsTransient();
            Container.Bind<PlayerStates>().AsSingle();

            // Bind the player components
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
            // Bind each state implementation to the IState with identifiers
            Container.Bind<IEnemyState>().WithId("patrolState").To<EnemyPatrolState>().AsTransient();
            Container.Bind<IEnemyState>().WithId("chaseState").To<EnemyChaseState>().AsTransient();
            Container.Bind<IEnemyState>().WithId("attackState").To<EnemyAttackState>().AsTransient();
            Container.Bind<IEnemyState>().WithId("idleState").To<EnemyIdleState>().AsTransient();

            Container.Bind<EnemyStates>().AsTransient();
            Container.Bind<EnemyModel>().AsTransient();
            Container.Bind<EnemyController>().AsTransient();
            Container.Bind<WarriorDetector>().AsTransient();
            Container.Bind<IDeathStrategy>().To<EnemyDeathStrategy>().AsTransient()
                .WhenInjectedInto<EnemySystemInitializer>();
        }

        private void BindHealthComponents()
        {
            Container.Bind<IHealthModel>().To<HealthModel>().AsTransient();
            Container.Bind<IHealthController>().To<HealthController>().AsTransient();
            Container.Bind<HealthCalculator>().AsTransient();
            Container.Bind<IDeathStrategy>().To<PlayerDeathStrategy>().AsSingle()
                .WhenInjectedInto<PlayerSystemInitializer>();
        }

        private void BindGameplayComponents()
        {
            Container.Bind<AttackHandler>().AsSingle();
            Container.Bind<GameplayManager>().AsSingle();
            Container.Bind<GameplayUI>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<GameplayData>().AsSingle();
            Container.Bind<EnemySpawner>().AsTransient();
        }

        private void BindOtherComponents()
        {
            Container.Bind<PowerCalculator>().AsTransient();
            Container.Bind<BoneStorage>().FromComponentsInHierarchy().AsTransient();
            Container.Bind<NavMeshPositionGenerator>().AsTransient();
        }

        private void BindFactories()
        {
            Container
                .BindFactory<HealthSystemInitializerParams, HealthSystemInitializer, HealthSystemInitializerFactory>()
                .AsTransient();
            
            // Bind the EnemyFactory with the enemy prefabs 
            Container.BindFactory<EnemyType, GameObject, EnemyFactory>()
                .FromMethod((container, prefabId) =>
                {
                    switch (prefabId)
                    {
                        case EnemyType.Male1:
                            return container.InstantiatePrefab(male1Prefab);
                        case EnemyType.Male2:
                            return container.InstantiatePrefab(male2Prefab);
                        case EnemyType.Male3:
                            return container.InstantiatePrefab(male3Prefab);
                        case EnemyType.Female1:
                            return container.InstantiatePrefab(female1Prefab);
                        case EnemyType.Female2:
                            return container.InstantiatePrefab(female2Prefab);
                        default:
                            throw new System.ArgumentException($"Unknown prefabId: {prefabId}");
                    }
                });

        }
    }
}