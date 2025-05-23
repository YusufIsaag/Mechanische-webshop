using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_1_Base.Pages.Producten
{
    public class P5Model : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public P5Model(MatrixIncDbContext context)
        {
            _context = context;
        }

        public IList<WinkelwagenItem> WinkelwagenItems { get; set; }

        public async Task OnGetAsync()
        {
            WinkelwagenItems = await _context.WinkelwagenItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostToevoegenAanWinkelwagen(int productId, int aantal)
        {
            var sessionId = HttpContext.Session.Id;

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var winkelwagenItem = new WinkelwagenItem
            {
                ProductId = product.ProductId,
                Aantal = aantal,
                Product = product,
                TotaalBedrag = product.Prijs * aantal

            };

            _context.WinkelwagenItems.Add(winkelwagenItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Winkelwagen/Winkelwagen");
        }

    }

}