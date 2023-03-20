using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models {
    public class Student {
        [Required]
        public string studName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        [Required]
        public long contact { get; set; }
        [Required]
        public bool status { get; set; }

        public ICollection<Enrollment> enrollments { get; set; }
    }
}
