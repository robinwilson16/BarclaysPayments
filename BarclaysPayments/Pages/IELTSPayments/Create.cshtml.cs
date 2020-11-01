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

namespace BarclaysPayments.Pages.IELTSPayments
{
    public class CreateModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CreateModel(
            ApplicationDbContext context,
            IConfiguration configuration
            )
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(
            string ielts,
            string TestType,
            string reffname,
            string refsname,
            string ref1,
            string ref2,
            string confirmref1,
            string confirmref2,
            string email,
            string email2,
            decimal tpymt,
            DateTime TestDate,
            string dep,
            bool mockexam1,
            bool refbooks,
            bool DuplicateCertificate,
            bool TransferFees,
            bool EnquiryOnResult,
            bool ieltsexam,
            bool ieltsexam2,
            int formId,
            string oid
            )
        {
            FormSubmitted = false;

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

            BarclaysPayment = new BarclaysPayment
            {
                UniquePaymentRef = Guid.NewGuid(),
                PaymentURL = paymentURL,
                PSPID = _configuration.GetSection("SystemSettings")["PSPID"],
                ORDERID = oid,
                PaymentReasonID = "IELTS",
                AMOUNT = tpymt,
                CURRENCY = _configuration.GetSection("SystemSettings")["Currency"],
                LANGUAGE = "en_GB",
                CN = reffname + " " + refsname,
                EMAIL = email,
                //OWNERZIP = "W14 9BL",
                //OWNERADDRESS = "West London College",
                //OWNERCTY = "Hammersmith",
                //OWNERTOWN = "London",
                //OWNERTELNO = "07712345678",
                SHASIGN = "",
                TITLE = _configuration.GetSection("SystemSettings")["BarclaysTitle"],
                BGCOLOR = "",
                TXTCOLOR = "",
                TBLBGCOLOR = "",
                TBLTXTCOLOR = "",
                BUTTONBGCOLOR = "",
                BUTTONTXTCOLOR = "",
                LOGO = "https://apps.wlc.ac.uk/BarclaysPayments/images/CollegeLogo.png",
                FONTTYPE = "",
                ACCEPTURL = "https://www.wlc.ac.uk",
                DECLINEURL = "https://www.wlc.ac.uk",
                EXCEPTIONURL = "https://www.wlc.ac.uk",
                CANCELURL = "https://www.wlc.ac.uk",
                CreatedDate = DateTime.Now,
                CreatedBy = "IELTS"
            };

            _context.BarclaysPayment.Add(BarclaysPayment);
            await _context.SaveChangesAsync();

            IELTSOrder = new IELTSOrder
            {
                BarclaysPaymentID = BarclaysPayment.BarclaysPaymentID,
                IELTSTestDate = TestDate,
                TestType = TestType,
                OrderStatusID = 1 //To-Do
            };

            if (ielts == "ieltsexam" || ieltsexam == true)
            {
                IELTSTestAmount = await _context.IELTSPrice
                    .Where(p => p.Code == "ieltsexam")
                    .FirstOrDefaultAsync();

                IELTSOrder.IELTSTestAmount = IELTSTestAmount.Price;
                IELTSTestAmountValue = IELTSTestAmount.Price;
            }
            else if (ielts == "ieltsexam2" || ieltsexam2 == true)
            {
                IELTSTestAmount = await _context.IELTSPrice
                    .Where(p => p.Code == "ieltsexam2")
                    .FirstOrDefaultAsync();

                IELTSOrder.IELTSTestAmount = IELTSTestAmount.Price;
                IELTSTestAmountValue = IELTSTestAmount.Price;
            }
            else if (ielts == "ieltsexamTFL")
            {
                IELTSTestAmount = await _context.IELTSPrice
                    .Where(p => p.Code == "ieltsexamTFL")
                    .FirstOrDefaultAsync();

                IELTSOrder.IELTSTestAmount = IELTSTestAmount.Price;
                IELTSTestAmountValue = IELTSTestAmount.Price;
            }

            if (mockexam1 == true)
            {
                PracticeTestAmount = await _context.IELTSPrice
                    .Where(p => p.Code == "mockexam1")
                    .FirstOrDefaultAsync();

                IELTSOrder.PracticeTestAmount = PracticeTestAmount.Price;
                PracticeTestAmountValue = PracticeTestAmount.Price;
            }

            if (mockexam1 == true)
            {
                PracticeMaterialsAmount = await _context.IELTSPrice
                    .Where(p => p.Code == "refbooks")
                    .FirstOrDefaultAsync();

                IELTSOrder.PracticeMaterialsAmount = PracticeMaterialsAmount.Price;
                PracticeMaterialsAmountValue = PracticeMaterialsAmount.Price;
            }

            _context.IELTSOrder.Add(IELTSOrder);
            await _context.SaveChangesAsync();

            PracticeTestDate = TestDate;

            UniquePaymentRef = BarclaysPayment.UniquePaymentRef;

            //Update Payment Reference
            BarclaysPayment.ORDERID = IELTSOrder.IELTSOrderID + "-" + IELTSOrder.TestType + "-" + BarclaysPayment.ORDERID;
            await _context.SaveChangesAsync();

            return Page();
        }

