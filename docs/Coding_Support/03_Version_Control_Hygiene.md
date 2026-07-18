# Version Control & Repo Hygiene

**Overview:** To maintain a clean Git history and prevent multi-platform merge conflicts, the repository relies on strict `.gitignore` rules. Godot and .NET generate local metadata and binaries that must never be pushed to the main branch.

## 1. Mandatory .gitignore Rules
The following directories and file types are strictly banned from version control commits:

*   `.godot/` (Contains imported assets, local editor state, and cached data).
*   `.mono/` / `.vs/` / `bin/` / `obj/` (.NET and Visual Studio/Rider build artifacts).
*   `*.translation` (Compiled translation binaries).
*   `export_presets.cfg` (Contains keystore passwords and sensitive export configurations).

## 2. Documentation Placement
*   The `docs/` folder (containing `TDD/` and `Coding_Support/`) must remain at the root of the repository, outside of any build pipelines. This allows Cursor and other AI agents to read the design bible without it being compiled into the game's final export payload.