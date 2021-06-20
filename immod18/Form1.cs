using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace immod18
{
    public partial class Form1 : Form
    {
        public int windowNumber;
        public int customersInQueueNumber;
        public int customersServed;
        Random rnd = new Random();
        public double l = 200, m = 80;
        public Form1()
        {
            InitializeComponent();
            customersInQueueNumber = 0;
            customersServed = 0;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            windowsUpDown.Enabled = false;
            windowNumber = (int)windowsUpDown.Value;
            customersServed = windowNumber;
            textBox1.Text = "";

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            servedCustBox.Text = customersServed.ToString();
            queueBox.Text = customersInQueueNumber.ToString();
            double theory = countValues(l);
            textBox1.Text += "Customers served: " + customersServed + Environment.NewLine;
            double discrete = countValues(m * customersServed);
            textBox1.Text += "Queue: " + customersInQueueNumber + Environment.NewLine;
            textBox1.Text += "N: " + windowNumber + Environment.NewLine + "Theory: " + theory + Environment.NewLine + "Discrete: " + discrete + Environment.NewLine;
            if(theory > discrete)
            {
                if (customersServed >= windowNumber)
                {
                    customersInQueueNumber++;
                } 
                else 
                {
                    customersServed++;
                }
            } 
            else
            {
                if (customersInQueueNumber == 0)
                {
                    if (customersServed > 0)
                    {
                        customersServed--;
                    }
                }
                else
                {
                    if (customersInQueueNumber > 0)
                    {
                        customersInQueueNumber--;
                    }
                }
            }


        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            servedCustBox.Text = "";
            queueBox.Text = "";
            windowsUpDown.Enabled = true;
            textBox1.Text += "Stop" + Environment.NewLine;
            customersServed = 0;
            customersInQueueNumber = 0;
        }

        private double countValues(double n)
        {
            return n * Math.Exp(n * rnd.NextDouble() * (-1));
        }
    }
}
