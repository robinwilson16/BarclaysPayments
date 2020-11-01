using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using System.Net;

namespace BarclaysPayments.Pages.Response
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public CreateModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BarclaysResponse BarclaysResponse { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(
            string ORDERID,
            string PAYID,
            string PAYMENT_REFERENCE,
            string TRXDATE,
            int STATUS,
            string NCERROR,
            string AAVADDRESS,
            string ACCEPTANCE,
            decimal AMOUNT,
            string BRAND,
            string CARDNO,
            string CN,
            string COMPLUS,
            string CURRENCY,
            string ED,
            string IP,
            string PM
            )
        {
            BarclaysResponse.ORDERID = ORDERID;
            BarclaysResponse.PAYID = PAYID;
            BarclaysResponse.PAYMENT_REFERENCE = PAYMENT_REFERENCE;
            BarclaysResponse.TRXDATE = TRXDATE;
            BarclaysResponse.STATUS = STATUS;
            BarclaysResponse.NCERROR = NCERROR;
            BarclaysResponse.AAVADDRESS = AAVADDRESS;
            BarclaysResponse.ACCEPTANCE = ACCEPTANCE;
            BarclaysResponse.AMOUNT = AMOUNT;
            BarclaysResponse.BRAND = BRAND;
            BarclaysResponse.CARDNO = CARDNO;
            BarclaysResponse.CN = CN;
            BarclaysResponse.COMPLUS = COMPLUS;
            BarclaysResponse.CURRENCY = CURRENCY;
            BarclaysResponse.ED = ED;
            BarclaysResponse.IP = IP;
            BarclaysResponse.PM = PM;
            BarclaysResponse.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            BarclaysResponse.HostName = Dns.GetHostEntry(Request.HttpContext.Connection.RemoteIpAddress).HostName;
            BarclaysResponse.CreatedBy = "EPDQ";
            BarclaysResponse.CreatedDate = DateTime.Now;

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.BarclaysResponse.Add(BarclaysResponse);
            await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            //Used by Barclays EPDQ to redirect user and overrides anything set elsewhere according to Support
            //May want to consider redirecting differently if the payment fails etc.
            //return RedirectToPage("https://www.wlc.ac.uk");

            return Page();
        }
    }
}
