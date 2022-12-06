using System.ComponentModel.DataAnnotations;

namespace Rede_Social_Da_Galera___Tryitter.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
