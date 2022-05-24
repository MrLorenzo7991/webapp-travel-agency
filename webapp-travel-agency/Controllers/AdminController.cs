using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            List<PacchettoViaggio> listaPacchetti = new List<PacchettoViaggio>();
            using(TravelContext db = new TravelContext())
            {
                listaPacchetti = db.PacchettiViaggio.ToList();
            }
            return View("Admin", listaPacchetti);
        }
        public ActionResult Details(int id)
        {
            using(TravelContext db = new TravelContext())
            {
                try
                {
                    PacchettoViaggio pacchettoTrovato = db.PacchettiViaggio.Where(pacchetto => pacchetto.Id == id).FirstOrDefault();
                    return View("Details", pacchettoTrovato);
                }
                catch(InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PacchettoViaggio nuovoPacchetto)
        {
            using(TravelContext db = new TravelContext())
            {
                if (!ModelState.IsValid)
                {
                    return View(nuovoPacchetto);
                }
                PacchettoViaggio pacchettoDaAggiungere = new PacchettoViaggio();
                pacchettoDaAggiungere.Nome = nuovoPacchetto.Nome;
                pacchettoDaAggiungere.UrlImmagine = nuovoPacchetto.UrlImmagine;
                pacchettoDaAggiungere.GiorniDiViaggio = nuovoPacchetto.GiorniDiViaggio;
                pacchettoDaAggiungere.DescrizioneBreve = nuovoPacchetto.DescrizioneBreve;
                pacchettoDaAggiungere.DescrizioneCompleta = nuovoPacchetto.DescrizioneCompleta;
                pacchettoDaAggiungere.Prezzo = nuovoPacchetto.Prezzo;   
                db.Add(pacchettoDaAggiungere);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            using (TravelContext db = new TravelContext())
            {
                try
                {
                    PacchettoViaggio pacchettoTrovato = db.PacchettiViaggio.Where(pacchetto => pacchetto.Id == id).FirstOrDefault();
                    return View("Edit", pacchettoTrovato);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PacchettoViaggio pacchetto)
        {
            using (TravelContext db = new TravelContext())
            {
                try
                {
                    PacchettoViaggio pacchettoTrovato = db.PacchettiViaggio.Where(pacchetto => pacchetto.Id == id).FirstOrDefault();
                    if (!ModelState.IsValid)
                    {
                        return View("Edit", pacchettoTrovato);
                    }
                
                    pacchettoTrovato.Nome = pacchetto.Nome;
                    pacchettoTrovato.UrlImmagine = pacchetto.UrlImmagine;
                    pacchettoTrovato.GiorniDiViaggio = pacchetto.GiorniDiViaggio;
                    pacchettoTrovato.DescrizioneBreve = pacchetto.DescrizioneBreve;
                    pacchettoTrovato.DescrizioneCompleta = pacchetto.DescrizioneCompleta;
                    pacchettoTrovato.Prezzo = pacchetto.Prezzo;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (TravelContext db = new TravelContext())
            {
                try
                {
                    PacchettoViaggio pacchettoDaEliminare = db.PacchettiViaggio.Where(pacchetto => pacchetto.Id == id).FirstOrDefault();
                    db.Remove(pacchettoDaEliminare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
    }
}
