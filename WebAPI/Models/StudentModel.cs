using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class StudentModel
    {
        [Key]
        public int UfId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
