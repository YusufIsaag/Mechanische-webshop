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
            WinkelwagenItems = await _context.WinkelwagenItems
                  .Include(w => w.Product) // Dit laadt de gerelateerde Product gegevens
                  .ToListAsync();
        }

        public async Task<IActionResult> OnPostRemoveItem(int itemId)
        {
            var winkelwagenItem = await _context.WinkelwagenItems.FindAsync(itemId);

            if (winkelwagenItem != null)
            {
                _context.WinkelwagenItems.Remove(winkelwagenItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateQuantity(int itemId, int aantal)
        {
            var winkelwagenItem = await _context.WinkelwagenItems
                .Include(w => w.Product)
                .FirstOrDefaultAsync(w => w.Id == itemId);

            if (winkelwagenItem != null)
            {
                winkelwagenItem.Aantal = aantal;
                winkelwagenItem.TotaalBedrag = winkelwagenItem.Product.Prijs * aantal;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();

        }
    }
}
