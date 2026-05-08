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
                Genero = "Animación",
                Ano = 2014,
                Plataforma = "Netflix",
                Descripcion = "Basada en la cultura mexicana sobre el día de los murtos, nos cuentan una intrepida aventura de 3 amigos de infancia."
            },
            new Item {
                Id  = 3,
                Titulo = "La chica del siglo XXI",
                Genero = "k-drama",
                Ano = 2022,
                Plataforma = "Netflix",
                Descripcion = "Una chica quiere ayudar a su amiga a descubrir más sobre el chico que le gusta, pero en el intento, ella igual se enamora de un chico y la misión se complica."
            },
            new Item {
                Id  = 4,
                Titulo = "Auque nuestro amor desvanezca a esta noche",
                Genero = "k-drama",
                Ano = 2026,
                Plataforma = "Netflix",
                Descripcion = "Una chica que tiene un problema y un chico que por un reto se declaró a la chica, empiezan a salir, pero las cosas se complican con el tiempo."
            },
            new Item {
                Id  = 5,
                Titulo = "I am Sam",
                Genero = "Drama",
                Ano = 2001,
                Plataforma = "Amazon Prime",
                Descripcion = "Nos muestra una narrativa de un amor incondicional entre un padre y su hija a pesar de las dificultades que se presentan."
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
