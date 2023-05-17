using System.Globalization;
using System.Threading.Channels;

namespace CSharp_PR_8
{
    public static class Printer
    {
        public static void Print(string s)
        {
            Console.WriteLine(s);
        }

        public static void PrintError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static void SkipLine()
        {
            Console.WriteLine();
        }

        public static void PrintInSameLine(string s)
        {
            Console.Write(s);
        }
    }
}