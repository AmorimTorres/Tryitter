using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Rede_Social_Da_Galera___Tryitter.Models
{
    public class Account
    {
        public Account() 
        {
            Posts = new Collection<Post>();
        }
        [Key]
        public int AccountId { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
