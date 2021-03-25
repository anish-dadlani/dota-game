using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota_Two_Game
{
    class updation
    {
        public void updateTournament(int id, string t_name, string t_pp, DateTime t_date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_updateTournaments", MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@t_name", t_name);
                cmd.Parameters.AddWithValue("@t_pp", t_pp);
                cmd.Parameters.AddWithValue("@t_date", t_date);
                cmd.Parameters.AddWithValue("@id", id);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                MainClass.show_msg(t_name + " updated successfully.", "Success", "Success");

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MainClass.show_msg(ex.Message, "Error", "Error");
            }
        }
    }
}
