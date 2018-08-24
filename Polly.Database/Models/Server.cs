using System;
using System.ComponentModel.DataAnnotations;

namespace TheKrystalShip.Polly.Database.Models
{
    public class Server
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nickname { get; set; }

        public virtual Guild Guild { get; set; }
        public virtual User User { get; set; }
    }
}
