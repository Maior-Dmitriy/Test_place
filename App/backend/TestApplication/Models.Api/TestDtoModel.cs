using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models.Dto
{
    public class TestDtoModel : BaseDtoModel
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("questions")] public List<QuestionDtoModel> Questions { get; set; }
    }
}
