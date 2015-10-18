class Board(object):
	_instance = None
	n = 0;

	def __new__(cls, *arg):
		if cls._instance is None:
			_instance =
			while n==0:
				val = input("Enter the size of board (nxn) you want to play: ")	
				init_board(val)
		return cls._instance

	def init_board(self,arg):
		try:
		   self.n = int(arg)
		   return True
		except ValueError:
		   print("That's not an int!")
		   return False


def main():
	#print "Welcome to Lara's Tic Tac Toe!"
	#print "Let's play a game."
	board = Board(4)
	return


if __name__ == '__main__':
	main()

