using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DairyBarn.Data;

namespace Website.Pages;

/// <summary>
/// Sets up index page.
/// </summary>
public class IndexModel : PageModel
{
    /// <summary>
    /// Interface to get the logger.
    /// </summary>
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Puts the elements on the screen.
    /// </summary>
    public void OnGet()
    {

    }
}
