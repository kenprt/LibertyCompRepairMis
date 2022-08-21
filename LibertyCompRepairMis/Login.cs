using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;


namespace LibertyCompRepairMis
{
    
    public partial class Login : MaterialForm
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KL8RVKT;Initial Catalog=libertyshop;Integrated Security=True");
        string pass = "toor";
        string a = "Admin";
        string s = "User";
        public Login()
        {

            InitializeComponent();
           
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
        }
        public void clear()
        {
            txtpassword.Text = "";
            txtusername.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if(txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("All fields are required", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Select * from users where username = '" + txtusername.Text + "' And password = '" + txtpassword.Text + "'", con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            newRecord rs = new newRecord();
                            rs.lbluser.Text = "Welcome back " + table.Rows[0][1].ToString();
                            if (table.Rows[0][4].ToString() == pass)
                            {
                                this.Hide();
                                Form2 frm = new Form2();
                                frm.Show();
                                frm.label1.Text = table.Rows[0][2].ToString();
                                
                                
                            }
                            else if (table.Rows[0][3].ToString() == a)
                            {
                                this.Hide();
                                Form1 main = new Form1();
                                main.Show();
                                newRecord nr = new newRecord();
                        
                                nr.lbluser.Text = "Welcome back " + table.Rows[0][1].ToString();

                            }
                            else if (table.Rows[0][3].ToString() == s)
                            {
                                this.Hide();
                                newRecord nr = new newRecord();
                                nr.Show();
                                nr.lbluser.Text = "Welcome back " + table.Rows[0][1].ToString();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or Password", "wrong details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }   
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
