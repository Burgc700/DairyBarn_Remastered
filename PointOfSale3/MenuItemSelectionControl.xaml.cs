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
                        list.Add(new BYOBurger());
                    }
                    if(b.Name == "classicCheeseburger")
                    {
                        list.Add(new ClassicCheeseburger());
                    }
                    if(b.Name == "bBQBaconCheeseburger")
                    {
                        list.Add(new BBQBaconCheeseburger());
                    }
                    if(b.Name == "veggieBurger")
                    {
                        list.Add(new VeggieBurger());
                    }
                    if(b.Name == "mushroomSwissBurger")
                    {
                        list.Add(new MushroomSwissBurger());
                    }

                    //Ice Cream
                    if(b.Name == "classicSundae")
                    {
                        list.Add(new ClassicSundae());
                    }
                    if(b.Name == "iceCreamCone")
                    {
                        list.Add(new IceCreamCone());
                    }
                    if(b.Name == "brownieSundae")
                    {
                        list.Add(new BrownieSundae());
                    }
                    if(b.Name == "strawberryShortcake")
                    {
                        list.Add(new StrawBerryShortcake());
                    }
                    if(b.Name == "winterSwirl")
                    {
                        list.Add(new WinterSwirl());
                    }

                    //drinks
                    if(b.Name == "coffee")
                    {
                        list.Add(new Coffee());
                    }
                    if(b.Name == "latte")
                    {
                        list.Add(new Latte());
                    }
                    if(b.Name == "mocha")
                    {
                        list.Add(new Mocha());
                    }
                }
            }
        }
    }
}
