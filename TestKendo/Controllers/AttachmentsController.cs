using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;

using Newtonsoft.Json;
using TestKendo.Models;
using System;
using System.IO;

namespace TestKendo.Controllers
{
    [RoutePrefix("api/attachment")]
    public class AttachmentsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("save")]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var metaData = httpRequest.Form.Get("supportingInfo");
                var attachment = JsonConvert.DeserializeObject<Attachment>(metaData);
                attachment.DateAdded = DateTime.UtcNow;

                using (MemoryStream ms = new MemoryStream())
                {
                    postedFile.InputStream.CopyTo(ms);
                    attachment.Bytes = ms.ToArray();
                }

                var y = "";
                // NOTE: To store in memory use postedFile.InputStream
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}