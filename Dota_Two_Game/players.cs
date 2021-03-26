using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota_Two_Game
{
    public partial class players : Sample
    {
        int tournamentID;
        reterival r = new reterival();
        public players()
        {
            InitializeComponent();
        }

        private void players_Load(object sender, EventArgs e)
        {
            r.show_players(dataGridView1,PlayerIDGV,TournamentGV,PlayerGV,TournamentDateGV,PlayerPrizeGV);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tournament tournament = new tournament();
            MainClass.show_window(tournament, this, MDI.ActiveForm);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
