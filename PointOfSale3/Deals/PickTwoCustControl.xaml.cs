using DairyBarn.Data;
using System;
using System.Collections.Generic;
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

namespace DairyBarn.PointOfSale
{
    /// <summary>
    /// Interaction logic for PickTwoCustControl.xaml
    /// </summary>
    public partial class PickTwoCustControl : UserControl
    {
        public event EventHandler<MenuItemEventArgs>? EditBurgerEvent;

        public event EventHandler<MenuItemEventArgs>? EditIceCreamEvent;

        public PickTwoCustControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invokes that the menu item has changed when the button is clicked.
        /// </summary>
        /// <param name="sender">The edit burger button.</param>
        /// <param name="e">Tells main window something has changed.</param>
        public void EditBurgerClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(DataContext is PickTwo p2)
                {                                    
                    EditBurgerEvent?.Invoke(this, new MenuItemEventArgs(p2.BurgerChoice));                    
                }
            }
        }

        /// <summary>
        /// Invokes that the menu item has changed when the button is clicked.
        /// </summary>
        /// <param name="sender">The edit ice cream button.</param>
        /// <param name="e">Tells main window something has changed.</param>
        public void EditIceCreamClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(DataContext is PickTwo p2)
                {                                       
                    EditIceCreamEvent?.Invoke(this, new MenuItemEventArgs(p2.IceCreamChoice));                    
                }
            }
        }
    }
}
