using System.ComponentModel.DataAnnotations;
using webapp_travel_agency.Validations;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage = "Devi inserire un URL")]
        public string UrlImmagine { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(30, ErrorMessage = "Il nome deve essere di massimo 30 caratteri")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [GiorniMaggioreDi0Validation]
        public int GiorniDiViaggio { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(70, ErrorMessage = "La descrizione breve deve essere di massimo 70 caratteri")]
        public string DescrizioneBreve { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string DescrizioneCompleta { get; set; }
        [PrezzoMaggioreDi0Validation]
        public double Prezzo { get; set; }

        public PacchettoViaggio()
        {

        }
        public PacchettoViaggio(string UrlImmagine, string Nome, int GiorniDiViaggio, string DescrizioneBreve, string DescrizioneCompleta, double Prezzo)
        {
            this.UrlImmagine = UrlImmagine;
            this.Nome = Nome;
            this.GiorniDiViaggio = GiorniDiViaggio;
            this.DescrizioneBreve = DescrizioneBreve;
            this.DescrizioneCompleta = DescrizioneCompleta;
            this.Prezzo = Prezzo;
        }
    }
}
