namespace LibraryManagement.Interface
{
    public interface IPerson
    {
        string Name { get; }
        string ID { get; }
        string Password { get; }
        
        bool UpdatePassword(string oldPassword, string newPassword);

    }
}