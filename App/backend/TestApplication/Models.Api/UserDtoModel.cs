using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models.Dto
{
    public class UserDtoModel : BaseDtoModel
    {
        [JsonProperty("email")] public string Email { get; set; }
        //[JsonProperty("password")] public string Password { get; set; }
        [JsonProperty("roles")] public List<RoleDtoModel> Roles { get; set; }
        [JsonProperty("tests")] public List<TestDtoModel> Tests { get; set; }
    }
}
