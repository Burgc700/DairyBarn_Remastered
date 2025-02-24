using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// An instance where more than one item is on the order.
    /// </summary>
    public class Order : ICollection<IMenuItem>
    {
        /// <summary>
        /// List of menu items on this order.
        /// </summary>
        private List<IMenuItem> _menuItems = new();

        /// <summary>
        /// Calculates the subtotal for all the items being ordered.
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0;
                foreach(IMenuItem item in _menuItems)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }

        /// <summary>
        /// Represents the sales tax rate.
        /// </summary>
        public decimal TaxRate { get; set; } = 0.0915m;

        /// <summary>
        /// The tax for the order.
        /// </summary>
        public decimal Tax => (Subtotal * TaxRate);

        /// <summary>
        /// The total cost of the items ordered.
        /// </summary>
        public decimal Total => Subtotal + Tax;

        /// <summary>
        /// Finds the count of things on the order.
        /// </summary>
        public int Count => _menuItems.Count;

        /// <summary>
        /// If the order is readonly.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds items to the order.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(IMenuItem item)
        {
            if(item != null)
            {
                _menuItems.Add(item);
            }
        }

        /// <summary>
        /// Clears the order of all items.
        /// </summary>
        public void Clear()
        {
            _menuItems.Clear();
        }

        /// <summary>
        /// Finds if the item is on the menu.
        /// </summary>
        /// <param name="item">The item we are searching for.</param>
        /// <returns>Whether the item is or isn't on the menu.</returns>
        public bool Contains(IMenuItem item)
        {
            if(_menuItems.Contains(item))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Copies the elements from IMenuItem to the order.
        /// </summary>
        /// <param name="array">The things on the menu.</param>
        /// <param name="arrayIndex">The position we are at.</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _menuItems.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Finds all the items on the menu.
        /// </summary>
        /// <returns>All the items on the menu.</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            foreach(IMenuItem item in _menuItems)
            {
                if(item is Burger)
                {
                    yield return item;
                }
            }

            foreach(IMenuItem item in _menuItems)
            {
                if(item is IceCream)
                {
                    yield return item;
                }
            }

            foreach(IMenuItem item in _menuItems)
            {
                if(item is Drink)
                {
                    yield return item;
                }
            }

            foreach(IMenuItem item in _menuItems)
            {
                if(item is PickTwo)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Removes items from the order.
        /// </summary>
        /// <param name="item">The item we are removing.</param>
        /// <returns>If the item was removed or not.</returns>
        public bool Remove(IMenuItem item)
        {
            if(_menuItems.Remove(item))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
