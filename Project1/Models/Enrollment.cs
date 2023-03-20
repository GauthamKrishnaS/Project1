using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models {
    public class Enrollment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int enrollmentID { get; set; }

        [ForeignKey("Student")]
        public string email { get; set; }

        [ForeignKey("Course")]
        public int courseID { get; set; }

        public DateTime enrollDate { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
