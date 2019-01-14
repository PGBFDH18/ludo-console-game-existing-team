# User stories

PLAYER

## As a user I would like to have a representation of me as a player in the game so I could play the game with it.

* A player should have a color.
* A player should be represented by four pieces.

BOARD

## As a user I would like to have a board on which the game can be played and which would work as a visual representation of current game scores.

* There should be a certain number of steps for pieces on the board.
* Each piece should have its position checked after each move.
* Each piece’s position should be checked after each move so that it is known how many steps the piece has until goal. 
* If the player has any pieces on board the player should be asked which pieces player would like to move using the results from dice. 

DICE

## As a user I would like to have a dice so it could determine my score.

* The dice should create a random number each time it is used. 
* The number should be displayed for the player.

RULES

## As a player I would like to have rules for the game that would make game flow interesting and that would resolve potential problematic situations. 

* The number of players should be limited in the range two to four.
* A player should be able to move a piece onto the board after the player gets a result 6 from the dice. 
* After each throw of the dice the input from user must be checked and validated as certain restrictions apply for the ability to move pieces in different positions (for example, for the pieces that are not in the game / on board yet).
* If a piece reaches the step that is already occupied by other player’s piece, that other piece should be knocked out of its position onto step one.
* If the piece reaches the position in the range of 6 steps before the goal, it can be moved into the goal only if the player gets the result from dice that matches the exact number of steps to goal, otherwise the player skips a move.

WIN

## As a user I would like to have conditions which would allow me to win the game.

* After each move the positions of all the pieces of all the players should be checked so that in case if there is a player who has all four pieces in goal is declared as a winner.
* If one of the players was declared as winner, the game must be stopped and players must be notified that the game is over. 

