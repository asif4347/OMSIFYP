using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMSIFYP.Models
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string LastName { get; set; }
        public string imgUrl { get; set; }
        public string Email { get; set; }

        public int getID()
        {
            return ID;
        }
    }
}