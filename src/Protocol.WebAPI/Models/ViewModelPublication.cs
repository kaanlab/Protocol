using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class ViewModelPublication
    {
        public string RegistrationNumber { get; set; }
        public string Signature { get; set; }
        public IFormFile DocFile { get; set; }
    }
}
