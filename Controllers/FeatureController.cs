using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class FeatureController : Controller
    {
        MyPortfolioContext context=new MyPortfolioContext();
        public IActionResult Index()
        {
            var values=context.Features.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var values=context.Features.Find(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature feature)
        {
            context.Features.Update(feature);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
