namespace CatalogApi.Dtos
{
    public class NotaToGetDto
    {
        public int Id { get; set; }

        public int Valoare { get; set; }
        public DateTime OraAcordarii { get; set;}

        public string Curs { get; set; }
        public string Student { get; set; }
    }
}
