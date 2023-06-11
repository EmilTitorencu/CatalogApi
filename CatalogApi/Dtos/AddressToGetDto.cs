using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Dtos
{
    public class AddressToGetDto
    {
        /// <summary>
        /// Street name
        /// </summary>
        public string Strada { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string Oras { get; set; }

        /// <summary>
        /// Street no
        /// </summary>
        public int Numar { get; set; }
    }
}
