using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using Microsoft.Extensions.Configuration;
using BarclaysPayments.Shared;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BarclaysPayments.Pages.Payments
{
    [AllowAnonymous]
    public class PayModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PayModel(
            ApplicationDbContext context,
            IConfiguration configuration
            )
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            FormSubmitted = false;

            PaymentReason = await _context.PaymentReason
                .OrderBy(r => r.SortOrder)
                .ThenBy(r => r.Description)
                .Select(
                    r => new SelectListItem
                    {
                        Value = r.PaymentReasonID,
                        Text = r.Description
                    }
                )
                .AsNoTracking()
                .ToListAsync();

            SHAPassphrase = _configuration.GetSection("SystemSettings")["SHAPassphrase"];
            string paymentSystem = _configuration.GetSection("SystemSettings")["PaymentSystem"];

            string paymentURL = null;

            if (paymentSystem == "LIVE")
            {
                FormDestinationID = _configuration.GetSection("SystemSettings")["PaymentURLLive"];
            }
            else
            {
                FormDestinationID = _configuration.GetSection("SystemSettings")["PaymentURLTest"];
            }

            if (id == null)
            {
                return NotFound();
            }

            BarclaysPayment = await _context.BarclaysPayment
                .Include(r => r.PaymentReason)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UniquePaymentRef == id);

            if (BarclaysPayment == null)
            {
                return NotFound();
            }


            return Page();
        }

        [BindProperty]
        public BarclaysPayment BarclaysPayment { get; set; }
        public IList<SelectListItem> PaymentReason { get; set; }

        public string SHAPassphrase { get; set; }
        public string FormDestinationID { get; set; }
        public bool FormSubmitted { get; set; }
        public bool FormSaved { get; set; }
        public string FormErrors { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(BarclaysPayment model)
        {
            FormSubmitted = true;
            FormSaved = true;

            //if (!ModelState.IsValid)
            //{
            //    FormSaved = false;
            //    FormErrors = string.Join("; ", ModelState.Values
            //                            .SelectMany(x => x.Errors)
            //                            .Select(x => x.ErrorMessage));
            //}

            BarclaysPayment.UniquePaymentRef = Guid.NewGuid();
            BarclaysPayment.PSPID = _configuration.GetSection("SystemSettings")["PSPID"];
            BarclaysPayment.CURRENCY = _configuration.GetSection("SystemSettings")["Currency"];
            BarclaysPayment.LANGUAGE = "en_GB";
            BarclaysPayment.TITLE = _configuration.GetSection("SystemSettings")["BarclaysTitle"];
            BarclaysPayment.BGCOLOR = "";
            BarclaysPayment.TXTCOLOR = "";
            BarclaysPayment.TBLBGCOLOR = "";
            BarclaysPayment.TBLTXTCOLOR = "";
            BarclaysPayment.BUTTONBGCOLOR = "";
            BarclaysPayment.BUTTONTXTCOLOR = "";
            BarclaysPayment.LOGO = "https://apps.wlc.ac.uk/BarclaysPayments/images/CollegeLogo.png";
            BarclaysPayment.FONTTYPE = "";
            BarclaysPayment.ACCEPTURL = "https://www.wlc.ac.uk";
            BarclaysPayment.DECLINEURL = "https://www.wlc.ac.uk";
            BarclaysPayment.EXCEPTIONURL = "https://www.wlc.ac.uk";
            BarclaysPayment.CANCELURL = "https://www.wlc.ac.uk";
            BarclaysPayment.CreatedDate = DateTime.Now;
            BarclaysPayment.CreatedBy = User.Identity.Name.Split('\\').Last();

            _context.BarclaysPayment.Add(BarclaysPayment);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
