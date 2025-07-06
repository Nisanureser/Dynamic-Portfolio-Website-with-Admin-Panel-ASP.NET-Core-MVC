using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();
       public IViewComponentResult Invoke()
        {
            //var values=context.Features.ToList();
            ViewBag.featureTitle = context.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.featureDescription = context.Features.Select(x => x.Description).FirstOrDefault();

            var socialIcons = context.SocialMedias.ToList();
            return View(socialIcons);
            //return View();
        }

    }
}
