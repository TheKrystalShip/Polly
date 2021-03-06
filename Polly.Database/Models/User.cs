using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheKrystalShip.Polly.Database.Models
{
    public class User
    {
        [Key]
        [MaxLength(20)]
        public string Id { get; set; }

        public virtual List<Message> Messages { get; set; } = new List<Message>();
        public virtual List<Server> Servers { get; set; } = new List<Server>();
    }
}
