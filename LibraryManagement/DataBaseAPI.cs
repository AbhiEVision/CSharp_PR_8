using LibraryManagement.Interface;

namespace LibraryManagement
{
	public static class DataBaseAPI
	{
		private static LibraryDataBase _db = new();

		#region ( User related work )

		public static bool ValidateUser(string Id, string password)
		{
			List<IUser> temp = _db.GiveMeUserList();
			foreach (IUser user in temp)
			{
				if (user.ID == Id && user.Password == password)
				{
					return true;
				}
			}
			return false;
		}

		public static IUser GiveUserByID(string ID)
		{
			List<IUser> temp = _db.GiveMeUserList();
			foreach (IUser user in temp)
			{
				if (user.ID == ID)
				{
					return user;
				}
			}

			return null;
		} 

		public static bool ChangePassword(IUser user, string oldPassword, string newPassword)
		{
			List<IUser> temp = _db.GiveMeUserList();
			for (int i = 0, length = temp.Count; i < length; i++)
			{
				if (temp[i].ID == user.ID)
				{
					return temp[i].UpdatePassword(newPassword, oldPassword);
				}
			}
			return false;
		}

		public static bool IssueBookToUser(IUser user, IBook book)
		{
			List<IBook> books = _db.GiveMeBookList();
			foreach (var item in books)
			{
				if (!item.IsBookTaken)
				{
					user.BorrowBook(book);
					return true;
				}
			}
			return false;
		}

		public static bool IssueBookToUser(IUser user, string id)
		{
			List<IBook> books = _db.GiveMeBookList();
			foreach (var item in books)
			{
				if (item.Id == id && !item.IsBookTaken)
				{
					item.IsBookTaken = true;
					user.BorrowBook(item);
					return true;
				}
			}
			return false;
		}

		public static bool ReturnBookToLib(IBook book, IUser user)
		{
			List<IBook> books = _db.GiveMeBookList();

			if (book.IsBookTaken)
			{
				book.IsBookTaken = false;
				user.ReturnBook(book);
				return true;
			}
			return false;
		}

		public static bool ReturnBookToLib(IUser user, string id)
		{
			List<IBook> books = _db.GiveMeBookList();

			foreach (IBook book in books)
			{
				if (book.Id == id && book.IsBookTaken)
				{
					book.IsBookTaken = false;
					user.ReturnBook(book);
					return true;
				}
			}
			return false;
		}

		#endregion

		#region ( Add or remove in database)

		public static bool RemoveUser(IUser user)
		{
			return _db.RemoveUser(user);
		}

		public static bool AddUser(IUser user)
		{
			return _db.AddUser(user);
		}

		public static bool RemoveBook(IBook book)
		{
			return _db.RemoveBook(book);
		}

		public static bool AddBook(IBook book)
		{
			return _db.AddBook(book);
		}

		public static bool RemoveLibrarian(ILibrarian librarian)
		{
			return _db.RemoveLibrarian(librarian);
		}

		public static bool AddLibrarian(ILibrarian librarian)
		{
			return _db.AddLibrarian(librarian);
		}
		#endregion

		#region ( Book Related Working Methods )
		
		public static bool BookIsAvaLiable(IBook book)
		{
			if (book is not null)
			{
				return book.IsBookTaken;
			}

			return false;
		}

		public static IBook SearchBookByTitle(string title)
		{
			List<IBook> books = _db.GiveMeBookList();

			foreach (IBook book in books)
			{
				if (book.Title == title)
				{
					return book;
				}
			}

			return null;
		}

		public static IBook SearchBookByID(string id)
		{
			List<IBook> books = _db.GiveMeBookList();

			foreach (IBook book in books)
			{
				if (book.Id == id)
				{
					return book;
				}
			}

			return null;
		}

		public static List<IBook> ListOfAvailableBooks()
		{
			List<IBook> totalBooks = _db.GiveMeBookList();
			List<IBook> avaliableBooks = new();

			foreach (var book in totalBooks)
			{
				if (!book.IsBookTaken)
				{
					avaliableBooks.Add(book);
				}
			}

			return avaliableBooks;
		}

		public static List<IBook> ListOfTotalBooks()
		{
			return _db.GiveMeBookList();
		}

		public static List<IBook> ListOfTakenBooks()
		{
			List<IBook> books = _db.GiveMeBookList();
			List<IBook> ans = new();

			foreach (var book in books)
			{
				if (book.IsBookTaken)
				{
					ans.Add(book);
				}
			}

			return ans;
		}
		#endregion

		public static bool ValidateLibrarian(string _id, string _password)
		{
			List<ILibrarian> librarians = _db.GiveMeLibrariansList();
			foreach (var librarian in librarians)
			{
				if (librarian.ID == _id && librarian.Password == _password)
				{
					return true;
				}
			}
			return false;
		}

		public static ILibrarian GiveLibrarianById(string _id)
		{
			List<ILibrarian> librarians = _db.GiveMeLibrariansList();
			foreach (var librarian in librarians)
			{
				if (librarian.ID == _id)
				{
					return librarian;
				}
			}

			return null;
		}

		public static List<IUser> GiveListOfUsersInLibrary()
		{
			return _db.GiveMeUserList();
		}

		public static bool CheckUserHaveAnyBooksOrNot(string id)
		{
			List<IUser> users = GiveListOfUsersInLibrary();

			foreach (var user in users)
			{
				if (user.ID == id && user.TotalBorrowedBooks() > 0)
				{
					return true;
				}
			}

			return false;
		}

		public static bool UpdatePasswordOfLibrarian(ILibrarian librarian, string oldPassword, string newPassword)
		{
			List<ILibrarian> librarians = _db.GiveMeLibrariansList();
			foreach (var item in librarians)
			{
				if (librarian.ID == item.ID)
				{
					return item.UpdatePassword(oldPassword, newPassword);
				}
			}

			return false;
		}
	}
}
