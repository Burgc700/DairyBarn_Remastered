using DairyBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DairyBarn.PointOfSale
{
    /// <summary>
    /// Defines a custom event args to use when customizing menu items.
    /// </summary>
    public class MenuItemEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// The menu item we are selecting to customize.
        /// </summary>
        public IMenuItem MenuItem { get; }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="s">The menu item name.</param>
        public MenuItemEventArgs(IMenuItem s)
        {
            MenuItem = s;
        }
    }
}
