# MUI-project

Programmin project for Modern User Interfaces course. The task was to implement a classic Minesweeper game with mouse and keyboard controls, using the Unity game engine.

Contributors:

Maija Rikala (2406863)
- game logic
    - reveal all empty tiles (until a bomb is encountered), when player clicks on a tile
    - when a player wins or loses, the right UI panel is enabled
- UI functionality
    - connect buttons to their correct functions: Main Menu button loads the Main Menu scene etc.
- keyboard controls (arrow keys and WASD)
    - establish button navigation so pressing up (or any other diretion) takes the player to the next logical button (since the number of buttons in menus was limited, this was done manually with explicit navigation)
    - looping through a menu possible (pressing up, when highest button is selected, moves the selection to the lowest button etc.)
    - even if user clicks something (not necessarily a button, could be just background) with a mouse, the selection is not lost and they can continue with keyboard
    - when enabling and disabling UI panels (for example pause menu panel), the game keeps track of the selected UI element, so that player can continue using keyboard
    - when a button is selected, its colour changes to significantly darker or lighter, so that it is easy for the player to see
    - when a panel is enabled, the player cannot click buttons in the background
 - graphics
     - background images (similar theme and colour palette, but distinct enough for the user to not get confused)

Ruusu Aavikko (2508242)
- game logic
      - core minesweeper mechanics
- graphics
      - selecting and adding visual assests from Unity Asses Store
      - consistant visual style across the game
- UI layout and functionality
    - menu layouts (placement of elements and overall structure)
    - visual style for menus and UI
- audio
  - background music and sound effects
