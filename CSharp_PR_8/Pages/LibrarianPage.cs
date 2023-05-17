using CSharp_PR_8.StandardMessages;
using LibraryManagement;
using LibraryManagement.Interface;

namespace CSharp_PR_8.Pages
{
    public static class LibrarianPage
	{
		public static void LibraryLibrarian()
		{
			bool runUntil = true;
			ILibrarian librarian;
			Console.Clear();
			while (runUntil)
			{
				StandardMessagesForAdmin.PrintStartUpMessage();
				ConsoleColorChange.MakeColorGreen();
				Printer.PrintInSameLine("Option : ");
				int choice = 0;
				try
				{
					ConsoleColorChange.MakeColorBlue();
					choice = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
					choice = 0;
				}
				switch (choice)
				{
					case 1:
						librarian = LoginPage();
						HomePageOfLibrarian(librarian);
						break;
					case 2:
						librarian = SignUpPage();
						DataBaseAPI.AddLibrarian(librarian);
						HomePageOfLibrarian(librarian);
						break;
					case 3:
						runUntil = false;
						Console.Clear();
						break;
					default:
						StandardMessageForGeneral.PrintInvalidInput();
						break;
				}
			}
		}

		public static void HomePageOfLibrarian(ILibrarian librarian)
		{
			bool runUntil = true;
			while (runUntil)
			{
				int choice = 0;
				StandardMessagesForAdmin.PrintHomePageWelcomeMessage(librarian.Name);
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.PrintInSameLine("Option : ");
				try
				{
					ConsoleColorChange.MakeColorBlue();
					choice = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception e)
				{
					choice = 0;
				}
				
				switch (choice)
				{
					case 1 : 
						// add book
						AddBookToLibrary();
						break;
					case 2 :
						// remove a book
						RemoveBookFromLibrary();
						break;
					case 3 :
						// list of total books in library
						ListOutTotalBooksInLibrary();
						break;
					case 4 :
						// list of total taken books
						ListOutTotalTakenBooks();
						break;
					case 5 :
						// remove user
						RemoveUser();
						break;
					case 6 :
						// add user
						AddUser();
						break;
					case 7 :
						// change Password
						ChangePassword(librarian);
						break;
					case 8 :
						// clearing a console
						Console.Clear();
						break;
					case 9 :
						// loggedout
						runUntil = false;
						Console.Clear();
						break;
					default:
						StandardMessageForGeneral.PrintInvalidInput();
						break;
				}
			}
		}
		
		#region ( Local signup and login function )

		// check that user is  exist or not in database if exists than return
		private static ILibrarian LoginPage()
		{
			string id;
			string password;

			StandardMessagesForAdmin.PrintWelcomeMessageOnLogInPage();
			
			Printer.SkipLine();
			id = Input.TakeID();
			Printer.SkipLine();
			password = Input.TakePassword();
			
			while (!DataBaseAPI.ValidateLibrarian(id,password))
			{
				Printer.SkipLine();
				Printer.PrintError("Invalid Credentials");
				Printer.SkipLine();
				id = Input.TakeID();
				Printer.SkipLine();
				password = Input.TakePassword();
				Printer.SkipLine();
			}
			Console.Clear();

			return DataBaseAPI.GiveLibrarianById(id);
		}

		// creating librarian 
		private static ILibrarian SignUpPage()
		{
			string id;
			string password;
			string name;
			
			StandardMessagesForAdmin.PrintWelcomeMessageOnSignUpPage();

			id = Input.TakeID();
			name = Input.TakeName();
			password = Input.TakePassword();
			
			Console.Clear();
			return new Librarian(id, name, password);
		}

		#endregion

		#region ( Local option functions )

		private static void AddBookToLibrary()
		{
			string id;
			string author;
			string title;
			int pages;
			
			Printer.SkipLine();
			ConsoleColorChange.MakeColorGreen();
			Printer.Print("Enter Book Details :");
			Printer.SkipLine();
			id = Input.TakeBookID();
			Printer.SkipLine();
			author = Input.TakeBookAuthor();
			Printer.SkipLine();
			title = Input.TakeBookTitle();
			Printer.SkipLine();
			pages = Input.TakeBookPages();
			Printer.SkipLine();

			if (DataBaseAPI.AddBook(new Book(id, author, title, pages)))
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Book Added Successfully!");
				
			}
			else
			{
				Printer.SkipLine();
				Printer.PrintError("Book is already exists or id conflict happen!");
			}
			Printer.SkipLine();
		}

