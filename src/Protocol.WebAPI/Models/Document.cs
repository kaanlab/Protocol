using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int DocumentTypeId { get; set; }
        public int SenderId { get; set; }

        // Project
        public DateTime RegistrationDate { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectDescription { get; set; }
        public bool IsProject { get; set; } = true;
        public string IncomingDocNumber { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }


        // Agreement
        public bool IsApproved { get; set; } = false;

        // Publication
        public DateTime? PublicationDate { get; set; }
        public string PublicationNumber { get; set; }
        public string PublicationSignature { get; set; }
        public string DocFile { get; set; }
        public string PdfFile { get; set; }
        //public bool isPublished { get; set; } = false;

        public DocumentType DocumentType { get; set; }
        public Sender Sender { get; set; }
        public virtual ICollection<Agreement> Agreements { get; set; }
    }
}
