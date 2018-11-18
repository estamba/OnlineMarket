using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.DAL;
using System.IO;
using System.Data.Entity;

namespace OnlineMarket.Repositories
{
    public class DocumentRepository: GenericRepository<Document>
    {
        DbContext _context;
        public DocumentRepository(DbContext context): base(context)
        {
            this._context = context;
        }
       
    }
}
