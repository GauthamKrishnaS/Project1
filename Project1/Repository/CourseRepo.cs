using Project1.Models;
using Project1.Repository;

public class CourseRepo : ICourseRepo {
    private SMSDBContext db;
    public CourseRepo(SMSDBContext context)
    {
        db = context;
    }
    public bool AddCourse(Course course)
    {
        bool result = false;
        Course cos = db.Courses.FirstOrDefault(x => x.courseID == course.courseID);
        if (cos != null)
        {
            result = false;
        }
        else
        {
            result = true;
            db.Courses.Add(course);
            db.SaveChanges();
        }
        return result;
    }
    public bool DeleteCourse(int id)
    {
        bool result = false;
        Course cos = db.Courses.FirstOrDefault(x => x.courseID == id);
        if (cos != null)
        {
            cos.status = false;
            result = true;

            db.SaveChanges();
        }
        else
        {
            result = false;

        }
        return result;
    }

    public List<Course> GetAll()
    {
        List<Course> list = db.Courses.ToList();
        return list;
    }

    public Course GetDetails(int id)
    {
        Course course = db.Courses.FirstOrDefault(x => x.courseID == id);
        return course;
    }

    public bool Update(Course c)
    {
        bool result = true;
        Course course = db.Courses.FirstOrDefault(x => x.courseID == c.courseID);
        course.courseName = c.courseName;
        course.status = c.status;
        course.courseFee = c.courseFee;
        course.courseDuration = c.courseDuration;
        db.Courses.Update(course);
        db.SaveChanges();
        return result;
    }
}