using DairyBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DairyBarn.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : UserControl
    {
        public event EventHandler<MenuItemEventArgs>? FinishedPayEvent;

        public PaymentView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the button is clicked the following message appears.
        /// </summary>
        /// <param name="sender">The finalize payment and print receipt button.</param>
        /// <param name="e">Displays a message box with the message.</param>
        public void FinalizePaymentClick(object sender, RoutedEventArgs e)
        {
            
                //string receipt = viewModel.Receipts;
                //viewModel.FinishPayment();
                MessageBox.Show("Payment has been finalized and the receipt is being printed. Click OK to continue.");
                //FinishedPayEvent?.Invoke(this, new MenuItemEventArgs(viewModel.Order));
            
        }
    }
}
