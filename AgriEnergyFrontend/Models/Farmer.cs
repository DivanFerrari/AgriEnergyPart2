using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyFrontend.Model
{
    public class Farmer
    {
        [Key]

        public int FarmerID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }


    }
}
