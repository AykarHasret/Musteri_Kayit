using System.ComponentModel.DataAnnotations;

namespace Projecore.Models
{
    public class Uyeler
    {

        [Key]
        public int id { get; set; }
        
        public string tc { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        
        public string telefon { get; set; }
        public string mail { get; set; }
        //public string dogumYili { get; set; }
        public DateTime dogumyil { get; set; }
        public int Firmaid { get; set; }
        public Firma Firma { get; set; }

    }
}
