using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;

namespace neptune
{
    public partial class Form4 : Form
    {
        OracleConnection connect = new OracleConnection("Data Source=OFFICE_DB;Persist Security Info=True;User ID=fortunelive;Password=fortunelive");

        public Form4()
        {
            InitializeComponent();
        }

        private void signup_loginhere_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void signup_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showpass.Checked)
            {
                login_pass.PasswordChar = '\0';
            }
            else
            {
                login_pass.PasswordChar = '*';
            }
        }

        private void sighnup_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (login_pass.Text == "" || signup_username.Text == "")
            {
                MessageBox.Show("Please enter the blanks.");
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        string checkUsername = "SELECT * FROM loginTable WHERE username = :username";

                        using (OracleCommand checkUser = new OracleCommand(checkUsername, connect))
                        {
                            checkUser.Parameters.Add(new OracleParameter(":username", signup_username.Text.Trim()));
                            OracleDataAdapter adapter = new OracleDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(signup_username.Text + " already exists.");
                            }
                            else
                            {
                                // Insertion of user details in the database
                                string insertData = "INSERT INTO loginTable (username, password, date_created) VALUES (:username, :password, :date_created)";
                                DateTime date = DateTime.Today;

                                using (OracleCommand cmd = new OracleCommand(insertData, connect))
                                {
                                    cmd.Parameters.Add(new OracleParameter(":username", signup_username.Text.Trim()));
                                    cmd.Parameters.Add(new OracleParameter(":password", login_pass.Text.Trim()));
                                    cmd.Parameters.Add(new OracleParameter(":date_created", date));

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered successfully", "Information Message");

                                    // To switch to the form
                                    Form3 form3 = new Form3();
                                    form3.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting to database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

