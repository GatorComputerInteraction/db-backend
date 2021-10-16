using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class DegreeModel
    {
        [Key]
        [Column(Order = 1)]
        public int DegreeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DegreeName { get; set; }
    }
}
