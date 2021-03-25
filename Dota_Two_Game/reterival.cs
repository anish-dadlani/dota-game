using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota_Two_Game
{
    class reterival
    {
        public void show_tournaments(DataGridView gv, DataGridViewColumn IDGV, DataGridViewColumn NameGV, DataGridViewColumn ppGV, DataGridViewColumn DateGV, string data = null)
        {
            try
            {
                SqlCommand cmd;
                if (data == null)
                {
                    cmd = new SqlCommand("st_getTournamentsData", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("st_getTournamentsDataLike", MainClass.con);
                    cmd.Parameters.AddWithValue("@data", data);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                IDGV.DataPropertyName = dt.Columns["ID"].ToString();
                NameGV.DataPropertyName = dt.Columns["Tournament"].ToString();
                ppGV.DataPropertyName = dt.Columns["Pool Prize"].ToString();
                DateGV.DataPropertyName = dt.Columns["Date"].ToString();

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MainClass.show_msg(ex.Message, "Error", "Error");
            }
        }
    }
}
