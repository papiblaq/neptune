using System;
using System.Windows.Forms;

namespace neptune
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void login_register_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
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
    }

}
