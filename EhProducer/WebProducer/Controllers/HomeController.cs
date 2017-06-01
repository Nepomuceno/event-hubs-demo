using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.ServiceBus.Messaging;
using UAParser;

namespace WebProducer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessages(string messages, int times)
        {
            var parser = Parser.GetDefault();
            if (times > 0 && times < 100)
            {
                var device = parser.ParseOS(Request.UserAgent).Family;
                var connectionString = "EhConnectionString";
                var client = EventHubClient.CreateFromConnectionString(connectionString);
                for (int i = 0; i < times; i++)
                {
                    
                    client.Send(new EventData(Encoding.UTF8.GetBytes($"{messages} from ip : {Request.UserHostAddress} with: {device}")));
                    Console.WriteLine($"{i} number");
                }

            }
            return Redirect("/");
        }
    }
}