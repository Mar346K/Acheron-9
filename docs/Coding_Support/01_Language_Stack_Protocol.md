# Language Stack Protocol

**Overview:** This project utilizes a polyglot architecture within Godot 4.6.3 (.NET Version). To maintain performance, security, and code readability, languages must remain strictly isolated by their domain. Do not mix GDScript and C# within the same feature node.

## 1. Domain Definitions

*   **GDScript (Node Glue & UI):**
    *   *Use Cases:* UI logic, menu navigation, HUD updates, animation trees, and lightweight node signaling.
    *   *Rationale:* Native to Godot, allowing for the fastest iteration of visual and front-end components.
*   **C# (Core Systems & AI):**
    *   *Use Cases:* The Director AI, player movement vector math, state machines, round progression scaling, and Scrap economy logic.
    *   *Rationale:* Strongly typed and significantly faster for heavy data processing, physics calculations, and complex logic loops.
*   **Rust / C++ (Networking & Headless Backend):**
    *   *Use Cases:* Headless WebSocket server, P2P matchmaking, and authority state management.
    *   *Rationale:* Maximum performance, memory safety, and zero-trust security infrastructure. Integrated into Godot via GDExtension.

## 2. strict Enforcement
*   **Never attach a GDScript to a child node if the parent node's core logic is driven by C# (and vice versa).** Keep the boundary clean. If a C# system needs to trigger a GDScript UI update, it must do so strictly via Godot Signals.
