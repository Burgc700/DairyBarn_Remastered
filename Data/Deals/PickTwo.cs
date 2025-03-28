using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Defines an instance of the PickTwo menu item.
    /// </summary>
    public class PickTwo : IMenuItem
    {
        /// <summary>
        /// Finds the listens and tells it that the property has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the menu item.
        /// </summary>
        public string Name => "Pick Two";

        /// <summary>
        /// The description of the menu item.
        /// </summary>
        public string Description => "Any burger plus your favorite ice cream.";

        /// <summary>
        /// The default kind of burger for the deal.
        /// </summary>
        private Burger _burgerChoice = new ClassicCheeseburger();

        /// <summary>
        /// The choice of burger.
        /// </summary>
        public Burger BurgerChoice
        {
            get => _burgerChoice;
            set
            {
                _burgerChoice = value;
                OnPropertyChanged(nameof(BurgerChoice));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default kind of ice cream for the deal.
        /// </summary>
        private IceCream _iceCreamChoice = new ClassicSundae();

        /// <summary>
        /// The choice of ice cream.
        /// </summary>
        public IceCream IceCreamChoice
        {
            get => _iceCreamChoice;
            set
            {
                _iceCreamChoice = value;
                OnPropertyChanged(nameof(IceCreamChoice));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of the burger and ice cream.
        /// </summary>
        public decimal Price => ((BurgerChoice.Price + IceCreamChoice.Price) * .75m);

        /// <summary>
        /// The calories for the burger and ice cream.
        /// </summary>
        public uint Calories => (BurgerChoice.Calories + IceCreamChoice.Calories);

        /// <summary>
        /// The preparation information for the burger and ice cream.
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"Burger: {BurgerChoice.Name}");
                foreach (string topping in BurgerChoice.PreparationInformation)
                {
                    instructions.Add($"\t {topping}");
                }

                instructions.Add($"Ice Cream: {IceCreamChoice.Name}");
                foreach (string topping in IceCreamChoice.PreparationInformation)
                {
                    instructions.Add($"\t {topping}");
                }

                return instructions;
            }
        }

        /// <summary>
        /// Finds the name of the items.
        /// </summary>
        /// <returns>The name of the items.</returns>
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
