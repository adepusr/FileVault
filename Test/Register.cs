using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace Test
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtUname.Text;
            string psw = txtPassword.Text;
            string hint = txtHint.Text;
            string email = txtEmailId.Text;
            Int64 phone = Int64.Parse(txtPhone.Text);
            string address = txtAddress.Text;
            string id = null;
            string connection = "server=localhost;user id=root;database=testdb";
            try
            {
                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                try
                {
                    string command = $"INSERT INTO registration(username,password,re_enter,contact,id,email) VALUES('{name}','{psw}','{psw}',{phone},'{id}','{email}');";
                    MySqlCommand cmd = new MySqlCommand(command, con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted Successfully the registration data");
                    MessageBox.Show("Registered Successfully.");
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in executing " + ex);
                }
            }catch(Exception es)
            {
                MessageBox.Show("Dont know nij" + es);
            }
        }
    }
}
