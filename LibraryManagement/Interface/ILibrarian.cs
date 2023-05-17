namespace LibraryManagement.Interface
{
    public interface ILibrarian : IPerson
    {
        IBook SearchBookByID(string id);
        IBook SearchBookByTitle(string title);
    }
}