using System.ComponentModel.DataAnnotations;

namespace TheKrystalShip.Polly.Database.Models
{
    public class Message
    {
        [Key]
        [MaxLength(20)]
        public string Id { get; set; }

        public virtual User User { get; set; }
    }
}
