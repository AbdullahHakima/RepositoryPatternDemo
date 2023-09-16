using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Core.Interfaces;
using RepositoryPatternDemo.Core.Models;

namespace RepositoryPatternDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
           
            return Ok(_unitOfWork.Movies.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            return Ok(_unitOfWork.Movies.GetAll());
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByName(string Title)
        {
            return Ok(_unitOfWork.Movies.Find(m=>m.Title == Title, new[] {"Genre"}));
        }

        [HttpGet("GetAllByYear")]
        public IActionResult FindAll(int year)
        {
            return Ok(_unitOfWork.Movies.FindAll(m=>m.Year == year, new[] {"Genre"} ));
        }
    }
}
