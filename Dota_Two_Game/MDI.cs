using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota_Two_Game
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(path + "\\connect"))
            {
                tournament tournament = new tournament();
                MainClass.show_window(tournament, this);
            }
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cHARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            MainClass.show_window(chart, this);
        }

        private void tOURNAMENTDETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            players player = new players();
            MainClass.show_window(player, this);
        }
    }
}
