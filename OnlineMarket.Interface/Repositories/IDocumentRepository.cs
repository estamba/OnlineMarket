using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Interface.Repositories
{
    public interface IDocumentRepository
    {
        Document SaveDocument(Stream stream, string fileName, string contentType);
        Task<Document> SaveDocumentAsync(Stream stream, string fileName, string contentType);
        Document UpdateDocument(Document document);
        Task<Document> UpdateDocumentAsync(Document document);
        Document DeleteDocument(Guid id);
        Task<Document> DeleteDocumentAsync(Guid id);
        Document GetDocument(Guid id);
        Task<Document> GetDocumentAsync(Guid id);
    }
}
