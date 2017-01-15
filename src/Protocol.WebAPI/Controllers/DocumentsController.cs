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
    public class DocumentsController : Controller
    {
        public IDbRepository _repository { get; set; }

        public DocumentsController(IDbRepository repository)
        {
            _repository = repository;
        }
        
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Document>> Get()
        {
            return await _repository.GetAllDocuments();
        }

        //[HttpGet]
        //public async Task<IEnumerable<Document>> Get(string published)
        //{
        //    return await _repository.FindPublished();
        //}

        // GET api/values/5
        [HttpGet("{id}", Name = "GetDocument")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var documentToFind = await _repository.FindDocument(id);
            if (documentToFind == null)
                return NotFound();
            return new ObjectResult(documentToFind);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Document document)
        {
            try
            {
                
                //var sender = new Sender
                //{
                //    SenderId = document.Sender.SenderId,
                //    AuthoritySender = document.Sender.AuthoritySender
                //};

                //var documentType = new DocumentType
                //{
                //    DocumentTypeId = document.DocumentType.DocumentTypeId,
                //    Name = document.DocumentType.Name
                //};

                //var doc = new Document
                //{
                //    DocumentType = documentType,
                //    ProjectNumber = document.ProjectNumber,
                //    RegistrationDate = document.RegistrationDate
                    
                    
                //};
                //_repository.AddDocumentType(documentType);

                //var newDocument = new Document
                //{

                //    DocumentType = documentType,
                //    RegistrationDate = document.RegistrationDate,
                //    ProjectNumber = document.ProjectNumber,
                //    ProjectDescription = document.ProjectDescription
                //};


                await _repository.AddDocument(document);

                return CreatedAtRoute("GetDocument", new { id = document.DocumentId }, document);
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
