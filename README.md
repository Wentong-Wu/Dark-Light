# Dark-Light

A platform game where the goal is simply to kill all enemy and find the exits. Inspired by Pokemon Generation 3 - Browly gym.

Here are the links to all the asset used:

- https://edermunizz.itch.io/free-pixel-art-forest
- https://cactusturtle.itch.io/green-slime
- https://rvros.itch.io/animated-pixel-hero
- https://maaot.itch.io/mossy-cavern

## Player Controller

- Player movements and animations is created in this class
- Using linecast to check if the player is on the ground which can flip the boolean to determine if the player can jump or not.

## Player Combat

- Player combat and the gimmick of showing the player more surroundings when enemy is killed.
- Using Universal Light2D it is possible to modify the lighting of the game.

## Player Collision

- Player death and resetting the game.
- Using OnCollisionEnter2D it is possible to check what object it has collided.
- The game will reset by reloading the same game scene.

## Patrol and Enemy

- Patrol is basically the enemy.
- A object which moves from each end of the platform by using Raycast
- If the object reaches to the other side of the platform they are standing in then it will flip the movement.
- In the enemy class, the only purpose is to allow the script from the player collision class to delete the object using Destroy method.

## Main Menu

- This is a script for the menu to check if the player quits or move on to the next level.

## Door

- Checks to see if all enemy is defeated before allowing the user to proceed to the next level

