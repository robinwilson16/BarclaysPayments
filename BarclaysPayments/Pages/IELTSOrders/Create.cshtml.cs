﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using Microsoft.AspNetCore.Authorization;

namespace BarclaysPayments.Pages.IELTSOrders
{
    [Authorize(Roles = "ALLSTAFF")]
    public class CreateModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public CreateModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BarclaysPaymentID"] = new SelectList(_context.BarclaysPayment, "BarclaysPaymentID", "CN");
        ViewData["OrderStatusID"] = new SelectList(_context.OrderStatus, "OrderStatusID", "OrderStatusID");
            return Page();
        }

        [BindProperty]
        public IELTSOrder IELTSOrder { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.IELTSOrder.Add(IELTSOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
