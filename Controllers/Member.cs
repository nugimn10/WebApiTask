using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaskWebApiIntro.Controllers
{
    [ApiController]
    [Route("member")]
    public class MemberController : ControllerBase
    {
        private static List<Member> categories = new List<Member>(){
            new Member(){Id=1,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=2,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=3,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=4,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
            new Member(){Id=5,Username="NNbesar", Password="BeTheOneThatYouWantToBe", Email ="nugi.mn@gmail.com", FullName ="Nugi Mulya Nugraha", Popularity ="Very Popular"},
              
        };


        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categories);         
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(categories.Find( e => e.Id == id));
        }
        [HttpPost]
        public IActionResult MemberAdd(Member member)
        {
            var addCategories = new Member(){Id=member.Id, Username = member.Username, Password = member.Password, Email=member.Email, FullName = member.FullName, Popularity = member.Popularity};
            categories.Add(addCategories);

            return Ok(new {Status = "Success", Message ="SUccess Add Data", data =categories});
        }
    }
}
