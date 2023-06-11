using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class StudentCursMedie
    {
        public int StudentId { get; set; }
        public int CursId { get; set; }

        public Curs Curs { get; set; }
        public Student Student { get; set; }

        public double Medie { get; set; }
    }
}
