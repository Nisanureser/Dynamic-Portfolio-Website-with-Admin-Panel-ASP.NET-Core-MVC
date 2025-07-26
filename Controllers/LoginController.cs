using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;


namespace MyPortfolioUdemy.Controllers
{
    public class LoginController : Controller
    {
        MyPortfolioContext context=new MyPortfolioContext();
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult AdminList()
        {
            var values =context.Logins.ToList();    
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAdmin() {
            return View();

        }
        [HttpPost]
        public IActionResult CreateAdmin(Login login)
        {
            context.Logins.Add(login);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
        public IActionResult DeleteAdmin(int id)
        {
            var value = context.Logins.Find(id);
            context.Logins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var value = context.Logins.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(Login login)
        {
            context.Logins.Update(login);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
        [HttpPost]
        public IActionResult LoginControl(string username, string password)
        {
            var admin = context.Logins.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (admin != null)
            {
                // Başarılı giriş → AdminList sayfasına git
                return RedirectToAction("AdminList");
            }

            // Hatalı giriş → Hata mesajı göster
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View("Index");
        }





    }
}
