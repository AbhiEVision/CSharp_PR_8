using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Interface;

namespace LibraryManagement
{
	public sealed class Book : IBook
	{
		private string _id;
		private string _author;
		private string _title;
		private int _pages;

		public bool IsBookTaken { get; set; }

		public Book(string id, string author, string title, int pages)
		{
			_id = id;
			_author = author;
			_title = title;
			_pages = pages;
			IsBookTaken = false;
		}

		public string Title { get { return _title; } }
		public string Id { get { return _id; } }
		public string Author { get { return _author; } }
		public int Pages { get { return _pages; } }
		public string Borrower { get; set; }
		public DateTime BorrowTime { get; set; }
		
		public void CheckIn()
		{
			Borrower = string.Empty;
		}
		public void CheckOut(string borrower)
		{
			Borrower = borrower;
		}
	}
}
