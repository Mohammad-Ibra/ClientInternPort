using ClientInternPort.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInternPort.Pages
{
    public class IndexModel : PageModel
    {
        private readonly InternPortContext _db;

        public IndexModel(InternPortContext db)
        {
            _db = db;
        }

        public IEnumerable<Programs> Programs { get; set; }

        public async Task OnGet()
        {
            Programs = await _db.Program.ToListAsync();
        }
    }
}
