using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace placement_cell_final.Shared.ModelsDTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression("^(student|company)$", ErrorMessage = "Type must be 'student' or 'company'.")]
        public string? Type { get; set; }
    }
}
