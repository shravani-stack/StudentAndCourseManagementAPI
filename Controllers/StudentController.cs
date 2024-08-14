using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAndCourseManagementAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAndCourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<StudentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<StudentController>/5
        [HttpGet()]
        public async Task<IActionResult> ListStudents()
        {
            var students = await _context.Students.Include(s => s.StudentCourse).ThenInclude(sc => sc.Course).Select(s => new
            { 
                s.Name,
                s.Email,
                s.Phone,
                Course = string.Join(",", s.StudentCourse.Select(sc => sc.Course.Name))
            }).ToListAsync();

            return Ok(students);

        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]  Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        // POST api/<StudentController>/5
        //[HttpPost("{studentId}/courses")]
        //public async Task<IActionResult> ChooseCourse(int studentId, [FromBody] List<int> courseIds)
        //{
        //    var student = await _context.
        //}
       
    }
}