		private static void RemoveBookFromLibrary()
		{
			if (DataBaseAPI.ListOfTotalBooks().Count > 0)
			{
				ListOutTotalBooksInLibrary();
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Which book do you want o remove from Library?");
				Printer.SkipLine();
				string id = Input.TakeBookID();
				if ((DataBaseAPI.SearchBookByID(id)) is not null)
				{
					if (!DataBaseAPI.BookIsAvaLiable(DataBaseAPI.SearchBookByID(id)))
					{
						if (DataBaseAPI.RemoveBook(DataBaseAPI.SearchBookByID(id)))
						{
							Printer.SkipLine();
							ConsoleColorChange.MakeColorGreen();
							Printer.Print("Book is removed successfully form Library!");
						}
						else
						{
							Printer.SkipLine();
							Printer.PrintError("Book is taken by user so try to delete book when he/she returns a book!");
						}
					}
					else
					{
						Printer.SkipLine();
						Printer.PrintError("Book is not available, may be taken by another user!");
					}
				}
				else
				{
					Printer.SkipLine();
					Printer.PrintError("Library doesn't contains the requested book!");
				}
			}
			else
			{
				Printer.SkipLine();
				Printer.PrintError("Sorry There is no book inside a Library!");
			}
			Printer.SkipLine();
		}

		private static void ListOutTotalBooksInLibrary()
		{
			List<IBook> books = DataBaseAPI.ListOfTotalBooks();

			Printer.SkipLine();
			if (books.Count > 0)
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Total books in Library is listed below :");
				foreach (var book in books)
				{
					ConsoleColorChange.MakeColorBlue();
					Printer.Print(
						$" Book id : {book.Id}\t Book Title : {book.Title}\t Book Author : {book.Author}\t Pages : {book.Pages}");
				}
			}
			else
			{
				Printer.PrintError("Sorry, there is no book in Library!");
			}
			Console.ResetColor();
			Printer.SkipLine();
		}

		private static void ListOutTotalTakenBooks()
		{
			List<IBook> books = DataBaseAPI.ListOfTakenBooks();
			if (books.Count > 0)
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Total taken books in Library is listed below :");
				foreach (var book in books)
				{
					ConsoleColorChange.MakeColorBlue();
					Printer.Print($" Book id : {book.Id}\t Book Title : {book.Title}\t Book Author : {book.Author}\t Pages : {book.Pages}");
				}
			}
			else
			{
				Printer.SkipLine();
				Printer.PrintError("Sorry, no one borrowed a book!");
			}
			Printer.SkipLine();
		}

		private static void RemoveUser()
		{
			if (DataBaseAPI.GiveListOfUsersInLibrary().Count > 0)
			{
				PrintAllUserOfLibrary();
				string id = Input.TakeID();
				if (DataBaseAPI.CheckUserHaveAnyBooksOrNot(id))
				{
					Printer.PrintError("user have some books so wait until he/she return a book");
				}
				else
				{
					if (DataBaseAPI.RemoveUser(DataBaseAPI.GiveUserByID(id)))
					{
						ConsoleColorChange.MakeColorGreen();
						Printer.Print("user removed successfully!");
					}
					else
					{
						Printer.PrintError("user doesn't exists in Library");
					}
				}
			}
			else
			{
				Printer.SkipLine();
				Printer.PrintError("No user exists in Library!");
			}
			Printer.SkipLine();

		}

		private static void AddUser()
		{
			Console.Clear();
			StandardMessagesForAdmin.PrintAddUserPageMessage();
			Printer.SkipLine();
			string id = Input.TakeID();
			string name = Input.TakeName();
			string password = Input.TakePassword();

			if (DataBaseAPI.AddUser(new User(id, name, password)))
			{
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("User added successfully!");
			}
			else
			{
				Printer.PrintError("User already exists or user id already exists!");
			}
			Printer.SkipLine();
		}

		private static void ChangePassword(ILibrarian librarian)
		{
			Printer.SkipLine();
			string oldPassword = Input.TakeOldPassword();
			string newPassword = Input.TakeNewPassword();

			if (DataBaseAPI.UpdatePasswordOfLibrarian(librarian, oldPassword, newPassword))
			{
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Password updated successfully!");
			}
			else
			{
				Printer.PrintError("Invalid old password or user doesn't exists!");
			}
			Printer.SkipLine();
		}

		private static void PrintAllUserOfLibrary()
		{
			List<IUser> users = DataBaseAPI.GiveListOfUsersInLibrary();

			if (users.Count > 0)
			{
				Printer.Print("Total users of Library is :");
				foreach (var user in users)
				{
					Printer.Print($"User id : {user.ID}\t User Name : {user.Name}");
				}
			}
			else
			{
				Printer.PrintError("There is not user in Library!");
			}
			Printer.SkipLine();
		}

		#endregion
	}
}