using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace neptune
{
    public partial class Form9 : Form
    {
        private string connectionString = "Data Source=OFFICE_DB;Persist Security Info=True;User ID=fortunelive;Password=fortunelive";
        private bool isCollapsed;

        public Form9()
        {
            InitializeComponent();
            displayViewData();
        }

        public void displayViewData()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM   AVAILABLE_ACCOUNTS_DETAILS";
                OracleDataAdapter da = new OracleDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                conn.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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

        private void button14_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

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
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            fillcombobox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void fillcombobox()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    using (OracleCommand command = new OracleCommand("SELECT DISTINCT branch_DETAILS FROM AVAILABLE_ACCOUNTS_DETAILS", conn))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            comboBox2.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox2.Items.Add(reader.GetString(0));
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

        private void displayDatagrid()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM view_portfolio_contents WHERE PORTFOLIO_CD LIKE :portfolio_CD AND branch_DETAILS LIKE :branch_DETAILS";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":portfolio_CD", "%" + textBox1.Text + "%"));
                    cmd.Parameters.Add(new OracleParameter(":branch_DETAILS", "%" + comboBox2.Text + "%"));

                    OracleDataAdapter da2 = new OracleDataAdapter(cmd);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dataGridView1.DataSource = dt2;
                }

                conn.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayDatagrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textboxValue();
        }

        private void textboxValue()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM view_portfolio_contents WHERE PORTFOLIO_CD = '" + textBox1.Text + "'";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayViewData();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
