using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_NetCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly ICategoryService _service;

        public ProductsController(ICategoryService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _service.ListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategories(string id)
        {
            var response = await _service.GetAsync(id);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> PostCategories([FromBody] CategoryRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetCategories", new
            {
                id = response.Result
            }, response);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutCategories(string id, [FromBody] CategoryRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

    }
}
