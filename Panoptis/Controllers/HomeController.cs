using Panoptis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Panoptis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Makerequest()
        {
            ViewBag.Message = "Request audio visual content";

            WebClient wclient = new WebClient();
            wclient.Encoding = System.Text.Encoding.UTF8;
            string RSSData = wclient.DownloadString("http://www.nicosia.org.cy/el-GR/rss/general/?path=/news/events/&num=200");

            XDocument xml = XDocument.Parse(RSSData);
            var RSSFeedData = (from x in xml.Descendants("item")
                               select new Item
                               {
                                    image = ((string)x.Element("image")),
                                    title = ((string)x.Element("title")),
                                   link = ((string)x.Element("link")),
                                   description = ((string)x.Element("description")),
                                   pubdate = ((string)x.Element("pubDate"))
                               });
            ViewBag.RSSFeed = RSSFeedData;

            return View();
        }

        

        public ActionResult Requestsubmitted()
        {
            ViewBag.Message = "Request submitted successfully";

            return View();
        }
        
        public ActionResult Materialsubmitted()
        {
            ViewBag.Message = "Material submitted successfully";

            return View();
        }

        public ActionResult MyRequests()
        {
            ViewBag.Message = "MyRequests";

            return View();
        }

        public ActionResult Fullfilledrequests()
        {
            ViewBag.Message = "MyRequests";

            return View();
        }

    }
}