using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Dtos
{
    public class CursToCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " numele cursului nu poate fi gol")]
        public string Nume { get; set; }
    }
}
