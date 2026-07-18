# Acheron-9 — Project Overview

## I. Executive Summary

| | |
|---|---|
| **Project Title** | Acheron-9 |
| **Genre** | Sci-Fi Survival Horror / Wave-Based Shooter |
| **Core Experience** | Intense, round-based survival gameplay focusing on high-mobility movement, tactical resource management, and cooperative strategy in a hostile, industrial alien environment. |

### High-Level Pitch

In the year 2360, on the resource-rich planet of Acheron-9, six bio-hacked vampires—fallen Founders turned Exiles—find themselves trapped in a desperate siege. The "Mechanical God"—a cold, self-optimizing neural network they once built to run their empire—seeks to harvest the planet's unique biomaterials for its own expansion. Cut off from the galaxy, the vampires are forced to abandon their centuries-old hierarchies to survive the relentless assault of the Machine Vanguard.

### Unique Selling Propositions (USPs)

- **Bio-Kinetic Flow:** A movement-based combat system that rewards speed and environmental awareness. Players are not soldiers; they are bio-hacked predators capable of momentum-based traversal, wall-kicking, and high-speed slides.
- **The Vampire/Machine Dynamic:** A complete inversion of the traditional "zombie shooter." Players possess superhuman abilities (Blood Arts) and distinct personalities, but must balance their "Vitae Meter" through high-risk melee engagement, pitting predatory biology against mechanical, systemic coldness.
- **Relocating Economy:** Instead of static weapon spawns, the "3D Fabricator"—the team's only reliable source of high-tier weaponry—is a portable, hackable terminal that dynamically moves to different "Anchor Points" across the map, preventing camping and forcing constant movement.

### Game Modes

Acheron-9 ships with two primary modes (see `Launch_Menus_Infrastructure_Blueprint.md`):

| Mode | Fantasy | Win Condition |
|---|---|---|
| **Campaign (The Extraction)** | Story-driven, objective-based siege | Complete Chapter objectives and escape via the Mag-Train |
| **Endless (The Siege)** | Pure arcade survival | None — survive as many rounds as possible for global leaderboards; the Mag-Train is sealed |

---

## II. Narrative World-Building

### 1. History & Lore: The Ascension, The Divide, and The Siege

The history of the vampires is not one of fantasy, but of corporate consolidation, exile, and survival. Canon timeline:

- **2020s – The Founders & The Mechanical God:** The Vampire "Founders" (the six playable characters) control Earth's mega-corporations. They build the Mechanical God AI to run their logistics empire.
- **2270s – The Great Divide:** The AI invents Warp Tech. Calculating that vampires will consume the galaxy, it allies with the human resistance. The Founders' empire falls; they are hunted. The Narrator gathers these fallen Founders—now **Exiles**—and flees to Acheron-9, where magnetic storms hide them from AI optical targeting.
- **2360 – Present (The Siege):** The AI discovers Acheron-9's core contains the biomaterials it needs. It attacks the Bio-Outpost. The game begins.

### 2. The Protagonists: The Vampire Hierarchy (Social vs. Mechanical)

The vampires retain a traditional hierarchy in dialogue (Thralls to Kings), but on Acheron-9 that hierarchy is social and narrative—not a power fantasy of the old empire.

- **Narrative Impact:** Rank dictates a character's voice lines, worldview, background, and how they perceive squadmates. An "Aristocrat" Lord will look down on a "Squire" Bio-Hacker; those attitudes create reactive dialogue.
- **Mechanical Baseline:** All six playable characters share **identical base stats, hitboxes, and weapon handling**. Hierarchy does not grant combat advantages.
- **Unique Blood Arts:** Each character starts the match with one Unique equipped Blood Art tied to their lore (see `Blood_Arts_System.md`). Mid-match, players may spend 2,000 Scrap at the **Vitae Splicer** in the Decontamination Hub to swap to any other character's Blood Art. Rank is a privilege of the past; Vitae and teamwork are the currency of the present.

### 3. The World: Acheron-9

Acheron-9 is a "Bio-Hazard World" defined by extreme magnetic interference and corrosive atmospheric conditions.

- **Why the Machines struggle:** The planet's erratic magnetic storms short-circuit high-end **energy shields** and scramble long-range targeting. Elite units therefore rely on rugged construction and **Ablative Plasma-Plating** (physical heavy armor)—not energy shields—to operate in the storms.
- **The Lockdown:** When the Machine Vanguard arrives, they disable all planetary communications and airspace, sealing the Exiles within the Bio-Outpost they once used as sanctuary.

