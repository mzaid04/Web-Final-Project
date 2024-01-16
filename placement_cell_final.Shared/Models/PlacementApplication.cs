using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace placement_cell_final.Shared.Models
{
    public class PlacementApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [ForeignKey(nameof(Placement))]
        public int PlacementId { get; set; }

        [JsonIgnore]
        public Placement Placement { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

    }
}
