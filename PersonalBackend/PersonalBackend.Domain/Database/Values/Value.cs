using System.ComponentModel.DataAnnotations;

namespace PersonalBackend.Domain.Database.Values
{
    public class Value
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string JsonValue { get; set; }
    }
}
