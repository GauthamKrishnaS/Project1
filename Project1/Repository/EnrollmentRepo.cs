using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Repository {
    public class EnrollmentRepo:IEnrollmentRepo {

        private SMSDBContext db;
        public EnrollmentRepo(SMSDBContext _db)
        {
            db = _db;
        }

        //SMS_12
        public bool AddEnrollment(Enrollment enrollment)
        {
            int flag;
            bool isExists = db.Enrollments.Contains(enrollment);
            if (!isExists)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                flag = 1;
            }
            else flag = 0;

            if (flag == 1) return true;
            else return false;   
        }

        //SMS_13
        public List<Enrollment> GetEnrollments()
        {
            var result = new List<Enrollment>();
            result =  db.Enrollments.ToList();
            return result;
        }

        //SMS_14
        public List<Enrollment> GetEnrollmentsByCourse(int id)
        {
            var result = new List<Enrollment>();
            result = db.Enrollments.Include(u=>u.Course).Where(x => x.courseID == id).ToList();
            return result;
        }

    }
}
