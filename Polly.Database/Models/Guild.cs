using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheKrystalShip.Polly.Database.Models
{
    public class Guild
    {
        [Key]
        [MaxLength(20)]
        public string Id { get; set; }

        public virtual List<Server> Servers { get; set; } = new List<Server>();
    }
}
