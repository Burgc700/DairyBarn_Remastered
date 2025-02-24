using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of the Mocha class.
    /// </summary>
    public class Mocha : Drink
    {
        /// <summary>
        /// The name of the Mocha instance.
        /// </summary>
        public override string Name { get; } = "Mocha";

        /// <summary>
        /// The description of this drink.
        /// </summary>
        public override string Description { get; } = "Chocolate, espresso, and steamed milk with decaf and ice options available.";

        /// <summary>
        /// If this drink has vanilla in it.
        /// </summary>
        public override bool Vanilla
        {
            get => _vanilla;
            set
            {
                if (_vanilla == false)
                {
                    _vanilla = value;
                }
                if (_vanilla == true)
                {
                    _vanilla = false;
                }
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
                if (_cream == false)
                {
                    _cream = value;
                }
                if (_cream == true)
                {
                    _cream = false;
                }
            }
        }

        /// <summary>
        /// Whether this drink has sugar
        /// </summary>
        public override bool Sugar
        {
            get => _sugar;
            set
            {
                if (_sugar == false)
                {
                    _sugar = value;
                }
                if (_sugar == true)
                {
                    _sugar = false;
                }
            }
        }

        public Mocha()
        {
            _sizeOfCup = CoffeeSize.Tall;
            Iced = false;
            Decaf = false;
            _vanilla = false;
            _sugar = false;
            _cream = false;
            _startingCost = 3.99m;
            _startingCals = 200;
        }
    }
}
