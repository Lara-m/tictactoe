using System;

/* 
* Tic Tac Toe game
* 
* Class: tictactoe
* Contains the main method. Starting point of the game.
* Required arguments: None
* 
* Author: Lara M.
*/

namespace tictactoe{ 
	public class tictactoe
	{
		//Define Variables
		public static bool win = false;
		public static Player turn;

		//main method
		static public void Main (){
			IO.println("Welcome to Lara's tictactoe game!");
			Grid grid = Grid.get_instance();
			//Intialize board for a new game
			grid.init_board();
			//Set Players
			Player x = new Player("X");
			Player o = new Player("O");
			//For a Null reference had to first set turn to something
			turn = o;
			//Give turns to players and let them play
			while(!win && Grid.get_instance().empty_house_available()){
				turn = (turn.Sign == o.Sign) ? x : o ;
				win = turn.make_move();
			}
			//If the game is over, check if it's tied or a win.
			if(!win && !Grid.get_instance().empty_house_available())
				IO.println("Tied." );
			else
				IO.println("Player "+turn.Sign+" has won." );
		}
	}
}