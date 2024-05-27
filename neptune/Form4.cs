using System;
using System.Windows.Forms;

namespace neptune
{
    public partial class Form4 : Form
    {
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

        }
    }
}

