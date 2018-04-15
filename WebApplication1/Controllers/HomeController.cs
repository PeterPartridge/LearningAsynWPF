using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            try
            {
                var client = new HttpClient();
               var httpMessage = await client.GetAsync("http://www.filipekberg.se/rss/").ConfigureAwait(false);

                var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
               
                return Content(content);
            }
            catch(Exception ex)
            {

            }


            return View();
        }
    }
}