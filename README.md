# Glory of Warrior

Glory of Warrior is a fast-paced 3D casual mediavel themed battle game where the player fight AI-controlled enemies in an arena, aiming to be the last one standing. Characters use a variety of weapons and armors as they engage in the combat.

## Architecture
The project follows SOLID principles an MVC (Model-View-Controller) architecture with Dependency Injection (DI) via Zenject and a Finite State Machine (FSM) for managing gameplay flow, enabling modularity and efficient handling of AI, player states, and combat.

## Key Features
- **Medieval Battle Arena:** Fight in medieval environment with medieval weapons.
- **AI Enemies:** AI controlled opponents. 
- **Equipment System:** Equip your character with various weapons and armor.
- **Optimized:** CPU, GPU and Memory optimizations for a smooth gameplay.

## Design Patterns and Technologies
- **Model-View-Controller (MVC)**
- **Dependency Incejtion (DI):** Implemented using Zenject. 
- **Strategy Pattern:** Implements different behaviors for death events of player and enemy.
- **Observer Pattern:** Mostly used to handle events between model-controller, view-controller, and controller-controller.
- **State Pattern:** For player and enemy state machines.
- **Navmesh:** To control AI enemies in the battle area.
- **Cinemachine**


## Optimization Techniques

- **Gpu Instancing**
- **Static and Dynamic batching**
- **Custom skinned mesh combiner**

> [!NOTE]
> The drawcalls are reduced signifantly with the optimizations.



## Gameplay

https://github.com/user-attachments/assets/c24cda15-b2ac-4f7c-b35c-b0aa1505f6bd

