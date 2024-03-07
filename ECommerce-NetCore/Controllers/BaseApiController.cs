using ECommerce_NetCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_NetCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        List<Category> caterogyListServicio = new();

        public BaseApiController()
        {
            Category category = new Category();
            category.Id = Guid.NewGuid().ToString();
            category.Name = "Categoria 1";

            Category category2 = new Category();
            category2.Id = Guid.NewGuid().ToString();
            category2.Name = "Categoria 2";


            Category category3 = new Category();
            category3.Id = Guid.NewGuid().ToString();
            category3.Name = "Categoria 3";


            caterogyListServicio.Add(category);
            caterogyListServicio.Add(category2);
            caterogyListServicio.Add(category3);

        }

        /*[HttpGet]
        public List<Category> GetCategory()
        {
            return caterogyList;
        }*/

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(caterogyListServicio);
        }


       [HttpGet]
        [Route("{name}")]
        public IActionResult GetCategory(string name)
        {
            var result = caterogyListServicio.FirstOrDefault(x => x.Name == name);
                
                //Where(p => p.Id == id).ToList();

            if (result == null)
            {
                return BadRequest(result);
            }
            else {

                return Ok(result);
            }
        }


    }
}
