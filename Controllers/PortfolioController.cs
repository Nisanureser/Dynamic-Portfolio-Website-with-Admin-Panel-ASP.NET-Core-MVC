using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioUdemy.Controllers
{
    public class PortfolioController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();

        public IActionResult Index()
        {
            var values = context.Portfolios.ToList();
            return View(values);
        }

        public IActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Resmi kaydedin
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                portfolio.ImageUrl = "/images/" + imageFile.FileName;
            }
            else
            {
                // Varsayılan bir resim URL'si atayabilirsiniz
                portfolio.ImageUrl = "/images/default.jpg";
            }

            context.Portfolios.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = context.Portfolios.Find(id);
            if (value != null)
            {
                // Resmi silmek istiyorsanız, önce resmi dosya sisteminden silin
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Path.GetFileName(value.ImageUrl.TrimStart('/')));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                context.Portfolios.Remove(value);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = context.Portfolios.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio, IFormFile imageFile)
        {
            var existingPortfolio = context.Portfolios.Find(portfolio.PortfolioId);

            if (existingPortfolio == null)
            {
                return NotFound();
            }

            // Bilgileri güncelle
            existingPortfolio.Title = portfolio.Title;
            existingPortfolio.SubTitle = portfolio.SubTitle;
            existingPortfolio.Url = portfolio.Url;
            existingPortfolio.Description = portfolio.Description;

            // Eğer yeni bir resim yüklendiyse
            if (imageFile != null && imageFile.Length > 0)
            {
                // Eski resmi sil
                if (!string.IsNullOrEmpty(existingPortfolio.ImageUrl))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingPortfolio.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Yeni resmi kaydet
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                existingPortfolio.ImageUrl = "/images/" + imageFile.FileName;
            }
            // Eğer yeni resim yüklenmediyse, eski resim kalacak.

            context.Portfolios.Update(existingPortfolio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
