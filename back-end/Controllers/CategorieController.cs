using back_end.Data;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategorieController : Controller
    {
        public CategorieController()
        {

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categories>> Post([FromServices] DataContext context, [FromBody] Categories model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categories categorie = new Categories()
            {
                Name = model.Name,
                DateCreate = model.DateCreate,
                Department = model.Department,
            };

            context.Categories.Add(categorie);
            await context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpGet]
        public async Task<ActionResult<List<Categories>>> GetCategories([FromServices] DataContext context)
        {
            List<Categories> categories = await context.Categories.ToListAsync();

            return Ok(categories);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Categories>> Delete([FromServices] DataContext context, int id)
        {
            Categories categorie = await context.Categories.FirstOrDefaultAsync(f => f.Id == id);

            if (categorie == null)
                return NotFound();

            context.Categories.Remove(categorie);
            await context.SaveChangesAsync();

            return Ok(categorie);
        }

    }
}
