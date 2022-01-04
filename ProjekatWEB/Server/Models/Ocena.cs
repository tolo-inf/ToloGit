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

        public Igra IgraFK { get; set; }
    }
}