using KCMS.GestaoDeProdutos.Application.DTO.Input;
using KCMS.GestaoDeProdutos.Application.DTO.Output;
using KCMS.GestaoDeProdutos.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KCMS.GestaoDeProdutos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }
        [HttpPost]
        public async Task<IActionResult> CriarCategoria(CategoriaInput categoriaInput)
        {
            await _categoriaAppService.Create(categoriaInput);
            return StatusCode(200, new { message = "Categoria cadastrada com sucesso" });
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarCategoria(CategoriaOutput categoriaOutput)
        {
            await _categoriaAppService.Update(categoriaOutput);
            return StatusCode(200, new { message = "Categoria atualizada com sucesso" });
        }
        [HttpPost]
        public async Task<IActionResult> RemoverCategoria(Guid id)
        {
            var categoria = await _categoriaAppService.GetById(id);
            if (categoria == null) return NotFound();
            _categoriaAppService.Delete(categoria);
            return StatusCode(200, new { message="Categoria removida com sucesso" });
            
        }
        [HttpPost]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias = await _categoriaAppService.GetAll();
            return StatusCode(200,categorias);
        }
        [HttpPost]
        public async Task<CategoriaOutput> GetCategoriaByID(Guid id)
        {
            var categoria = await _categoriaAppService.GetById(id);
            return categoria;
        }
       


    }
}
