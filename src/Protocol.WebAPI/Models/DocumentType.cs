using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }

        public string Name { get; set; }

        //public ICollection<Document> Documents { get; set; }
    }
}
