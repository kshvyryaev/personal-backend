using System.ComponentModel.DataAnnotations;

namespace PersonalBackend.Domain.Database.KeyIdPairs
{
    public class KeyIdPair
    {
        [Key]
        public string Key { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