---

## III. Gameplay Core

### 1. The Core Loop

The game centers on a round-based survival loop designed to maximize tension and resource management:

- **The Wave Progression:** Players must survive increasingly difficult waves of Machine incursions. Each round ends when the spawn array is exhausted.
- **Expansion & Strategy:** Players earn "Scrap" by damaging and destroying enemies. Scrap is used to open new map areas, purchase wall-mounted weapons, and access utility traps.
- **The Relocating Economy:** The "3D Fabricator" (a hackable terminal) acts as the high-tier loot dispenser. To prevent static gameplay ("camping"), the Fabricator periodically overheats and relocates to a new structural Anchor Point, forcing players to rotate through the map.
- **Campaign Objectives:** In Campaign mode, players must also complete narrative/mechanical objectives (e.g., the Harmonic Frequency Hack) to unlock Mag-Train extraction. In Endless mode, extraction is disabled and the Director scales aggression for leaderboard play.

### 2. Player Movement: "Bio-Kinetic Flow"

Vampire movement is defined by momentum and physics, not just speed. It rewards players for chaining actions without losing velocity:

- **The Momentum Slide:** Sprinting into a crouch drastically reduces friction, allowing for high-speed traversal, especially on inclines.
- **The Vault-Boost:** Jumping during a hurdle action launches the player forward, maintaining their momentum.
- **Wall-Kick:** Allows for an instant reversal of direction when hitting a wall, facilitating rapid tactical escapes from tight corners.
- **Kinetic Heat Variable:** A scaling movement speed buff (up to 15%) earned by chaining movement actions. Taking damage resets the heat, penalizing reckless play.

### 3. The Combat Economy

- **Wallbuys:** Distributed throughout the map, these provide reliable, consistent firepower (e.g., Scrap-Pistol, Mag-Rail Shotgun, Vanguard Cannon) to ensure players always have access to basic equipment. Full tier list: `Weapons_and_Economy.md`.
- **Gene-Splicers (Perks):** Instead of vending machines, players locate Gene-Splicing Centrifuges. These provide permanent buffs:
  - **Goliath Marrow:** Increased health (hits to down: 3 → 5).
  - **Synaptic Overdrive:** Faster reload and weapon-swap speeds.
  - **Necro-Pulse:** Accelerated revive speeds.
  - **Crimson Chamber:** Double-damage scaling against machine armor.
  - **Vampiric Stride:** Infinite tactical sprinting. (*Perk name only—base movement sprint is simply "Sprint."*)

---

## IV. Enemy Design

### 1. The Machine Philosophy: Swarm Intelligence

The enemy does not operate as individual "monsters," but as a self-optimizing system directed by the Mechanical God. Even early "dumb" units demonstrate coordinated behavior based on a centralized directive.

- **The Director AI:** Manages spawn density and unit composition. The AI actively calculates player proximity and filters spawns through vents, ceilings, and paths within two zones of the player to maintain constant pressure.
- **Environmental Dominance:** Machines use the architecture. Certain units possess magnetic adhesion, allowing them to traverse ceilings and walls, forcing players to monitor verticality as well as horizontal sightlines.

### 2. The Bestiary

The machine army is tiered to scale difficulty across the rounds:

