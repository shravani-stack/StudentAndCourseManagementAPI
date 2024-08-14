namespace StudentAndCourseManagementAPI.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfessorName { get; set; }
        public string Description { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
