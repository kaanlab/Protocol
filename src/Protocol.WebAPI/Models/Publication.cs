using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class Publication
    {
        public int PublicationId { get; set; }
        public int DocumentId { get; set; }

        public DateTime Date { get; set; }
        public string RegistrationNumber { get; set; }
        public string Signature { get; set; }
        public string DocFile { get; set; }
        public string PdfFile { get; set; }

        public Document Document { get; set; }
    }
}
