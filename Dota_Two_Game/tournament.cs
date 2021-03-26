using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota_Two_Game
{
    public partial class tournament : Sample2
    {
        int edit = 0; //this 0 is an indication for save operation and 1 is an indication for update operation
        int tournamentID;
        reterival r = new reterival();
        updation u = new updation();
        insertion i = new insertion();

        public tournament()
        {
            InitializeComponent();
            dataGridView2.Hide();
        }

        public override void addBtn_Click(object sender, EventArgs e)
        {
            MainClass.enable_reset(leftPanel);
            edit = 0;
            dataGridView2.Hide();
        }

        public override void editBtn_Click(object sender, EventArgs e)
        {
            edit = 1;
            dataGridView2.Hide();
            MainClass.enable(leftPanel);
        }

        public override void saveBtn_Click(object sender, EventArgs e)
        {
            if (tournamentTxt.Text == "")
                nameError.Visible = true;
            else
                nameError.Visible = false;

            if (ppTxt.Text == "")
                ppError.Visible = true;
            else
                ppError.Visible = false;

            if (nameError.Visible || ppError.Visible)
            {
                MainClass.show_msg("Fields with * are mandatory", "Stop", "Error"); //Error is the type of msg
            }
            else
            {
                if (edit == 0) // code for save operation
                {
                    i.insertTournaments(tournamentTxt.Text, ppTxt.Text, dateTimePicker1.Value);
                    r.show_tournaments(dataGridView1, IDGV, NameGV, PPGV, dateGV);
                    MainClass.disable_reset(leftPanel);

                }
                else if (edit == 1) // code for update operation
                {
                    DialogResult dr = MessageBox.Show("Are you sure, you want to update record?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        u.updateTournament(tournamentID, tournamentTxt.Text, ppTxt.Text, dateTimePicker1.Value);
                        r.show_tournaments(dataGridView1, IDGV, NameGV, PPGV, dateGV);
                        MainClass.disable_reset(leftPanel);
                    }
                }
            }
            dataGridView2.Hide();
        }

        public override void delBtn_Click(object sender, EventArgs e)
        {
            if (edit == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete record?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    deletion d = new deletion();
                    d.delete(tournamentID, "st_deleteTournaments", "@id");
                    r.show_tournaments(dataGridView1, IDGV, NameGV, PPGV, dateGV);
                    MainClass.disable_reset(leftPanel);
                }
            }
            dataGridView2.Hide();
        }

        public override void searchTxt_TextChanged(object sender, EventArgs e)
        {
            if (searchTxt.Text != "")
            {
                r.show_tournaments(dataGridView1, IDGV, NameGV, PPGV, dateGV, searchTxt.Text);
            }
            else
            {
                r.show_tournaments(dataGridView1, IDGV, NameGV, PPGV, dateGV);
            }
            dataGridView2.Hide();
        }

        private void tournament_Load(object sender, EventArgs e)
        {
            MainClass.disable_reset(leftPanel);
            dataGridView2.Hide();
            r.show_tournaments(dataGridView1, IDGV, NameGV, PPGV, dateGV);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                edit = 1;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                tournamentID = Convert.ToInt32(row.Cells["IDGV"].Value.ToString());
                tournamentTxt.Text = row.Cells["NameGV"].Value.ToString();
                ppTxt.Text = row.Cells["PPGV"].Value.ToString();
                MainClass.disable(leftPanel);
                dataGridView2.Hide();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                tournamentID = Convert.ToInt32(row.Cells["IDGV"].Value.ToString());
                dataGridView2.Show();
                r.show_players(dataGridView2, PlayerIDGV, TournamentGV, PlayerGV, TournamentDateGV, PlayerPrizeGV, tournamentID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            tournament tournament = new tournament();
            MainClass.show_window(tournament, this, MDI.ActiveForm);
        }
    }
}
