using Newtonsoft.Json;

namespace Models.Dto
{
    public class OptionDtoModel : BaseDtoModel
    {
        [JsonProperty("letter")] public char Letter { get; set; }
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("isRight")] public bool IsRight { get; set; }
    }
}
