using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace DairyBarn.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainItemSelectionControl.xaml
    /// </summary>
    public partial class MainItemSelectionControl : UserControl
    {
        /// <summary>
        /// Creates the event when a button is added to the order.
        /// </summary>
        public event EventHandler<MenuItemEventArgs>? MenuEvent;

        public MainItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the name of the menu item to the list view in the order control
        /// </summary>
        /// <param name="sender">The button we are clicking.</param>
        /// <param name="e">Button</param>
        public void MenuItemClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(DataContext is Order list)
                {
                    //Burgers
                    if(b.Name == "bYOBurger")
                    {
                        BYOBurger byob = new();
                        list.Add(byob);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(byob));
                    }
                    if(b.Name == "classicCheeseburger")
                    {
                        ClassicCheeseburger cb = new();
                        list.Add(cb);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(cb));
                    }
                    if(b.Name == "bBQBaconCheeseburger")
                    {
                        BBQBaconCheeseburger bbqbc = new();
                        list.Add(bbqbc);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(bbqbc));
                    }
                    if(b.Name == "veggieBurger")
                    {
                        VeggieBurger vb = new();
                        list.Add(vb);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(vb));
                    }
                    if(b.Name == "mushroomSwissBurger")
                    {
                        MushroomSwissBurger msb = new();
                        list.Add(msb);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(msb));
                    }

                    //Ice Cream
                    if(b.Name == "classicSundae")
                    {
                        ClassicSundae cs = new();
                        list.Add(cs);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(cs));
                    }
                    if(b.Name == "iceCreamCone")
                    {
                        IceCreamCone cone = new();
                        list.Add(cone);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(cone));
                    }
                    if(b.Name == "brownieSundae")
                    {
                        BrownieSundae bs = new();
                        list.Add(bs);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(bs));
                    }
                    if(b.Name == "strawberryShortcake")
                    {
                        StrawBerryShortcake sb = new();
                        list.Add(sb);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(sb));
                    }
                    if(b.Name == "winterSwirl")
                    {
                        WinterSwirl winterSwirl = new();
                        list.Add(winterSwirl);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(winterSwirl));
                    }

                    //drinks
                    if(b.Name == "coffee")
                    {
                        Coffee c = new();
                        list.Add(c);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(c));
                    }
                    if(b.Name == "latte")
                    {
                        Latte l = new();
                        list.Add(l);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(l));
                    }
                    if(b.Name == "mocha")
                    {
                        Mocha m = new();
                        list.Add(m);
                        MenuEvent?.Invoke(this, new MenuItemEventArgs(m));
                    }
                }
            }
        }
    }
}
