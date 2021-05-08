using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAD_Assignment3_BlogApplication.Models
{
    public class AdminRepository
    {
        public static List<Admin> admin = new List<Admin>();

        static AdminRepository()
        {
            admin.Add(new Admin { Email = "admin@gmail.com", Password = "pass" });
        }
    
    }
}
