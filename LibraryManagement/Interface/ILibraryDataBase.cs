namespace LibraryManagement.Interface
{
    public interface ILibraryDataBase
    {
        bool AddBook(IBook book);
        bool AddLibrarian(ILibrarian librarian);
        bool AddUser(IUser user);
        bool RemoveBook(IBook book);
        bool RemoveLibrarian(ILibrarian librarian);
        bool RemoveUser(IUser user);
    }
}