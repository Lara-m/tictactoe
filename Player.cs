using System;

/* 
* Tic Tac Toe game
* 
* Class: Player
* Represents a player and makes move using the board/grid
* 
* Author: Lara M.
*/

namespace tictactoe{ 
	public class Player{
		// Keeper of a player's sign.
		public String Sign{get; set;}

		//Constructor
		public Player(String s){
			this.Sign = s;
		}

		// Communicate with player and the board/grid to make a move.
		// Check for the end of the game and invalid moves.
		public bool make_move(){
			IO.println("Player "+Sign+", it's your turn.");
			IO.println("Enter row and column of the house you want to mark!");
			IO.print_string("Row: ");
			int row = IO.read_int();
			IO.print_string("Column: ");
			int column = IO.read_int();
			// Check if the move is possible
			if (Grid.get_instance().set_house(row, column, this.Sign)){
				// Show updated board
				Grid.get_instance().show_board();
				// Check for win situation
				return Grid.get_instance().check_win();
			}
			else{
				IO.println("That was not the best you could do. Try again!");
				// Let player redo a move.
				return make_move();
			}
		}
	}
}

