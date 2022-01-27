using System.ComponentModel.DataAnnotations;

namespace Projecore.Models
{
    public class Firma
    {
        [Key]
        public int id { get; set; }
        public string firma_adi { get; set; }
        public bool mernis_kontrol { get; set; }

        public IList<Uyeler> Uyelers { get; set;}

    }
}
