using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Ocena")]
    public class Ocena
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Range(1,5)]
        public int Gameplay { get; set; }

        [Required]
        [Range(1,5)]
        public int Story { get; set; }
        
        [Required]
        [Range(1,5)]
        public int Music { get; set; }

        [Required]
        [Range(1,5)]
        public int Graphics { get; set; }

        [Range(1,5)]
        public double Summary { get{ return (Gameplay+Story+Music+Graphics)/4; } }

        public Igra IgraFK { get; set; }
    }
}