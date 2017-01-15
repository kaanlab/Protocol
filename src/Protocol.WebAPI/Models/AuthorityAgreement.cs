using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class AuthorityAgreement
    {
        public int AuthorityAgreementId { get; set; }
        public string Name { get; set; }

        //public ICollection<Agreement> Agreements { get; set; }
    }
}
