using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class Agreement
    {
        public int AgreementId { get; set; }
        //public int DocumentId { get; set; }
        //public int AuthorityAgreementId { get; set; }
                
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }
        public string AgreementSignature { get; set; }        

        //public virtual Document Document { get; set; }
        public virtual AuthorityAgreement AuthorityAgreement { get; set; }        
    }
}
