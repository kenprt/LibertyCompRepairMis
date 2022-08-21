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

namespace LibertyCompRepairMis
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KL8RVKT;Initial Catalog=libertyshop;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (txtpass.Text =="" || txtnewpass.Text == "")
            {
                MessageBox.Show("All fields are required", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if(txtnewpass.Text != txtpass.Text)
            {
                MessageBox.Show("New password and confirm pass did not match", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if(txtnewpass.Text == "toor" && txtpass.Text == "toor")
            {
                MessageBox.Show("Use another password","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Login lgn = new Login();
                    con.Open();
                    if(con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Update users set password = '"+txtnewpass.Text+"' where username= '"+label1.Text+"'", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You have Succesfully updated your password, continue to login", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtpass.Text = "";
                        txtnewpass.Text = "";
                        this.Hide();
                        lgn.txtpassword.Text = "";
                        lgn.Show();
                      
                      

                    }                   
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
