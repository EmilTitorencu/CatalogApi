using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AccessLayer
{
    public partial class AccessLayer : IAccessLayer
    {
        public void AcordaNota(int valoare, int studentId, int cursId)
        {
            if (!ctx.Studenti.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"id student invalid {studentId}");
            }
            if (!ctx.Cursuri.Any(s => s.Id == cursId))
            {
                throw new InvalidIdException($"id curs invalid {cursId}");
            }

            var curs = ctx.Cursuri.Include(s => s.Students).FirstOrDefault(c => c.Id == cursId);
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == studentId);

            if (!curs.Students.Any(s => s.Id == studentId))
            {
                curs.Students.Add(student);
            }

            ctx.Note.Add(new Nota { Valoare = valoare, StudentId = studentId, CursId = cursId, OraAcordarii=DateTime.Now });
            ctx.SaveChanges();
        }

        public List<Nota> GetStudentNote(int studentId)
        {
            return ctx.Note.Include(c=>c.Curs).Include(s => s.Student).Where(s => s.StudentId == studentId).ToList<Nota>();
        }

        public List<Nota> GetStudentCursNote(int studentId, int cursId)
        {
            return ctx.Note.Include(c => c.Curs).Include(s => s.Student).Where(s => s.StudentId == studentId && s.CursId== cursId).ToList<Nota>();
        }

        public List<StudentCursMedie> GetStudentCursuriMedii(int studentId)
        {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == studentId);

            return ctx.Note.Include(c => c.Curs).Include(s => s.Student).Where(s => s.StudentId == studentId).GroupBy(c => c.Curs, v=> v.Valoare).Select(c => new StudentCursMedie
            {
                Curs = c.Key,
                CursId = c.Key.Id,
                Medie = c.Average(),
                StudentId = studentId,
                Student = student
            }).ToList<StudentCursMedie>();
        }

        public List<StudentMedie> GetStudentMedii()
        {
            return ctx.Studenti.Include(s => s.Note)
                .Select(c => new { Student = c, MediiCursuri = c.Note.GroupBy(g => g.Curs, g => g.Valoare).Select(z => z.Average()) })
                .Select(v => new StudentMedie { Student = v.Student, Medie = v.MediiCursuri.Average() })
                .ToList<StudentMedie>();
        }
    }
}
