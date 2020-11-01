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

namespace BarclaysPayments.Pages.IELTSOrders
{
    [Authorize(Roles = "ALLSTAFF")]
    public class DeleteModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public DeleteModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IELTSOrder IELTSOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IELTSOrder = await _context.IELTSOrder
                .Include(i => i.BarclaysPayment)
                .Include(i => i.OrderStatus).FirstOrDefaultAsync(m => m.IELTSOrderID == id);

            if (IELTSOrder == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IELTSOrder = await _context.IELTSOrder.FindAsync(id);

            if (IELTSOrder != null)
            {
                _context.IELTSOrder.Remove(IELTSOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
