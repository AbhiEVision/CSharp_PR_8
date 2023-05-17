namespace LibraryManagement.Interface
{
	public interface ILibraryItem
	{
		string Author { get; }
		string Id { get; }
		int Pages { get; }
		string Title { get; }
	}
}