using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Defines an Interface that stores common properties between classes
    /// </summary>
    public interface IMenuItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the menu item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The description of the menu item.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The price of the menu item.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The calories of the menu item.
        /// </summary>
        public uint Calories { get; }

        /// <summary>
        /// The preparation information of the menu item.
        /// </summary>
        public IEnumerable<string> PreparationInformation { get; }
    }
}
