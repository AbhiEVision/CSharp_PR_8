using LibraryManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public sealed class User : IUser
	{
		private string _id;
		private string _name;
		private string _password;
		private List<IBook> borrowedBookList = new();

		public string Name { get { return _name; } }
		public string ID { get { return _id; } }
		public string Password { get { return _password; } }

		public User(string id, string name, string password)
		{
			_id = id;
			_name = name;
			_password = password;
		}

		public void BorrowBook(IBook libraryItem)
		{
			borrowedBookList.Add(libraryItem);
		}

		public void ReturnBook(IBook libraryItem)
		{
			borrowedBookList.Remove(libraryItem);
		}

		public List<IBook> GiveMeListOfBook()
		{
			return borrowedBookList;
		}

		public int TotalBorrowedBooks()
		{
			return borrowedBookList.Count;
		}

		public bool UpdatePassword(string oldPassword,  string newPassword)
		{
			if(oldPassword == _password)
			{
				_password = newPassword;
				return true;
			}
			return false;
		}
	}
}
