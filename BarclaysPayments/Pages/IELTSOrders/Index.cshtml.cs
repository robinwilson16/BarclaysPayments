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
    public class IndexModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public IndexModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<IELTSOrder> IELTSOrder { get;set; }

        public async Task OnGetAsync()
        {
            IELTSOrder = await _context.IELTSOrder
                .Include(i => i.BarclaysPayment)
                .Include(i => i.OrderStatus).ToListAsync();
        }
    }
}
