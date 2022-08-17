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
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary. Orange800, Primary.Orange900, Primary.Orange500, Accent.Orange200, TextShade.WHITE);

        }
        public void loadChart()
        {
            SqlCommand cmd = new SqlCommand("Select model, count(serial) as total from new group by model",con);  
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series["Series1"].XValueMember = "model";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart1.Series["Series1"].YValueMembers = "total";
            chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            newRecord nr = new newRecord();
            nr.Show();
        }
    }
}
