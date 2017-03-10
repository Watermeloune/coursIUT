using Microsoft.Xna.Framework;
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
    public partial class Editer_Ennemi : Form
    {
        Ennemis ennemi;
        Niveau niveau;
        ContentManager content;
        bool ajout;
        private void InitialiserComposant(Case[] ennemis, Case[] objets)
        {
            foreach(Case ennemi in ennemis)
            {
                if(ennemi.identifiant!=0)type.Items.Add(Niveau.getNom(ennemi.identifiant, "BD_Ennemis.txt"));
            }
            type.SelectedItem = ennemi.nom;
            foreach (Case objet in objets)
            {
                if(ennemi.identifiant != 0 && objet.identifiant >= Objet.min_id_arme) armes.Items.Add(Niveau.getNom(objet.identifiant, "BD_Objets.txt"));
            }
        }
        private void InitialiserValeursComposant()
        {
            nomEditeur.Text = ennemi.nomEditeur;
            if (ennemi.Armé())
            {
                armes.SelectedItem = ennemi.arme.nom;
                Portée.Value = ennemi.arme.portée;
                Dégats.Value = ennemi.arme.dégats;
                Fréquence.Value = ennemi.arme.fréquence;
            }
        }
        public Editer_Ennemi(Ennemis ennemi, Niveau niveau, Case[] ennemis, Case[] objets, ContentManager content, bool ajout)
        {
            InitializeComponent();
            this.ennemi = ennemi;
            this.niveau = niveau;
            this.ajout = ajout;
            this.content = content;
            InitialiserComposant(ennemis, objets);
            if(!ajout)
                InitialiserValeursComposant();
            Cursor.Show();

        }
        private void Editer_Ennemi_Load(object sender, EventArgs e)
        {

        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Cursor.Hide();
        }

        private void armé_CheckedChanged(object sender, EventArgs e)
        {
            if (armé.Checked)
            {
                armes.Enabled = true;
                Portée.Enabled = true;
                Dégats.Enabled = true;
                Fréquence.Enabled = true;
            }
            else
            {
                armes.Enabled = false;
                Portée.Enabled = false;
                Dégats.Enabled = false;
                Fréquence.Enabled = false;
            }
        }

        private void Sauver_Click(object sender, EventArgs e)
        {
            if(nomEditeur.Text.Length > 0)
            {
                if(armé.Checked)
                {
                    ennemi.arme = new Arme(Niveau.getID(armes.GetItemText(armes.SelectedItem), "BD_Objets.txt"), ennemi.PointDépart, (int)Portée.Value, (int)Dégats.Value, (int)(Fréquence.Value * 100), ennemi);
                    ennemi.aggressivité = Ennemis.Aggressivité.Armé;
                }
                else
                {
                    if(ennemi.Pattern.Count>1)
                        ennemi.aggressivité = Ennemis.Aggressivité.Non_armé;
                    else
                        ennemi.aggressivité = Ennemis.Aggressivité.Statique;
                }
                ennemi.nomEditeur = nomEditeur.Text;
                ennemi.nom = type.GetItemText(type.SelectedItem);
                ennemi.identifiant = Niveau.getID(ennemi.nom, "BD_Ennemis.txt");
                ennemi.GetTextures(content);
                if(ajout)
                {
                    niveau.ennemis.Add(ennemi);
                }
                else
                {
                    for (int i = 0; i < niveau.ennemis.Count; i++)
                    {
                        if (((Ennemis)niveau.ennemis[i]).nom.Equals(ennemi.nom))
                        {
                            niveau.ennemis.RemoveAt(i);
                            niveau.ennemis.Insert(i, ennemi);
                        }
                    }
                }
                this.Dispose();
                this.Close();
            }           
        }
    }
}
