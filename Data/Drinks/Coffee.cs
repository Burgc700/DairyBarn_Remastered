using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of Coffee class
    /// </summary>
    public class Coffee : Drink
    {
        /// <summary>
        /// The name of the Coffee instance
        /// </summary>
        public override string Name { get; } = "Coffee";

        /// <summary>
        /// THe description of this coffee
        /// </summary>
        public override string Description { get; } = "Freshly brewed coffee with decaf and iced options available";

        /// <summary>
        /// Whether this coffee contains sugar
        /// </summary>
        public override bool Sugar 
        {
            get => _sugar;
            set
            {
                _sugar = value;
            }
        }

        /// <summary>
        /// Whether this drink has cream.
        /// </summary>
        public override bool Cream
        {
            get => _cream;
            set
            {
                _cream = value;
            }
        }

        /// <summary>
        /// If this drink has vanilla in it.
        /// </summary>
        public override bool Vanilla
        {
            get => _vanilla;
            set
            {
                if(_vanilla == false)
                {
                    _vanilla = value;
                }
                if(_vanilla == true)
                {
                    _vanilla = false;
                }
            }

        }

        public Coffee()
        {
            _sizeOfCup = CoffeeSize.Tall;
            Decaf = false;
            Iced = false;
            _vanilla = false;
            _cream = false;
            _sugar = false;
            _startingCost = 2.49m;
            _startingCals = 5;
        }

    }
}
