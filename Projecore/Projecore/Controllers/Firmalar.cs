using Microsoft.AspNetCore.Mvc;
using Projecore.Models;

namespace Projecore.Controllers
{
    public class Firmalar : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler =  c.Firmas.ToList();
            return View(degerler);
        }

        public IActionResult YeniFirma()
        {

            return View();
        }
        [HttpPost]
        public IActionResult YeniFirma(Firma f)
        {
            c.Firmas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
            //return View();
        }

      

        public IActionResult FirmaGetir(int id)
        {
            var firma = c.Firmas.Find(id);
            return View("FirmaGetir",firma);
        }
        public IActionResult FİrmaGuncelle(Firma f)
        {
            var firma = c.Firmas.Find(f.id);
            firma.firma_adi = f.firma_adi;
            firma.mernis_kontrol=f.mernis_kontrol;
            c.SaveChanges();


            return RedirectToAction("Index");
        
        }




    }
}
