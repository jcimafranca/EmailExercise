using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using EmailExercise.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailExercise.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public EmailFormModel Contact { get; set; }
        
        public bool IsSuccess { get; set; }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {                       
            try
            {
                if (ModelState.IsValid)
                {
                    if (Contact.Photo != null)
                    {
                        string targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Settings.ImageFolder, Contact.Photo.FileName);

                        using (FileStream targetStream = System.IO.File.Create(targetFilePath))
                        {
                            await Contact.Photo.CopyToAsync(targetStream);
                        }

                        Contact.PhotoPath = $"{"https://"}{Request.Host.ToUriComponent().ToString()}{"/"}{Settings.ImageFolder}{"/"}{Contact.Photo.FileName}";
                    }

                    string mailbody = PrepareMail(Contact);

                    SmtpClient smtpClient = GetSmtpClient();
                    await Task.Run(() =>
                    {
                        smtpClient.Send(GetMailMessage(mailbody));
                    });                    
              
                    ModelState.Clear();                        
                    ViewData.Add("IsSuccess", true);                     
                   
                        
                }
                else { ViewData.Add("IsSuccess", false); }
                
            }
            catch (Exception ex)
            {
            }

            return Page();
        }       

        private string PrepareMail(EmailFormModel form)
        {
            string emailBody = string.Empty;
            try
            {
                emailBody= Settings.MailBody;
                emailBody=emailBody.Replace(Settings.FullName, form.FullName);
                emailBody=emailBody.Replace(Settings.PhotoPath, form.PhotoPath);
                emailBody=emailBody.Replace(Settings.Email, form.Email);
                emailBody=emailBody.Replace(Settings.Mobile, form.Mobile.ToString());
                emailBody=emailBody.Replace(Settings.Message, form.Message);
            }
            catch (Exception ex)
            {
            }

            return emailBody;

        }

        private MailMessage GetMailMessage(string MailBody)
        {
            MailMessage message = new MailMessage(Contact.Email, Settings.MailAddressTo);
            try
            {                
                message.To.Add(new MailAddress(Settings.MailAddressTo));
                message.From = new MailAddress(Contact.Email);
                message.Subject = Settings.MailSubject;
                message.Body = MailBody;
                return message;               
            }
            catch (Exception ex)
            {                
            }

            return message;
        }

        private SmtpClient GetSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient(Settings.MailHost, Settings.MailPort);
            try
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = Settings.SmtpUsername,
                    Password = Settings.SmtpPassword
                };
                
                smtpClient.EnableSsl = Settings.EnableSsl;
                return smtpClient;
                
            }
            catch (Exception ex)
            { }

            return smtpClient;
        }

    }
}
