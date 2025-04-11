using DairyBarn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.PointOfSale
{
    /// <summary>
    /// The view model for the payment control.
    /// </summary>
    public class PaymentViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// An instance of the order class.
        /// </summary>
        private Order Order { get; }

        /// <summary>
        /// The subtotal.
        /// </summary>
        public decimal Subtotal => Order.Subtotal;

        /// <summary>
        /// The tax.
        /// </summary>
        public decimal Tax => Order.Tax;

        /// <summary>
        /// The total.
        /// </summary>
        public decimal Total => Order.Total;

        /// <summary>
        /// Calculates the change.
        /// </summary>
        public decimal Change
        {
            get
            {
                if(PaymentAmount >= Total)
                {
                    return PaymentAmount - Total;
                }
                return 0.00m;
            }
        }

        /// <summary>
        /// Field for the payment amount.
        /// </summary>
        private decimal _paymentAmount;

        /// <summary>
        /// Gets the payment amount. It is the same initially the same as the total.
        /// </summary>
        public decimal PaymentAmount
        {
            get
            {
                return _paymentAmount;
            }
            set
            {
                _paymentAmount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PaymentAmount)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValidPaymentAmount)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorMessage)));
                if(value < Total)
                {
                    throw new ArgumentException("Invalid funds.");
                }
            }
        }

        /// <summary>
        /// Determines if the button in the control is enabled or disabled.
        /// </summary>
        public bool ValidPaymentAmount
        {
            get
            {
                if(PaymentAmount >= Total)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// The error message to be displayed if the payment is less than the total.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                if(PaymentAmount < Total)
                {
                    throw new InvalidOperationException("Invalid funds...");
                }
                return "";
            }
        }

        /// <summary>
        /// Places all the information for the receipt.
        /// </summary>
        public string Receipts
        {
            get
            {
                StringBuilder receiptInfo = new();
                receiptInfo.AppendLine("--------------------");
                receiptInfo.AppendLine("Order: " + Order.OrderNumber);
                receiptInfo.AppendLine("Date: " + Order.PlacedAt);
                receiptInfo.AppendLine("Items:");
                foreach(IMenuItem item in Order)
                {
                    receiptInfo.AppendLine(item.Name + "  " + item.Price);
                    if(item is Burger b)
                    {
                        foreach(string prepInfo in b.PreparationInformation)
                        {
                            receiptInfo.AppendLine(prepInfo);
                        }
                    }
                    else if(item is IceCream iceCream)
                    {
                        foreach(string prepInfo in iceCream.PreparationInformation)
                        {
                            receiptInfo.AppendLine(prepInfo);
                        }
                    }
                    else if(item is Drink d)
                    {
                        foreach(string prepInfo in d.PreparationInformation)
                        {
                            receiptInfo.AppendLine(prepInfo);
                        }
                    }
                    else if( item is PickTwo p2)
                    {
                        foreach(string prepInfo in p2.PreparationInformation)
                        {
                            receiptInfo.AppendLine(prepInfo);
                        }
                    }
                }
                receiptInfo.AppendLine();
                receiptInfo.AppendLine("Subtotal: " + Subtotal);
                receiptInfo.AppendLine("Tax: " + Tax);
                receiptInfo.AppendLine("Total: " + Total);
                receiptInfo.AppendLine();
                receiptInfo.AppendLine("--------------------");
                return receiptInfo.ToString();
            }
        }

        /// <summary>
        /// Finishes the payment and saves the receipt to the assigned file.
        /// </summary>
        public void FinishPayment()
        {
            File.AppendAllText("receipts.txt", Receipts);
        }

        /// <summary>
        /// The constructor that initializes the order.
        /// </summary>
        /// <param name="order">An instance of order.</param>
        public PaymentViewViewModel(Order order)
        {
            Order = order;
            PaymentAmount = order.Total;
        }
    }
}
