using Microsoft.AspNetCore.Mvc;
using ListaDeDesenhos.Models;

namespace ListaDeDesenhos.Controllers
{
    public class DesenhosController : Controller
    {
        private static List<Desenho> desenhos = new();

        public IActionResult Index(string searchString)
        {
            var lista = string.IsNullOrEmpty(searchString)
                ? desenhos
                : desenhos.Where(d => d.Titulo.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(lista);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Desenho desenho)
        {
            desenho.Id = desenhos.Count + 1;
            desenhos.Add(desenho);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var desenho = desenhos.FirstOrDefault(d => d.Id == id);
            if (desenho == null) return NotFound();
            return View(desenho);
        }

        [HttpPost]
        public IActionResult Edit(Desenho desenho)
        {
            var existente = desenhos.FirstOrDefault(d => d.Id == desenho.Id);
            if (existente == null) return NotFound();

            existente.Titulo = desenho.Titulo;
            existente.Data = desenho.Data;
            existente.Material = desenho.Material;
            existente.Descricao = desenho.Descricao;
            existente.NotaDesempenho = desenho.NotaDesempenho;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var desenho = desenhos.FirstOrDefault(d => d.Id == id);
            if (desenho == null) return NotFound();
            return View(desenho);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmado(int id)
        {
            var desenho = desenhos.FirstOrDefault(d => d.Id == id);
            if (desenho != null) desenhos.Remove(desenho);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var desenho = desenhos.FirstOrDefault(d => d.Id == id);
            if (desenho == null) return NotFound();
            return View(desenho);
        }
    }
}
