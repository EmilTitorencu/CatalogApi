using CatalogApi.Dtos;
using Data.Models;

namespace CatalogApi.Utils
{
    public static class CursUtils
    {
        public static Curs ToEntity(this CursToCreateDto curs)
        {
            if (curs == null)
            {
                return null;
            }

            return new Curs
            {
                Nume = curs.Nume,
            };
        }
    }
}
