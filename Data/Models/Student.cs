﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public string Prenume { get; set; }

        public int Varsta { get; set; }

        public Adresa Adresa { get; set; }

        public List<Nota> Note { get; set; } = new List<Nota>();
        public List<Curs> Cursuri { get; set; } = new List<Curs>();
    }
}
