using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();
       
          public IActionResult Index()
        {
            var about = portfolioContext.Abouts.FirstOrDefault();
            ViewBag.aboutId = about?.AboutId;
            ViewBag.aboutTitle = about?.Title;
            ViewBag.aboutSubdescription = about?.SubDescription;
            ViewBag.aboutDetail = about?.Details;
            return View();
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var values = portfolioContext.Abouts.Find(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            portfolioContext.Abouts.Update(about);
            portfolioContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
