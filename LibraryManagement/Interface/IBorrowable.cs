using System.Runtime.CompilerServices;

namespace LibraryManagement.Interface
{
	public interface IBorrowable
	{
		string Borrower { get; set; }
		DateTime BorrowTime { get; set; }
		void CheckIn();
		void CheckOut(string borrower);
	}
}
