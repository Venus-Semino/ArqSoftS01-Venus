using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;
namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        private static List<Item> _items = new()
        {
            new Item {
                Id = 1,
                Titulo = "La princesa y el sapo",
                Genero = "Animación",
                Ano = 2001,
                Plataforma = "Disney",
                Descripcion = "Videojuego que trata de un cazador..."
            },
            new Item {
                Id = 2,
                Titulo = "El libro de la vida",
                Genero = "Hack and Slash",
                Ano = 2001,
                Plataforma = "Netflix",
                Descripcion = "Videojuego que trata de un cazador..."
            },
            new Item {
                Id  = 3,
                Titulo = "La chica del siglo XXI",
                Genero = "Hack and Slash",
                Ano = 2001,
                Plataforma = "Netflix",
                Descripcion = "Videojuego que trata de un cazador..."
            },
            new Item {
                Id  = 4,
                Titulo = "Auque nuestro amor desvanezca a medianoche",
                Genero = "Hack and Slash",
                Ano = 2001,
                Plataforma = "Netflix",
                Descripcion = "Videojuego que trata de un cazador..."
            },
            new Item {
                Id  = 5,
                Titulo = "I am Sam",
                Genero = "Drama",
                Ano = 2001,
                Plataforma = "Amazon Prime",
                Descripcion = "Videojuego que trata de un cazador..."
            },

        };
        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList();
            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;
            return View(resultado);
        }
        // Detalle
        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }
        // Formulario — GET
        public IActionResult Agregar()
        {
            return View();
        }
        // Formulario — POST
        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}
