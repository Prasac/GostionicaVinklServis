using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;



namespace VinklWebService 
{
    public class tjedniMenu : IHttpHandler
    {
        MenuConnectionTableAdapters.TjedniMenuTableAdapter tableAdapterTjedniMenu;
        MenuConnection.TjedniMenuDataTable dataTableTjedniMenu;

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

                        tableAdapterTjedniMenu = new MenuConnectionTableAdapters.TjedniMenuTableAdapter();

                        dataTableTjedniMenu = tableAdapterTjedniMenu.GetData();
                        var v = new { tjedniMenu = dataTableTjedniMenu };
                        string json = string.Empty;
                        json = JsonConvert.SerializeObject(v);
                        HttpContext.Current.Response.Write(json);

                        break;

                    default:

                        break;
                }

            }
            catch(Exception e)
            {
                HttpContext.Current.Response.Write("Došlo je do pogreške u web servisu!");
            }
        }
    }
}
