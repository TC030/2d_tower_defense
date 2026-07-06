# 🏰 12-Week Summer Self-Learning Project: Standard 2D Tower Defense
**Target Engine:** Godot 4.x .NET (C#)
**Core Learning Goal:** Master Industrial-Grade OOP Architectures & Advanced Design Patterns
**Estimated Total Time:** 3 - 4 Weeks (60 - 80 Working Hours)

---

## 📈 Strategic Timeline Matrix

| Phase / Stage | Estimated Time | Est. Hours | Core Architectural Focus & OOP Deliverables |
| :--- | :---: | :---: | :--- |
| **Stage 1: Core OOP Foundation** | Week 1 (7 Days) | 20 Hrs | - Abstract Base Classes (`TowerBase`, `EnemyBase`, `ProjectileBase`) <br>- Polymorphism via virtual/abstract methods <br>- Pathfollowing-based locomotion system <br>- Basic target detection & shooting lifecycle |
| **Stage 2: Game State & Economy** | Week 2 (3 Days) | 10 Hrs | - Global Game Manager (Singleton/Autoload) <br>- Decoupled Event-Bus System for Economy (Gold/Hearts) <br>- Data-driven Wave Spawner <br>- Grid-snapped Dynamic Placement System |
| **Stage 3: Advanced Design Patterns** | Week 2-3 (7 Days)| 25 Hrs | - **Strategy Pattern:** Target Selection AIs (First, Last, Strongest) <br>- **State Pattern:** Enemy status effects (Normal, Slowed, Burn/DOT) <br>- Inheritance & Polymorphism variations for Towers, Enemies & Projectiles |
| **Stage 4: Active Tools & Multi-Map** | Week 3-4 (4 Days)| 15 Hrs | - **Command Pattern:** Player active abilities (Airstrike, Landmines, Barricades) <br>- Modular Level/Map Manager to swap scene configurations <br>- Dynamic UI interaction handling |
| **Stage 5: Polish & Architectural Audit** | Week 4 (3 Days) | 10 Hrs | - Game HUD Panel & context-aware upgrade/sell menus <br>- Performance optimization & Memory Leak check <br>- Final Markdown technical documentation & release tag |

---

## 🛠️ Detailed Stage-by-Stage Workflow

### 🟩 Stage 1: Core OOP Base Classes & Game Loop
> **Objective:** Build the rigid skeleton of the game using pure OOP contracts before writing any concrete gameplay logic.

*   **The Big Three Hierarchy:** 
    *   `EnemyBase` (Inherits `PathFollow2D`): Handles health, speed, and standard damage-taking virtual methods.
    *   `TowerBase` (Inherits `Node2D`): Manages range scanning (`Area2D`), tracking targets, and attack cooldown timers.
    *   `ProjectileBase` (Inherits `Node2D`): Manages velocity vectors, target tracking, and impact detection payloads.
*   **Locomotion & Detection:** Implement Godot's `Path2D` navigation. Hook up C# signals from the tower's `Area2D` detector to identify entry/exit of `EnemyBase` instances.
*   **Lifecycle Management:** Implement safe object destruction routines (`QueueFree()`) when health dropped below zero or when objects left boundaries.

### 🟨 Stage 2: Economy, Sourcing, & Placement
> **Objective:** Introduce state persistence, global event dispatching, and dynamic node instantiation.

*   **Global Managers (Autoload):**
    *   `GameManager`: Stores player HP (Hearts) and currency (Gold).
    *   `EventBus`: Centralized broker for loose decoupling (e.g., `EnemyDied` triggers `GoldChanged` without direct coupling).
*   **Data-Driven Wave Spawner:** Create structure arrays or text configs detailing incoming wave schemas (e.g., `Wave 1: [10x Grunts, 1.0s interval]`).
*   **Grid Placement System:** Convert mouse screen coordinates into 2D grid coordinates, check for affordability via `GameManager`, and spawn physical `TowerBase` instances onto valid tiles.

### 🟦 Stage 3: Design Pattern Injections & Varied Extensions
> **Objective:** Expand the content variety exponentially by inserting formal software design patterns.

*   **Targeting Strategy (Strategy Pattern):** Wrap targeting logic inside an `ITargetingStrategy` interface. Create concrete behaviors (`TargetFirst`, `TargetStrongest`, `TargetClosest`) that can be hot-swapped at runtime on any tower.
*   **Status Effects System (State Pattern / Composition):** Introduce an `AilmentManager` on enemies. Implement dynamic states such as `SlowedState` (modifies velocity multiplier) and `BurnState` (ticks damage over time formulas).
*   **Polymorphic Variants:**
    *   *Towers:* Single-target Sniper, AOE Splash Cannon, Continuous Laser Beam.
    *   *Enemies:* Armored Bruiser, High-Speed Sprinter, Broodmother (spawns smaller sub-nodes on death).

### 🟪 Stage 4: Active Command Tools & Level Swapping
> **Objective:** Give the player agency via active abilities and scale the architecture to accept arbitrary level maps.

*   **Active Abilites (Command Pattern):** Decouple player inputs from system responses. Map abilities into a `Command` queue hierarchy:
    *   `AirstrikeCommand`: Spawns heavy AOE explosions across a designated zone.
    *   `TrapCommand`: Drops a stationary physics obstacle that triggers on contact.
*   **Multi-Map Scalability:** Abstracts map layouts from game logic. Create a master level loader that injects varied `Path2D` data into the existing Stage 2 Spawner script without rewriting loop cycles.

### ⬛ Stage 5: System Polishing & Technical Audit
> **Objective:** Iron out UX details, optimize performance bottlenecks, and document the architectural design.

*   **Contextual UI:** Build reactive UI overlay menus for buying, upgrading stats (increased range/fire-rate via polymorphism), or selling towers.
*   **Optimization Profiling:** Verify memory allocations. Guard against memory leaks caused by stray C# events/signals. Ensure the application can maintain fluid frame rates even when rendering hundreds of projectiles simultaneously.
*   **Git & Doc Maintenance:** Clean up version control tags. Author a comprehensive `README.md` containing class relationship descriptions and structural diagrams.