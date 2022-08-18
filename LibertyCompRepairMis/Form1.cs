using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class Form1 : MaterialForm
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OQQ6I8M;Initial Catalog=ItlogistsDb;Integrated Security=True");
        string a = "Admin";
        string s = "User";
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange900, Primary.Orange500, Accent.Orange200, TextShade.WHITE);

        }
        public void loadChart()
        {
            SqlCommand cmd = new SqlCommand("Select model, count(serial) as total from new group by model", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"].XValueMember = "model";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart1.Series["Series1"].YValueMembers = "total";
            chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

        }
        public void countRegister()
        {
            SqlCommand cmd = new SqlCommand("Select count(id) as total from new", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbltotalregister.Text = dt.Rows[0]["total"].ToString();
            }

        }
        public void coutComplete()
        {
            SqlCommand cmd = new SqlCommand("Select count(id) as total from new where iscomplete = '" + label2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblpending.Text = dt.Rows[0]["total"].ToString();
            }
        }
        public void countPending()
        {
            SqlCommand cmd = new SqlCommand("Select count(id) as total from new where iscomplete = '" + label1.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblfixed.Text = dt.Rows[0]["total"].ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'itlogistsDbDataSet1.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.itlogistsDbDataSet1.users);
            loadChart();
            countRegister();
            countPending();
            coutComplete();
            countMoney();
            bindUsers();
            users();
            admin();
            this.reportViewer1.RefreshReport();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            newRecord nr = new newRecord();
            nr.Show();
        }
        public void countMoney()
        {
            SqlCommand cmd = new SqlCommand("Select sum(Amount) as total from accounts", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblaccounts.Text = "KES: " + dt.Rows[0]["total"].ToString();
            }
        }
        public void users()
        {
            SqlCommand cmd = new SqlCommand("Select count(id) as total from users where Category = '"+a+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbladmin.Text = dt.Rows[0]["total"].ToString();
            }
        }
        public void admin()
        {

            SqlCommand cmd = new SqlCommand("Select count(id) as total from users where Category = '" + s + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblsystemusers.Text = dt.Rows[0]["total"].ToString();
            }
        }
        public void bindUsers()
        {
            SqlCommand cmd = new SqlCommand("Select * from users", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
        }
        public void clearUsers()
        {
            txtname.Text = "";
            txtusername.Text = "";
            txtpass.Text = "";
            cmbcategory.Text = "~Select Category~";
            txtfind.Text = "";
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            loadChart();
            countRegister();
            countPending();
            coutComplete();
            countMoney();
            users();
            admin();
        }

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtusername.Text == "" || cmbcategory.Text == "~Select Category~" || cmbcategory.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("All fields are required to perform this spesific action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Select * from users where username = '" + txtusername.Text + "'", con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("The spesified Username already exists", "Dublicate Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            SqlCommand command = new SqlCommand("Insert into users (name, username, Category, password, date)Values('" + txtname.Text + "', '" + txtusername.Text + "','" + cmbcategory.SelectedItem.ToString() + "', '" + txtpass.Text + "', '" + bunifuDatePicker1.Text + "')", con);
                            command.ExecuteNonQuery();
                            MessageBox.Show("User added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindUsers();
                            users();
                            admin();
                            clearUsers();
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

        private void materialButton5_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtusername.Text == "" || cmbcategory.Text == "~Select Category~" || cmbcategory.Text == "" || txtpass.Text == "" || txtfind.Text == "")
            {
                MessageBox.Show("All fields are required to perform this spesific action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                       
                        {
                            SqlCommand command = new SqlCommand("Update users set name = '" + txtname.Text + "', username = '" + txtusername.Text + "', Category = '" + cmbcategory.SelectedItem.ToString() + "', password = '" + txtpass.Text + "' where id = '" + txtfind.Text + "'", con);
                            command.ExecuteNonQuery();
                            MessageBox.Show("User Update Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindUsers();
                            users();
                            admin();
                            clearUsers();
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



        private void materialButton6_Click(object sender, EventArgs e)
        {
            if(txtfind.Text == "")
            {
                MessageBox.Show("The search field is required", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Select * from users where id = '" + txtfind.Text + "'", con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            SqlCommand command = new SqlCommand("Delete from users where id = '" + txtfind.Text + "'", con);
                            if(MessageBox.Show("Are you sure you want to permently delete this record","Cornfimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("User Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bindUsers();
                                users();
                                admin();
                                clearUsers();
                            }
                        }
                        else
                        {
                            MessageBox.Show("The searched record no longer exists", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void materialButton8_Click(object sender, EventArgs e)
        {
            if (txtfind.Text == "")
            {
                MessageBox.Show("The search field is required", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Select * from users where id = '" + txtfind.Text + "'", con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            txtname.Text = table.Rows[0][1].ToString();
                            txtusername.Text = table.Rows[0][2].ToString();
                            txtpass.Text = table.Rows[0][4].ToString();
                            cmbcategory.Text = table.Rows[0][3].ToString();
                            //bunifuDatePicker1.Text = table.Rows[0][5].ToString();

                        }
                        else
                        {
                            MessageBox.Show("The searched record no longer exists", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void materialButton7_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("customer");
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("comp");
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("money");
        }
    }
}
