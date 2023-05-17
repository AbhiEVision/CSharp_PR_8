using System.Security.AccessControl;
using CSharp_PR_8.StandardMessages;

namespace CSharp_PR_8
{
    internal static class Input
	{
		public static string TakeID()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter your id : ");
			ConsoleColorChange.MakeColorBlue();
			string x = Console.ReadLine();
			while (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x))
			{
				Printer.PrintError("Id can not be null!");
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Enter your id");
				ConsoleColorChange.MakeColorBlue();
				x = Console.ReadLine();
				Console.ResetColor();
			}
			Console.ResetColor();
			return x;
		}


		public static string TakeName()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter your username : ");
			ConsoleColorChange.MakeColorBlue();
			string x = Console.ReadLine();
			while (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x))
			{
				Printer.PrintError("Username can not be null!");
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Enter your username");
				ConsoleColorChange.MakeColorBlue();
				x = Console.ReadLine();
				Console.ResetColor();
			}
			Console.ResetColor();
			return x;
		}

		public static string TakePassword()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter your password : ");
			ConsoleColorChange.MakeColorBlue();
			string x = Console.ReadLine();
			while (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x))
			{
				Printer.PrintError("Password can not be null!");
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Enter your password");
				ConsoleColorChange.MakeColorBlue();
				x = Console.ReadLine();
				Console.ResetColor();
			}
			Console.ResetColor();
			return x;
		}

		public static string TakeBookID()
		{
			string id;
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Please Enter a book Id : ");
			ConsoleColorChange.MakeColorBlue();
			id = Console.ReadLine();
			Console.ResetColor();
			while (string.IsNullOrWhiteSpace(id) || string.IsNullOrEmpty(id))
			{
				Printer.PrintError("Id Can not be null or whitespace");
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.PrintInSameLine("Enter Valid Id : ");
				ConsoleColorChange.MakeColorBlue();
				id = Console.ReadLine();
			}
			
			Console.ResetColor();
			return id;
		}
		
		public static string TakeNewPassword()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter your new password : ");
			ConsoleColorChange.MakeColorBlue();
			string x = Console.ReadLine();
			while (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(x))
			{
				Printer.PrintError("New password can not be null!");
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Enter your new password");
				ConsoleColorChange.MakeColorBlue();
				x = Console.ReadLine();
				Console.ResetColor();
			}
			Console.ResetColor();
			return x;
		}
		
		public static string TakeOldPassword()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter your old password : ");
			ConsoleColorChange.MakeColorBlue();
			string x = Console.ReadLine();
			while (string.IsNullOrEmpty(x)|| string.IsNullOrEmpty(x))
			{
				Printer.PrintError("Old password can not be null!");
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.Print("Enter your old password");
				ConsoleColorChange.MakeColorBlue();
				x = Console.ReadLine();
				Console.ResetColor();
			}
			Console.ResetColor();
			return x;
		}

		public static string TakeBookAuthor()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter the author name : ");
			ConsoleColorChange.MakeColorBlue();
			String x = Console.ReadLine();
			while (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x))
			{
				Printer.PrintError("Author can not be empty!");
				Printer.SkipLine();
				Printer.PrintInSameLine("Enter book author name Again");
				ConsoleColorChange.MakeColorBlue();
				x = Console.ReadLine();
				Console.ResetColor();
			}
			Console.ResetColor();
			return x;
		}

		public static string TakeBookTitle()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter the title of book : ");
			ConsoleColorChange.MakeColorBlue();
			String x = Console.ReadLine();
			while (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x))
			{
				Printer.PrintError("title can not be empty!");
				Printer.SkipLine();
				Printer.PrintInSameLine("Enter title of book Again");
				ConsoleColorChange.MakeColorBlue();
				x = Console.ReadLine();
				Console.ResetColor();
			}
			Console.ResetColor();
			return x;
		}

		public static int TakeBookPages()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.PrintInSameLine("Enter the page number of book : ");
			int x;
			ConsoleColorChange.MakeColorBlue();
			while ((int.TryParse(Console.ReadLine(), out x) && x <= 0))
			{
				Printer.PrintError("Enter valid page no.");
				Printer.SkipLine();
				ConsoleColorChange.MakeColorGreen();
				Printer.PrintInSameLine("enter page no again : ");
				ConsoleColorChange.MakeColorBlue();
			}

			Console.ResetColor();
			return x;
		}
	}
}
