using System;

/* 
* Tic Tac Toe game
* 
* Class: Grid
* Basic Structure of the board. Create, update, and show board.
* Also checks for win and tie situations.
* 
* Author: Lara M.
*/

namespace tictactoe{ 
	public class Grid{

		//Define Variables
		private static Grid grid = new Grid();
		private String[,] houses;
		private int n = 0;

		//Constructor
		private Grid() {}

		//Get instance. Required for Singleton
		public static Grid get_instance(){
			return grid;
		}

		//Initialize board
		public void init_board(){
			while (this.n < 2){
				IO.println("What size of grid would you like to play with? (nxn)");
				this.n = IO.read_int();
				if(this.n<2 || this.n>10) IO.println("Given number cannot make a grid.");
			}
			houses = new String[n,n];
			for(int i=0; i<n; i++){
				for(int j=0; j<n; j++){
					houses[i,j]=" ";
				}
			}
			//IO.println("n = "+n);
			//IO.println("length : "+ houses.Length);
			show_board();
		}

		//Show updated board
		public void show_board(){
			for(int i=0; i<this.n; i++){
				IO.print_string(" ");
				for(int j=0; j<this.n; j++){
					IO.print_string(this.houses[i,j]);
						if (j<n-1) IO.print_string(" | ");
				}
				IO.println();
				if (i!=this.n-1){
					for(int j=0; j<this.n; j++){
						IO.print_string("––––");
					}
				}
				IO.println();
			}
		}

		//Mark a house in the grid with X or O
		public bool set_house(int i, int j, String sign){
			//Check if the house is in the Grid
			if (i>n || j>n){
				IO.println("Out Of Boundary.");
				return false;
			}
			// Set house mark
			else if (houses[i-1,j-1] == " ") {
				houses[i-1,j-1] = sign;
				return true;
			}
			// The house is not empty
			else{
				IO.println("The spot is not empty.");
				return false;
			}
		}

		//Check for tie
		public bool empty_house_available(){
			for(int i=0; i<n; i++){
				for(int j=0; j<n; j++){
					if (houses[i,j]==" ")
					return true;
				}
			}
			return false;
		}

		//Check for win
		public bool check_win(){
			for(int i=0; i<n; i++){
				for(int j=0; j<n-2; j++){
					if (houses[i,j] == houses[i,j+1] 
						&& houses[i,j+1] == houses[i,j+2]
						&& houses[i,j+1]!= " ")
						return true;
				}
			}
			
			for(int i=0; i<n-2; i++){
				for(int j=0; j<n; j++){
					if (houses[i,j] == houses[i+1,j] 
						&& houses[i+1,j] == houses[i+2,j]
						&& houses[i+1,j] != " ")
					return true;
				}
			}
			//similar logic can be applied to diagonal, etc.

			return false;
		}
	}
}

