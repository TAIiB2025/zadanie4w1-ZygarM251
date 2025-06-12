using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KsiazkaController : ControllerBase
    {
        private static List<Ksiazka> lista = new()
        {
            new Ksiazka { Id = 1, Tytul = "Zbrodnia i kara", Autor = "Fiodor Dostojewski", Gatunek = "Powieść psychologiczna", Rok = 1866 },
            new Ksiazka { Id = 2, Tytul = "Pan Tadeusz", Autor = "Adam Mickiewicz", Gatunek = "Epopeja narodowa", Rok = 1834 },
            new Ksiazka { Id = 3, Tytul = "Rok 1984", Autor = "George Orwell", Gatunek = "Dystopia", Rok = 1949 }
        };

        private static int nextId = 4;

        [HttpGet]
    public ActionResult<IEnumerable<Ksiazka>> Get([FromQuery] string? fraza)
    {
        var wynik = lista;

        if (!string.IsNullOrWhiteSpace(fraza))
        {
            wynik = wynik
            .Where(k => k.Tytul.Contains(fraza, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }
            
        return Ok(wynik);
    }


        [HttpPost]
        public IActionResult Post([FromBody] KsiazkaBody body)
        {
            var ksiazka = new Ksiazka
            {
                Id = nextId++,
                Tytul = body.Tytul,
                Autor = body.Autor,
                Gatunek = body.Gatunek,
                Rok = body.Rok
            };
            lista.Add(ksiazka);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] KsiazkaBody body)
        {
            var ksiazka = lista.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null) return NotFound();

            ksiazka.Tytul = body.Tytul;
            ksiazka.Autor = body.Autor;
            ksiazka.Gatunek = body.Gatunek;
            ksiazka.Rok = body.Rok;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ksiazka = lista.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null) return NotFound();

            lista.Remove(ksiazka);
            return Ok();
        }
    }
}
