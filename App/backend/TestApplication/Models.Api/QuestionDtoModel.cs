using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Models.Dto
{
    public class QuestionDtoModel : BaseDtoModel
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("testId")] public Guid TestId { get; set; }
        [JsonProperty("options")] public List<OptionDtoModel> Options { get; set; }
    }
}
