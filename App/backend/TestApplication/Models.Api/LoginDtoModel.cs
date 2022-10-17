using Newtonsoft.Json;

namespace Models.Dto
{
    public class LoginDtoModel
    {
        [JsonProperty("login")] public string Login { get; set; }
        [JsonProperty("password")] public string Password { get; set; }
    }
}