- **Scrap-Walkers (Early Game):** Repurposed mining bots. They use direct-intercept logic to clog pathways and corner players. Their primary threat is the "grab" mechanic, which severely slows the player's movement speed.
- **Hunter-Killers (Mid Game):** Agile, synthetic units that utilize swarm tactics. They avoid grouping, preferring to flank through parallel hallways to cut off escape routes. They are capable of erratic leaps and wall-clinging to avoid direct fire.
- **The Vanguard (Late Game):** Heavy military hardware. These units move in a Phalanx formation with overlapping **Ablative Plasma-Plating** (physical heavy armor—not energy shields, which Acheron-9's storms would short out). They do not dodge or jump; they physically shatter destructible cover (crates, doors), forcing players to adapt to the changing map geometry in real-time.

---

## V. Level Design & Technical References

### 1. Map Design Philosophy: The Circular Loop

The map architecture is built on a "circular loop" framework, ensuring players are constantly funneled through high-intensity zones rather than dead-ends.

- **Anchor Points:** Every major room centers around massive obstacles (e.g., downed Harvester drones, stasis pods, central pillars). Players are encouraged to manipulate the AI's direct-intercept pathfinding by running "figure-eights" around these points.
- **Verticality:** The environment utilizes multi-level architecture (trenches, catwalks, and ceiling vents) to force players to monitor vertical sightlines, preventing "corner-camping."

### 2. Chapter 1: The Bio-Outpost Layout

Canonical zone detail lives in `Chapter-1/Map_Chapter-1`. Summary:

- **Zone 1 — The Decontamination Hub (Spawn):** A multi-tier security/decontamination block (Purge Grate, Observation Deck, Security Checkpoint). Ingress via shattered skylight, wall vents, and floor grates. Teaches verticality and Bio-Kinetic movement before heavy pressure. Houses the Vitae Splicer.
- **Zone 2A — The Bio-Wing (Hydroponics):** Large, curved rooms with massive, shattered glass terrariums. Optimized for "training" or "kiting" large groups of enemies.
- **Zone 2B — The Industrial Wing (Geothermal Maintenance):** A linear, angular path featuring a wide central trench with side catwalks. Designed to force flanking maneuvers.
- **Zone 3 — The Mag-Train Platform (The Apex):** The final holdout zone where both wings converge. Houses the primary Power Switch, highest spawn density, and (in Campaign) Mag-Train extraction.

### 3. Environmental Interaction (Traps)

Players can spend Scrap to activate map-specific traps, creating tactical choke points:

- **Pheromone Vents:** Summons temporary Vampire Thralls to act as a "meat-shield" against machines.
- **Corrosive Sprinklers:** Strip Ablative Plasma-Plating from heavy Vanguard units, increasing ballistic damage.
- **Mag-Crushers:** Industrial blast doors that slam shut, crushing enemies in the Geothermal wing.
- **Arc-Coil Overload:** A map-wide EMP shockwave that stuns all machines for 10 seconds.

---

## VI. Appendices

### 1. Character Roster Summary

All characters share identical base stats, hitboxes, and weapon handling. Each starts with one Unique Blood Art (swappable later; full definitions in `Blood_Arts_System.md`).

| Character | Role | Narrative Focus | Starting Blood Art |
|---|---|---|---|
| The Narrator | Knight | Pragmatic protector; brute strength | Acheron Resonance |
| The Aristocrat | Lord | High-society exile; Thrall-command themes | Founder’s Edict |
| The Feral | Newborn | Berserker; speed and environmental aggression | Apex Ossification |
| The Bio-Hacker | Squire | Field medic; machine-splicing themes | Marrow-Rust |
| The Sympathizer | Knight | Tactical specialist; human-military hardware | EMP-Spliced Vitae |
| The Ancient | Unknown | Cryptic relic; lore-heavy insight | Coagulated Wraith |

### 2. Arsenal & Economy

Full cost tables and loot pools: `Weapons_and_Economy.md` (source of truth).

- **Wallbuys:** 11 tiers of equipment, from *Scrap-Pistol* (Tier 1, Zone 1) through *Vanguard Cannon* (Tier 11, Zone 3). *Aegis-Breaker* is Tier 9 Bio-Tech on the Mag-Train Platform—not the endgame tier.
- **The 3D Fabricator:** A hackable, mobile terminal. Contains exclusive prints categorized into "Duds," "Workhorses," and "Wonder Weapons" (e.g., Singularity Projector).
- **Easter Egg Exclusive:** *The Acheron Spewer* is **not** in the Fabricator loot pool. It is obtained only via the Bio-Canister Synthesis wonder-weapon quest (`Chapter-1/puzzles/Narrative_Puzzles.md`).

### 3. Perk System: "Gene-Splicing Centrifuges"

| Perk | COD Analogue | Effect |
|---|---|---|
| Goliath Marrow | Juggernaut | Increases survivability from 3 hits to 5 |
| Synaptic Overdrive | Speed Cola | Accelerates reload and swap speeds |
| Necro-Pulse | Quick Revive | Rapid team revives or solo auto-revives |
| Crimson Chamber | Double Tap | Scales damage against armor |
| Vampiric Stride | Stamin-Up | Infinite tactical sprint |
