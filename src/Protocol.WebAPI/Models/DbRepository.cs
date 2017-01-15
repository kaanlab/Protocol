using Microsoft.EntityFrameworkCore;
using Protocol.WebAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public class DbRepository : IDbRepository
    {
        private readonly ProtocolDbContext _context;

        public DbRepository(ProtocolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document>> GetAllDocuments() =>
           await _context.Documents
                         .Include(d => d.DocumentType)
                         .Include(s => s.Sender)
                            //.ThenInclude(sender => sender.AuthoritySender)
                         .Include(a => a.Agreements)
                            .ThenInclude(agreement => agreement.AuthorityAgreement)
                         .OrderByDescending(date => date.RegistrationDate)
                         .AsNoTracking()
                         .ToListAsync();

        public async Task<Document> FindDocument(int id) =>
            await _context.Documents
                          .Where(d => d.DocumentId == id)
                          .Include(d => d.DocumentType)
                          .Include(s => s.Sender)
                            //.ThenInclude(sender => sender.AuthoritySender)
                          .Include(a => a.Agreements)
                            .ThenInclude(agreement => agreement.AuthorityAgreement)
                          .AsNoTracking()
                          .SingleOrDefaultAsync();

        //public async Task<IEnumerable<Document>> FindPublished() =>
        //    await _context.Documents
        //                  .Where(d => d.isPublished == true)
        //                  .Include(d => d.DocumentType)
        //                  .Include(s => s.Sender)
        //                  //.ThenInclude(sender => sender.AuthoritySender)
        //                  .Include(a => a.Agreements)
        //                    .ThenInclude(agreement => agreement.AuthorityAgreement)
        //                  .AsNoTracking()
        //                  .OrderByDescending(date => date.RegistrationDate)
        //                  .AsNoTracking()
        //                  .ToListAsync();

        public async Task AddDocument(Document document)
        {
            _context.Add(document);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument(int id)
        {
            var documentToDelete = await _context.Documents
                                                 .Where(d => d.DocumentId == id)
                                                 .Include(s => s.Sender)
                                                 .Include(a => a.Agreements)
                                                 .SingleOrDefaultAsync();

            _context.Documents.Remove(documentToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateDocument(Document document)
        {
            _context.Documents.Update(document);

            await _context.SaveChangesAsync();
        }

        //public async Task AddDocWithDocType()
        //{

        //}

        //#################################################################

        public async Task<IEnumerable<DocumentType>> GetAllDocTypes() =>
          await _context.DocumentTypes.ToListAsync();

        public async Task<DocumentType> FindDocType(int id) =>
            await _context.DocumentTypes
                          .Where(dt => dt.DocumentTypeId == id)
                          .SingleOrDefaultAsync();

        public async Task AddDocType(DocumentType docType)
        {
            _context.DocumentTypes.Add(docType);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocType(int id)
        {
            var docTypeToDelete = await _context.DocumentTypes
                                                 .Where(dt => dt.DocumentTypeId == id)                                                 
                                                 .SingleOrDefaultAsync();

            _context.DocumentTypes.Remove(docTypeToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateDocType(DocumentType docType)
        {
            _context.DocumentTypes.Update(docType);

            await _context.SaveChangesAsync();
        }

        //###########################################################
        public async Task<IEnumerable<Sender>> GetAllSenders() =>
                await _context.Senders.ToListAsync();

        public async Task<Sender> FindSender(int id) =>
            await _context.Senders
                          .Where(s => s.SenderId == id)
                          .SingleOrDefaultAsync();

        public async Task AddSender(Sender sender)
        {
            _context.Senders.Add(sender);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSender(int id)
        {
            var senderToDelete = await _context.Senders
                                                 .Where(s => s.SenderId == id)
                                                 .SingleOrDefaultAsync();

            _context.Senders.Remove(senderToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSender(Sender sender)
        {
            _context.Senders.Update(sender);

            await _context.SaveChangesAsync();
        }

    }
}
