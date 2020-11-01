using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarclaysPayments.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BarclaysPayments.Pages.Report
{
    [Authorize(Roles = "ALLSTAFF")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(
            ILogger<IndexModel> logger,
            ApplicationDbContext context,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public IList<SelectListItem> PaymentReason { get; set; }
        public IList<SelectListItem> OrderStatus { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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

            OrderStatus = await _context.OrderStatus
                .OrderBy(r => r.SortOrder)
                .ThenBy(r => r.Description)
                .Select(
                    r => new SelectListItem
                    {
                        Value = r.OrderStatusID.ToString(),
                        Text = r.Description
                    }
                )
                .AsNoTracking()
                .ToListAsync();

            return Page();
        }
    }
}
