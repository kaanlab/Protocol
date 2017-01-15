﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Protocol.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Protocol.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SendersController : Controller
    {
        public IDbRepository _repository { get; set; }

        public SendersController(IDbRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Sender>> Get()
        {
            return await _repository.GetAllSenders();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var senderToFind = await _repository.FindSender(id);
            if (senderToFind == null)
                return NotFound();
            return new ObjectResult(senderToFind);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
