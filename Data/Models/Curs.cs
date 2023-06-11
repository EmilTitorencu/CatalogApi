using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Curs
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public List<Nota> Nota { get; set; } = new List<Nota>();
        public List<Student> Students { get; set; } = new List<Student>();    
    }
}
