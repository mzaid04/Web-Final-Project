using System.ComponentModel.DataAnnotations;

namespace placement_cell_final.Client.ClassModels
{
    public class JobDetail
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Job title must be between 5-20 characters")]
        [Required]
        public string? JobTitle { get; set; }
      
        [Required]
        public string? Location { get; set; }

        [Required]
        public string? CompanyName { get; set; }
      
        [Required]
        public string? PostedAgo { get; set; }
    }
}