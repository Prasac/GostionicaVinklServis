using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace VinklWebService
{
    class menu : IHttpHandler
    {
        aLaCarteConnectionTableAdapters.MenuTableAdapter taAlaCarte;
        aLaCarteConnection.MenuDataTable dtAlaCarte;

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                switch (context.Request.HttpMethod)
                {
                    case "POST":
                        break;
                    case "GET":
                        taAlaCarte = new aLaCarteConnectionTableAdapters.MenuTableAdapter();
                        dtAlaCarte = taAlaCarte.GetaLaCarte();
                        var v = new { menu = dtAlaCarte };
                        string json = string.Empty;
                        json = JsonConvert.SerializeObject(v);
                        HttpContext.Current.Response.Write(json);

                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("Došlo je do pogreške u web servisu!");
            }
        }
    }
}
