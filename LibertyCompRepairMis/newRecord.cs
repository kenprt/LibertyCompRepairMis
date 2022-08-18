using System;
using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class newRecord : MaterialForm
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OQQ6I8M;Initial Catalog=ItlogistsDb;Integrated Security=True");
        string g; 
        public newRecord()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange900, Primary.Orange500, Accent.Orange200, TextShade.WHITE);
        }
        public void bindData()
        {
            SqlCommand cmd = new SqlCommand("Select * from new", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
        }
        public void resetData()
        {
            txtname.Text = "";
            materialRadioButton1.Checked = false;
            materialRadioButton2.Checked = false;
            txtphone.Text = "";
            txtmodel.Text = "";
            txtserial.Text = "";
            txtproblem.Text = "";
            label2.Text = "";
        }
        public void liveSearch()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from new where id LIKE '" + this.txtfind.Text + "%' or name like '"+this.txtfind.Text+"%' or gender like '"+this.txtfind.Text+"%' or phone like '"+this.txtfind.Text+"%' or model like '"+this.txtfind.Text+"%' or serial like '"+this.txtfind.Text+"%' or problem like'"+this.txtfind.Text+"%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
        }
        private void newRecord_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'itlogistsDbDataSet._new' table. You can move, or remove it, as needed.
            this.newTableAdapter.Fill(this.itlogistsDbDataSet._new);
            bindData();
            liveSearch();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            
            if (txtname.Text == "" || txtphone.Text == "" || txtmodel.Text == "" || txtserial.Text =="" || txtproblem.Text == "" || materialRadioButton2.Checked == false && materialRadioButton1.Checked == false)
            {
                MessageBox.Show("All fields are required to complete this request", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtphone.Text.Length != 10)
            {
                MessageBox.Show("Invalid Phone number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (materialRadioButton1.Checked == true)
                    {
                        g = "Male";
                    }
                    else if(materialRadioButton2.Checked == true)
                    {
                        g = "Female";
                    }
                    con.Open();
                    if(con.State == System.Data.ConnectionState.Open)
                    {
                        
                        {
                            SqlCommand checkUpdate = new SqlCommand("Select * from new where id = '" + label2.Text + "'", con);
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUpdate);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                SqlCommand updateData = new SqlCommand("Update new set name = '" + txtname.Text + "', gender = '" + g + "', phone = '" + txtphone.Text + "', model = '" + txtmodel.Text + "',serial = '" + txtserial.Text + "', problem = '" + txtproblem.Text + "', iscomplete = '" + iscomplete.SelectedItem + "', harddrive = '" + harddrive.SelectedItem + "', ram = '" + ram.SelectedItem + "' where id = '" + label2.Text + "'", con);
                                updateData.ExecuteNonQuery();
                                MessageBox.Show("Data updated successfully", "Successfull Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                bindData();
                                
                                resetData();
                            }
                            else
                            {
                                SqlCommand command = new SqlCommand("Insert into new (name, gender, phone, model, serial, problem, iscomplete, harddrive, ram, date)Values('" + txtname.Text + "', '" + g + "', '" + txtphone.Text + "', '" + txtmodel.Text + "', '" + txtserial.Text + "','" + txtproblem.Text + "','" + iscomplete.SelectedItem.ToString() + "','" + harddrive.SelectedItem.ToString() + "', '" + ram.SelectedItem.ToString() + "','" + currentdate.Text + "')", con);
                                command.ExecuteNonQuery();
                                bindData();
                                MessageBox.Show("Record Added Succesfully", "Success Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                resetData();
                            }
                           
                        }
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

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "edit")
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr = bunifuDataGridView1.SelectedRows[0];
                label2.Text = dr.Cells[0].Value.ToString();
                txtname.Text = dr.Cells[1].Value.ToString();
                txtphone.Text = dr.Cells[3].Value.ToString();
                txtmodel.Text = dr.Cells[4].Value.ToString();
                txtserial.Text = dr.Cells[5].Value.ToString();
                txtproblem.Text = dr.Cells[6].Value.ToString();
                iscomplete.Text = dr.Cells[7].Value.ToString();
                harddrive.Text = dr.Cells[8].Value.ToString();
                ram.Text = dr.Cells[9].Value.ToString();
            }
            else if(bunifuDataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr = bunifuDataGridView1.SelectedRows[0];
                try
                {
                    con.Open();
                    if(con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand("Delete from new where id = '" + label2.Text + "'", con);
                        if(MessageBox.Show("Are you sure you want to permently delete this record","Cornfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("This record has been permently deleted","Deletion Complete",MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindData();
                            resetData();
                        }
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

        private void materialTextBox6_TextChanged(object sender, EventArgs e)
        {
            liveSearch();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            checkOut co = new checkOut();
            co.Show();
        }
    }
}
