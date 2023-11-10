using KCMS.GestaoDeProdutos.Application.DTO.Input;
using KCMS.GestaoDeProdutos.Application.DTO.Output;
using KCMS.GestaoDeProdutos.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KCMS.GestaoDeProdutos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto(ProdutoInput produtoInput)
        {
            await _produtoAppService.Create(produtoInput);
            return StatusCode(200, new { message = "Produto cadastrado com sucesso" });
        }
        [HttpPost]
        public async Task<IActionResult> AtualizarProduto(ProdutoOutput produtoOutput)
        {
            await _produtoAppService.Update(produtoOutput);
            return StatusCode(200, new { message = "Produto atualizado com sucesso" });
        }
        [HttpPost]
        public async Task<IActionResult> RemoverProduto(Guid id)
        {
            var produto = await _produtoAppService.GetById(id);
            if(produto == null) return NotFound();
            _produtoAppService.Delete(produto);
            return StatusCode(200, new { message = "Produto removido com sucesso" });
        }
        [HttpPost]
        public async Task<IActionResult> GetProdutoByID(Guid id)
        {
            var produto = await _produtoAppService.GetById(id);
            return StatusCode(200,produto);
        }

        [HttpPost]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _produtoAppService.GetAll();
            return StatusCode(200, produtos);
        }
        [HttpPost]
        public async Task<IActionResult> ListarProdutosByCategoriaId(Guid id)
        {
            var produtos = await _produtoAppService.GetByCategoriaId(id);
            return StatusCode(200, produtos);
        }

    }
}
