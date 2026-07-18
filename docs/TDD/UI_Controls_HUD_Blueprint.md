# Chapter 1: UI, Controls, and Player HUD Blueprint

**Overview:** This document defines the standardized input mapping, camera perspective, and diegetic Heads Up Display (HUD) required to ensure a frictionless, high-mobility player experience that meets Steam PC standards.

---

## 1. Camera & Perspective
*   **Perspective:** True First-Person.
*   **Base Field of View (FOV):** 90 degrees (Default).
*   **Accessibility Standard:** An FOV slider (75 to 110) is mandatory in settings to prevent motion sickness during high-speed slides and wall-kicks.
*   **Camera Shake:** Minimal. Use heavy bobbing during standard sprinting to emphasize physical weight, but disable camera shake entirely during the Momentum Slide for precise targeting.

---

## 2. Standardized Input Mapping
*   **Move:** W, A, S, D (M&K) / Left Stick (Gamepad)
*   **Look:** Mouse (M&K) / Right Stick (Gamepad)
*   **Sprint:** Left Shift (M&K) / Left Stick Click / L3 (Gamepad)
    *   *Note:* Base movement is "Sprint." **Vampiric Stride** is the Gene-Splicer perk name only (infinite tactical sprint).
*   **Crouch / Momentum Slide:** C or Left Ctrl (M&K) / B or Circle (Gamepad)
*   **Jump / Vault-Boost:** Spacebar (M&K) / A or Cross (Gamepad)
*   **Interact / Buy:** F or E (M&K) / X or Square (Gamepad) - Hold to spend Scrap.
*   **Fire:** Left Click (M&K) / Right Trigger / R2 (Gamepad)
*   **Aim Down Sights (ADS):** Right Click (M&K) / Left Trigger / L2 (Gamepad)
*   **Reload:** R (M&K) / X or Square (Gamepad)
*   **Switch Weapon:** 1, 2, or Mouse Wheel (M&K) / Y or Triangle (Gamepad)
*   **Melee / Rupture:** V or Mouse 4 (M&K) / Right Stick Click / R3 (Gamepad)
*   **Trigger Blood Art:** Q or Mouse 5 (M&K) / Left Bumper / L1 (Gamepad)

---

## 3. The Player HUD (Heads Up Display)
*   **Top Left (The Director’s Counter):** A clean, glowing amber numerical tally for the current Wave. Features a subtle directional edge-glow warning for machine proximity (no minimap).
*   **Bottom Left (The Biological State):** Segmented shield/armor visual representing "Hits to Down" (standard 3). A crimson fluid gauge beneath it represents the Vitae Meter, which fills via close-quarters kills to power Blood Arts.
*   **Bottom Right (The Arsenal Economy):** Weapon name, current magazine, and reserve ammo in a sans-serif industrial font. The Scrap Counter is displayed prominently above it, with floating "+10" dissolve animations upon earning.
*   **Center (The Interaction Crosshair):** A dynamic reticle that expands based on weapon spread and movement. Contextual interaction prompts (e.g., "[Hold F] Clear Debris - 750 Scrap") anchor directly beneath it.
*   **Left Edge (Squad Roster - Co-op):** Minimalist vertical list showing teammate names, character portraits, health state, and total Scrap.

---

## 4. Steam & PC Accessibility Standards
*   **Input Remapping:** Every action in the input map must be fully remappable in the settings menu.
*   **Toggle vs. Hold:** Options must exist for Sprint and Aim Down Sights to be toggle-based or hold-based.
*   **Subtitles:** Mandatory for lore drops (Schism Transmissions) and cryptic voice lines. Positioned bottom-center with the speaker's name clearly identified.