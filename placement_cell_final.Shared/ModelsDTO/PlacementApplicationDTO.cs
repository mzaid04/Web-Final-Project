using System.ComponentModel.DataAnnotations;

namespace placement_cell_final.Shared.ModelsDTO
{
    public class PlacementApplicationDTO
    {
        //[Key]
        //public int Id { get; set; }

        [Required]
        public string? Description { get; set; }


        [Required]
        public int UserId { get; set; }

        [Required]
        public int PlacementId { get; set; }
    }
}
