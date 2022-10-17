using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManagers
{
    public class PasswordManager : IPasswordManager
    {
        public string HashPassword(string password)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(password);

            SHA256Managed sha = new SHA256Managed();
            byte[] crypto = sha.ComputeHash(bytes, 0, bytes.Length);
            return Convert.ToBase64String(crypto);
        }
    }
}
