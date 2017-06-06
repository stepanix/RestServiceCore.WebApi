using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestServiceCore.WebApi.Controllers.Base
{
    public class BaseController : ApiController
    {

        public BaseController()
        {
            
        }

        protected HttpStatusCode NoContent()
        {
            return HttpStatusCode.NoContent;
        }

    }
}
