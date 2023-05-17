using CSharp_PR_8.StandardMessages;
using LibraryManagement;
using LibraryManagement.Interface;

namespace CSharp_PR_8.Pages
{
    public static class GeneralPage
    {
        public static void RunGeneralPage()
        {
            bool runUntill = true;
            InitializeTheLibrary();
            while (runUntill)
            {
                int choice = 0;
                StandardMessageForGeneral.PrintStartUpMessage();
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
                        UserPage.LibraryUser();
                        break;
                    case 2:
                        LibrarianPage.LibraryLibrarian();
                        break;
                    case 3:
                        runUntill = false;
                        break;
                    default:
                        StandardMessageForGeneral.PrintInvalidInput();
                        break;
                }
            }
            Printer.SkipLine();
            StandardMessageForGeneral.PrintEndingMessage();

        }



		private static void InitializeTheLibrary()
		{
			IBook book = new Book("123", "Harper Lee", "To Kill a Mockingbird", 500);
			DataBaseAPI.AddBook(book);
			book = new Book("124", "Jane Austen", "Pride and Prejudice", 480);
			DataBaseAPI.AddBook(book);
			book = new Book("125", "Jhon Green", "The Fault in Our Stars", 300);
			DataBaseAPI.AddBook(book);
		}
    }
}