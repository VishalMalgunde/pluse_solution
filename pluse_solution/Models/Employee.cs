using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pluse_solution.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Emp_Id { get; set; }
        
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^(?![0])[0-9]{10}$", ErrorMessage = "The {0} field should contain numbers only and 10 digits with the first digit not being 0.")]
        public string? Phone { get; set; }

        [Required]
        public string? Department { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}
