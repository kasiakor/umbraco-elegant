using CleanBlog.Core.ViewModels;
using System;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace CleanBlog.Core.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        [HttpGet]
        public ActionResult RenderForm()
        {
            ContactViewModel model = new ContactViewModel() { ContactFormId = CurrentPage.Id };
            return PartialView("~Views/Partial/Contact/contactForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult RenderForm(ContactViewModel model)
        {
            return PartialView("~Views/Partial/Contact/contactForm.cshtml", model);
        }

        public ActionResult SubmitForm(ContactViewModel model)
        {
            bool success = false;

            // attributes from ContactViewModel
            if (ModelState.IsValid)
            {
                success = SendEmail(model);
            }

            // message to display
            var contactPage = UmbracoContext.Content.GetById(false, model.ContactFormId);
            var successMessage = contactPage.Value<IHtmlString>("successMessage");
            var errorMessage = contactPage.Value<IHtmlString>("errorMessage");

            return PartialView("~Views/Partials/Contact/result.cshtml");
        }
        public bool SendEmail(ContactViewModel model)
        {
            try
            {
                // smtp client
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();

                string toAddress = "to@test.com";
                string fromAddress = "from@test.com";
                // we use the model to build up a subject
                message.Subject = $"Enquiry from: {model.Name} - {model.Email}";
                message.Body = model.Message;
                message.To.Add(new MailAddress(toAddress, toAddress));
                message.From = new MailAddress(fromAddress, fromAddress);

                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
