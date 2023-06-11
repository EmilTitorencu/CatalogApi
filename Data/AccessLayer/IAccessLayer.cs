using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AccessLayer
{
    public interface IAccessLayer
    {
        Student CreateStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        bool UpdateOrCreateStudentAddress(int studentId, Adresa nouaAdresa);
        Student GetStudentById(int id);

        Adresa GetAdresaByStudentId(int id);
        void DeleteStudent(int studentId);
        Student UpdateStudent(Student studentToUpdate);

        Curs AddCurs(Curs curs);
        List<Curs> GetAllCursuri();

        void AcordaNota(int valoare, int studentId, int cursId);

        List<Nota> GetStudentNote(int studentId);

        List<Nota> GetStudentCursNote(int studentId, int cursId);

        List<StudentCursMedie> GetStudentCursuriMedii(int studentId);

        List<StudentMedie> GetStudentMedii();
    }
}
