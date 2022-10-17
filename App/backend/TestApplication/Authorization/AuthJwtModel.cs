using System;

namespace AuthorizationJwt
{
    public class AuthJwtModel
    {
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenType { get; set; }
        public DateTime Expires { get; set; }
    }
}