        [BindProperty]
        public BarclaysPayment BarclaysPayment { get; set; }
        public IELTSOrder IELTSOrder { get; set; }
        public IList<SelectListItem> PaymentReason { get; set; }
        public IList<IELTSPrice> IELTSPrice { get; set; }
        public IELTSPrice IELTSTestAmount { get; set; }
        public decimal IELTSTestAmountValue { get; set; }
        public IELTSPrice PracticeTestAmount { get; set; }
        public decimal PracticeTestAmountValue { get; set; }
        public IELTSPrice PracticeMaterialsAmount { get; set; }
        public decimal PracticeMaterialsAmountValue { get; set; }
        public DateTime PracticeTestDate { get; set; }

        public string SHAPassphrase { get; set; }
        public string FormDestinationID { get; set; }
        public bool FormSubmitted { get; set; }
        public bool FormSaved { get; set; }
        public string FormErrors { get; set; }

        public Guid UniquePaymentRef { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(
            BarclaysPayment model,
            string ielts,
            DateTime TestDate,
            string TestType,
            bool mockexam1,
            bool ieltsexam,
            bool ieltsexam2
            )
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

            

            IELTSOrder = new IELTSOrder
            {
                BarclaysPaymentID = BarclaysPayment.BarclaysPaymentID,
                IELTSTestDate = TestDate,
                TestType = TestType
            };

            if (ielts == "ieltsexam" || ieltsexam == true)
            {
                IELTSTestAmount = IELTSPrice
                    .Where(p => p.Code == "ieltsexam")
                    .FirstOrDefault();

                IELTSOrder.IELTSTestAmount = IELTSTestAmount.Price;
                IELTSTestAmountValue = IELTSTestAmount.Price;
            }
            else if (ielts == "ieltsexam2" || ieltsexam2 == true)
            {
                IELTSTestAmount = IELTSPrice
                    .Where(p => p.Code == "ieltsexam2")
                    .FirstOrDefault();

                IELTSOrder.IELTSTestAmount = IELTSTestAmount.Price;
                IELTSTestAmountValue = IELTSTestAmount.Price;
            }
            else if (ielts == "ieltsexamTFL")
            {
                IELTSTestAmount = IELTSPrice
                    .Where(p => p.Code == "ieltsexamTFL")
                    .FirstOrDefault();

                IELTSOrder.IELTSTestAmount = IELTSTestAmount.Price;
                IELTSTestAmountValue = IELTSTestAmount.Price;
            }

            if (mockexam1 == true)
            {
                PracticeTestAmount = IELTSPrice
                    .Where(p => p.Code == "mockexam1")
                    .FirstOrDefault();

                IELTSOrder.PracticeTestAmount = PracticeTestAmount.Price;
                PracticeTestAmountValue = PracticeTestAmount.Price;
            }

            if (mockexam1 == true)
            {
                PracticeMaterialsAmount = IELTSPrice
                    .Where(p => p.Code == "refbooks")
                    .FirstOrDefault();

                IELTSOrder.PracticeMaterialsAmount = PracticeMaterialsAmount.Price;
                PracticeMaterialsAmountValue = PracticeMaterialsAmount.Price;
            }

            _context.IELTSOrder.Add(IELTSOrder);
            await _context.SaveChangesAsync();

            PracticeTestDate = TestDate;

            UniquePaymentRef = BarclaysPayment.UniquePaymentRef;

            //Update Payment Reference
            BarclaysPayment.ORDERID = IELTSOrder.IELTSOrderID + "-" + IELTSOrder.TestType + "-" + BarclaysPayment.ORDERID;

            return Page();
        }
    }
}
