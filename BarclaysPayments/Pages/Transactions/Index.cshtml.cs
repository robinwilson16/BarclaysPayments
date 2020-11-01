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

namespace BarclaysPayments.Pages.Transactions
{
    [Authorize(Roles = "ALLSTAFF")]
    public class IndexModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public IndexModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; }

        public async Task OnGetAsync(
            string PaymentReason,
            string OnlineBookingRefNo,
            string Email,
            DateTime? PaymentDateFrom,
            DateTime? PaymentDateTo,
            int? OrderStatus,
            DateTime? TestDateFrom,
            DateTime? TestDateTo,
            int? TransactionID
            )
        {
            //Transaction = await _context.Transaction.ToListAsync();
            Transaction = await _context.Transaction
                .FromSqlInterpolated($"EXEC SPR_PAY_Transactions @PaymentReason={PaymentReason}, @OnlineBookingRefNo={OnlineBookingRefNo}, @Email={Email}, @PaymentDateFrom={PaymentDateFrom}, @PaymentDateTo={PaymentDateTo}, @OrderStatus={OrderStatus}, @TestDateFrom={TestDateFrom}, @TestDateTo={TestDateTo}, @TransactionID={TransactionID}")
                .ToListAsync();
        }

        public async Task<JsonResult> OnGetJsonAsync(
            string PaymentReason,
            string OnlineBookingRefNo,
            string Email,
            DateTime? PaymentDateFrom,
            DateTime? PaymentDateTo,
            int? OrderStatus,
            DateTime? TestDateFrom,
            DateTime? TestDateTo,
            int? TransactionID
            )
        {
            //Transaction = await _context.Transaction.ToListAsync();
            Transaction = await _context.Transaction
                .FromSqlInterpolated($"EXEC SPR_PAY_Transactions @PaymentReason={PaymentReason}, @OnlineBookingRefNo={OnlineBookingRefNo}, @Email={Email}, @PaymentDateFrom={PaymentDateFrom}, @PaymentDateTo={PaymentDateTo}, @OrderStatus={OrderStatus}, @TestDateFrom={TestDateFrom}, @TestDateTo={TestDateTo}, @TransactionID={TransactionID}")
                .ToListAsync();

            var collectionWrapper = new
            {
                transactions = Transaction
            };

            return new JsonResult(Transaction);
        }
    }
}
