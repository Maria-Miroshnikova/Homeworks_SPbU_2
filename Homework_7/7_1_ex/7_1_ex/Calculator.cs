using System;
using System.Windows.Forms;

namespace _7_1_ex
{
    public enum Operation { PLUS, MINUS, MULTIPLICATION, DIVISION };
    public enum Sign { POSITIVE, NEGATIVE, ZERO};

    public partial class Calculator : Form
    {
        private Operation operation;
        private bool gotFirstOperand = false;
        private bool isError = false;
        private Calculation calculation;

        public Calculator()
        {
            calculation = new Calculation();
            InitializeComponent();
        }

        private void ErrorCase()
        {
            textBox.Text = "";
            labelCurrentData.Text = "";
            gotFirstOperand = false;
            isError = false;
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            if (isError)
            {
                ErrorCase();
                return;
            }

            textBox.Text += ((Button)sender).Text;
            
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (isError)
            {
                ErrorCase();
                return;
            }

            if (textBox.Text.Contains(","))
            {
                return;
            }
            textBox.Text += ',';
        }

        public void ZeroDivisionErrorMessage()
        {
            textBox.Text = "Error: division by zero";
        }

        private Operation OperationType(object sender)
        {
            string operationText = ((Button)sender).Text;
            if (operationText == "+")
            {
                return Operation.PLUS;
            }
            else if (operationText == "-")
            {
                return Operation.MINUS;
            }
            else if (operationText == "*")
            {
                return Operation.MULTIPLICATION;
            }
            else if (operationText == "/")
            {
                return Operation.DIVISION;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void buttonOperation_Click(object sender, EventArgs e)
        {
            if (isError)
            {
                ErrorCase();
                return;
            }

            if (!float.TryParse(textBox.Text, out float currentData))
            {
                return;
            }
            textBox.Clear();

            labelCurrentData.Text += $"{currentData} {((Button)sender).Text} ";
            if (!gotFirstOperand)
            {
                gotFirstOperand = true;
                operation = OperationType(sender);
                calculation.PushStack(currentData);
                return;
            }

            calculation.PushStack(currentData);  // приняли введенное до операции число число

            if (gotFirstOperand)
            {
                if (!calculation.Calculate(ref currentData, operation))
                {
                    isError = true;
                    ZeroDivisionErrorMessage();
                    return;
                }
                operation = OperationType(sender);
            }
        }

        private Sign CheckSign(float data)
        {
            if (data > 0)
            {
                return Sign.POSITIVE;
            }
            else if (data < 0)
            {
                return Sign.NEGATIVE;
            }
            else
            {
                return Sign.ZERO;
            }
        }
        
        private void buttonEqualSign_Click(object sender, EventArgs e)
        {
            if (isError)
            {
                ErrorCase();
                return;
            }

            if ((!float.TryParse(textBox.Text, out float currentData)))
            {
                return;
            }
            labelCurrentData.Text = "";

            calculation.PushStack(currentData);

            if (!gotFirstOperand)
            {
                return;
            }

            if (!calculation.Calculate(ref currentData, operation))
            {
                isError = true;
                ZeroDivisionErrorMessage();
                return;
            }

            textBox.Text = Convert.ToString(currentData);
            gotFirstOperand = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (isError)
            {
                ErrorCase();
                return;
            }

            textBox.Text = "";
            labelCurrentData.Text = "";
            gotFirstOperand = false;
            isError = false;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (isError)
            {
                ErrorCase();
                return;
            }

            float data;
            if ((!float.TryParse(textBox.Text, out data)))
            {
                textBox.Text.Replace("-", "");
                return;
            }

            switch (CheckSign(data))
            {
                case Sign.POSITIVE:
                    textBox.Text = "-" + textBox.Text;
                    break;

                case Sign.NEGATIVE:
                    textBox.Text = textBox.Text.Replace("-", "");
                    break;

                case Sign.ZERO:
                    break;

                default:
                    System.Diagnostics.Debug.Assert(false);
                    break;

            }
        }
    }
}
