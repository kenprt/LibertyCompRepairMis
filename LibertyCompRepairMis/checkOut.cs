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
    public partial class checkOut : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OQQ6I8M;Initial Catalog=ItlogistsDb;Integrated Security=True");
        public checkOut()
        {
            InitializeComponent();
        }

        private void checkOut_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("All fields are required", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    con.Open();
                    if(con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Select * from new where id = '" + txtid.Text + "'", con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if(dt.Rows.Count > 0)
                        {
                            lblname.Text = dt.Rows[0][1].ToString();
                        }
                        else
                        {
                            MessageBox.Show("The id entered does not exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtid.Text == "" || lblname.Text == "NULL" || txtamount.Text == "")
            {
                MessageBox.Show("All fields are required", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Insert into accounts (Name, Amount, date)Values('"+lblname.Text+"', '"+txtamount.Text+"', '"+bunifuDatePicker1.Text+"')",con);
                        cmd.ExecuteNonQuery();
                        SqlCommand command = new SqlCommand("Delete From new where id = '"+txtid.Text+"'",con);
                        command.ExecuteNonQuery();
                        txtamount.Text = "";
                        txtid.Text = "";
                        lblname.Text = "NULL";
                        MessageBox.Show("Customer cashed out successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
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
    }
}
