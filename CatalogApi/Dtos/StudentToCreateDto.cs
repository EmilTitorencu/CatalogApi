using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Dtos
{
    public class StudentToCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " numele nu poate fi gol")]
        public string Nume { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " prenumele nu poate fi gol")]
        public string Prenume { get; set; }


        [Range(1, 100)]
        public int Varsta { get; set; }
    }
}
