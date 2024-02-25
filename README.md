# Basquare

### Requirements
Unity v2019.1 but now being developed in v2020.3.24f1
Currently building for PC Standalone. Plans to build for Android devices also.

### Quick Start

Start the scene. Your player square will move forward. Press up arrow or spacebar to jump (or climb if stuck).

Press Reset to start over. 

Collect coins to increase your score.

### Dev Overview
- BasilEye prefab is the player with Player.cs script.
- LevelStart contains the level's platforms and coin objects.
- Canvas has the HUD
  - Score text is linked into Player's inspector
  - Reset button triggers a reload of the scene
- There's an Event System.

### Next steps...

TBD

