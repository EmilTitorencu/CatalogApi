using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class StudentsDbContext : DbContext, IStudentsDbContext
    {
        public DbSet<Student> Studenti { get; set; }

        public DbSet<Curs> Cursuri { get; set; }

        public DbSet<Nota> Note { get; set; }

        public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }

}
