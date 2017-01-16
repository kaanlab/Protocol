using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Protocol.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Protocol.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PublishedController : Controller
    {
        public IDbRepository _repository { get; set; }

        public PublishedController(IDbRepository repository)
        {
            _repository = repository;
        }
        // GET: api/values        
        [HttpGet]
        public async Task<IEnumerable<Document>> Get()
        {
             return await _repository.GetAllPublished();             
        }
    }
}
