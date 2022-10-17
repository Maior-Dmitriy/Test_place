using Newtonsoft.Json;

namespace Models.Dto
{
    public class RoleDtoModel : BaseDtoModel
    {
        [JsonProperty("title")] public string Title { get; set; }
    }
}
