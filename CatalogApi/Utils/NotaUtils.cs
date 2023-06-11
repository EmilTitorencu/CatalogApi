using CatalogApi.Dtos;
using Data.Models;

namespace CatalogApi.Utils
{
    public static class NotaUtils
    {
        public static NotaToGetDto ToDto(this Nota nota)
        {
            if (nota == null)
            {
                return null;
            }

            return new NotaToGetDto { Id = nota.Id, Valoare = nota.Valoare, OraAcordarii = nota.OraAcordarii, Curs = nota.Curs.Nume, Student = nota.Student.Nume };
        }

        public static StudentCursMedieToGetDto ToDto(this StudentCursMedie medie)
        {
            if (medie == null)
            {
                return null;
            }

            return new StudentCursMedieToGetDto { Curs = medie.Curs.Nume, Student = medie.Student.Nume, Medie = medie.Medie };
        }

        public static StudentMedieToGetDto ToDto(this StudentMedie medie)
        {
            if (medie == null)
            {
                return null;
            }

            return new StudentMedieToGetDto { Student = medie.Student.Nume, Medie = medie.Medie };
        }
    }
}
