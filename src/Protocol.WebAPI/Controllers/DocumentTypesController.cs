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
    public class DocumentTypesController : Controller
    {
        public IDbRepository _repository { get; set; }

        public DocumentTypesController(IDbRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<DocumentType>> Get()
        {
            return await _repository.GetAllDocTypes();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetDocType")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var docTypeToFind = await _repository.FindDocType(id);
            if (docTypeToFind == null)
                return NotFound();
            return new ObjectResult(docTypeToFind);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DocumentType docType)
        {
            try
            {
                await _repository.AddDocType(docType);

                return CreatedAtRoute("GetDocument", new { id = docType.DocumentTypeId }, docType);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
