using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineMarket.Services;
using OnlineMarket.DAL;
using OnlineMarket.Repositories;

namespace OnlineMarket.Controllers
{
    public class DocumentController : Controller
    {
        DocumentService _documentService;
        UnitOfWork _unitOfWork;

        public DocumentController(DocumentService documentService, UnitOfWork unitOfWork)
        {
            _documentService = documentService;
            _unitOfWork = unitOfWork;
        }
        public ActionResult GetImage(string imageId)
        {
            Document image = _unitOfWork.DocumentRepository.GetByID(imageId);

            return new FileContentResult(image.Content, image.ContentType);
        }
    }
}