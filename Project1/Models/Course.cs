using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models {
    public class Course {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseID { get; set; }

        [Required]
        public string courseName { get; set; }
        public DateTime courseDuration { get; set; }

        [Required]
        public float courseFee { get; set; }

        [Required]
        public bool status { get; set; }

        public ICollection<Enrollment> enrollments { get; set; }
    }
}
