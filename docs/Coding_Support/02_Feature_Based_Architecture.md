# Feature-Based File Architecture

**Overview:** The repository strictly follows Feature-Based Encapsulation. Assets, scripts, and scenes related to a specific entity must live in the same folder. Do not organize the `res://` directory by file type (e.g., no global `scripts/` or `scenes/` folders).

## The Directory Structure

*   `assets/`
    *   `audio/` (SFX, Music)
    *   `models/` (Raw `.blend` or `.glb` files)
    *   `textures/` (Materials, decals)
*   `core/` (Global Singletons and Autoloads)
    *   `GameManager.cs`
    *   `DirectorAI.cs`
    *   `NetworkManager.gd`
*   `entities/` (Playable and Non-Playable Characters)
    *   `player/` (`Player.tscn`, `PlayerController.cs`, `BloodArts.gd`)
    *   `enemies/`
        *   `scrap_walker/` (`ScrapWalker.tscn`, `ScrapWalkerAI.cs`)
        *   `hunter_killer/`
        *   `heavy_vanguard/`
*   `environments/` (Map chunks and levels)
    *   `chapter_1/`
        *   `zone_1_hub/`
        *   `zone_2_industrial/`
*   `systems/` (Standalone mechanics)
    *   `weapons/` (`WeaponBase.cs`, `RaycastGun.tscn`)
    *   `fabricator/`
*   `ui/` (Menus and HUD)
    *   `hud/`
    *   `main_menu/`