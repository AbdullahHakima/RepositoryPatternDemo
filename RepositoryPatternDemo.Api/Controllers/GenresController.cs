using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Core.Consts;
using RepositoryPatternDemo.Core.Interfaces;
using RepositoryPatternDemo.Core.Models;

namespace RepositoryPatternDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Genres.GetById(id));
        }

        [HttpGet("GetAllByOrder")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Genres.FindAll(g=>g.Name.Contains("a"), null,g=>g.Id,OrderBy.Decending ));
        }

        [HttpPost("AddOne")]
        public IActionResult Add(Genre genre)
        {
            if (ModelState.IsValid)
            {
                var newgenre = _unitOfWork.Genres.Add(genre);
                _unitOfWork.Complete();
                return Ok(newgenre);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("AddRange")]
        public IActionResult AddRange(IEnumerable<Genre> genreList) 
        {

            IEnumerable<Genre> genres= _unitOfWork.Genres.AddRange(genreList);
            _unitOfWork.Complete();
            return Ok(genres);
        }
    }
}
