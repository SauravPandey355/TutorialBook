namespace TutorialBook.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class TutorialBookData
    {
        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty("name")]
        public string ?Name { get; set; }

        [JsonProperty("tutorial")]
        public string? TutorialBookId { get; set; }

    }
    public class TutorialBookInput
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("tutorial")]
        public string? TutorialBookId { get; set; }
    }
}
