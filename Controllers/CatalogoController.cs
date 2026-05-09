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
                Ano = 2009,
                Plataforma = "Disney",
                Descripcion = "Una chica con el sueño de abrir un restaurante, se convierte en un sapo por culpa de una estrella..."
            },
            new Item {
                Id = 2,
                Titulo = "El libro de la vida",
                Genero = "Hack and Slash",
                Ano = 2014,
                Plataforma = "Netflix",
                Descripcion = "Basada en las tradiciones mexicanan nos cuentan un poco de su cultura con 3 intrepidos protagonistas."
            },
            new Item {
                Id  = 3,
                Titulo = "La chica del siglo XXI",
                Genero = "kdrama",
                Ano = 2001,
                Plataforma = "Netflix",
                Descripcion = "Unos adolecentes que entre amistades, peleas y malentendidos hacen que el amor florezca..."
            },
            new Item {
                Id  = 4,
                Titulo = "Auque nuestro amor desvanezca a medianoche",
                Genero = "kdrama",
                Ano = 2001,
                Plataforma = "Netflix",
                Descripcion = "Una chica que se le olvida que hizo el día anteriro y un chavo que quiere hacerle vivir cada día memorable..."
            },
            new Item {
                Id  = 5,
                Titulo = "I am Sam",
                Genero = "Drama",
                Ano = 2001,
                Plataforma = "Amazon Prime",
                Descripcion = "Nos muestra como el amor de un padre va más alla de los probleas que uno puede pacer en la vida."
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
