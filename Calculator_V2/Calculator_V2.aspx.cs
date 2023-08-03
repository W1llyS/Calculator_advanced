using System;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator_V2
{
    public partial class Calculator_V2 : System.Web.UI.Page
    {
        public void SendError(Exception ex)
        {         
            System.Diagnostics.Debug.WriteLine(ex.ToString()); 
        }

        // DataLayer instance for data access
        private DataLayer dataLayer = new DataLayer();

        // ViewState variables to store calculator state
        protected double resultValue
        {
            get { return ViewState["resultValue"] != null ? (double)ViewState["resultValue"] : 0; }
            set { ViewState["resultValue"] = value; }
        }

        protected string operationPerformed
        {
            get { return ViewState["operationPerformed"] != null ? (string)ViewState["operationPerformed"] : ""; }
            set { ViewState["operationPerformed"] = value; }
        }

        protected bool isOperationPerformed
        {
            get { return ViewState["isOperationPerformed"] != null ? (bool)ViewState["isOperationPerformed"] : false; }
            set { ViewState["isOperationPerformed"] = value; }
        }

        protected bool justCalculated
        {
            get { return ViewState["justCalculated"] != null ? (bool)ViewState["justCalculated"] : false; }
            set { ViewState["justCalculated"] = value; }
        }     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadHistory(); // Load and display calculation history on initial page load
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (justCalculated)
            {
                TextBoxVysledek.Text = string.Empty;
                justCalculated = false;
            }

            if ((TextBoxVysledek.Text == "0") || (isOperationPerformed))
            {
                TextBoxVysledek.Text = string.Empty;
            }

            isOperationPerformed = false;
            Button button = (Button)sender;
            TextBoxVysledek.Text = TextBoxVysledek.Text + button.Text; // will show clicked digit on the display
        }

        protected void Operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;  // Store the selected arithmetic operator
            resultValue = double.Parse(TextBoxVysledek.Text); // Store the first number for the operation
            isOperationPerformed = true;
        }

        protected void ButtonC_Click(object sender, EventArgs e)
        {
            TextBoxVysledek.Text = "0"; // Clear the display
            resultValue = 0; // Reset the first number for the next calculation
        }

        protected void ButtonSpocitat_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(TextBoxVysledek.Text);
            double result = 0;

            // Perform the calculation based on the selected operator
            switch (operationPerformed)
            {
                case "+":
                    result = resultValue + secondNumber;
                    break;
                case "-":
                    result = resultValue - secondNumber;
                    break;
                case "*":
                    result = resultValue * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result = resultValue / secondNumber;
                    }
                    else
                    {
                        
                        TextBoxVysledek.Text = "Error: Division by zero";
                        return; // Exit the method without saving the result
                    }
                    break;
                default:
                    break;
            }

            // Round the result to the closest whole number if checkbox is checked
            if (CheckBoxWholeNumbers.Checked)
            {
                result = Math.Round(result); 
            }

            // Display the result, save it in the history, and reload the history
            TextBoxVysledek.Text = result.ToString();
            dataLayer.SaveResult(resultValue, operationPerformed, secondNumber, result);
            LoadHistory();

            // Setting the variable for the next calculation
            justCalculated = true;
            operationPerformed = "";
            resultValue = 0;
            isOperationPerformed = false;
        }

        // Method to load and display calculation history
        private void LoadHistory()
        {
            try
            {
                var history = dataLayer.GetHistory();
                TextBoxHistory.Text = ""; // Deleting existing content
                foreach (var record in history)
                {
                    TextBoxHistory.Text += $"{record.FirstNumber} {record.Operation} {record.SecondNumber} = {record.Result}\r\n";
                }
            }
            catch (Exception ex)
            {
                TextBoxHistory.Text = $"Chyba při načítání historie: {ex.Message}\r\n";
                SendError(ex); 
            }
        }
    }
}
