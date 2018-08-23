using System.ComponentModel.DataAnnotations;

namespace TheKrystalShip.Polly.Database.Models
{
    public class User
    {
        [Key]
        [MaxLength(20)]
        public string Id { get;set; }
        
    }
}
