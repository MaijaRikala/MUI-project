# MUI-project

This repository contains the programmin project for Modern User Interfaces course. The task was to implement a classic Minesweeper game with mouse and keyboard controls, using the Unity game engine.


## Introduction 

This project contains the implementation of the project exercise on the Modern User Interfaces –course. We chose a classical Minesweeper game as the topic of this exercise. 

We implemented the game logic of Minesweeper (except for marking mines with flags) in Unity and added menus for navigation. The project includes main and options menu, when the program is started, and pause, victory and lose menus, when playing. In options menu the player can adjust audio levels for music and sound effects. In game mode a 10x10 tile board is initialised with 10 mines placed randomly on the board. 

## Implementation 

Options, pause, victory and lose menus are panels that appear in front of other UI elements, so background is toned down with grey tone for clarity. 

Each tile in the game mode board is a button a player can reveal by clicking. When all tiles without a mine have been revealed, the player wins. Once a tile has been revealed, the player cannot click it anymore, and the button is disabled. 

All menus and the game board can be navigated with either mouse or keyboard (WASD or arrow keys and enter for selecting, ESC for pause menu). Even if player clicks somewhere (not even necessarily a navigation element) with a mouse, the program remembers the last selection and player can continue navigation with keyboard. Similarly, the selection is not lost, when a menu panel pops up or is disabled, and the player cannot click “behind” the panel. 

We made keyboard navigation as intuitive as possible (for example clicking down takes the selection to the button below) and enabled looping through menus (going from top straight to bottom and vice versa). However, since the game board is randomly generated, and the player can click on tiles in any order, we couldn’t implement pre-defined explicit navigation. Instead, the game does its best to guess the next button or tile the player wants to move into, when they press an arrow or WASD key. 

## User Interface and User Experience 

The UI in game mode includes a timer, showing how long the current run has taken, the number of mines on the board (next to a bomb icon) and buttons for restarting the run and opening the pause menu. While pause menu is open, the game (timer) is paused. The restart-button is a circular arrow that is typically used in similar functions, so it is familiar to the player. The menu icon is a hamburger menu, which should also be familiar to the player. 

All buttons on the board and on each menu are placed evenly and with enough space between to keep them distinct. Each button is also big enough so that clicking them should not be a problem. On top of the game board the buttons are a little bit smaller, but not very small, so this should not be an issue. 

From main menu the player can go to game mode by pressing Play-button. From game mode the player can return to main menu by pressing the pause menu –button or ESC key and pressing the Main Menu –button. From there the player can quit the game, by clicking Quit. Thus, mouse is not needed to stop the game. In game mode the player can restart the game by pressing the restart-button in the top panel or enabling pause menu and clicking the Restart-button. Since there are only a small number of menus, the program and its navigation is efficient. 

Overall game graphics were kept consistent with a blue colour theme and simple icons, and the overall aesthetics are visually pleasing. We added contrast to clicked/unclicked tiles and selected/not selected buttons, so that they are easy to distinguish. There is also a background music to create a relaxed and positive atmosphere. 

We also added audio to aid the player. When the player clicks on a tile, a sound is played sort of as a confirmation of the action. If the player clicks on a tile with a mine, a different sound is played, which informs the player they failed (in addition to the lose menu text). If the player wins, a victory sound is played.

## Contributors:

MaijaRikala
- game logic
    - reveal empty tiles (until a mine is encountered), when player clicks on a tile
    - enable correct panel on win and game over
- UI functionality
    - connect buttons to their correct functions
- keyboard controls
    - establish button navigation
    - retain selection, even if user clicks something with a mouse
    - keep track of the selected UI element, when enabling and disabling UI panels
    - when a panel is enabled, prevent clicking buttons in the background
 - graphics
     - background images

Rosel1a
- game logic
    - rest of the core minesweeper mechanics (initialise board, show number of mines in adjacent tiles etc.)
- graphics
    - selecting and adding visual assests from Unity Asses Store
    - consistent, appealing and clear visual style across the game
- UI layout and functionality
    - menu layouts (placement of elements and overall structure)
    - visual style for menus and UI
    - connect buttons to their correct functions (and create the functions)
- audio
  - background music and sound effects
