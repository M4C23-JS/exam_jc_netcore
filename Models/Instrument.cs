using System.Text.Json.Serialization;

namespace exam_jc_netcore_react.Models
{
    public class Instrument
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Price { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }

    }
}
