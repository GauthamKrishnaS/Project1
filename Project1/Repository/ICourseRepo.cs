using Project1.Models;

public interface ICourseRepo {
    bool AddCourse(Course course);
    bool DeleteCourse(int id);
    Course GetDetails(int id);
    List<Course> GetAll();
    public bool Update(Course c);
}