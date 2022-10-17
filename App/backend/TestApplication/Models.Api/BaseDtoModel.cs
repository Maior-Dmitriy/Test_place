using System;
using Newtonsoft.Json;


namespace Models.Dto
{
    public class BaseDtoModel
    {
        [JsonProperty("id")] public Guid Id { get; set; }
    }
}
