using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Eliminates duplicated code out of the drink menu items.
    /// </summary>
    public abstract class Drink : IMenuItem
    {
        /// <summary>
        /// Gets the name of the drink.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the name of the drink.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Gets the price of the drink.
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Gets the calories of the drink.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Gets the preparation information of the drink.
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// If the drink is iced.
        /// </summary>
        public bool Iced { get; set; } = false;

        /// <summary>
        /// If the drink is decaf.
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// The size of cup that comes default with the coffee.
        /// </summary>
        protected CoffeeSize _sizeOfCup = CoffeeSize.Tall;

        /// <summary>
        /// The allowed sizes of cups that come with the drinks.
        /// </summary>
        public CoffeeSize SizeOfCup
        {
            get => _sizeOfCup;
            set
            {
                if (value == CoffeeSize.Grande || value == CoffeeSize.Venti)
                {
                    _sizeOfCup = value;
                }
            }
        }
    }
}
