using System;
 
public class tictactoe
{
	public static bool win = false;
	public static Player turn;
	static public void Main (){
		IO.println("Welcome to Lara's tictactoe game!");
		Grid grid = Grid.get_instance();
		grid.init_board();
		Player x = new Player("X");
		Player o = new Player("O");
		turn = o;
		while(!win && Grid.get_instance().empty_house_available()){
			turn = (turn.Sign == o.Sign) ? x : o ;
			win = turn.make_move();
		}
		if(!win && !Grid.get_instance().empty_house_available())
			IO.println("Tied." );
		else
			IO.println("Player "+turn.Sign+" has won." );
	}
}


public class Grid{
	private static Grid grid = new Grid();
	private String[,] houses;
	private int n = 0;

	private Grid() {}

	public static Grid get_instance(){
		return grid;
	}

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
		IO.println("length : "+ houses.Length);
		show_board();
	}

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

	public bool set_house(int i, int j, String sign){
		//mark a house
		if (i>n || j>n){
			IO.println("Out Of Boundary.");
			return false;
		}
		else if (houses[i-1,j-1] == " ") {
			houses[i-1,j-1] = sign;
			return true;
		}
		else{
			IO.println("The spot is not empty.");
			return false;
		}
	}

	public bool empty_house_available(){
		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				if (houses[i,j]==" ")
				return true;
			}
		}
		return false;
	}

	public bool check_win(){
		//set winner
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


public class Player{
	public String Sign{get; set;}

	public Player(String s){
		this.Sign = s;
	}

	public bool make_move(){
		IO.println("Player "+Sign+", it's your turn.");
		IO.println("Enter row and column of the house you want to mark!");
		IO.print_string("Row: ");
		int row = IO.read_int();
		IO.print_string("Column: ");
		int column = IO.read_int();
		if (Grid.get_instance().set_house(row, column, this.Sign)){
			Grid.get_instance().show_board();
			return Grid.get_instance().check_win();
		}
		else{
			IO.println("That was not the best you could do. Try again!");
			return make_move();
		}
	}
}


public static class IO{
	public static void println(String s){
		Console.WriteLine(s);
	}
	public static void println(){
		Console.WriteLine();
	}
	public static void print_string(String s){
		Console.Write(s);
	}
	public static void print_char(Char c){
		Console.Write(c);
	}
	public static int read_int(){
		try{
			return Convert.ToInt32(Console.ReadLine());
		}
		catch(Exception e){
			IO.println("" + e + "Exception caught.");
			IO.println("Try again:");
			return read_int();
		}		
	}
	public static String read_String(){
		return Console.ReadLine();
	}
}


