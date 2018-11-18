using OnlineMarket.Common.Utilities;
using OnlineMarket.DAL;
using OnlineMarket.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineMarket.Services
{
    public class DocumentService
    {
        private UnitOfWork _UnitOfWork;

        public DocumentService(UnitOfWork uow)
        {
            this._UnitOfWork = uow;
        }

        public Task<Document> GetDocumentAsync(Guid id)
        {
            return _UnitOfWork.DocumentRepository.GetByIDAsync(id);
        }
        public List<Document> GetDocumentByItemID(int ItemID)
        {

            return _UnitOfWork.DocumentRepository.Get(x => x.Items.Any(a => a.Id == ItemID));
        }
    }
}
