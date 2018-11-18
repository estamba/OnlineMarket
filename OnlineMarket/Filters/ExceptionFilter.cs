using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Filters
{
    public class CustomExceptionFilter: HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}