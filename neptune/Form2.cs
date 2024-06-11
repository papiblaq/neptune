using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace neptune
{
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=OFFICE_DB;Persist Security Info=True;User ID=fortunelive;Password=fortunelive";
        private bool isCollapsed;

        public Form2()
        {
            InitializeComponent();
            displayPotfolioData();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

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

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e) { }

        private void button4_Click(object sender, EventArgs e) { }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        public void displayPotfolioData()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS";
                OracleDataAdapter da = new OracleDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                conn.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fillcomboboxPortfolios();
        }

        private void displayDatagrid()
        {
            // Get the selected item from the ComboBox
            string selectedObject = comboBox2.SelectedItem?.ToString();
            string portfolioCode = textBox1.Text;

            // Build the query with parameters
            string query = "SELECT * FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS WHERE 1=1";
            if (!string.IsNullOrEmpty(selectedObject))
            {
                query += " AND BU_NM = :BU_NM";
            }
            if (!string.IsNullOrEmpty(portfolioCode))
            {
                query += " AND PORTFOLIO_CD = :PORTFOLIO_CD";
            }

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Add parameters if they are not null or empty
                    if (!string.IsNullOrEmpty(selectedObject))
                    {
                        cmd.Parameters.Add(new OracleParameter("BU_NM", selectedObject));
                    }
                    if (!string.IsNullOrEmpty(portfolioCode))
                    {
                        cmd.Parameters.Add(new OracleParameter("PORTFOLIO_CD", portfolioCode));
                    }

                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        // Fill data into DataTable
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Bind DataTable to DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }

                conn.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayDatagrid();
        }

        public void fillcomboboxPortfolios()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // Create a new OracleCommand
                    using (OracleCommand cmd = new OracleCommand("SELECT DISTINCT BU_NM FROM CREDITPRO_PORTFOLIO_RISK_PRODBRS", conn))
                    {
                        // Execute the OracleCommand and retrieve the data
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear the ComboBox
                            comboBox2.Items.Clear();

                            // Loop through the data and add each unique value to the ComboBox
                            while (reader.Read())
                            {
                                comboBox2.Items.Add(reader["BU_NM"].ToString());
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textboxValue()
        {
            displayDatagrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            displayDatagrid();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            displayDatagrid();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            displayPotfolioData();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
