using Microsoft.Xna.Framework.Content;
using System;
using System.Collections;
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
    public partial class Editer_PNJ : Form
    {
        PNJ_Neutres pnj;
        Niveau niveau;
        ContentManager content;
        bool ajout;
        private void InitialiserComposant(Case[] PNJs)
        {
            foreach (Case PNJ in PNJs)
            {
                if (PNJ.identifiant != 0) type.Items.Add(Niveau.getNom(PNJ.identifiant, "BD_PNJs.txt"));
            }
            type.SelectedItem = pnj.nom;
            foreach(Evenement ev in niveau.evenements)
            {
                event_déclencheur.Items.Add(ev.nom);
            }
            
        }
        private void InitialiserValeursComposant()
        {
            nomEditeur.Text = pnj.nomEditeur;
            Dialogue.Text = pnj.dialogue;
            if (pnj.déclencheur != null)
            {
                déclencheur.Checked = true;
                event_déclencheur.SelectedItem = pnj.déclencheur.nom;
            }
            else
                event_déclencheur.Enabled = false;

        }
        public Editer_PNJ(PNJ_Neutres pnj, Niveau niveau, Case[] PNJs, ContentManager content, bool ajout)
        {
            InitializeComponent();
            this.pnj = pnj;
            this.ajout = ajout;
            this.niveau = niveau;
            this.content = content;
            InitialiserComposant(PNJs);
            if (!ajout)
                InitialiserValeursComposant();
            Cursor.Show();
        }

        private void Editer_PNJ_Load(object sender, EventArgs e)
        {

        }

        private void déclencheur_CheckedChanged(object sender, EventArgs e)
        {
            if (déclencheur.Checked)
            {
                event_déclencheur.Enabled = true;
                Sauver.Enabled = false;
            }
                
            else
            {
                event_déclencheur.Enabled = false;
                Sauver.Enabled = true;
                event_déclencheur.SelectedItem = null;
            }

        }

        private void Sauver_Click(object sender, EventArgs e)
        {
            if (nomEditeur.Text.Length > 0)
            {
                if (déclencheur.Checked)
                {
                    Evenement ev = null;
                    int i = 0;
                    while(ev == null)
                    {
                        if (((Evenement)niveau.evenements[i]).nom.Equals(event_déclencheur.GetItemText(event_déclencheur.SelectedItem)))
                            ev = ((Evenement)niveau.evenements[i]);
                        i++;
                    }
                    pnj.déclencheur = ev;
                }
                else
                {
                    pnj.déclencheur = null;
                }
                pnj.dialogue = Dialogue.Text;
                pnj.nomEditeur = nomEditeur.Text;
                pnj.nom = type.GetItemText(type.SelectedItem);
                pnj.identifiant = Niveau.getID(pnj.nom, "BD_PNJs.txt");
                pnj.GetTextures(content);
                if (ajout)
                {
                    niveau.PNJneutres.Add(pnj);
                }
                else
                {
                    for (int i = 0; i < niveau.PNJneutres.Count; i++)
                    {
                        if (((PNJ)niveau.PNJneutres[i]).nom.Equals(pnj.nom))
                        {
                            niveau.PNJneutres.RemoveAt(i);
                            niveau.PNJneutres.Insert(i, pnj);
                        }
                    }
                }
                this.Dispose();
                this.Close();
            }
        }

        private void event_déclencheur_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sauver.Enabled = true;
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Cursor.Hide();
        }
    }
}
