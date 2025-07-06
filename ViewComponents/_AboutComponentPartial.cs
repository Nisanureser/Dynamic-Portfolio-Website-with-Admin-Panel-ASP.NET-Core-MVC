using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
       MyPortfolioContext portfolioContext = new MyPortfolioContext(); 
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutId = portfolioContext.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutTitle=portfolioContext.Abouts.Select(x=>x.Title).FirstOrDefault();
            ViewBag.aboutSubdescription=portfolioContext.Abouts.Select(x=>x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail=portfolioContext.Abouts.Select(x=>x.Details).FirstOrDefault();
            return View();

        }
    }
}
