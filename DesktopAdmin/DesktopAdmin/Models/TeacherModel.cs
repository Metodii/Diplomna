using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAdmin.Models
{
    public class TeacherModel : PersonModel
    {   
        public TeacherModel(): base()
        {

        }   
        public String Subject { get; set; }
    }
}
    