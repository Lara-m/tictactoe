using System;

/* 
* Tic Tac Toe game
* 
* Class: IO
* Communicates input and output.
* 
* Author: Lara M.
*/

namespace tictactoe{ 
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
}

