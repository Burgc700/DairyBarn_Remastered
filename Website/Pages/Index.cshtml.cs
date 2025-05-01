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
        MenuItems = Menu.FullMenu;
        MenuItems =Menu.Search(MenuItems, SearchTerms);
        MenuItems = Menu.FilterByCalories(MenuItems, CaloriesMin, CaloriesMax);
        MenuItems = Menu.FilterByPrice(MenuItems, PriceMin, PriceMax);
    }

    /// <summary>
    /// Gets all the menu items that are avaliable.
    /// </summary>
    public IEnumerable<IMenuItem> MenuItems { get; set; }

    /// <summary>
    /// Gets all the burgers in the MenuItems.
    /// </summary>
    public IEnumerable<Burger> Burgers => MenuItems.OfType<Burger>();

    /// <summary>
    /// Gets all the ice cream in the MenuItems.
    /// </summary>
    public IEnumerable<IceCream> IceCream => MenuItems.OfType<IceCream>();

    /// <summary>
    /// Gets all the drinks in the MenuItems.
    /// </summary>
    public IEnumerable<Drink> Drinks => MenuItems.OfType<Drink>();

    /// <summary>
    /// Gets the terms that we are searching for.
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string SearchTerms { get; set; }

    /// <summary>
    /// Gets the minimum number of calories we can search for.
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public int? CaloriesMin { get; set; }

    /// <summary>
    /// Gets the maximum number of calories we can search for.
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public int? CaloriesMax { get; set; }

    /// <summary>
    /// Gets the minimum price that we can search for.
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public decimal? PriceMin { get; set; }

    /// <summary>
    /// Gets the maximum price that we can search for.
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public decimal? PriceMax { get; set; }
}
