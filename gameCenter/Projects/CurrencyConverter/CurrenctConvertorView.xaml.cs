using gameCenter.Projects.CurrencyConverter.Services;
using Microsoft.Extensions.Configuration;
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
using System.Windows.Shapes;

namespace gameCenter.Projects.CurrencyConverter
{
    /// <summary>
    /// Interaction logic for CurrenctConvertorView.xaml
    /// </summary>

  
    public partial class CurrenctConvertorView : Window
    {
        private CurrencyService _currencyService;
        private Dictionary<string, double> _exchangeRates;

       public CurrenctConvertorView()
        {
            InitializeComponent();
            _currencyService = new CurrencyService();
            LoadCurrencies();
            
        }

        


        private async void LoadCurrencies()
        {
            try
            {
                //We need to excute the method await _currencyService.GetExchangeRatesAsync()
                _exchangeRates = await _currencyService.GetExchangeRatesAsync();
                //get string[] of the keys of the dictionary
                string[] currencies = _exchangeRates.Keys.ToArray();
                //set the ItemsSource of the combo boxes to the string array of the currencies names
                FromCurrencyComboBox.ItemsSource = currencies;
                ToCurrencyComboBox.ItemsSource = currencies;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading currencies: {ex.Message}");
            }




        }
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                    return;

                // Get selected currencies and amount
                string fromCurrency = FromCurrencyComboBox.SelectedItem.ToString();
                string toCurrency = ToCurrencyComboBox.SelectedItem.ToString();
                double amount = double.Parse(AmountTextBox.Text);

                // Retrieve exchange rates from the dictionary
                if (_exchangeRates.TryGetValue(fromCurrency, out double baseToFromRate) &&
                    _exchangeRates.TryGetValue(toCurrency, out double baseToToRate))
                {
                    // Calculate converted amount
                    double convertedAmount = (baseToToRate / baseToFromRate) * amount;
                    txtResult.Text = $"Converted Amount: {amount} {fromCurrency} is {convertedAmount:0.00} {toCurrency}";
                }
                else
                {
                    MessageBox.Show("Exchange rates not available for selected currencies.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(FromCurrencyComboBox.SelectedItem as string) ||
                string.IsNullOrEmpty(ToCurrencyComboBox.SelectedItem as string))
            {
                MessageBox.Show("Please select source and target currencies.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(AmountTextBox.Text) || !double.TryParse(AmountTextBox.Text, out _))
            {
                MessageBox.Show("Please enter a valid amount.");
                return false;
            }

            return true;
        }

    }
}
