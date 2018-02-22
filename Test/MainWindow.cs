using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
namespace Test
{
    public partial class MainWindow : Form
    {
        
        static string title;
        string filelocation;
        //private int c=0;
        static string data;
        MySqlConnection con;
        string connection="server=localhost;user id=root;database=testdb";
        
        SymmetricAlgorithm desObj;
        static string selectedValue = "null";
        string sapp;
        public MainWindow()
        {
            InitializeComponent();
            label3.Text = Form1.uname;
            desObj = Rijndael.Create();
            DataGridMethod();
        }
       
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void browsebtn_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open File";
            open.Filter = "Text Files (*.txt)|*.txt| Doc (*.doc)|*.doc";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(open.FileName));
                location.Text = open.FileName;
                filelocation = open.FileName;
                read.Dispose();
            }

        }
        private void Encryption_Click(object sender, EventArgs e)
        {
            if (txtpasskey.Text != "" && txtpasskey.Text != "")
            {
                StreamReader f = new StreamReader(filelocation);
                title = txttitle.Text;
                title = title + ".txt";
                string line, secretdata = null;
                try
                {
                    con = new MySqlConnection(connection);
                    con.Open();
                    try
                    {
                        data = null;
                        while ((line = f.ReadLine()) != null)
                        {
                            secretdata += line + "\n";
                        }
                        string hash = Form1.psw + txtpasskey;
                        byte[] d = UTF8Encoding.UTF8.GetBytes(secretdata);
                        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                        {
                            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                            using (TripleDESCryptoServiceProvider tripleDS = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                            {
                                ICryptoTransform transform = tripleDS.CreateEncryptor();
                                byte[] result = transform.TransformFinalBlock(d, 0, d.Length);
                                sapp = Convert.ToBase64String(result, 0, result.Length);
                                string command = $"INSERT INTO userdata(uname,passkey,plainkey,filename,e_data) VALUES('{Form1.uname}','{txtpasskey.Text}','{hash}','{title}','{sapp}');";
                                MySqlCommand cmd = new MySqlCommand(command, con);
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("Inserted Successfully the registration data");
                                MessageBox.Show("FILE ENCrypTed & UploAded");
                                f.Close();
                                MessageBox.Show("ENCRYPTED:\n" + sapp);
                                DataGridMethod();
                            }
                        }
                        con.Close();
                        txttitle.Text = "";
                        MessageBox.Show("Save the PassKey for decrypting the file..\n");
                        txtpasskey.Text = "";

                    }
                    catch (Exception ex) { }

                }
                catch (Exception ex) { }
            }
            else
            {
                MessageBox.Show("PLease Enter Title and PassKey for Encrypting");
            }
        }
        private void Decrypt_btn_Click(object sender, EventArgs e)
        {
            if (txtpasskey.Text != "" && txtpasskey.Text != "")
            {
                //StreamWriter wd = new StreamWriter("C:\\Users\\adepu\\Desktop\\2" + title);
                try
                {
                con = new MySqlConnection(connection);
                string command = $"SELECT e_data FROM userdata WHERE uname='{Form1.uname}' AND filename='{selectedValue}';";
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(command, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string v = dt.Rows[0][0].ToString();
                if (dt.Rows.Count == 1)
                {
                    string hash = Form1.psw + txtpasskey;
                    byte[] d = Convert.FromBase64String(v);
                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                        using (TripleDESCryptoServiceProvider tripleDS = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                        {
                            ICryptoTransform transform = tripleDS.CreateDecryptor();
                            byte[] result = transform.TransformFinalBlock(d, 0, d.Length);
                            string r = UTF8Encoding.UTF8.GetString(result);
                            MessageBox.Show("DECRIPTED: \n" + r);
                        }
                    }
                }
                con.Close();

              }catch (Exception ex) { }
            }
             else
            {
                MessageBox.Show("PLease Enter Title and PassKey for Encrypting");
            }
        }

        private void DataGridMethod()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Open();
                MySqlDataAdapter msda = new MySqlDataAdapter("select filename from userdata where uname='"+Form1.uname+"';", con);
                DataTable DS = new DataTable();
                msda.Fill(DS);
                dataGridView1.DataSource = DS;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow d = dataGridView1.Rows[e.RowIndex];
            selectedValue = d.Cells[0].Value.ToString();
            MessageBox.Show("SELECTED: " + selectedValue);
        }
    }
}
