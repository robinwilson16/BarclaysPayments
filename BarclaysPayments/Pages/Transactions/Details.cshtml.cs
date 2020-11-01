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
using Microsoft.EntityFrameworkCore.Internal;

namespace BarclaysPayments.Pages.Transactions
{
    [Authorize(Roles = "ALLSTAFF")]
    public class DetailsModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public DetailsModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Transaction Transaction { get; set; }

        public IList<OrderStatus> OrderStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? TransactionID)
        {
            if (TransactionID == null)
            {
                return NotFound();
            }

            //Transaction = await _context.Transaction.FirstOrDefaultAsync(m => m.TransactionID == id);
            Transaction = (await _context.Transaction
                .FromSqlInterpolated($"EXEC SPR_PAY_Transactions @PaymentReason=null, @OnlineBookingRefNo=null, @Email=null, @PaymentDateFrom=null, @PaymentDateTo=null, @OrderStatus=null, @TestDateFrom=null, @TestDateTo=null, @TransactionID={TransactionID}")
                .ToListAsync())
                .FirstOrDefault();

            OrderStatus = await _context.OrderStatus
                .ToListAsync();

            if (Transaction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
