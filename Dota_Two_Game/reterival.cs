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

        public void show_players(DataGridView gv, DataGridViewColumn PlayerIDGV, DataGridViewColumn TournamentGV, DataGridViewColumn PlayerGV,
            DataGridViewColumn TournamentDateGV, DataGridViewColumn PlayerPrizeGV, int? data = null)
        {
            try
            {
                SqlCommand cmd;
                if (data == null)
                {
                    cmd = new SqlCommand("st_getTournamentDetails", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("st_getTournamentDetailsTID", MainClass.con);
                    cmd.Parameters.AddWithValue("@id", data);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                PlayerIDGV.DataPropertyName = dt.Columns["PlayerID"].ToString();
                TournamentGV.DataPropertyName = dt.Columns["Tournament"].ToString();
                PlayerGV.DataPropertyName = dt.Columns["Player"].ToString();
                TournamentDateGV.DataPropertyName = dt.Columns["Tournament Date"].ToString();
                PlayerPrizeGV.DataPropertyName = dt.Columns["Player Prize"].ToString();

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MainClass.show_msg(ex.Message, "Error", "Error");
            }
        }
    }
}
