namespace PasswordManagers
{
    public interface IPasswordManager
    {
        string HashPassword(string password);
    }
}
