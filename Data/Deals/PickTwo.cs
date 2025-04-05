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
        /// List of Burgers that can be applied to pick two.
        /// </summary>
        public List<Burger> BurgerOptions
        {
            get
            {
                List<Burger> list = new();
                list.Add(_burgerChoice);

                if (BurgerChoice is not ClassicCheeseburger) list.Add(new ClassicCheeseburger());
                if (BurgerChoice is not VeggieBurger) list.Add(new VeggieBurger());
                if (BurgerChoice is not BBQBaconCheeseburger) list.Add(new BBQBaconCheeseburger());
                if (BurgerChoice is not BYOBurger) list.Add(new BYOBurger());
                if (BurgerChoice is not MushroomSwissBurger) list.Add(new MushroomSwissBurger());
                return list;
            }
        }

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
                if(value != _burgerChoice)
                {
                    _burgerChoice.PropertyChanged -= HandleBurgerChanged;
                    _burgerChoice = value;
                    _burgerChoice.PropertyChanged += HandleBurgerChanged;
                    OnPropertyChanged(nameof(BurgerChoice));
                    OnPropertyChanged(nameof(BurgerOptions));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// List of ice creams that applied to pick two.
        /// </summary>
        public List<IceCream> IceCreamOptions
        {
            get
            {
                List<IceCream> list = new();
                list.Add(_iceCreamChoice);

                if(IceCreamChoice is not ClassicSundae) list.Add(new ClassicSundae());
                if(IceCreamChoice is not BrownieSundae)list.Add(new BrownieSundae());
                if(IceCreamChoice is not IceCreamCone)list.Add(new IceCreamCone());
                if(IceCreamChoice is not StrawBerryShortcake)list.Add(new StrawBerryShortcake());
                if(IceCreamChoice is not WinterSwirl)list.Add(new WinterSwirl());
                return list;
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
                if(value != _iceCreamChoice)
                {
                    _iceCreamChoice.PropertyChanged -= HandleBurgerChanged;
                    _iceCreamChoice = value;
                    _iceCreamChoice.PropertyChanged += HandleBurgerChanged;
                    OnPropertyChanged(nameof(IceCreamChoice));
                    OnPropertyChanged(nameof(IceCreamOptions));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
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
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Updates the price calories and prep info in the type of burger has changed.
        /// </summary>
        /// <param name="sender">The drop down that the burger has changed to.</param>
        /// <param name="e">Changes the information and it is reflected on the GUI.</param>
        public void HandleBurgerChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(Calories));
            OnPropertyChanged(nameof(PreparationInformation));
            OnPropertyChanged(nameof(BurgerOptions));
        }

        public PickTwo()
        {
            _burgerChoice = new ClassicCheeseburger();
            _iceCreamChoice = new ClassicSundae();
            _burgerChoice.PropertyChanged += HandleBurgerChanged;
            _iceCreamChoice.PropertyChanged += HandleBurgerChanged;
        }
    }
}
