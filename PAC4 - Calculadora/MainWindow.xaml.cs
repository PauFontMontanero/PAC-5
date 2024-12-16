using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PAC5___Calculadora
{
    public partial class MainWindow : Window
    {
        private String ScreenText;
        private String lastChar;
        private readonly CalculadoraCore calculadora;

        public MainWindow()
        {
            InitializeComponent();
            ScreenText = "";
            calculadora = new CalculadoraCore();
        }

        private void BTOne_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "1";
            Screen.Text = ScreenText;
        }

        private void BTTwo_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "2";
            Screen.Text = ScreenText;
        }

        private void BTThree_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "3";
            Screen.Text = ScreenText;
        }

        private void BTFour_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "4";
            Screen.Text = ScreenText;
        }

        private void BTFive_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "5";
            Screen.Text = ScreenText;
        }

        private void BTSix_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "6";
            Screen.Text = ScreenText;
        }

        private void BTSeven_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "7";
            Screen.Text = ScreenText;
        }

        private void BTEight_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "8";
            Screen.Text = ScreenText;
        }

        private void BTNine_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "9";
            Screen.Text = ScreenText;
        }

        private void BTZero_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "0";
            Screen.Text = ScreenText;
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/^".Contains(lastChar))
            {
                ScreenText += "+";
                Screen.Text = ScreenText;
            }
        }

        private void BTSub_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/^".Contains(lastChar))
            {
                ScreenText += "-";
                Screen.Text = ScreenText;
            }
        }

        private void BTMul_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/^".Contains(lastChar))
            {
                ScreenText += "*";
                Screen.Text = ScreenText;
            }
        }

        private void BTDiv_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/^".Contains(lastChar))
            {
                ScreenText += "/";
                Screen.Text = ScreenText;
            }
        }

        private void BTPow_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/^".Contains(lastChar))
            {
                ScreenText += "^";
                Screen.Text = ScreenText;
            }
        }

        private void BTSqrt_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "√";
            Screen.Text = ScreenText;
        }

        private void BTOpenPar_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "(";
            Screen.Text = ScreenText;
        }

        private void BTClosePar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ScreenText) && !"+-*/^(".Contains(lastChar))
            {
                ScreenText += ")";
                Screen.Text = ScreenText;
            }
        }

        private void BTEqual_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ScreenText) && !"+-*/^".Contains(lastChar))
            {
                try
                {
                    String result = calculadora.Calcula(ScreenText);
                    ScreenText = result;
                    Screen.Text = ScreenText;
                }
                catch (Exception)
                {
                    ScreenText = "Error";
                    Screen.Text = ScreenText;
                }
            }
        }

        private void BTC_Click(object sender, RoutedEventArgs e)
        {
            ScreenText = "";
            Screen.Text = ScreenText;
        }

        private void ScreenTextChanged(object sender, TextChangedEventArgs e)
        {
            if (ScreenText != null && ScreenText != "")
            {
                lastChar = ScreenText.Substring(ScreenText.Length - 1);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            String a = e.Key.ToString();
            switch (a)
            {
                case "NumPad0":
                    BTZero_Click(sender, e);
                    break;
                case "NumPad1":
                    BTOne_Click(sender, e);
                    break;
                case "NumPad2":
                    BTTwo_Click(sender, e);
                    break;
                case "NumPad3":
                    BTThree_Click(sender, e);
                    break;
                case "NumPad4":
                    BTFour_Click(sender, e);
                    break;
                case "NumPad5":
                    BTFive_Click(sender, e);
                    break;
                case "NumPad6":
                    BTSix_Click(sender, e);
                    break;
                case "NumPad7":
                    BTSeven_Click(sender, e);
                    break;
                case "NumPad8":
                    BTEight_Click(sender, e);
                    break;
                case "NumPad9":
                    BTNine_Click(sender, e);
                    break;
                case "Add":
                    BTAdd_Click(sender, e);
                    break;
                case "Subtract":
                    BTSub_Click(sender, e);
                    break;
                case "Multiply":
                    BTMul_Click(sender, e);
                    break;
                case "Divide":
                    BTDiv_Click(sender, e);
                    break;
                case "Enter":
                    BTEqual_Click(sender, e);
                    break;
                default:
                    // Handle other cases or ignore them
                    break;
            }
        }
    }
}