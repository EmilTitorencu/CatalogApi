using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Exceptions;

namespace Data.AccessLayer
{
    public partial class AccessLayer : IAccessLayer
    {
        private readonly StudentsDbContext ctx;
        public AccessLayer(StudentsDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Student> GetAllStudents() => ctx.Studenti.ToList();

        public Student GetStudentById(int id)
        {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidIdException($"invalid student id {id}");
            }
            return student;
        }

        public Student CreateStudent(Student student)
        {

            if (ctx.Studenti.Any(s => s.Id == student.Id))
            {
                throw new DuplicatedIdException($"duplicated student id");
            }

            ctx.Add(student);
            ctx.SaveChanges();

            return student;
        }

        public bool UpdateOrCreateStudentAddress(int studentId, Adresa nouaAdresa)
        {
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                //throw exception
            }

            var created = false;
            if (student.Adresa == null)
            {
                student.Adresa = new Adresa();
                created = true;
            }
            student.Adresa.Numar = nouaAdresa.Numar;
            student.Adresa.Strada = nouaAdresa.Strada;
            student.Adresa.Oras = nouaAdresa.Oras;

            ctx.SaveChanges();
            return created;
        }

        public Adresa GetAdresaByStudentId(int id)
        {
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidIdException($"invalid student id {id}");
            }
            return student.Adresa;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                //throw exception
            }

            student.Nume = studentToUpdate.Nume;
            student.Prenume = studentToUpdate.Prenume;
            student.Varsta = studentToUpdate.Varsta;

            ctx.SaveChanges();
            return student;
        }

        public void DeleteStudent(int studentId)
        {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"student not found {studentId}");
            }

            ctx.Studenti.Remove(student);
            ctx.SaveChanges();
        }
    }
}
