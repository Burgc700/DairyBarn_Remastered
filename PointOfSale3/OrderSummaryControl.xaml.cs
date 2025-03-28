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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DairyBarn.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public event EventHandler<RoutedEventArgs>? RemoveEvent;

        public event EventHandler<MenuItemEventArgs>? EditEvent;

        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes an item from the list view and updates the tax, subtotal, and total.
        /// </summary>
        /// <param name="sender">The button click</param>
        /// <param name="e">The item in the list view that is being removed.</param>
        public void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (DataContext is Order order)
                {
                    if (b.DataContext is IMenuItem item)
                    {
                        order.Remove(item);
                    }
                }
            }
            RemoveEvent?.Invoke(this, new RoutedEventArgs());
        }

        /// <summary>
        /// Displays the custom control to edit that menu item.
        /// </summary>
        /// <param name="sender">The edit button that is clicked.</param>
        /// <param name="e">The menu item control that shows when the button is clicked.</param>
        public void EditClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(DataContext is Order order)
                {
                    if(b.DataContext is IMenuItem item)
                    {
                        EditEvent?.Invoke(this, new MenuItemEventArgs(item));
                    }
                }
            }
        }
    }
}
