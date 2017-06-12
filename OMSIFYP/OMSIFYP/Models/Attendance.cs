using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMSIFYP.Models
{
    public enum status
    {
        A,P,L
    }
    public class Attendance
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public status? status { get; set; }
    }
}