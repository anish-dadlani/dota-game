using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota_Two_Game
{
    public partial class Chart : Sample
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void price_date_chart()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_getTournament", MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                chart1.DataSource = ds;
                chart1.Series["Graph"].XValueMember = "Date";
                chart1.Series["Graph"].YValueMembers = "Prize";
                chart1.Titles.Add("Date - Prize");
            }
            catch (Exception ex)
            {
                MainClass.show_msg(ex.Message, "Error", "Error");
            }
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            chart1.Show();
            price_date_chart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tournament tournament = new tournament();
            MainClass.show_window(tournament, this, MDI.ActiveForm);
        }
    }
}
