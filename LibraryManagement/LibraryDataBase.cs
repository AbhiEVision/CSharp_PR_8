using LibraryManagement.Interface;

namespace LibraryManagement
{
	public class LibraryDataBase : ILibraryDataBase
	{
		private List<IUser> usersList = new();
		private List<ILibrarian> librariansList = new();
		private List<IBook> bookList = new();

		public bool AddUser(IUser user)
		{
			if (usersList.Contains(user))
			{
				return false;
			}
			else
			{
				foreach (var item in usersList)
				{
					if (item.ID == user.ID)
					{
						return false;
					}
				}
				usersList.Add(user);
				return true;
			}
		}

		public bool RemoveUser(IUser user)
		{
			if (usersList.Contains(user))
			{
				usersList.Remove(user);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool AddBook(IBook book)
		{
			if (bookList.Contains(book))
			{
				return false;
			}
			else
			{
				foreach (var item in bookList)
				{
					if (item.Id == book.Id)
					{
						return false;
					}
				}
				bookList.Add(book);
				return true;
			}
		}

		public bool RemoveBook(IBook book)
		{
			if (bookList.Contains(book))
			{
				bookList.Remove(book);
				return true;
			}
			return false;
		}

		public bool AddLibrarian(ILibrarian librarian)
		{
			if (librariansList.Contains(librarian))
			{
				return false;
			}
			librariansList.Add(librarian);
			return true;
		}

		public bool RemoveLibrarian(ILibrarian librarian)
		{
			if (librariansList.Contains(librarian))
			{
				librariansList.Remove(librarian);
				return true;
			}
			return false;
		}

		public List<IBook> GiveMeBookList()
		{
			return bookList;
		}
		public List<ILibrarian> GiveMeLibrariansList()
		{
			return librariansList;
		}

		public List<IUser> GiveMeUserList()
		{
			return usersList;
		}
	}
}
