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
    /// <summary>
    /// The constructor.
    /// </summary>
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
        BurgerCustControl.BurgerEvent += HandlePickTwoClick!;
        pickTwoCustControl.EditBurgerEvent += HandleEditBurger;
        pickTwoCustControl.EditIceCreamEvent += HandleEditIceCream;
        OrderSummaryControl.RemoveEvent += HandleRemoveClick!;
        OrderSummaryControl.EditEvent += HandleEditClick!;
        PaymentReviewControl.FinishedPayEvent += HandleFinishPayment;
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
        else if(pickTwoCustControl.Visibility == Visibility.Visible)
        {
            pickTwoCustControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
        else if(PaymentReviewControl.Visibility == Visibility.Visible)
        {
            PaymentReviewControl.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Displays the payment review control when the button is clicked.
    /// </summary>
    /// <param name="sender">The complete order button.</param>
    /// <param name="e">Hides any other panel that is open and makes the payment review control visible.</param>
    public void CompleteOrderClick(object sender, RoutedEventArgs e)
    {
        if(MenuItemSelection.Visibility == Visibility.Visible)
        {
            MenuItemSelection.Visibility = Visibility.Hidden;
        }
        ClearOtherControls();
        PaymentReviewControl.DataContext = new PaymentViewViewModel((Order)DataContext);
        PaymentReviewControl.Visibility = Visibility.Visible;
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
            BurgerCustControl.LoadBurgerToppings();
            if (b.PartOfPickTwo == true)
            {
                BurgerCustControl.pickTwoButton.Visibility = Visibility.Hidden;
            }
            else
            {
                BurgerCustControl.pickTwoButton.Visibility = Visibility.Visible;
            }
        }
    }

    /// <summary>
    /// Displays the correct control and adds pick two to this list while removing the selected burger.
    /// </summary>
    /// <param name="sender">The pick two button click.</param>
    /// <param name="e">The new pick menu item.</param>
    private void HandlePickTwoClick(object sender, MenuItemEventArgs e)
    {
        BurgerCustControl.Visibility = Visibility.Hidden;
        if(e.MenuItem is Burger b && DataContext is Order o)
        {
            o.Remove(b);
            PickTwo p2 = new PickTwo { BurgerChoice = b };
            o.Add(p2);
            pickTwoCustControl.Visibility = Visibility.Visible;
            pickTwoCustControl.DataContext = p2;
        }
    }

    /// <summary>
    /// The logic for removing a menu item from the order summary.
    /// </summary>
    /// <param name="sender">The remove button.</param>
    /// <param name="e">Tells the item to be removed and changes the visibility.</param>
    private void HandleRemoveClick(object sender, RoutedEventArgs e)
    {
        ClearOtherControls();
        MenuItemSelection.Visibility = Visibility.Visible;
    }

    /// <summary>
    /// Clears all other controls from the display.
    /// </summary>
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
        pickTwoCustControl.Visibility = Visibility.Hidden;
    }

    /// <summary>
    /// The logic for editing a menu item in the order summary.
    /// </summary>
    /// <param name="sender">The edit button for each menu item in the order summary.</param>
    /// <param name="e">Hides the menu control and make the right control visible.</param>
    private void HandleEditClick(object sender, MenuItemEventArgs e)
    {
        MenuItemSelection.Visibility = Visibility.Hidden;
        if (e.MenuItem is Burger b)
        {
            BurgerCustControl.DataContext = e.MenuItem;
            BurgerCustControl.Visibility = Visibility.Visible;
            BurgerCustControl.LoadBurgerToppings();
            if (b.PartOfPickTwo == true)
            {
                BurgerCustControl.pickTwoButton.Visibility = Visibility.Hidden;
            }
            else
            {
                BurgerCustControl.pickTwoButton.Visibility = Visibility.Visible;
            }
        }
        else if (e.MenuItem is ClassicSundae cs)
        {
            ClassicSundaeCustControl.DataContext = e.MenuItem;
            ClassicSundaeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is IceCreamCone cone)
        {
            IceCreamConeCustControl.DataContext = e.MenuItem;
            IceCreamConeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is BrownieSundae bs)
        {
            BrownieSundaeCustControl.DataContext = e.MenuItem;
            BrownieSundaeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is StrawBerryShortcake sb)
        {
            StrawberryShortcakeCustControl.DataContext = e.MenuItem;
            StrawberryShortcakeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is WinterSwirl ws)
        {
            WinterSwirlCustControl.DataContext = e.MenuItem;
            WinterSwirlCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is Coffee c)
        {
            CoffeeCustControl.DataContext = e.MenuItem;
            CoffeeCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is Mocha m)
        {
            MochaCustControl.DataContext = e.MenuItem;
            MochaCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is Latte l)
        {
            LatteCustControl.DataContext = e.MenuItem;
            LatteCustControl.Visibility = Visibility.Visible;
        }
        else if(e.MenuItem is PickTwo p2)
        {
            pickTwoCustControl.DataContext = e.MenuItem;
            pickTwoCustControl.Visibility = Visibility.Visible;
            if(ClassicSundaeCustControl.Visibility == Visibility.Visible)
            {
                ClassicSundaeCustControl.Visibility = Visibility.Hidden;
            }
            else if(BrownieSundaeCustControl.Visibility == Visibility.Visible)
            {
                BrownieSundaeCustControl.Visibility = Visibility.Hidden;
            }
            else if(StrawberryShortcakeCustControl.Visibility == Visibility.Visible)
            {
                StrawberryShortcakeCustControl.Visibility = Visibility.Hidden;
            }
            else if(IceCreamConeCustControl.Visibility == Visibility.Visible)
            {
                IceCreamConeCustControl.Visibility = Visibility.Hidden;
            }
            else if(WinterSwirlCustControl.Visibility == Visibility.Visible)
            {
                WinterSwirlCustControl.Visibility = Visibility.Hidden;
            }
            else if(BurgerCustControl.Visibility == Visibility.Visible)
            {
                BurgerCustControl.Visibility = Visibility.Hidden;
            }
        }
    }

    /// <summary>
    /// Changed the controls so the right control is displayed when the button is clicked.
    /// </summary>
    /// <param name="sender">The edit burger click</param>
    /// <param name="e">Changed controls so burger control is visible.</param>
    private void HandleEditBurger(object? sender, MenuItemEventArgs e)
    {
        pickTwoCustControl.Visibility = Visibility.Hidden;
        if(e.MenuItem is Burger b)
        {
            BurgerCustControl.Visibility = Visibility.Visible;
            BurgerCustControl.DataContext = e.MenuItem;
            BurgerCustControl.LoadBurgerToppings();
            if(b.PartOfPickTwo == true)
            {
                BurgerCustControl.pickTwoButton.Visibility = Visibility.Hidden;
            }
            else
            {
                BurgerCustControl.pickTwoButton.Visibility = Visibility.Visible;
            }
        }
    } 

    /// <summary>
    /// Changed the controls so the right control is displayed when the button is clicked.
    /// </summary>
    /// <param name="sender">The edit ice cream click.</param>
    /// <param name="e">Changed controls so the right ice cream control is visible.</param>
    private void HandleEditIceCream(object? sender, MenuItemEventArgs e)
    {
        pickTwoCustControl.Visibility = Visibility.Hidden;
        if(e.MenuItem is BrownieSundae bs)
        {
            BrownieSundaeCustControl.Visibility = Visibility.Visible;
            BrownieSundaeCustControl.DataContext = e.MenuItem;
        }
        else if(e.MenuItem is ClassicSundae cs)
        {
            ClassicSundaeCustControl.Visibility = Visibility.Visible;
            ClassicSundaeCustControl.DataContext = e.MenuItem;
        }
        else if(e.MenuItem is IceCreamCone cone)
        {
            IceCreamConeCustControl.Visibility = Visibility.Visible;
            IceCreamConeCustControl.DataContext = e.MenuItem;
        }
        else if(e.MenuItem is StrawBerryShortcake sbsc)
        {
            StrawberryShortcakeCustControl.Visibility = Visibility.Visible;
            StrawberryShortcakeCustControl.DataContext = e.MenuItem;
        }
        else if(e.MenuItem is WinterSwirl ws)
        {
            WinterSwirlCustControl.Visibility = Visibility.Visible;
            WinterSwirlCustControl.DataContext = e.MenuItem;
        }
    }

    /// <summary>
    /// Handles changing displays and updates order and date info in the order summary.
    /// </summary>
    /// <param name="sender">The Finish payment and print receipt button.</param>
    /// <param name="e">Displays the correct controls and increments the order, changes the time for date placed.</param>
    private void HandleFinishPayment(object? sender, RoutedEventArgs e)
    {
        PaymentReviewControl.Visibility = Visibility.Hidden;
        MenuItemSelection.Visibility = Visibility.Visible;
        DataContext = new Order();
    }
}