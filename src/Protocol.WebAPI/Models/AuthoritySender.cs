using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class AuthoritySender
    {
        public int AuthoritySenderId { get; set; }
        public string Name { get; set; }

        //public ICollection<Sender> Senders { get; set; }
    }
}
