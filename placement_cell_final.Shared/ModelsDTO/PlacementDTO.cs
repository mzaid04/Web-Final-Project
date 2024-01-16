using System.ComponentModel.DataAnnotations;

namespace placement_cell_final.Shared.ModelsDTO
{
    public class PlacementDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }




        [Required(ErrorMessage = "Location is required.")]
        public string? Location { get; set; }


        [Required(ErrorMessage = "Company Name is required.")]
        public string? CompanyName { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
