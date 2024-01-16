using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using placement_cell_final.Server.Data;
using placement_cell_final.Shared.Models;
using placement_cell_final.Shared.ModelsDTO;

namespace placement_cell_final.Server.Controllers
{
    [Route("api/placements")]
    [ApiController]
    public class PlacementController : ControllerBase
    {
        public AppDbContext Context = new AppDbContext(new DbContextOptions<AppDbContext>());

        [HttpGet]
        public async Task<IActionResult> get()
        {
            var placements = await Context.Placements.ToListAsync();
            return Ok(placements);
        }

        [Route("{placementId}")]
        [HttpGet]
        public async Task<IActionResult> get(int placementId)
        {
            //Console.WriteLine(placementId);

            var placements = await Context.Placements
                .Include(x => x.PlacementApplication)
                .ThenInclude(x => x.User)
                .Where(x => x.Id == placementId)
                .FirstOrDefaultAsync();



            if (placements == null)
            {
                return NotFound(new { message = "Placement you are looking for has been closed or deleted." });
            }
            return Ok(placements);
        }

        [HttpPost]
        public async Task<IActionResult> add([FromBody] PlacementDTO placementDto)
        {
            try
            {




                var palcement = await Context.Placements.AddAsync(new Placement
                {
                    Description = placementDto.Description,
                    Title = placementDto.Title,
                    CompanyName = placementDto.CompanyName,
                    Location = placementDto.Location,
                    CreatedDate = DateTime.Now
                });


                int result = await Context.SaveChangesAsync();

                if (result == 0)
                    return BadRequest("message");

                return Ok(palcement.Entity);

            }
            catch (Exception error)
            {
                return BadRequest("message");

            }
        }


        [Route("{placementId}")]
        [HttpPut]
        public async Task<IActionResult> update(int placementId, [FromBody] PlacementDTO placementDto)
        {

            try

            {
                Placement? placement = await Context.Placements.FirstOrDefaultAsync(x => x.Id == placementId);

                if (placement == null)
                    return NotFound(new { Message = "Placement not found" });

                placement.Title = placementDto.Title;
                placement.Description = placementDto.Description;
                placement.Location = placementDto.Location;

                await Context.SaveChangesAsync();

                return Ok(placement);
            }
            catch (Exception error)
            {

                return BadRequest();

            }
        }
    }
}
