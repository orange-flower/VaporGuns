# VaporGuns
**Overview:**

Vapor Guns is a vaporwave-themed bullet-hell arcade game. The game is available to play in single or multiplayer. Shoot down hand minions and hand bosses to gain points. Minions are worth 10 points, mini-boss parts are 50 points each, and the main boss body is 100 points. Watch the game trailer here: https://youtu.be/SNrxMlV1Llk 

**Game Controls:**

Each player’s controls consists of a set which includes:
- Start button
- Joystick for movement
- Shoot key (can be held down for rapid shooting)
- Use Powerup key (will deploy powerup if there is one in the inventory)

With player 1 being on the left and player 2 on the right. 

**Code Goals:**

Main Menu - consists of two toggles that start off. Players can hit their start button to add their car. To start the game, it requires 2 button presses — either two player-1 start button presses or a player-1 and a player-2 button press. If 10 seconds pass before the second press happens, the mode select times out and is reset. 

![image](https://user-images.githubusercontent.com/73602536/145908509-506fa6c3-96a3-4fc3-9413-1bdf43849a8d.png) ![image](https://user-images.githubusercontent.com/73602536/145908718-574d71ef-4aed-45e9-bc59-254bf5fa0938.png) ![image](https://user-images.githubusercontent.com/73602536/145909029-3e102f65-57ec-4d64-ab98-727f1ba9c0b6.png)

Game Scene - the game loads in the correct number of players. Player controls consists of holding the shoot button to streamline a fixed shooting rate. The game is structured in stages. Each stage has x number of waves which increases every other stage. There are 5 different wave formation that are randomly picked and instantiated. After the waves are spawned in, the boss is instantiated. The boss consists of 6 mini boss parts. Players have to defeat all the mini bosses first before being able to damage to the main boss body. Once the boss is defeated, the script calls another stage and the core game loop is repeated. 

![image](https://user-images.githubusercontent.com/73602536/145909475-abf96f23-ac68-4f76-ba4d-6782112cebb2.png) ![image](https://user-images.githubusercontent.com/73602536/145909494-222f14cd-eaf3-4c98-88a5-4243f6f12078.png) ![image](https://user-images.githubusercontent.com/73602536/145910543-bcc604b3-1ec6-4a88-add0-8f9aae387538.png)


Players also only have 3 lives. The health script swaps out the sprite each time the player loses a life. The player also has a 3-second invincibility frame after getting hit. This gives players time for recovery and to get out of harms way. This prevents them from dying from 3 successive shots from the enemies. 

![image](https://user-images.githubusercontent.com/73602536/145911488-aa4025d1-a0eb-4691-a15f-43a00ecf22e4.png) ![image](https://user-images.githubusercontent.com/73602536/145911698-4cc2c581-930c-4fea-9a85-73cca2c41214.png)


Player also have the opportunity to pick up powerups. The game is programmed to spawn a powerup between 10 to 60 seconds. There's a 70% chance that the powerup spawned is a bomb and a 30% chance that the powerup spawned is a shield. Bombs destroy enemies in the area it area of effect and shields protect players for 5 seconds. The toggle updates with the sprite of the powerup the player currently has in possession. They can only hold one powerup at a time so the most recent powerup will override the last one they have.  

![image](https://user-images.githubusercontent.com/73602536/145910053-9bcb11dc-f733-4bb6-86a8-0fcf38792f0e.png) ![image](https://user-images.githubusercontent.com/73602536/145910884-a1ba0b41-463b-4bf2-a61a-870628fd527e.png)

Scoring consists of 10 points per enemy, 50 points per mini boss, and 100 points per boss. Both single player and multiplayer only have 1 score. Single player mode has their own score and multiplayer mode's score is the combined effort of both players. The game does not even unless both players have died.

End Scene - The end screen will show the player(s) current score. There are two leaderboards. One for single player and one for multiplayer. The leaderboard stores up to 5 names and score per mode. If a new high score is made, the keyboard will be called and players can enter in their name or team name. The keyboard is a container of buttons with and outline component attached. Players move between keys using the player 1 joystick and enter the letter using the shoot button. There is a max 4-character count. The rest of the space is reserved for score. Players can hit the start button to continue back to the main menu. 

![image](https://user-images.githubusercontent.com/73602536/145909300-6540535f-aada-49a4-b2a0-e0c25c9699b1.png) ![image](https://user-images.githubusercontent.com/73602536/145911257-3d61436a-fa80-4ed3-8902-30ee5f54cdf6.png)


