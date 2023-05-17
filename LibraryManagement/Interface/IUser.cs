namespace LibraryManagement.Interface
{
	public interface IUser : IPerson
	{

		void BorrowBook(IBook libraryItem);
		List<IBook> GiveMeListOfBook();
		void ReturnBook(IBook libraryItem);
		int TotalBorrowedBooks();
	}
}