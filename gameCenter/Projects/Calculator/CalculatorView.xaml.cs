using System;
using System.Collections.Generic;
using System.Data;
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

namespace gameCenter.Projects.Calculator
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : Window
    {
        public CalculatorView()
        {
            InitializeComponent();
        }
        private bool IsErrorExpressionAppear = false;
        private bool IsStartingFromZero = true;

        private void AddNumber(string number)
        {
            if (IsErrorExpressionAppear) resultTextBlock.Text = string.Empty; IsErrorExpressionAppear = false;
            if (IsStartingFromZero) resultTextBlock.Text = string.Empty; IsStartingFromZero = false;
            resultTextBlock.Text += number;
        }

        private void buttonZero_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("0");
        }

        private void buttonOne_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("1");
        }

        private void buttonTwo_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("2");
        }

        private void buttonThree_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("3");
        }

        private void buttonFour_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("4");
        }

        private void buttonFive_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("5");
        }

        private void buttonSix_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("6");
        }

        private void buttonSeven_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("7");
        }

        private void buttonEight_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("8");
        }

        private void buttonNine_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("9");
        }


        private void maximizedButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized) WindowState &= ~WindowState.Maximized;
            else WindowState = WindowState.Maximized;
        }

   
  
 
        private void buttonComma_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(".");
        }

        private void buttonChangeSign_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(resultTextBlock.Text)) return;
            if (resultTextBlock.Text[0] == '-') resultTextBlock.Text = resultTextBlock.Text.Substring(1);
            else resultTextBlock.Text = "-" + resultTextBlock.Text;
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), resultTextBlock.Text);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                if (decimal.TryParse((string)row["expression"], out decimal result))
                {
                    previousResultTextBlock.Text = resultTextBlock.Text + " =";
                    resultTextBlock.Text = result.ToString();
                    IsErrorExpressionAppear = false;
                }
                else
                {
                    //MessageBox.Show("Looks like you have a wrong expression inside of the result box.\nPlease write a normal equaltion to get the result.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    resultTextBlock.Text = "Wrong expression!";
                    IsErrorExpressionAppear = true;
                }
            }
            catch (OverflowException)
            {
                resultTextBlock.Text = "Number is too big!";
                IsErrorExpressionAppear = true;
            }
            catch (DivideByZeroException)
            {
                resultTextBlock.Text = "You cannot divide by zero!";
                IsErrorExpressionAppear = true;
            }
            catch (SyntaxErrorException)
            {
                resultTextBlock.Text = "Wrong expression!";
                IsErrorExpressionAppear = true;
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Internal error!";
                IsErrorExpressionAppear = true;
            }
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("+");
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("-");
        }

        private void buttonMultiply_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("*");
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("/");
        }

        private void buttonRemoveCharacter_Click(object sender, RoutedEventArgs e)
        {
            if (resultTextBlock.Text.Length == 0) return;
            resultTextBlock.Text = resultTextBlock.Text.Substring(0, resultTextBlock.Text.Length - 1);
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Text = string.Empty;
            IsStartingFromZero = true;
            IsErrorExpressionAppear = false;
        }

        private void buttonClearEverything_Click(object sender, RoutedEventArgs e)
        {
            previousResultTextBlock.Text = string.Empty;
            resultTextBlock.Text = string.Empty;
            IsStartingFromZero = true;
            IsErrorExpressionAppear = false;
        }

        private void buttonParentasisLeft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(resultTextBlock.Text)) return;
                resultTextBlock.Text += "(";
                IsErrorExpressionAppear = false;
            }
            catch
            {
                resultTextBlock.Text = "Wrong expression!";
                IsErrorExpressionAppear = true;
            }
        }

        private void buttonParentasisRight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(resultTextBlock.Text)) return;
                resultTextBlock.Text += ")";
                IsErrorExpressionAppear = false;
            }
            catch
            {
                resultTextBlock.Text = "Wrong expression!";
                IsErrorExpressionAppear = true;
            }
        }

        private void buttonOneOverX_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), resultTextBlock.Text);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                if (decimal.TryParse((string)row["expression"], out decimal result))
                {
                    previousResultTextBlock.Text = "1 / " + resultTextBlock.Text + " =";
                    decimal resultOverX = (1 / result);
                    resultTextBlock.Text = resultOverX.ToString();
                    IsErrorExpressionAppear = false;
                }
                else
                {
                    //MessageBox.Show("Looks like you have a wrong expression inside of the result box.\nPlease write a normal equaltion to get the result.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    resultTextBlock.Text = "Wrong expression!";
                    IsErrorExpressionAppear = true;
                }
            }
            catch (OverflowException)
            {
                resultTextBlock.Text = "Number is too big!";
                IsErrorExpressionAppear = true;
            }
            catch (DivideByZeroException)
            {
                resultTextBlock.Text = "You cannot divide by zero!";
                IsErrorExpressionAppear = true;
            }
            catch (SyntaxErrorException)
            {
                resultTextBlock.Text = "Wrong expression!";
                IsErrorExpressionAppear = true;
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Internal error!";
                IsErrorExpressionAppear = true;
            }
        }

        private void buttonSquare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), resultTextBlock.Text);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                if (decimal.TryParse((string)row["expression"], out decimal result))
                {
                    previousResultTextBlock.Text = resultTextBlock.Text + "² =";
                    result = (decimal)MathF.Pow((float)result, 2);
                    resultTextBlock.Text = result.ToString();
                    IsErrorExpressionAppear = false;
                }
                else
                {
                    //MessageBox.Show("Looks like you have a wrong expression inside of the result box.\nPlease write a normal equaltion to get the result.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    resultTextBlock.Text = "Wrong expression!";
                    IsErrorExpressionAppear = true;
                }
            }
            catch (OverflowException)
            {
                resultTextBlock.Text = "Number is too big!";
                IsErrorExpressionAppear = true;
            }
            catch (DivideByZeroException)
            {
                resultTextBlock.Text = "You cannot divide by zero!";
                IsErrorExpressionAppear = true;
            }
            catch (SyntaxErrorException)
            {
                resultTextBlock.Text = "Wrong expression!";
                IsErrorExpressionAppear = true;
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Internal error!";
                IsErrorExpressionAppear = true;
            }
        }

        private void buttonTwoSquared_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), resultTextBlock.Text);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                if (decimal.TryParse((string)row["expression"], out decimal result))
                {
                    previousResultTextBlock.Text = "2√" + resultTextBlock.Text + " =";
                    result = (decimal)MathF.Sqrt((float)result);
                    resultTextBlock.Text = result.ToString();
                    IsErrorExpressionAppear = false;
                }
                else
                {
                    //MessageBox.Show("Looks like you have a wrong expression inside of the result box.\nPlease write a normal equaltion to get the result.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    resultTextBlock.Text = "Wrong expression!";
                    IsErrorExpressionAppear = true;
                }
            }
            catch (OverflowException)
            {
                resultTextBlock.Text = "Number is too big!";
                IsErrorExpressionAppear = true;
            }
            catch (DivideByZeroException)
            {
                resultTextBlock.Text = "You cannot divide by zero!";
                IsErrorExpressionAppear = true;
            }
            catch (SyntaxErrorException)
            {
                resultTextBlock.Text = "Wrong expression!";
                IsErrorExpressionAppear = true;
            }
            catch (Exception)
            {
                resultTextBlock.Text = "Internal error!";
                IsErrorExpressionAppear = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                if (e.Key == Key.D9) buttonParentasisLeft_Click(sender, e);
                if (e.Key == Key.D0) buttonParentasisRight_Click(sender, e);
                if (e.Key == Key.D8) buttonMultiply_Click(sender, e);
                if (e.Key == Key.OemMinus) buttonMinus_Click(sender, e);
                if (e.Key == Key.OemPlus) buttonPlus_Click(sender, e);
                if (e.Key == Key.Escape) buttonClearEverything_Click(sender, e);
                return;
            }
            switch (e.Key)
            {
                case Key.OemPeriod:
                    buttonComma_Click(sender, e);
                    break;
                case Key.OemComma:
                    buttonComma_Click(sender, e);
                    break;
                case Key.Clear:
                    buttonClearEverything_Click(sender, e);
                    break;
                case Key.Enter:
                    buttonEquals_Click(sender, e);
                    break;
                case Key.D0:
                    buttonZero_Click(sender, e);
                    break;
                case Key.D1:
                    buttonOne_Click(sender, e);
                    break;
                case Key.D2:
                    buttonTwo_Click(sender, e);
                    break;
                case Key.D3:
                    buttonThree_Click(sender, e);
                    break;
                case Key.D4:
                    buttonFour_Click(sender, e);
                    break;
                case Key.D5:
                    buttonFive_Click(sender, e);
                    break;
                case Key.D6:
                    buttonSix_Click(sender, e);
                    break;
                case Key.D7:
                    buttonSeven_Click(sender, e);
                    break;
                case Key.D8:
                    buttonEight_Click(sender, e);
                    break;
                case Key.D9:
                    buttonNine_Click(sender, e);
                    break;
                case Key.NumPad0:
                    buttonZero_Click(sender, e);
                    break;
                case Key.NumPad1:
                    buttonOne_Click(sender, e);
                    break;
                case Key.NumPad2:
                    buttonTwo_Click(sender, e);
                    break;
                case Key.NumPad3:
                    buttonThree_Click(sender, e);
                    break;
                case Key.NumPad4:
                    buttonFour_Click(sender, e);
                    break;
                case Key.NumPad5:
                    buttonFive_Click(sender, e);
                    break;
                case Key.NumPad6:
                    buttonSix_Click(sender, e);
                    break;
                case Key.NumPad7:
                    buttonSeven_Click(sender, e);
                    break;
                case Key.NumPad8:
                    buttonEight_Click(sender, e);
                    break;
                case Key.NumPad9:
                    buttonNine_Click(sender, e);
                    break;
                case Key.Multiply:
                    buttonMultiply_Click(sender, e);
                    break;
                case Key.Add:
                    buttonPlus_Click(sender, e);
                    break;
                case Key.Subtract:
                    buttonMinus_Click(sender, e);
                    break;
                case Key.Decimal:
                    buttonComma_Click(sender, e);
                    break;
                case Key.Divide:
                    buttonDivide_Click(sender, e);
                    break;
                case Key.Back:
                    buttonRemoveCharacter_Click(sender, e);
                    break;
                case Key.F11:
                    maximizedButton_Click(sender, e);
                    break;
                case Key.Escape:
                    buttonClear_Click(sender, e);
                    break;
            }
        }
    }
}