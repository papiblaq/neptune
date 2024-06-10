using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

                string query = "SELECT * FROM portfolios";
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
            string selectedObject = comboBox2.SelectedItem.ToString();

            // Query the database using the selected item
            string query = "SELECT * FROM portfolios WHERE  ownership_REF LIKE '" + comboBox2.Text + "'";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Add parameter for the selected object
                    cmd.Parameters.Add(new OracleParameter("ownership_REF", selectedObject));

                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        // Fill data into DataTable
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Bind DataTable to DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayDatagrid();
        }

        private void textboxValue()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM portfolios WHERE portfolio_CD = '" + textBox1.Text + "'";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {


                    // Add the parameter to the command
                    cmd.Parameters.Add(new OracleParameter("portfolio_CD", textBox1.Text));

                    // Create a new OracleDataAdapter to retrieve the data
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        // Create a new DataTable to hold the data
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with the data retrieved by the adapter
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView to display the data
                        dataGridView1.DataSource = dataTable;
                    }
                }
                conn.Close();
            }

                
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        public void fillcomboboxPortfolios()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // Create a new OracleCommand
                    using (OracleCommand cmd = new OracleCommand("SELECT ownership_REF FROM portfolios", conn))
                    {
                        // Execute the OracleCommand and retrieve the data
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear the ComboBox
                            comboBox2.Items.Clear();

                            // Create a list to store the values
                            List<string> values = new List<string>();

                            // Loop through the data
                            while (reader.Read())
                            {
                                // Add each value to the list
                                values.Add(reader[0].ToString());
                            }

                            // Remove duplicates from the list
                            List<string> distinctValues = values.Distinct().ToList();

                            // Add each unique value to the ComboBox
                            foreach (string value in distinctValues)
                            {
                                comboBox2.Items.Add(value);
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

        private void button11_Click(object sender, EventArgs e)
        {
            textboxValue();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            displayPotfolioData();
        }
    }
}
