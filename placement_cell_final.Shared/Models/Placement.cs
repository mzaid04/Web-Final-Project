
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace placement_cell_final.Shared.Models
{
    public class Placement
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string? Title { get; set; }


        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Location { get; set; }


        [Required]
        public string? CompanyName { get; set; }


        [Required]
        public DateTime CreatedDate { get; set; }


        [JsonIgnore]
        public PlacementApplication PlacementApplication { get; set; }


        public Placement()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
