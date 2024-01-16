using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using placement_cell_final.Server.Data;
using placement_cell_final.Shared.Models;
using placement_cell_final.Shared.ModelsDTO;

namespace placement_cell_final.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public AppDbContext Context = new AppDbContext(new DbContextOptions<AppDbContext>());

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] UserDTO userDto)
        {
            try
            {
                // Check if the email is already taken
                if (await Context.Users.AnyAsync(u => u.Email == userDto.Email))
                {
                    return BadRequest(new { ErrorMessage = "Email is already taken." });
                }

                var user = await Context.Users.AddAsync(new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Type = userDto.Type,
                });
                await Context.SaveChangesAsync();

                return StatusCode(201, user.Entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var users = await Context.Users.ToListAsync();

                if (users == null || users.Count == 0)
                {
                    return NotFound("No records found.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetOneStudents(int userId)
        {
            try
            {
                var student = await Context.Users.FindAsync(userId);

                if (student == null)
                {
                    return NotFound("No record found.");
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteStudent(int userId)
        {
            try
            {
                // Find the student by ID
                var dbUser = await Context.Users.FirstOrDefaultAsync(x => x.Id == userId);

                // Check if the student exists
                if (dbUser == null)
                {
                    return NotFound($"No record found with ID {userId}");
                }

                // Remove the student from the database
                Context.Users.Remove(dbUser);
                await Context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateStudent(int userId, [FromBody] UserDTO userDto)
        {
            try
            {
                // Find the student by ID
                var existingStudent = await Context.Users.FirstOrDefaultAsync(x => x.Id == userId);

                // Check if the student exists
                if (existingStudent == null)
                {
                    return NotFound($"No record found with ID {userId}");
                }

                existingStudent.Name = userDto.Name;
                existingStudent.Email = userDto.Email;
                existingStudent.Password = userDto.Password;
                existingStudent.Type = userDto.Type;

                await Context.SaveChangesAsync();
                return Ok(existingStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
