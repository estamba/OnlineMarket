using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineMarket.Services
{
    public class CurrentUser
    {
        string _visitorId;
        public string visitorId
        {

            get
            {
                var visitorIdCookie = HttpContext.Current.Request.Cookies["visitorId"];
                if(visitorIdCookie != null)
                {

                    _visitorId = visitorIdCookie.Value;
                }

                return _visitorId;
            }
            set
            {
                HttpContext.Current.Response.Cookies["visitorId"].Value = value;
                HttpContext.Current.Request.Cookies["visitorId"].Expires = DateTime.Now.AddDays(7);


            }
        }

    }
}
