using OnlineMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using OnlineMarket.DAL;
using OnlineMarket.Repositories;

namespace OnlineMarket.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("images")]
    public class ImageController : ApiController
    {
        private DocumentRepository _DocumentRepository;

        public ImageController(DocumentRepository documentRepository)
        {
            this._DocumentRepository = documentRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> GetById(Guid id)
        {
            var document = await _DocumentRepository.GetByIDAsync(id);
            if (document != null && document.ContentType.Contains("image/"))
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(new MemoryStream(document.Content));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(document.ContentType);
                return result;
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        /*
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> SaveImages()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                Document document = new Document()
                {
                    Content = await file.ReadAsByteArrayAsync(),
                    ContentType = file.Headers.ContentType.MediaType,
                    Extension = Path.GetExtension(filename),
                    Name = filename,
                    Id = Guid.NewGuid()
                };

                _DocumentRepository.Insert(document);
                await _DocumentRepository.SaveChangesAsync();
            }

            return Ok();
        }
        */
    }
}
