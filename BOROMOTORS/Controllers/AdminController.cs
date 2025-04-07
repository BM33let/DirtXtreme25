using BOROMOTORS.Data;
using BOROMOTORS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Dashboard()
    {
        var total = await _context.DirtBikes.CountAsync();
        var avg = await _context.DirtBikes.AverageAsync(b => b.Price);
        var min = await _context.DirtBikes.MinAsync(b => b.Price);
        var top = await _context.DirtBikes
            .GroupBy(b => b.Manufacturer)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefaultAsync();

        var totalUsers = await _userManager.Users.CountAsync();

        var vm = new DashboardViewModel
        {
            TotalBikes = total,
            AveragePrice = avg.GetValueOrDefault(),
            CheapestBike = min.GetValueOrDefault(),
            TopManufacturer = top,
            TotalUsers = totalUsers
        };

        return View(vm);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChartData()
    {
        var brandCounts = await _context.DirtBikes
            .GroupBy(b => b.Manufacturer)
            .Select(g => new { label = g.Key, value = g.Count() })
            .ToListAsync();

        return Json(brandCounts);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChartByYear()
    {
        var result = await _context.DirtBikes
            .GroupBy(b => b.Year)
            .Select(g => new { label = g.Key.ToString(), value = g.Count() })
            .OrderBy(g => g.label)
            .ToListAsync();

        return Json(result);
    }
}
