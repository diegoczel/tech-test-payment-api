using Microsoft.AspNetCore.Mvc;
using PottencialApi.Application.Interfaces;
using PottencialApi.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace PottencialApi.WebUI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetProdutos();

            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoDTO produto)
        {
            if(ModelState.IsValid)
            {
                await _produtoService.CreateAsync(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);

            if (produto is null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.UpdateAsync(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);

            if (produto is null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        public async Task<ActionResult> Deletar(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);

            if (produto is null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [HttpPost, ActionName(nameof(Deletar))]
        public async Task<ActionResult> DeletarById(int id)
        {
            await _produtoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
