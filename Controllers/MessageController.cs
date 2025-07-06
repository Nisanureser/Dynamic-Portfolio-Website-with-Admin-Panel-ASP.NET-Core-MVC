using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class MessageController : Controller

    {
        MyPortfolioContext context= new MyPortfolioContext();
        public IActionResult InBox()
        {
            var values=context.Messages.ToList();
            return View(values);
        }
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("InBox");
        }
        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("InBox");
        }
        public IActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("InBox");
        }
        public IActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult SendMessage(string Email, string NameSurname, string MessageDetail,string Subject)
        {
            MyPortfolioUdemy.DAL.Entities.Message message = new MyPortfolioUdemy.DAL.Entities.Message();
            message.NameSurname = NameSurname;
            message.Email = Email;
            message.Subject = Subject;
            message.MessageDetail = MessageDetail;
            message.SendDate = DateTime.Now;
            message.IsRead = false;

            context.Messages.Add(message);
            context.SaveChanges();

            return RedirectToAction("InBox");
        }

    }
}
