using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Authorization
{
    public class JwtConfigure
    {
        private static readonly JwtConfigure _instance = new JwtConfigure();
        public static JwtConfigure Current => _instance;

        private JwtConfigure()
        {

        }
        public string SecretKey => "hello_my_super_super_secret_key_0000";
        public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public string SigningAlgorithm => SecurityAlgorithms.HmacSha256;
        public string Issuer => "AuthServer";
        public string Audience => "ResourseServer";
        public int TokenLifeTime => 3600;
    }
}
