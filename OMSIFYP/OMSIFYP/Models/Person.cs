using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSIFYP.Models
{
    public abstract class Person
    {
        
        public int ID { get; set; }
      
        public string userId{get;set;}
        public string email { get; set; }
        public int CNIC { get; set; }
        public string Adddress { get; set; }
        public string imgUrl { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public int logCont { get; set; }
        public string Role { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}