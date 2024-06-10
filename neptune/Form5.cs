using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neptune
{
    public partial class Form5 : Form
    {

        private string connectionString = "Data Source=OFFICE_DB;Persist Security Info=True;User ID=fortunelive;Password=fortunelive";

        private bool isCollapsed;
        public Form5()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (isCollapsed)
            {
                panelDropDown.Height += 10;
                if (panelDropDown.Size == panelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panelDropDown.Height -= 10;
                if (panelDropDown.Size == panelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("are you shure you want to logout?", "comfirmation message ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void DisplaySumTotal()
        {
            try
            {
                // Create a new OracleConnection
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(PORTFOLIO_AMMOUNT) FROM portfolios";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value)
                        {
                            label9.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label9.Text = " KESH 0";
                        }
                    }

                    // Close the connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DisplayDistributementLimit()
        {
            try
            {
                // Create a new OracleConnection
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(DISTRIBUTEMENT_LIMIT) FROM portfolio_contents";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value)
                        {
                            label10.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label10.Text = " KESH 0";
                        }
                    }

                    // Close the connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DisplayLoanRspayment()
        {
            try
            {
                // Create a new OracleConnection
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(CLEARED_BAL) FROM portfolio_contents";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value)
                        {
                            label13.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label13.Text = " KESH 0";
                        }
                    }

                    // Close the connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DisplayLoanIntrest()
        {
            try
            {
                // Create a new OracleConnection
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(PR_INT_ACCURED_LTD) FROM portfolio_contents";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value)
                        {
                            label11.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label11.Text = " KESH 0";
                        }
                    }

                    // Close the connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DisplaySumTotal();
            DisplayDistributementLimit();
            DisplayLoanRspayment();
            DisplayLoanIntrest();
        }
    }
}
