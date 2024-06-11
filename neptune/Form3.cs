using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;

namespace neptune
{


    public partial class Form3 : Form
    {
        // Initialize the Oracle connection with the correct connection string
        OracleConnection connect = new OracleConnection("Data Source=OFFICE_DB;Persist Security Info=True;User ID=fortunelive;Password=fortunelive");

        public Form3()
        {
            InitializeComponent();

            progressBar1.Visible = false;
            label4.Visible = true;
            login_register.Visible = true;
            label1.Visible = false;
        }

        private void login_register_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }





        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(login_username.Text) || string.IsNullOrEmpty(sighnup_pass.Text))
            {
                MessageBox.Show("Please fill the blank fields");
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        string selectData = "SELECT * FROM loginTable WHERE username = :username AND password = :password";
                        using (OracleCommand cmd = new OracleCommand(selectData, connect))
                        {
                            cmd.Parameters.Add(new OracleParameter("username", login_username.Text.Trim()));
                            cmd.Parameters.Add(new OracleParameter("password", sighnup_pass.Text.Trim()));

                            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {


                                timer1.Start();

                                MessageBox.Show("You are logged in");



                                



                                Form2 form2 = new Form2();
                                form2.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect username or password");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void login_showpas_CheckedChanged(object sender, EventArgs e)
        {
            if (signup_showpass.Checked)
            {
                sighnup_pass.PasswordChar = '\0';
            }
            else
            {
                sighnup_pass.PasswordChar = '*';
            }
        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label4.Visible = false;
            login_register.Visible = false;
            label1.Visible = true;

            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
            }

            else
            {
                timer1.Stop();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
