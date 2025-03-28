using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Eliminates duplicated code from the classes with ice cream.
    /// </summary>
    public abstract class IceCream : IMenuItem
    {
        /// <summary>
        /// Finds the listens and tells it that the property has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the menu item with ice cream.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the menu item with ice cream.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the menu item with ice cream.
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The calories of the menu item with ice cream.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The preparation information for the menu item with ice cream.
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// The number of scoops.
        /// </summary>
        protected uint _defaultScoops;

        /// <summary>
        /// The minimum number of scoops.
        /// </summary>
        protected uint _minScoops;

        /// <summary>
        /// The maximum number of scoops.
        /// </summary>
        protected uint _maxScoops;

        /// <summary>
        /// The number of scoops in this menu item.
        /// </summary>
        protected uint _scoops;

        /// <summary>
        /// The number of scoops of ice cream.
        /// </summary>
        public uint Scoops
        {
            get => _scoops;
            set
            {
                if (value >= _minScoops && value <= _maxScoops)
                {
                    _scoops = value;
                }
                OnPropertyChanged(nameof(Scoops));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default sauce option.
        /// </summary>
        protected IceCreamSauce _defaultChoice = IceCreamSauce.None;

        /// <summary>
        /// The choice of sauce for the ice cream.
        /// </summary>
        public IceCreamSauce SauceChoice
        {
            get => _sauceChoice;
            set
            {
                if (SauceOptions.Contains(value))
                {
                    _sauceChoice = value;
                }
                OnPropertyChanged(nameof(SauceChoice));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The current sauce choice.
        /// </summary>
        protected IceCreamSauce _sauceChoice = IceCreamSauce.None;

        /// <summary>
        /// The different sauce options allowed on this ice cream.
        /// </summary>
        public List<IceCreamSauce> SauceOptions { get; } = new();

        /// <summary>
        /// Gets the name of the ice cream.
        /// </summary>
        /// <returns>The name of the ice cream.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Helper method to invoke the properties that are changing when customizing the control.
        /// </summary>
        /// <param name="propertyName">The property we are invoking the change on.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
