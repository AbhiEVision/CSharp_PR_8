using CSharp_PR_8.StandardMessages;
using LibraryManagement;
using LibraryManagement.Interface;
namespace CSharp_PR_8.Pages
{
    public static class UserPage
	{
		// General page of user like login and logoutpage
		public static void LibraryUser()
		{
			bool runUntill = true;
			IUser user = null;
			ILibrarian librarian = new Librarian("Test", "Temp", "Test@123");
			Console.Clear();
			while (runUntill)
			{
				int choice = 0;

				StandardMessagesForUser.PrintStartUpMessage();
				ConsoleColorChange.MakeColorGreen();
				Printer.PrintInSameLine("Option : ");
				ConsoleColorChange.MakeColorBlue();
				try
				{
					choice = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
					choice = 0;
				}
				switch (choice)
				{
					case 1:
						user = LogInPage();
						HomePageViewOfUser(user, librarian);
						break;
					case 2:
						user = SignUpPage();
						DataBaseAPI.AddUser(user);
						HomePageViewOfUser(user, librarian);
						break;
					case 3:
						runUntill = false;
						break;
					default:
						//Console.Clear();
						StandardMessageForGeneral.PrintInvalidInput();
						break;
				}
			}
			Console.Clear() ;
		}
		
		// Home page of user after login or signup
		public static void HomePageViewOfUser(IUser user, ILibrarian librarian)
		{
			bool runUntil = true;
			while (runUntil)
			{
				int choice = 0;
				StandardMessagesForUser.PrintHomePageWelcomeMessage(user.Name);
				Printer.SkipLine();
				try
				{
					Printer.PrintInSameLine("Option : ");
					choice = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception e)
				{
					choice = 0;
				}
				Printer.SkipLine();
				switch (choice)
				{
					case 1:
						BorrowABookToUser(user);
						break;
					case 2:
						ReturnBookToLibFromUser(user);
						break;
					case 3:
						ListOutTotalBooksAvailable();
						break;
					case 4:
						ListOutTotalBooks();
						break;
					case 5:
						PrintBorrowedBooksByUser(user);
						break;
					case 6:
						ChangePasswordOfUser(user);
						break;
					case 7:
						Console.Clear();
						break;
					case 8:
						runUntil = false;
						Console.Clear();
						break;
					default:
						StandardMessageForGeneral.PrintInvalidInput();
						break;

				}
			}
		}

		
		
		#region ( Local user functions )

		private static void BorrowABookToUser(IUser user)
		{
			string id;

			ListOutTotalBooksAvailable();
			if (DataBaseAPI.ListOfAvailableBooks().Count > 0)
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Which book do you want to borrow?");
				id = Input.TakeBookID();
				bool temp = DataBaseAPI.IssueBookToUser(user, id);
				if (temp)
				{
					ConsoleColorChange.MakeColorGreen();
					Printer.SkipLine();
					Printer.Print("Book Borrowed Successfully!");
					Printer.SkipLine();
				}
				else
				{
					Printer.SkipLine();
					Printer.PrintError("Sorry, entered book id is owned by someone else or book id doesn't exists!");
					Printer.SkipLine();
				}
			}
		}

		private static void ChangePasswordOfUser(IUser user)
		{
			string _oldPasseord, _newPassword;

			_oldPasseord = Input.TakeOldPassword();
			_newPassword = Input.TakeNewPassword();

			bool temp = DataBaseAPI.ChangePassword(user, _oldPasseord, _newPassword);

			if (temp)
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.SkipLine();
				Printer.Print("Password Change Successfully!");
				Printer.SkipLine();
			}
			else
			{
				Printer.SkipLine();
				Printer.PrintError("Please, enter old password correct!");
				Printer.SkipLine();
			}
		}

		private static void ListOutTotalBooks()
		{
			List<IBook> books = DataBaseAPI.ListOfTotalBooks();

			if (books.Count > 0)
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Total Books :");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				foreach (IBook book in books)
				{
					Printer.Print($" Book ID : {book.Id} \t Book Title : {book.Title} \t Book Author : {book.Author} \t Book Pages : {book.Pages}");
				}
			}
			else
			{
				Printer.PrintError("Library is empty!");
			}
			Printer.SkipLine();
			Console.ResetColor();
		}

		
		private static void ListOutTotalBooksAvailable()
		{
			List<IBook> books = DataBaseAPI.ListOfAvailableBooks();

			if (books.Count > 0)
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Total Available Books is :");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				foreach (IBook book in books)
				{
					Printer.Print($" Book ID : {book.Id} \t Book Title : {book.Title} \t Book Author : {book.Author} \t Book Pages : {book.Pages}");
				}
			}
			else
			{
				Printer.PrintError("All books are taken! Please, come back again!");
			}
			Printer.SkipLine();
			Console.ResetColor();
		}

		private static void PrintBorrowedBooksByUser(IUser user)
		{
			List<IBook> books = user.GiveMeListOfBook();


			if (books.Count > 0)
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Borrowed books by you :");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				foreach (IBook book in books)
				{
					Printer.Print($" Book ID : {book.Id} \t Book Title : {book.Title} \t Book Author : {book.Author} \t Book Pages : {book.Pages}");
				}
			}
			else
			{
				Printer.PrintError("sorry, you do not have any borrowed books!");
			}
			Printer.SkipLine();
			Console.ResetColor();
		}

		private static void ReturnBookToLibFromUser(IUser user)
		{
			string id;

			PrintBorrowedBooksByUser(user);
			if (user.GiveMeListOfBook().Count > 0)
			{
				id = Input.TakeBookID();
				bool test = DataBaseAPI.ReturnBookToLib(user, id);
				if (test)
				{
					ConsoleColorChange.MakeColorGreen();
					Printer.SkipLine();
					Printer.Print("Book Returned successfully!");
					Printer.SkipLine();
				}
				else
				{
					Printer.SkipLine();
					Printer.PrintError("Entered book id is wrong or book owned by other user!");
				}
			}

		}
		
		#endregion

		#region ( Local login and signup functions) 

		// creating a new user
		private static IUser SignUpPage()
		{
			string _id;
			string _username;
			string _password;

			StandardMessagesForUser.PrintWelcomeMessageOnSignUpPage();

			_id = Input.TakeID();
			_username = Input.TakeName();
			_password = Input.TakePassword();

			Console.Clear();
			return new User(_id, _username, _password);
		}
		
		// validating user if exists than return user
		private static IUser LogInPage()
		{
			string _id;
			string _password;

			StandardMessagesForUser.PrintWelcomeMessageOnLogInPage();

			_id = Input.TakeID();
			_password = Input.TakePassword();

			while (!DataBaseAPI.ValidateUser(_id, _password))
			{
				// Console.Clear();
				Printer.SkipLine();
				Printer.PrintError("Invalid Credentials");
				_id = Input.TakeID();
				_password = Input.TakePassword();
			}

			Console.Clear();
			return DataBaseAPI.GiveUserByID(_id);
		}

		#endregion
	}
}