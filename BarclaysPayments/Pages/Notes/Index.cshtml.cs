using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using Microsoft.AspNetCore.Authorization;

namespace BarclaysPayments.Pages.Notes
{
    [Authorize(Roles = "ALLSTAFF")]
    public class IndexModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public IndexModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; }

        public async Task OnGetAsync(int? id, bool? alertOnly)
        {
            IQueryable<Note> noteIQ = from n in _context.Note
                                      .Where(n => n.TransactionID == id)
                                      .OrderByDescending(n => n.CreatedDate)
                                     select n;

            if (alertOnly != null)
            {
                noteIQ.Where(n => n.IsAlert == alertOnly);
            }

            //Note = await _context.Note
            //    .Where ( n => n.TransactionID == id)
            //    .OrderByDescending(n => n.CreatedDate)
            //    .ToListAsync();

            Note = await noteIQ.AsNoTracking().ToListAsync();

            ViewData["Alerts"] = GetAlerts(Note);
        }

        public async Task<IActionResult> OnGetJsonAsync(int? id, bool? alertOnly)
        {
            IQueryable<Note> noteIQ = from n in _context.Note
                                      .Where(n => n.TransactionID == id)
                                      .OrderByDescending(n => n.CreatedDate)
                                      select n;

            if (alertOnly != null)
            {
                noteIQ = noteIQ.Where(n => n.IsAlert == alertOnly);
            }

            //Note = await _context.Note
            //    .Where ( n => n.TransactionID == id)
            //    .OrderByDescending(n => n.CreatedDate)
            //    .ToListAsync();

            Note = await noteIQ.AsNoTracking().ToListAsync();

            var collectionWrapper = new
            {
                Notes = Note
            };

            return new JsonResult(Note);
        }

        public static string GetAlerts(IList<Note> notes)
        {
            string alerts = "";
            foreach (var note in notes)
            {
                if (note.IsAlert)
                {
                    if (alerts == "")
                    {
                        alerts += note.NoteText;
                    }
                    else
                    {
                        alerts += "|" + note.NoteText;
                    }
                }
            }

            return alerts;
        }
    }
}
