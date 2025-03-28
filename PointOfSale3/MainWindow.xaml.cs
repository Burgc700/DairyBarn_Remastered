using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DairyBarn.Data;

namespace DairyBarn.PointOfSale;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new Order();
        MenuItemSelection.MenuEvent += HandleWinterSwirlClick!;
        MenuItemSelection.MenuEvent += HandleBrownieSundaeClick!;
        MenuItemSelection.MenuEvent += HandleClassicSundaeClick!;
        MenuItemSelection.MenuEvent += HandleIceCreamConeClick!;
        MenuItemSelection.MenuEvent += HandleStrawberryShortcakeClick!;
        MenuItemSelection.MenuEvent += HandleCoffeeClick!;
        MenuItemSelection.MenuEvent += HandleLatteClick!;
        MenuItemSelection.MenuEvent += HandleMochaClick!;
        MenuItemSelection.MenuEvent += HandleBurgerClick!;
        OrderSummaryControl.RemoveEvent += HandleRemoveClick!;
        OrderSummaryControl.EditEvent += HandleEditClick!;
    }

    /// <summary>
    /// Clears every item from an order.
    /// </summary>
    /// <param name="sender">The cancel order click.</param>
    /// <param name="e">The button click on the button.</param>
    public void CancelOrderClick(object sender, RoutedEventArgs e)
    {
        if(DataContext is Order order)
        {
            order.Clear();
        }
    }

    /// <summary>
    /// Button that goes back to menu selection if there is another control in that spot in the grid.
    /// </summary>
    /// <param name="sender">The back to menu button.</param>
    /// <param name="e">Routes the menu control in that spot in the grid.</param>
    public void BackToMenuClick(object sender, RoutedEventArgs e)
    {
        if(WinterSwirlCustControl.Visibility == Visibility.Visible)
        {
            WinterSwirlCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (BrownieSundaeCustControl.Visibility == Visibility.Visible)
        {
            BrownieSundaeCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (ClassicSundaeCustControl.Visibility == Visibility.Visible)
        {
            ClassicSundaeCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (IceCreamConeCustControl.Visibility == Visibility.Visible)
        {
            IceCreamConeCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (StrawberryShortcakeCustControl.Visibility == Visibility.Visible)
        {
            StrawberryShortcakeCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (CoffeeCustControl.Visibility == Visibility.Visible)
        {
            CoffeeCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (LatteCustControl.Visibility == Visibility.Visible)
        {
            LatteCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (MochaCustControl.Visibility == Visibility.Visible)
        {
            MochaCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if (BurgerCustControl.Visibility == Visibility.Visible)
        {
            BurgerCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The winter swirl button</param>
    /// <param name="e">The MenuItem we have selected.</param>
    private void HandleWinterSwirlClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if (e.MenuItem is WinterSwirl ws)
        {
            WinterSwirlCustControl.DataContext = e.MenuItem;
            WinterSwirlCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The Brownie Sundae Button</param>
    /// <param name="e">THe MenuItem we have selected.</param>
    private void HandleBrownieSundaeClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is BrownieSundae bs)
        {
            BrownieSundaeCustControl.DataContext = e.MenuItem;
            BrownieSundaeCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The Classic Sundae button.</param>
    /// <param name="e">The MenuItem we have selected.</param>
    private void HandleClassicSundaeClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is ClassicSundae cs)
        {
            ClassicSundaeCustControl.DataContext = e.MenuItem;
            ClassicSundaeCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The ice cream cone button.</param>
    /// <param name="e">The MenuItem we have selected.</param>
    private void HandleIceCreamConeClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is IceCreamCone cone)
        {
            IceCreamConeCustControl.DataContext = e.MenuItem;
            IceCreamConeCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The strawberry shortcake button.</param>
    /// <param name="e">The MenuItem we have selected.</param>
    private void HandleStrawberryShortcakeClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is StrawBerryShortcake sb)
        {
            StrawberryShortcakeCustControl.DataContext = e.MenuItem;
            StrawberryShortcakeCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The coffee button.</param>
    /// <param name="e">The MenuItem we have selected.</param>
    private void HandleCoffeeClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is Coffee c)
        {
            CoffeeCustControl.DataContext = e.MenuItem;
            CoffeeCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The latte button.</param>
    /// <param name="e">The MenuItem we have selected.</param>
    private void HandleLatteClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is Latte l)
        {
            LatteCustControl.DataContext = e.MenuItem;
            LatteCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">The mocha button</param>
    /// <param name="e">The MenuItem we have selected</param>
    private void HandleMochaClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is Mocha m)
        {
            MochaCustControl.DataContext = e.MenuItem;
            MochaCustControl.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the correct control to customize the menu item.
    /// </summary>
    /// <param name="sender">Any of the burger clicks.</param>
    /// <param name="e">The menu item we have selected.</param>
    private void HandleBurgerClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if(e.MenuItem is Burger b)
        {
            BurgerCustControl.DataContext = e.MenuItem;
            BurgerCustControl.Visibility = Visibility.Visible;
        }
    }

    private void HandleRemoveClick(object sender, RoutedEventArgs e)
    {
        ClearOtherControls();
        MenuItemSelection.Visibility = Visibility.Visible;
    }

    private void ClearOtherControls()
    {
        BurgerCustControl.Visibility = Visibility.Hidden;
        IceCreamConeCustControl.Visibility = Visibility.Hidden;
        ClassicSundaeCustControl.Visibility = Visibility.Hidden;
        WinterSwirlCustControl.Visibility = Visibility.Hidden;
        BrownieSundaeCustControl.Visibility = Visibility.Hidden;
        StrawberryShortcakeCustControl.Visibility = Visibility.Hidden;
        CoffeeCustControl.Visibility = Visibility.Hidden;
        LatteCustControl.Visibility = Visibility.Hidden;
        MochaCustControl.Visibility = Visibility.Hidden;
    }

    private void HandleEditClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if (e.MenuItem is Burger b)
        {
            BurgerCustControl.Visibility = Visibility.Visible;
        }
        else if (e.MenuItem is ClassicSundae cs)
        {
            ClassicSundaeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is IceCreamCone cone)
        {
            IceCreamConeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is BrownieSundae bs)
        {
            BrownieSundaeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is StrawBerryShortcake sb)
        {
            StrawberryShortcakeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is WinterSwirl ws)
        {
            WinterSwirlCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is Coffee c)
        {
            CoffeeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is Mocha m)
        {
            MochaCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is Latte l)
        {
            LatteCustControl.Visibility = Visibility.Visible;
        }
    }
}