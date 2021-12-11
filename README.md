# VaporGuns
**Overview:**

Vapor Guns is a vaporwave-themed bullet-hell arcade game. The game is available to play in single or multiplayer. Shoot down hand minions and hand bosses to gain points. Minions are worth 10 points, mini-boss parts are 50 points each, and the main boss body is 100 points. 

**Game Controls:**

Each player’s controls are the left set of controls which includes:
Start button
Joystick for movement
Shoot key (can be held down for rapid shooting)
Use Powerup key (will deploy powerup if there is one in the inventory)

**Code Goals:**

Main Menu - consists of two toggles that start off. Players can hit their start button to add their car. To start the game, it requires 2 button presses — either two player-1 start button presses or a player-1 and a player-2 button press. If 10 seconds pass before the second press happens, the mode select times out and is reset. 

Game Scene - the game loads in the correct number of players. Player controls consists of holding the shoot button to streamline a fixed shooting rate. The game is structured in stages. Each stage has x number of waves which increases every other stage. There are 5 different wave formation that are randomly picked and instantiated. After the waves are spawned in, the boss is instantiated. The boss consists of 6 mini boss parts. Players have to defeat all the mini bosses first before being able to damage to the main boss body. Once the boss is defeated, the script calls another stage and the core game loop is repeated.  

Players also only have 3 lives. The health script swaps out the sprite each time the player loses a life. The player also has a 3-second invincibility frame after getting hit. This gives players time to recovery and get out of harms way. This prevents them from dying from 3 successive shots from the enemies. 

End Scene - 

