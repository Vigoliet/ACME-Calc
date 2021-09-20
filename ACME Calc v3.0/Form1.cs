using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACME_Calc_v3._0
{
    public partial class Form1 : Form
    {
        CalculationEngine MyEngine = new CalculationEngine(); //copies to the memory, initiates
                                                              //can become an issue if you have the wrong namespace 
                                                              //by copying from a previous task.
        public Form1()
        {
            InitializeComponent();
            addition.Text = "+";            //sender
            subtraction.Text = "-";         //sender
            multiplication.Text = "*";      //sender
            division.Text = "/";            //sender

            addition.Click += new EventHandler(ButtonHandler);
            subtraction.Click += new EventHandler(ButtonHandler);
            multiplication.Click += new EventHandler(ButtonHandler);
            division.Click += new EventHandler(ButtonHandler);

            // We want to control the textbox, so that only numbers through 0-9 are allowed.
            textBox1.KeyPress += new KeyPressEventHandler(KeyPressControl);
            textBox2.KeyPress += new KeyPressEventHandler(KeyPressControl);
        }
        // Here's the Control
        private void KeyPressControl(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                //Not a number
                //We need to handle Backspace

                //Handled cancels the flow to the textbox,
                //by fooling that it has already been handled
                if (((short)e.KeyChar) != 8)
                {
                    e.Handled = true;
                }
            }

        }
        private void ButtonHandler(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string operation = btn.Text;
            double i = double.Parse(textBox1.Text);
            double j = double.Parse(textBox2.Text);
            double answer = 0;

            switch (operation)
            {
                case "+":
                    answer = MyEngine.Add(i, j);
                    break;

                case "-":
                    answer = MyEngine.Subtract(i, j);
                    break;

                case "*":
                    answer = MyEngine.Multiply(i, j); //Note that dividing by 0 does not result in an issue due to the use of double
                    break;                            //Instead it returns the value of infinate, therefore using try & catch is not needed

                case "/":
                    answer = MyEngine.Divide(i, j);
                    break;

                default:
                    break;
            }

            PresentResult(i, j, answer, operation);

        }
        private void PresentResult(double i, double j, double answer, string operation) // här lägger man in parametrarna i listboxen. Var tvungen att ta bort static
        {
            listBox1.Items.Add($"{i} {operation} {j} = {answer}");
        }
    }
}
