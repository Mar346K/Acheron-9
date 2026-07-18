# Infrastructure & Systems: Launch, Menus, and Game Modes

**Overview:** This document outlines the pre-game player experience, defining the structural logic for menu navigation, game mode selection, client updates, and the overarching settings framework required for a polished Steam release.

---

## 1. Game Launch & Update System
*   **The Launch Sequence:** Upon execution via Steam, the game skips unskippable splash screens (a major frustration point for PC gamers). It transitions immediately from a dark screen into the diegetic Main Menu, loading the environmental background dynamically.
*   **Update Infrastructure (Steamworks):** The game will rely entirely on Steam's native delta-patching for updates, ensuring players only download modified byte-code rather than redownloading the entire game.
*   **Version Control:** The bottom-right corner of the Main Menu will permanently display the current semantic version (e.g., `v1.0.4-live`). 

---

## 2. Menu Navigation & Aesthetic
*   **Visual Style:** The UI will heavily utilize Godot 4's Control nodes to create a diegetic, industrial-sci-fi terminal aesthetic. Menus will feature clean, sans-serif fonts, subtle CRT-scanline shaders, and a dark grey/amber color palette.
*   **The Backdrop:** The Main Menu background is a live, real-time 3D scene (e.g., a static camera viewing the rain-slicked Decontamination Hub).
*   **Navigation Flow:**
    1.  **Play** (Expands to Mode Selection)
    2.  **Barracks** (Unlocks, Lore Logs, and Stats)
    3.  **Settings**
    4.  **Quit to Desktop**

---

## 3. Game Modes: Campaign vs. Endless
*   **Campaign Mode (The Extraction):**
    *   *Logic:* The story-driven, objective-based mode. 
    *   *Win Condition:* The Chapter ending sequence (The Magnetic Decoupling and Mag-Train escape) is fully active and achievable. 
    *   *Pacing:* Spawns are curated by the Director AI to allow brief breathing room for players to complete the Harmonic Frequency Hack and synthesize the Wonder Weapon.
*   **Endless Mode (The Siege):**
    *   *Logic:* Pure, arcade survival. The Mag-Train is completely deactivated and the exit is sealed.
    *   *Win Condition:* None. The goal is to survive as many rounds as possible for the global Steam Leaderboards.
    *   *Pacing:* The Director AI rapidly scales enemy health, armor, and spawn density. Narrative audio logs and objective prompts are disabled to focus purely on combat.

---

## 4. Multiplayer Integration (Solo vs. Squad)
*   **Solo Play:** Runs entirely on a local server instance. Pausing the game freezes all logic and AI tracking.
*   **Squad Play (Co-Op):** 
    *   *Networking:* To maintain low latency and secure connections, matchmaking and social presence are driven by a headless WebSocket backend.
    *   *Friend Requesting:* Integrated directly with the Steam Overlay (Shift+Tab). Players can invite friends from their Steam list directly into the in-game lobby via Steamworks P2P networking.
    *   *Drop-in/Drop-out:* If a player disconnects during a match, their character model enters a "stasis" state, allowing them a 3-minute window to reconnect via the WebSocket server before their Scrap is distributed to the team.

---

## 5. Global Settings Architecture
*   **Video:**
    *   *Display:* Fullscreen, Borderless Windowed, Windowed.
    *   *Resolution & Scaling:* Native resolution support. When defining the baseline performance profiles, optimization targets smooth 60fps execution on mid-to-high-tier GPUs (like an Intel Arc A770 or RTX 3060) before scaling up for enthusiast hardware.
    *   *Advanced:* FOV Slider (75-110), VSync, Anti-Aliasing, Texture Quality, Shadow Resolution, and a toggle for the CRT Menu Shader.
*   **Audio:**
    *   Independent volume sliders for: Master, SFX (weapons/enemies), Dialogue (character banter/lore logs), and Music.
    *   *Dynamic Range:* Option for "Night Mode" (compresses loud explosions and raises quiet footsteps).
*   **Input & Controls:**
    *   Full key-rebinding for Mouse & Keyboard.
    *   Gamepad layout selection with adjustable stick deadzones and aim-assist toggles (snap-to-target vs. friction slowdown).
    *   Sprint/ADS behavior toggles (Hold vs. Press).