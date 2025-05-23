// WinkelwagenModel.cshtml.cs
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class WinkelwagenModel : PageModel
    {
        private readonly MatrixIncDbContext _context;
        public List<WinkelwagenItem> WinkelwagenItems { get; set; }
        public WinkelwagenModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            WinkelwagenItems = await _context.WinkelwagenItems.ToListAsync();
        }

    }
}
