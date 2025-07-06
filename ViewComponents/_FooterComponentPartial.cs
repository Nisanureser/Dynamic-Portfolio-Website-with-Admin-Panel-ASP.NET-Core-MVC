using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        MyPortfolioContext context=new MyPortfolioContext();
        public IViewComponentResult Footer()
        {
            return View();

        }
        public IViewComponentResult Invoke()
        {
            var socialMediaList = context.SocialMedias.ToList();
            return View(socialMediaList); // default.cshtml'e bu liste gidecek
        }
    }
}
