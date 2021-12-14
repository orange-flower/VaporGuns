# VaporGuns
**Overview:**

Vapor Guns is a vaporwave-themed bullet-hell arcade game. The game is available to play in single or multiplayer. Shoot down hand minions and hand bosses to gain points. Minions are worth 10 points, mini-boss parts are 50 points each, and the main boss body is 100 points. 

**Game Controls:**

Each player’s controls are the left set of controls which includes:
- Start button
- Joystick for movement
- Shoot key (can be held down for rapid shooting)
- Use Powerup key (will deploy powerup if there is one in the inventory)

**Code Goals:**

Main Menu - consists of two toggles that start off. Players can hit their start button to add their car. To start the game, it requires 2 button presses — either two player-1 start button presses or a player-1 and a player-2 button press. If 10 seconds pass before the second press happens, the mode select times out and is reset. 
![image](https://user-images.githubusercontent.com/73602536/145908509-506fa6c3-96a3-4fc3-9413-1bdf43849a8d.png)

Game Scene - the game loads in the correct number of players. Player controls consists of holding the shoot button to streamline a fixed shooting rate. The game is structured in stages. Each stage has x number of waves which increases every other stage. There are 5 different wave formation that are randomly picked and instantiated. After the waves are spawned in, the boss is instantiated. The boss consists of 6 mini boss parts. Players have to defeat all the mini bosses first before being able to damage to the main boss body. Once the boss is defeated, the script calls another stage and the core game loop is repeated.  

Players also only have 3 lives. The health script swaps out the sprite each time the player loses a life. The player also has a 3-second invincibility frame after getting hit. This gives players time for recovery and to get out of harms way. This prevents them from dying from 3 successive shots from the enemies. 

Player also have the opportunity to pick up powerups. The game is programmed to spawn a powerup between 10 to 60 seconds. There's a 70% chance that the powerup spawned is a bomb and a 30% chance that the powerup spawned is a shield. Bombs destroy enemies in the area it area of effect and shields protect players for 5 seconds. The toggle updates with the sprite of the powerup the player currently has in possession. They can only hold one powerup at a time so the mos recent powerup will override the last one they have.  

Scoring consists of 10 points per enemy, 50 points per mini boss, and 100 points per boss. Both single player and multiplayer only have 1 score. Single player mode has their own score and multiplayer mode's score is the combined effort of both players. The game does not even unless both players have died.

End Scene - The end screen will show the player(s) current score. There are two leaderboards. One for single player and one for multiplayer. The leaderboard stores up to 5 names and score per mode. If a new high score is made, the keyboard will be called and players can enter in their name or team name. The keyboard is a container of buttons with and outline component attached. Players move between keys using the player 1 joystick and enter the letter using the shoot button. There is a max 4-character count. The rest of the space is reserved for score. Players can hit the start button to continue back to the main menu. 

