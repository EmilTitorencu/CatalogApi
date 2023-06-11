using Data.Models;

namespace CatalogApi.Dtos
{
    public class StudentCursMedieToGetDto
    {
        public string Curs { get; set; }
        public string Student { get; set; }
        public double Medie { get; set; }
    }
}
