using ECommerce.Areas.Management.Models.Context;
using ECommerce.Areas.Management.Models.Entities;
using ECommerce.Areas.Management.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository CustomerManager = new CustomerRepository(new ApplicationDbContext());
        // GET: Customer
        public ActionResult Index()
        {
            return RedirectToAction("Register");
        }
        public ActionResult Register(Customer model)
        {
            bool status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                if (isExistUser(model.email))
                {
                    status = false;
                    message = "Bu mail adresi daha önce kullanılmış";
                    ViewBag.Status = status;
                    ViewBag.Message = message;
                    return View();
                }
                model.password = Crypto.Crypto.Hash(model.password);
                model.rePassword = Crypto.Crypto.Hash(model.rePassword);
                model.roleId = 2;
                model.createdDate = DateTime.Now;
                model.activationCode = Guid.NewGuid().ToString();
                model.isMailVerified = false;
                CustomerManager.Save(model);

                var verifyUrl = "/Customer/VerifyAccount/" + model.activationCode;
                Services.MailService.Link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                Services.MailService.title = "Car Store Rent a car";
                Services.MailService.Subject = Services.MailService.title + "Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz";
                Services.MailService.Body = "Hesabınız başarıyla oluşturulmuştur. Hesabınız aktive etmek için aşağıdaki linke tıklayınız" +
                    " <br/><br/><a href='" + Services.MailService.Link  + "'> Doğrulama Linki </a> ";
                Services.MailService.sendEmail(model.email);
                status = true;
                message = "Kaydınız Başarıyla gerçekleşmiştir.Lütfen gelen mail ile aktivasyon yapınız";
                ViewBag.Status = status;
                ViewBag.Message = message;
                return View();
            }
            ModelState.AddModelError("", "Bilgileri Kontrol Ediniz");
            return View();

          
        }
        [NonAction]
        public bool isExistUser(string username)
        {
            var user = CustomerManager.GetAll().Where(a => a.email == username).FirstOrDefault();
            return user == null ? false : true;
        }
    }
}