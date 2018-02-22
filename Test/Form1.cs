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
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace Test
{
    public partial class Form1 : Form
    {
        internal static string uname;
        internal static string psw;
        SpeechCommands sc = new SpeechCommands();
        private SpeechSynthesizer voice;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            sc.SCommands();
            voice = new SpeechSynthesizer();
            voice.SelectVoiceByHints(VoiceGender.Female);
        }


        private void label4_Click(object sender, EventArgs e)
        {        }


        public  void LogingIn() {
            string connection = "server=localhost;user id=root;database=testdb";
            try
            {
                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                try
                {

                    uname = txtusername.Text;
                    psw = txtpassword.Text;
                    MessageBox.Show("USER: " + uname + "  PASS:" + psw);
                    string command = $"SELECT * FROM login WHERE username='{uname}' AND password='{psw}';";
                    MySqlDataAdapter da = new MySqlDataAdapter(command, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        MainWindow mw = new MainWindow();
                        voice.SpeakAsync("Welcome, "+uname+",.");
                        mw.Show();
                        this.Hide();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID LOGIN DETAILS");
                        voice.SpeakAsync("INVALID LOGIN DETAILS");
                        txtpassword.Text = "";
                        txtusername.Select();
                        invalid_input.Text = "Invalid UserName / Password";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("   " + ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("1.   " + ex);
            }


        }
        public void Register() {
            Register r = new Register();
            voice.SpeakAsync("Please Register ");
            r.Show();
            this.Hide();
        }
        public void Forget() {
            GetPassword gp = new GetPassword();
            gp.Show();
            this.Hide();
        }
        public void username()
        {
            txtusername.Focus();
        }
        public void passWord()
        {
            this.ActiveControl = txtpassword;
        }

        private void ForgetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forget();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            LogingIn();
        }
    }
}




