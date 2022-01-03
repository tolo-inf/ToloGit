using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Nagrada")]
    public class Nagrada
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string NazivOrg { get; set; }

        [Required]
        [MaxLength(50)]
        public string Kategorija { get; set; }

        public Igra IgraFK { get; set; }
    }
}