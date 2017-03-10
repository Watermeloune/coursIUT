using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resonance.Niveaux
{
    public partial class ChangerNom : Form
    {
        public String nom_niveau;
        public bool nom_modifié = false;
        public ChangerNom()
        {
            InitializeComponent();
            Cursor.Show();
        }

        private void NewNomNiveau_TextChanged(object sender, EventArgs e)
        {

        }

        private void Valider_Click(object sender, EventArgs e)
        {
            if (NewNomNiveau.Text.ToString().Length != 0)
            {
                nom_niveau = NewNomNiveau.Text.ToString();
                nom_modifié = true;
                Cursor.Hide();
                this.Dispose();
            }
        }

        private void ChangerNom_Load(object sender, EventArgs e)
        {

        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Cursor.Hide();
        }
    }
}
