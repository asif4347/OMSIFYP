using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMSIFYP.Models
{
    public class Section
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Section")]
        public string sec { get; set; }
        [Required]
        [Display(Name = "Course")]
        public string cour { get; set; }
        [Required]
        [Display(Name = "Instructor")]
        public string ins { get; set; }
    }
}