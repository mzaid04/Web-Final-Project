using System.ComponentModel.DataAnnotations;

namespace placement_cell_final.Client.ClassModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
