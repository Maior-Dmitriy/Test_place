using Newtonsoft.Json;
using System;

namespace Models.Dto
{
    public class SignInDtoModel
    {
        [JsonProperty("userId")] public string UserId { get; set; }
        [JsonProperty("accessToken")] public string AccessToken { get; set; }
        [JsonProperty("expires")] public DateTime Expires { get; set; }
        [JsonProperty("user")] public UserDtoModel User { get; set; }
    }
}
