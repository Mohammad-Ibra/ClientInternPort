using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ClientInternPort.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ClientInternPort.Pages.Join_internship
{
    public class IndexModel : PageModel
    {
        private InternPortContext _db;

        public IndexModel(InternPortContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Programs Programs { get; set; }
        [BindProperty]
        public Interns Intern { get; set; }
        public IFormFile file { get; set; }

        public async Task OnGet(int id)
        {
            Programs = await _db.Program.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            
            await _db.Interns.AddAsync(Intern);
            await _db.SaveChangesAsync();
            await SendEmail();
            download(file);
            return RedirectToPage("/Index");
            
        }

        private async Task SendEmail ()
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"C:\Users\Lenovo\Desktop\dotnet\ClientInternPort\Demos",
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From("test@test.com")
                .To(Intern.Email)
                .Subject("Thanks for Applying!")
                .Body("Thanks for Applying to our Internship program we will be contacting you as soon as possible!")
                .SendAsync();
        }

        private void download(IFormFile file)
        {
            using(var fileStream = new FileStream($"C:/Users/Lenovo/Desktop/dotnet/ClientInternPort/{Intern.FullName}-CV.pdf", FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
        }

    }
}
