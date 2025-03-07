using System;
using System.Collections.Generic;
using System.IO;
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
        /// Whether this drink has coffee in it.
        /// </summary>
        protected bool _vanilla;

        /// <summary>
        /// Whether this drink contains vanilla.
        /// </summary>
        public abstract bool Vanilla { get; set; }

        /// <summary>
        /// If the drink has cream.
        /// </summary>
        protected bool _cream;

        /// <summary>
        /// Whether the drink has cream.
        /// </summary>
        public abstract bool Cream { get; set; }
       

        /// <summary>
        /// If the drink has sugar.
        /// </summary>
        protected bool _sugar;

        /// <summary>
        /// Whether the drink has sugar.
        /// </summary>
        public abstract bool Sugar { get; set; }
        

        /// <summary>
        /// Starting price for the coffee.
        /// </summary>
        protected decimal _startingCost;

        /// <summary>
        /// Gets the price of the drink.
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = _startingCost;
                if(SizeOfCup == CoffeeSize.Grande)
                {
                    cost += .75m;
                }
                if(SizeOfCup == CoffeeSize.Venti)
                {
                    cost += 1.25m;
                }
                if(Vanilla == true)
                {
                    cost += .24m;
                }

                return cost;
            }

        }

        /// <summary>
        /// The starting calories for this drink.
        /// </summary>
        protected uint _startingCals;

        /// <summary>
        /// The total number of calories in this coffee
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = _startingCals;
                if (Decaf == true)
                {
                    cals -= 3;
                }
                if (Cream == true)
                {
                    cals += 40;
                }
                if (Sugar == true)
                {
                    cals += 25;
                }
                if(Vanilla == true)
                {
                    cals += 80;
                }
                if (SizeOfCup == CoffeeSize.Grande)
                {
                    cals = (uint)(cals * (16.0 / 12.0));
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    cals = (uint)(cals * (20.0 / 12.0));
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this coffee
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Iced == true)
                {
                    instructions.Add("Iced");
                }
                if (Decaf == true)
                {
                    instructions.Add("Decaf");
                }
                if (Cream == true)
                {
                    instructions.Add("Add Cream");
                }
                if (Sugar == true)
                {
                    instructions.Add("Add Sugar");
                }
                if(Vanilla == true)
                {
                    instructions.Add("Add Vanilla");
                }
                if (SizeOfCup == CoffeeSize.Grande)
                {
                    instructions.Add("Grande");
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    instructions.Add("Venti");
                }

                return instructions;
            }
        }

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

        /// <summary>
        /// Gets the name of the drink.
        /// </summary>
        /// <returns>The name of the drink.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
