using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAdmin.Models
{
    public class StudentModel : PersonModel
    {
        public StudentModel() : base()
        {
            
        }
        public int Grade { get; set; }

        public String Class { get; set; }

        public int ClassNumber { get; set; }

    }
}
