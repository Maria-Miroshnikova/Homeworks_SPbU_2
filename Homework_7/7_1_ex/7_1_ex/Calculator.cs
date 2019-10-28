using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_1_ex
{
    public partial class Calculator : Form
    {
        private Stack<float> stack;
        private float currentData;
        private bool isPositive = true;
        private int operationNumber;

        public Calculator()
        {
            stack = new Stack<float>();
            InitializeComponent();
        }

        private void buttonNumber1_Click(object sender, EventArgs e)
        {
            textBox.Text += 1;
            
        }

        private void buttonNumber2_Click(object sender, EventArgs e)
        {
            textBox.Text += 2;
        }

        private void buttonNumber3_Click(object sender, EventArgs e)
        {
            textBox.Text += 3;
        }

        private void buttonNumber4_Click(object sender, EventArgs e)
        {
            textBox.Text += 4;
        }

        private void buttonNumber5_Click(object sender, EventArgs e)
        {
            textBox.Text += 5;
        }

        private void buttonNumber6_Click(object sender, EventArgs e)
        {
            textBox.Text += 6;
        }

        private void buttonNumber7_Click(object sender, EventArgs e)
        {
            textBox.Text += 7;
        }

        private void buttonNumber8_Click(object sender, EventArgs e)
        {
            textBox.Text += 8;
        }

        private void buttonNumber9_Click(object sender, EventArgs e)
        {
            textBox.Text += 9;
        }

        private void buttonNumber0_Click(object sender, EventArgs e)
        {
            textBox.Text += 0;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            textBox.Text += ',';
        }

        private void ZeroDivisionErrorMessage()
        {
            textBox.Text = "Error: division by zero";
        }

        private void buttonOperationPlus_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox.Text, out currentData))
            {
                return;
            }
            textBox.Clear();
            labelCurrentData.Text = currentData.ToString() + "+";
            stack.Push(currentData);

            isPositive = true;
            operationNumber = 1;
        }

        private void buttonOperationMinus_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox.Text, out currentData))
            {
                return;
            }
            textBox.Clear();
            labelCurrentData.Text = currentData.ToString() + "-";
            stack.Push(currentData);

            isPositive = true;
            operationNumber = 2;
        }

        private void buttonOperationMultiplication_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox.Text, out currentData))
            {
                return;
            }
            textBox.Clear();
            labelCurrentData.Text = currentData.ToString() + "*";
            stack.Push(currentData);

            isPositive = true;
            operationNumber = 3;
        }

        private void buttonOperationDivision_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox.Text, out currentData))
            {
                return;
            }
            textBox.Clear();
            labelCurrentData.Text = currentData.ToString() + "/";
            stack.Push(currentData);

            isPositive = true;
            operationNumber = 4;
        }

        private void calculate()
        {
            float secondOperand = stack.Pop();
            float firstOperand = stack.Pop();

            switch(operationNumber)
            {
                case 1:
                    currentData = firstOperand + secondOperand;
                    textBox.Text = currentData.ToString();
                    break;
                case 2:
                    currentData = firstOperand - secondOperand;
                    textBox.Text = currentData.ToString();
                    break;
                case 3:
                    currentData = firstOperand * secondOperand;
                    textBox.Text = currentData.ToString();
                    break;
                case 4:
                    if (secondOperand == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    currentData = firstOperand / secondOperand;
                    textBox.Text = currentData.ToString();
                    break;

                default:
                    break;
            }

            isPositive = currentData > 0;
            stack.Push(currentData);
        }

        private void buttonEqualSign_Click(object sender, EventArgs e)
        {
            if ((!float.TryParse(textBox.Text, out currentData)) || (operationNumber == 0))
            {
                return;
            }
            textBox.Clear();
            labelCurrentData.Text = "";

            stack.Push(currentData);
            
            calculate();
            operationNumber = 0;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            labelCurrentData.Text = "";
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (isPositive)
            {
                textBox.Text = "-" + textBox.Text;
            }
            else
            {
                textBox.Text = textBox.Text.Replace("-", "");
            }

            isPositive = !isPositive;
        }
    }
}
