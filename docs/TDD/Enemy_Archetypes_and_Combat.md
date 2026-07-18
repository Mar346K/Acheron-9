# Foundational System: Enemy Archetypes & Combat Manifest

**Related Files:** project_overview.md, Map_Chapter-1, Weapons_and_Economy.md  
**Scope:** This document is the absolute source of truth for core machine AI, scaling math, combat mechanics, and swarm logic across Chapter 1 and all future installments.

**Overview:** The Mechanical God does not simply throw bodies at the Exiles; it calculates the most efficient path to their termination. This document defines the behavioral logic, critical-hit mechanics, adjusted spawn scaling, and dynamic coordination of the machine swarm based on player count and tight environmental constraints.

---

## 1. Combat Mechanics: The "Battery Shot" & Dismemberment
To reinforce the industrial sci-fi setting, machines do not take extra damage to the head. Destroying their primary power supply acts as the critical hit, resulting in an immediate ragdoll termination.

*   **Target Accessibility:** Power cells act as "headboxes." They are luminescent and strategically placed to be targetable from multiple angles.
*   **The Overcharge Synergy:** 
    *   *Human Kinetic Weapons:* Cleanly powers the machine down. 
    *   *Machine Energy Weapons:* Triggers a thermal overload, detonating the machine in a localized explosion.
*   **Limb Severance (The "Crawler" Mechanic):** Players can intentionally aim low with Human Kinetic weapons to shatter the leg servos of basic Scrap-Walkers. This turns them into a **Severed Chassis**—a crippled machine that slowly drags itself across the floor by its arms. 

---

## 2. AI Logic: The Director & Squad Coordination
The game does not use random spawns. The overarching "Director AI" analyzes player positioning and dynamically adjusts machine tactics to fit the claustrophobic map geometry.

### Spawn Caps (Spatial Balancing)
To prevent physical body-blocking and rendering chaos in tight corridors, the maximum number of simultaneous active machines is strictly capped:
*   **Solo Play:** Max 18 active machines at once.
*   **Squad Play (4 Players):** Max 32 active machines at once.
*   *Note:* The total number of enemies per round still scales up infinitely, but the Director will only spawn replacements as active machines are destroyed, keeping the map readable.

### Pacing & The "Breather" Phase
*   **End-of-Round Management:** If players reduce the horde down to a single **Severed Chassis**, the Director AI will stall the next wave. This grants the squad a crucial "breather" to safely traverse the map, spend Scrap at the Fabricator, and progress Easter Egg steps (like the Bio-Canister Synthesis).
*   **Director Auto-Cull:** To prevent soft-locks, if a Severed Chassis has not dealt or received damage for 4 full minutes, its internal battery auto-vents (killing it) and immediately triggers the start of the next round.

### Tactical AI Responses
*   **The Deathball Response:** If the squad camps tightly in one corner, the Director deploys Heavy Vanguards to the front to absorb fire, while routing Scrap-Walkers through the ceiling to drop behind the squad.
*   **The Isolation Protocol:** If the squad divides (e.g., during the Mag-Train hack), the Director assigns Hunter-Killer packs to actively hunt the player with the lowest health.

---

## 3. Global Spawn Progression & Health Scaling
Enemy health and armor scale mathematically. The baseline formula for machine HP is: `Base HP * (1.1 ^ Current Round)`.

*   **Rounds 1 - 4 (The Breach):** Exclusively Scrap-Walkers. Low spawn cap. Designed to let players build their early Scrap economy.
*   **Round 5 (The Hunt Begins):** Introduction of Hunter-Killers. The Director uses them to break players out of early-game camping spots. 
*   **Round 8+ (Heavy Resistance):** Introduction of Heavy Vanguards. Ablative Plasma-Plating begins scaling in durability, requiring Bio-Tech (Marrow-Rust) or Machine Energy weapons to strip armor.
*   **Round 15+ (The Endless Scaling):** Max simultaneous spawn cap is permanently locked. Difficulty increases strictly through health multipliers, armor thickness, and aggressive AI pathing speed.

---

## 4. The Machine Horde: Attacks & Critical Zones
The swarm is divided into three distinct chassis archetypes.

### Archetype 1: Scrap-Walkers (The Swarm Grunts)
*   **Critical Zone (The Cervical Hump):** A glowing fusion battery mounted at the top of the spine. Targetable from the front, back, and sides.
*   **Attack Profiles:**
    *   *Serrated Swipe:* Standard standing melee attack.
    *   *Ceiling Drop (Ambush):* Detaches from the ceiling directly above a player, applying a 1-second movement slow if it lands.
    *   *Ankle-Grab:* Only used when converted into a Severed Chassis. If a player walks over them, they latch on and deal rapid minor damage until kicked off.

### Archetype 2: Hunter-Killers (The Predators)
*   **Critical Zone (The Thoracic Core):** A glass-like cylinder running straight through the center of their chest cavity. Their constant elevation changes make this center-mass placement the only reliable target.
*   **Attack Profiles:**
    *   *Kinetic Pounce:* Leaping attack. If it connects, it pins the player to the ground, requiring the player to mash the melee key (V/R3) to rupture the machine.
    *   *Evasive Strafe:* When a player aims down sights (ADS) directly at them, the machine will actively perform a lateral dodge to avoid fire.

### Archetype 3: Heavy Vanguards (The Elite Suppressors)
*   **Critical Zone (The Asymmetrical Shoulder Cell):** A massive plasma battery slung high on their left shoulder. The off-center placement forces players to adjust aim away from center-mass.
*   **Attack Profiles:**
    *   *Plasma Barrage:* Ranged suppressive fire. Forces players to use Bio-Kinetic slides to dodge underneath the projectiles.
    *   *Grav-Slam (AoE):* If players get too close, the Vanguard slams its fist into the ground, creating a 5-meter shockwave that knocks players backward and cancels their slides.
    *   *Ablative March:* The Vanguard raises its heavily armored arm to protect its optical sensors, completely ignoring small-arms fire and kinetic stagger until its armor is stripped.