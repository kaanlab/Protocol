using Protocol.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Models
{
    public interface IDbRepository
    {
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> FindDocument(int id);
       // Task<IEnumerable<Document>> FindPublished();
        Task AddDocument(Document document);
        Task UpdateDocument(Document document);
        Task DeleteDocument(int id);

        // ############################################

        Task<IEnumerable<DocumentType>> GetAllDocTypes();
        Task<DocumentType> FindDocType(int id);
        Task AddDocType(DocumentType documentType);
        Task UpdateDocType(DocumentType documentType);
        Task DeleteDocType(int id);

        // ############################################

        Task<IEnumerable<Sender>> GetAllSenders();
        Task<Sender> FindSender(int id);
        Task AddSender(Sender sender);
        Task UpdateSender(Sender sender);
        Task DeleteSender(int id);
    }
}
