using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rede_Social_Da_Galera___Tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [MaxLength(300)]
        public string? PostContent { get; set; }
        public int AccountId { get; set; }
        [JsonIgnore]
        public Account? Account { get; set; } 
    }
}
