namespace WebAPI.Models
{
    public class KsiazkaBody
    {
        public string Tytul { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Gatunek { get; set; } = string.Empty;
        public int Rok { get; set; }
    }
}
