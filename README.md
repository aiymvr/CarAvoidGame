# Car Avoid Game

A simple 2D arcade-style game built with **C# and Windows Forms** where you control a car, dodge falling obstacles, and rack up points for as long as you can survive.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple)
![Platform](https://img.shields.io/badge/platform-Windows-blue)

## Gameplay

- Steer your car left and right across the road to avoid oncoming obstacles falling from the top of the screen.
- Every obstacle you dodge adds to your score, and points also tick up automatically the longer you survive.
- Colliding with an obstacle costs you health. Lose all your health and it's game over.
- The game gets progressively harder over time — obstacles spawn more frequently as your score climbs.

### Controls

| Action      | Input                          |
|-------------|---------------------------------|
| Move left   | `←` Left Arrow key, or **Left** button |
| Move right  | `→` Right Arrow key, or **Right** button |
| Start / Restart | **Start** button |

## How It Works

- **Game loop**: A `Timer` ticks every 40ms (~25 FPS), updating obstacle positions, checking collisions, and repainting the game area.
- **Difficulty scaling**: Every 200 points, the interval between obstacle spawns decreases (down to a minimum), making the game faster and harder.
- **Scoring**: 1 point per game tick, plus a bonus for every obstacle successfully avoided.
- **Health**: Starts at 100 and drops by 25 on each collision; the game ends at 0.

## Project Structure

```
CarAvoidGame/
├── CarAvoidGame.sln              # Visual Studio solution
└── CarAvoidGame/
    ├── Program.cs                 # Application entry point
    ├── MainForm.cs                # Form logic: input, rendering, game loop wiring
    ├── MainForm.Designer.cs       # UI layout (buttons, panel, progress bar, timer)
    ├── Domain/
    │   ├── GameEngine.cs          # Core game state and update logic
    │   ├── GameObject.cs          # Base class for positioned/bounded game entities
    │   ├── Car.cs                 # Player car: movement and boundary clamping
    │   ├── Obstacle.cs            # Falling obstacle: position and fall speed
    │   └── GameConstants.cs       # Tunable game parameters (speeds, sizes, scoring)
    └── Images/
        ├── road.png               # Background
        ├── car.png                # Player car sprite
        └── cone.png               # Obstacle sprite
```

The project follows a simple separation of concerns:
- **`Domain/`** contains pure game logic (no UI dependencies) — the game engine, car, and obstacles.
- **`MainForm`** handles rendering, keyboard/button input, and wiring the game loop to the UI.

## Requirements

- Windows OS
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) (or later, backward-compatible)
- Visual Studio 2019/2022 (or any IDE/toolchain that supports .NET Framework WinForms projects)

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/aiymvr/CarAvoidGame.git
   ```
2. Open `CarAvoidGame.sln` in Visual Studio.
3. Build and run the project (`F5` or `Ctrl+F5`).
4. Click **Start** in the game window to begin playing.

## Customization

All key gameplay parameters live in [`GameConstants.cs`](CarAvoidGame/Domain/GameConstants.cs), including:

- Car/obstacle dimensions and speed
- Obstacle spawn rate and difficulty ramp-up
- Scoring values

Tweak these values to make the game easier, harder, or faster-paced.

## License

No license file is currently included in this repository. Add one (e.g., MIT) if you intend for others to reuse this code.
