using CadastroLivros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CadastroLivros.Controllers
{
    public class LivrosController : Controller
    {
        // Lista estática simulando banco de dados
        private static List<Livro> livros = new List<Livro>
        {
            new Livro { Id = 1, Titulo = "Dom Casmurro", Autor = "Machado de Assis", Ano = 1899, ImagemUrl = "https://ia601804.us.archive.org/view_archive.php?archive=/17/items/olcovers649/olcovers649-L.zip&file=6491476-L.jpg" },
            new Livro { Id = 2, Titulo = "O Pequeno Príncipe", Autor = "Antoine de Saint-Exupéry", Ano = 1943, ImagemUrl= "https://covers.openlibrary.org/b/id/12372681-L.jpg" },
            new Livro { Id = 3, Titulo = "1984", Autor = "George Orwell", Ano = 1949, ImagemUrl= "https://m.media-amazon.com/images/I/51feD87yuEL._SY445_SX342_.jpg" },
            new Livro { Id = 4, Titulo = "De Zero a Um", Autor = "Peter Thiel", Ano = 2014, ImagemUrl="data:image/jpeg;base64,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" },
            new Livro { Id = 5, Titulo = "A Estratégia do Oceano Azul", Autor = "W. Chan Kim & Renée Mauborgne", Ano = 2005, ImagemUrl="https://m.media-amazon.com/images/I/51d44v-GHYL._SY445_SX342_.jpg" },
            new Livro { Id = 6, Titulo = "Mindset: A Nova Psicologia do Sucesso", Autor = "Carol S. Dweck", Ano = 2006, ImagemUrl="https://m.media-amazon.com/images/I/41suUFbw-eL._SY445_SX342_.jpg" }
        };

        public IActionResult Index()
        {
            return View(livros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Livro livro)
        {
            livro.Id = livros.Count + 1;
            livros.Add(livro);
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);
            if (livro == null) return NotFound();
            return View(livro);
        }
    }
}
