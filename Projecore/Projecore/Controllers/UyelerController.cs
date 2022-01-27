using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projecore.Models;

namespace Projecore.Controllers
{
    public class UyelerController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler= c.Uyelers.Include(x => x.Firma).ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniUye()
        {

            List<SelectListItem> degerler = (from x in c.Firmas.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=x.firma_adi,
                                                 Value=x.id.ToString()

                                             }).ToList();
            
            ViewBag.dgr = degerler;
            return View();
        }


      


        [HttpPost]
        public async Task<IActionResult> YeniUyeAsync(Uyeler u)
        {
            var per = c.Firmas.Where(x => x.id == u.Firma.id).FirstOrDefault();
            u.Firmaid = per.id;
            u.Firma = per;

            if (u.tc == null || u.ad == null || u.soyad == null || u.dogumyil == null || u.mail == null || u.telefon == null)
            {
                return RedirectToAction();
            }
            else
            {
                if (per.mernis_kontrol)
                {

                    var client = new ServiceReference1.KPSPublicSoapClient(ServiceReference1.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                    var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(u.tc), u.ad, u.soyad, Convert.ToInt32(u.dogumyil.Year));
                    var result = response.Body.TCKimlikNoDogrulaResult;
                    if (result)
                    {
                        c.Uyelers.Add(u);
                        c.SaveChanges();


                        return RedirectToAction();
                    }
                    else
                    {
                        return RedirectToAction();
                    }

                }
                else
                {
                    c.Uyelers.Add(u);
                    c.SaveChanges();

                    return RedirectToAction();
                }
            }
            
         

        }

    }
}
