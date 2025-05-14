using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Model
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }


    }
}
