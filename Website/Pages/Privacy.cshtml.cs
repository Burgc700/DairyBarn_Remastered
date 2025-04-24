using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages;

/// <summary>
/// Sets up index page.
/// </summary>
public class PrivacyModel : PageModel
{
    /// <summary>
    /// Interface to get the logger.
    /// </summary>
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
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

