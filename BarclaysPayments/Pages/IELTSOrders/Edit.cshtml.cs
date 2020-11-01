using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using Microsoft.AspNetCore.Authorization;

namespace BarclaysPayments.Pages.IELTSOrders
{
    [Authorize(Roles = "ALLSTAFF")]
    public class EditModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public EditModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IELTSOrder IELTSOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? OrderStatus, bool? PracticeTestBooked, bool? PracticeMaterialsSent)
        {
            if (id == null)
            {
                return NotFound();
            }

            IELTSOrder = await _context.IELTSOrder
                .Include(i => i.BarclaysPayment)
                .Include(i => i.OrderStatus)
                //.FirstOrDefaultAsync(m => m.IELTSOrderID == id);
                .FirstOrDefaultAsync(m => m.BarclaysPaymentID == id);

            if (OrderStatus != null)
            {
                IELTSOrder.OrderStatusID = OrderStatus;
            }

            if (PracticeTestBooked != null)
            {
                IELTSOrder.PracticeTestBooked = (bool)PracticeTestBooked;
            }

            if (PracticeMaterialsSent != null)
            {
                IELTSOrder.PracticeMaterialsSent = (bool)PracticeMaterialsSent;
            }

            if (IELTSOrder == null)
            {
                return NotFound();
            }
            ViewData["BarclaysPaymentID"] = new SelectList(_context.BarclaysPayment, "BarclaysPaymentID", "CN");
            ViewData["OrderStatusID"] = new SelectList(_context.OrderStatus, "OrderStatusID", "OrderStatusID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, int? OrderStatus, bool? PracticeTestBooked, bool? PracticeMaterialsSent)
        {
            if (id != null)
            {
                IELTSOrder = await _context.IELTSOrder
                    .FirstOrDefaultAsync(m => m.BarclaysPaymentID == id);
            }

            if(OrderStatus != null) {
                IELTSOrder.OrderStatusID = OrderStatus;
            }

            if (PracticeTestBooked != null)
            {
                IELTSOrder.PracticeTestBooked = (bool)PracticeTestBooked;
            }

            if (PracticeMaterialsSent != null)
            {
                IELTSOrder.PracticeMaterialsSent = (bool)PracticeMaterialsSent;
            }

            ModelState.Remove("IELTSOrder.IELTSTestDate");

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(IELTSOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IELTSOrderExists(IELTSOrder.IELTSOrderID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IELTSOrderExists(int id)
        {
            return _context.IELTSOrder.Any(e => e.IELTSOrderID == id);
        }
    }
}
