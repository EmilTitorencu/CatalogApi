using CatalogApi.Dtos;
using Data.Models;

namespace CatalogApi.Utils
{
    public static class StudentUtils
    {
        public static StudentToGetDto ToDto(this Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentToGetDto { Id = student.Id, Nume = student.Nume, Prenume = student.Prenume, Varsta = student.Varsta };
        }

        public static Student ToEntity(this StudentToCreateDto student)
        {
            if (student == null)
            {
                return null;
            }

            return new Student
            {
                Nume = student.Nume,
                Prenume = student.Prenume,
                Varsta = student.Varsta
            };
        }

        public static Adresa ToEntity(this AddressToUpdateDto addressToUpdate)
        {
            if (addressToUpdate == null)
                return null;

            return new Adresa
            {
                Numar = addressToUpdate.Numar,
                Oras = addressToUpdate.Oras,
                Strada = addressToUpdate.Strada
            };
        }

        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }

            return new Student
            {
                Id = student.Id,
                Nume = student.Nume,
                Prenume = student.Prenume,
                Varsta = student.Varsta
            };
        }
    }
}
