using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class Sender
    {
        public int SenderId { get; set; }
        public string Name { get; set; }
        //public int AuthoritySenderId { get; set; }

        //public string DocumentNumber { get; set; }        
        //public string ContactPerson { get; set; }
        //public string ContactPhone { get; set; }

        //public ICollection<Document> Documents { get; set; }
        //public virtual AuthoritySender AuthoritySender { get; set; }        
    }
}
