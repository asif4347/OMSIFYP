using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace OMSIFYP.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public int test1 { get; set; }
        public int test2 { get; set; }
        public int final { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection MyProperty { get; set; }
    }
}

