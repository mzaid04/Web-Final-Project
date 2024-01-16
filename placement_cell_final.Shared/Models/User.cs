using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace placement_cell_final.Shared.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }


        [Required]
        public string? Name { get; set; }

        [Required]
        [RegularExpression("^(student|company)$", ErrorMessage = "Type must be 'student' or 'company'.")]
        public string? Type { get; set; }

        [JsonIgnore]
        public PlacementApplication PlacementApplication { get; set; }
    }
}
