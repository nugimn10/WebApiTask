using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaskWebApiIntro.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoriesControler : ControllerBase
    {
        private static List<Categories> categories = new List<Categories>(){
            new Categories(){Id=1,Name="Tulang Ekor", Description="Tulang ekor yang seperti buntut tapi literaly bukan"},
            new Categories(){Id=2,Name="Tulang Kering", Description="Tulang yang basah tapi gak tau kenapa di sebut kering"},
            new Categories(){Id=3,Name="Tulang Lunak", Description="tulang ini banyak betebaran di lampu merah"},
            new Categories(){Id=4,Name="Tulang Tak Nampak", Description="kalau tulang tak nampak biasanya dia lagi pergi main"},
            new Categories(){Id=5,Name="Tulang Punggung", Description="Aku padamu(hoeek)"}
        };


        private readonly ILogger<CategoriesControler> _logger;

        public CategoriesControler(ILogger<CategoriesControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Ge()
        {
            return Ok(categories);         
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(categories.Find( e => e.Id == id));
        }
        [HttpPost]
        public IActionResult ContactAdd(Categories category)
        {
            var addCategories = new Categories(){Id=category.Id, Name = category.Name, Description = category.Description};
            categories.Add(addCategories);

            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =categories});
        }
    }
}
