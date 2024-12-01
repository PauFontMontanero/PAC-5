using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PAC4___Calculadora
{
    /// <summary>
    /// This is the MainWindow of the Calculator.
    /// </summary>
    public partial class MainWindow : Window
    {
        private String ScreenText;
        private String lastChar;
        public MainWindow()
        {
            InitializeComponent();
            ScreenText = "";
        }

        /// <summary>
        /// The logic of the Button 1. It places a 1 in the calculator screen.
        /// </summary>
        private void BTOne_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "1";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 2. It places a 2 in the calculator screen.
        /// </summary>
        private void BTTwo_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "2";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 3. It places a 3 in the calculator screen.
        /// </summary>
        private void BTThree_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "3";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 4. It places a 4 in the calculator screen.
        /// </summary>
        private void BTFour_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "4";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 5. It places a 5 in the calculator screen.
        /// </summary>
        private void BTFive_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "5";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 6. It places a 6 in the calculator screen.
        /// </summary>
        private void BTSix_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "6";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 7. It places a 7 in the calculator screen.
        /// </summary>
        private void BTSeven_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "7";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 8. It places a 8 in the calculator screen.
        /// </summary>
        private void BTEight_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "8";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 9. It places a 9 in the calculator screen.
        /// </summary>
        private void BTNine_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "9";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// The logic of the Button 0. It places a 0 in the calculator screen.
        /// </summary>
        private void BTZero_Click(object sender, RoutedEventArgs e)
        {
            ScreenText += "0";
            Screen.Text = ScreenText;
        }
        //OPERATIONS
        /// <summary>
        /// The logic of the Button +. It places a + in the calculator screen.
        /// </summary>
        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {

            if (lastChar != null && !"+-*/".Contains(lastChar))
            {
                ScreenText += "+";
                Screen.Text = ScreenText;
            }

        }
        /// <summary>
        /// The logic of the Button -. It places a - in the calculator screen.
        /// </summary>
        private void BTSub_Click(object sender, RoutedEventArgs e)
        {

            if (lastChar != null && !"+-*/".Contains(lastChar))
            {
                ScreenText += "-";
                Screen.Text = ScreenText;
            }

        }
        /// <summary>
        /// The logic of the Button *. It places a * in the calculator screen.
        /// </summary>
        private void BTMul_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/".Contains(lastChar))
            {
                ScreenText += "*";
                Screen.Text = ScreenText;
            }
        }
        /// <summary>
        /// The logic of the Button /. It places a / in the calculator screen.
        /// </summary>
        private void BTDiv_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/".Contains(lastChar))
            {
                ScreenText += "/";
                Screen.Text = ScreenText;
            }
        }
        /// <summary>
        /// The logic of the Button =. Writes the result of the current operation on the screen.
        /// </summary>
        private void BTEqual_Click(object sender, RoutedEventArgs e)
        {
            if (lastChar != null && !"+-*/".Contains(lastChar))
            {
                String result = Calculate(ButcherOperation());
                ScreenText = result;
                Screen.Text = ScreenText;
            }
        }
        /// <summary>
        /// The logic of the Button C. It deletes all the content of the screen.
        /// </summary>
        private void BTC_Click(object sender, RoutedEventArgs e)
        {
            ScreenText = "";
            Screen.Text = ScreenText;
        }
        /// <summary>
        /// This function updates the lastChar variable. This variable is used to check if the last character of the screen is a operator, and if it can be placed on the screen.
        /// </summary>
        private void ScreenTextChanged(object sender, TextChangedEventArgs e)
        {
            if (ScreenText != null && ScreenText != "")
            {
                lastChar = ScreenText.Substring(ScreenText.Length - 1);
            }
        }
        /// <summary>
        /// This function permits the usage of the NumPad of the keyboard in the aplication.
        /// </summary>
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
        /// <summary>
        /// This function gets the current text on the screen and it divides the text in values and operators in a Array
        /// </summary>
        /// <returns>String[] of the values and operators of the screen text</returns>
        private String[] ButcherOperation()
        {
            // First, count the operators to determine array size
            int operators = 0;
            foreach (char character in ScreenText)
            {
                if (!char.IsDigit(character))
                {
                    operators++;
                }
            }

            // Create array with exact size needed
            String[] butcheredOperation = new String[operators * 2 + 1];
            String value = "";
            int index = 0;

            // Fill the array
            foreach (char character in ScreenText)
            {
                if (char.IsDigit(character))
                {
                    value += character;
                }
                else
                {
                    butcheredOperation[index] = value;
                    index++;
                    butcheredOperation[index] = character.ToString();
                    index++;
                    value = "";
                }
            }
            butcheredOperation[index] = value;  // Add last number
            return butcheredOperation;
        }
        /// <summary>
        /// This function does the order of operations.
        /// </summary>
        /// <param name="butcheredOperation">The array of values and operators</param>
        /// <returns>Returns the String final result of the operation.</returns>
        private String Calculate(String[] butcheredOperation)
        {
            // First pass: multiplication and division
            for (int i = 1; i < butcheredOperation.Length; i += 2)
            {
                if (butcheredOperation[i] == "*" || butcheredOperation[i] == "/")
                {
                    String a = butcheredOperation[i - 1];
                    String b = butcheredOperation[i + 1];
                    String o = butcheredOperation[i];
                    butcheredOperation[i - 1] = Operator(a, b, o);
                    butcheredOperation[i] = "";
                    butcheredOperation[i + 1] = "";

                    // Resize array after operation
                    butcheredOperation = ResizeArray(butcheredOperation);
                    i = -1;  // Reset index since we resized the array
                }
            }

            // Second pass: addition and subtraction
            for (int i = 1; i < butcheredOperation.Length; i += 2)
            {
                if (butcheredOperation[i] == "+" || butcheredOperation[i] == "-")
                {
                    String a = butcheredOperation[i - 1];
                    String b = butcheredOperation[i + 1];
                    String o = butcheredOperation[i];
                    butcheredOperation[i - 1] = Operator(a, b, o);
                    butcheredOperation[i] = "";
                    butcheredOperation[i + 1] = "";

                    // Resize array after operation
                    butcheredOperation = ResizeArray(butcheredOperation);
                    i = -1;  // Reset index since we resized the array
                }
            }

            return butcheredOperation[0];  // Final result
        }
        /// <summary>
        /// This function does the operation, getting the two values and then the operator to decide what operation needs to be done.
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="b">The second value</param>
        /// <param name="o">The operator</param>
        /// <returns>Returns the String result of the operation. In case you devide for 0 it returns error</returns>
        private String Operator(String a, String b, String o)
        {
            try
            {
                int result = 0;
                switch (o)
                {
                    case "+":
                        result = int.Parse(a) + int.Parse(b);
                        break;
                    case "-":
                        result = int.Parse(a) - int.Parse(b);
                        break;
                    case "*":
                        result = int.Parse(a) * int.Parse(b);
                        break;
                    case "/":
                        if (int.Parse(b) == 0)
                            return "Error";
                        result = int.Parse(a) / int.Parse(b);
                        break;
                }
                return result.ToString();
            }
            catch
            {
                return "Error";
            }
        }
        /// <summary>
        /// This function resize the Array to be able to continue with the operations.
        /// </summary>
        /// <param name="butcheredOperation">The array of values and operators</param>
        /// <returns>Returns the String[] with the new size</returns>
        private String[] ResizeArray(String[] butcheredOperation)
        {
            // Step 1: Count non-empty elements
            int count = 0;
            for (int i = 0; i < butcheredOperation.Length; i++)
            {
                if (!string.IsNullOrEmpty(butcheredOperation[i]))
                {
                    count++;
                }
            }

            // Step 2: Create new array with exact size needed
            String[] resizedArray = new String[count];
            int newIndex = 0;

            // Step 3: Copy non-empty elements
            for (int i = 0; i < butcheredOperation.Length; i++)
            {
                if (!string.IsNullOrEmpty(butcheredOperation[i]))
                {
                    resizedArray[newIndex] = butcheredOperation[i];
                    newIndex++;
                }
            }

            return resizedArray;
        }
    }
}