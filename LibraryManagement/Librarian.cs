using LibraryManagement.Interface;

namespace LibraryManagement
{
	public class Librarian : ILibrarian
	{
		private string _name;
		private string _password;
		private string _id;

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string ID
		{
			get { return _id; }
		}

		public string Password
		{
			get
			{
				return _password;
			}
		}
		public Librarian(string id, string Name, string Password)
		{
			_id = id;
			_name = Name;
			_password = Password;
		}

		public IBook SearchBookByTitle(string title)
		{
			return DataBaseAPI.SearchBookByTitle(title);
		}

		public IBook SearchBookByID(string id)
		{
			return DataBaseAPI.SearchBookByID(id);
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
