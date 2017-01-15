using Microsoft.EntityFrameworkCore;
using Protocol.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Context
{
    public class ProtocolDbContext : DbContext
    {
        public ProtocolDbContext (DbContextOptions<ProtocolDbContext> options) : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Sender> Senders { get; set; }
        //public DbSet<AuthoritySender> AuthoritySenders { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<AuthorityAgreement> AuthorityAgreements { get; set; }
        //public DbSet<Publication> Publications { get; set; }

    }
}
