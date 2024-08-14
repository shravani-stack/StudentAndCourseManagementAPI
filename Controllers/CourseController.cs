using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAndCourseManagementAPI.Model;

namespace StudentAndCourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        { 
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
