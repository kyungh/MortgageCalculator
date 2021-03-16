using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace MortgageCalculator
{
    //**Public access modifiers**
    public partial class Form1 : Form
    {
        //Starts Form
        public Form1()
        {
            InitializeComponent();
        }

        //Code excecuted when "Calculate" button is clicked
        // **Non-static Void Method**
        public void calculatebtn_Click(object sender, EventArgs e)
        {
            //Error handling for empty textboxes
            //**Loops**
            while (true)
            {
                if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text.All(char.IsLetter))
                {
                    System.Windows.Forms.MessageBox.Show("Please enter a real number!");
                    Application.Restart();
                }

                if (String.IsNullOrEmpty(textBox2.Text) || textBox1.Text.All(char.IsLetter))
                {
                    System.Windows.Forms.MessageBox.Show("Please enter a downpayment");
                    Application.Restart();
                }
                break;
            }

            //Convert textbox string to doubles/decimals
            double homeprice = Convert.ToDouble(textBox1.Text);
            double downpay = Convert.ToDouble(textBox2.Text);
            decimal loanlen = Convert.ToDecimal(textBox3.Text);
            decimal interestrate = Convert.ToDecimal(textBox4.Text);

            //Math to produce mortgage information
            double principle = MathTools.ToSub(homeprice, downpay);
            decimal power = 12 * loanlen;
            decimal monthlyint = (decimal)interestrate / 12;
            decimal p3 = (1 + monthlyint);
            decimal p5 = MathTools.ToPower((decimal)p3, (int)power);
            decimal denom = MathTools.ToPower((decimal)p3, (int)power) - 1;

            decimal numer = (decimal)principle * (decimal)monthlyint * p5;

            //Executes code to display name
            Client client = new Client((string)textBox6.Text);

            //Property test
            //client.Name = "Property Example";
            label12.Text = "Hello " + client.DisplayName() + "!";


            //dividing by 0 error handling
            if (monthlyint != 0)
            {   
                decimal result = numer / denom;
                decimal totalresult = result * power;

                label6.Text = "$" + (Decimal.Round(result, 2));
                label11.Text = "$" + (Decimal.Round(totalresult, 2));

                textCreate(); //Creates log for results
            }
            else
            { 
                System.Windows.Forms.MessageBox.Show("Please enter a real number!"); 
            }
        }

        //Code excecuted when tab2 "Calculate" button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            double range1 = Convert.ToDouble(textBox7.Text);
            double range2 = Convert.ToDouble(textBox5.Text);

            List<double> numbers = new List<double>();
            numbers.Add(range1);
            numbers.Add(range2);
        }

        //Creates a log of the calculated results (**Work with files**)
        //**Private access modifiers**
        //**Non-static void method**
        private void textCreate()
        {   //**Array**
            //Creates an exported textfile to log results for future import capabilities into Microsoft Excel
            string[] array = new string[] { label6.Text, label11.Text };
            string fileName = "exportresult.txt";
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                foreach (string i in array)
                {
                    sw.WriteLine(i);
                }
            }
        }
        //Resets form when Reset button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
