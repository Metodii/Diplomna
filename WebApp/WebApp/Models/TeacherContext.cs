using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class TeacherContext :DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options)
            :base(options)
        {
        }

        public DbSet<Teacher>Teachers { get; set; }
    }
}
