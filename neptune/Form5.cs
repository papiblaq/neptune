using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


                    string portfolio_code_input = textBox1.Text;

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(CURRENT_BALS) AS portfolio_balance FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS WHERE PORTFOLIO_CD = :portfolio_code_input";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Bind the portfolio_code_input parameter to the query
                        cmd.Parameters.Add(new OracleParameter("PORTFOLIO_CD", portfolio_code_input));

                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value && result != null)
                        {
                            label9.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label9.Text = "(null)";
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
                    string query = "SELECT PORTFOLIO_AMT FROM PORTFOLIO_LIMIT WHERE PORTFOLIO_CD = :portfolio_code_input";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Bind the portfolio_code_input parameter to the query
                        cmd.Parameters.Add(new OracleParameter("portfolio_code_input", textBox1.Text));

                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value && result != null)
                        {
                            label10.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label10.Text = "(null)";
                        }
                    }
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
                        if (result != DBNull.Value && result != null)
                        {
                            label13.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label13.Text = "(null)";
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

                    string portfolio_code_input = textBox1.Text;

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(LEDGER_BAL) AS portfolio_balance FROM LEDGER_BAL WHERE PORTFOLIO_CD = :portfolio_code_input";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        // Bind the portfolio_code_input parameter to the query
                        cmd.Parameters.Add(new OracleParameter("PORTFOLIO_CD", portfolio_code_input));

                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value && result != null)
                        {
                            label11.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label11.Text = "(null)";
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


        private void DisplayCurrentBalance()
        {
            try
            {
                // Create a new OracleConnection
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();


                    string portfolio_code_input = textBox1.Text;

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(CURRENT_BALS) AS portfolio_balance FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS WHERE PORTFOLIO_CD = :portfolio_code_input";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Bind the portfolio_code_input parameter to the query
                        cmd.Parameters.Add(new OracleParameter("PORTFOLIO_CD", portfolio_code_input));

                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value && result != null)
                        {
                            label9.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label9.Text = "(null)";
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


        private void DisplayPercentage()
        {
            try
            {
                // Create a new OracleConnection
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string portfolio_code_input = textBox1.Text;

                    // Define your query to calculate the sum of the column
                    string query = @"SELECT 
                                    ROUND(
                                        (
                                            COUNT(*) - 
                                            COUNT(CASE WHEN DAYS_61_90 > 0 OR DAYS_91_180 > 0 OR DAYS_EX_180 > 0 THEN 1 END)
                                        ) * 100.0 / COUNT(*), 
                                        2
                                    ) AS percentage
                                FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS
                                WHERE portfolio_cd = :portfolio_code_input ";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Bind the portfolio_code_input parameter to the query
                        cmd.Parameters.Add(new OracleParameter("portfolio_code_input", portfolio_code_input));

                        // Execute the query and get the result
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check if the column is null
                                if (!reader.IsDBNull(reader.GetOrdinal("percentage")))
                                {
                                    decimal percentage = reader.GetDecimal(reader.GetOrdinal("percentage"));

                                    // Check if the percentage is 0
                                    if (percentage == 0)
                                    {
                                        label12.Text = "0.00%";
                                    }
                                    else
                                    {
                                        label12.Text = percentage.ToString("F2") + "%";
                                    }
                                }
                                else
                                {
                                    label12.Text = "(null)";
                                }
                            }
                            else
                            {
                                label12.Text = "(null)";
                            }
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







    private void DisplayPortfoliosAtRisk()
    {
        try
        {
            // Create a new OracleConnection
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                string portfolio_code_input = textBox1.Text;

                // Define your query to calculate the sum of the column
                string query = @"SELECT 
                            ROUND(
                                CAST(
                                    COUNT(CASE WHEN (DAYS_61_90 > 0 OR DAYS_91_180 > 0 OR DAYS_EX_180 > 0) THEN 1 END) AS DECIMAL(18, 2)
                                ) / 
                                CAST(
                                    COUNT(*) AS DECIMAL(18, 2)
                                ) * 100, 
                                2
                            ) AS percentage
                        FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS
                        WHERE portfolio_cd = :portfolio_code_input";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Bind the portfolio_code_input parameter to the query
                        cmd.Parameters.Add(new OracleParameter("portfolio_code_input", portfolio_code_input));

                        // Execute the query and get the result
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check if the column is null
                                if (!reader.IsDBNull(reader.GetOrdinal("percentage")))
                                {
                                    // Use GetOracleDecimal for Oracle-specific numeric types
                                    OracleDecimal oracleDecimal = reader.GetOracleDecimal(reader.GetOrdinal("percentage"));
                                    decimal percentage = oracleDecimal.Value;

                                    // Check if the percentage is 0
                                    if (percentage == 0)
                                    {
                                        label14.Text = "(null)";
                                    }
                                    else
                                    {
                                        label14.Text = percentage.ToString("F2") + "%";
                                    }
                                }
                                else
                                {
                                    label14.Text = "(null)";
                                }
                            }
                            else
                            {
                                label14.Text = "(null)";
                            }

                            // Close the connection
                            conn.Close();
                        }
                    }
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that might have occurred
            MessageBox.Show("Error: " + ex.Message);
        }
    }






    private void DisplayAmmountRepaid()
        {
            try
            {
                // Create a new OracleConnection
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string portfolio_code_input = textBox1.Text;

                    // Define your query to calculate the sum of the column
                    string query = "SELECT SUM(TOTAL_PORTFOLIO) AS portfolio_balance FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS WHERE PORTFOLIO_CD = :portfolio_code_input";

                    // Create an OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        // Bind the portfolio_code_input parameter to the query
                        cmd.Parameters.Add(new OracleParameter("PORTFOLIO_CD", portfolio_code_input));

                        // Execute the query and get the result
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display it in the label
                        if (result != DBNull.Value)
                        {
                            label13.Text = "KESH " + result.ToString();
                        }
                        else
                        {
                            label13.Text = "(null)";
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
            //DisplaySumTotal();
            //DisplayDistributementLimit();
            //DisplayLoanRspayment();
           // DisplayLoanIntrest();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("are you shure you want to logout?", "comfirmation message ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DisplayLoanIntrest();
            DisplaySumTotal();
            DisplayPercentage();
            DisplayPortfoliosAtRisk();
            DisplayAmmountRepaid();
            DisplayDistributementLimit();




        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
