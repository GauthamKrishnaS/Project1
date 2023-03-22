using Project1.Models;
namespace Project1.Repository {
    public interface IEnrollmentRepo {

        public bool AddEnrollment(Enrollment enrollment);
        public List<Enrollment> GetEnrollments();
        public List<Enrollment>GetEnrollmentsByCourse(int id);

    }
}
