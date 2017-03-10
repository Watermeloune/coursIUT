using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Resonance.Niveaux
{
    public partial class Editer_Evenement : Form
    {
        Niveau niveau;
        Evenement evenement;
        private void InitialiserValeursComposant(Case[] ListeEnnemis)
        {
            String[] Data;
            this.Text = evenement.nom;
            if (evenement.nom != "Ajouter un évènement")
                NomEvent.Text = evenement.nom;
            else
                NomEvent.Text = "";
            if (evenement.timer > 0)
            {
                Timer.Checked = true;
                secondes.Value = evenement.timer % 60;
                minutes.Value = evenement.timer / 60;
            }
            for (int i = 1; i < niveau.evenements.Count; i++)
            {
                if (((Evenement)niveau.evenements[i]).nom != evenement.nom)
                    EventCible.Items.Add(((Evenement)niveau.evenements[i]).nom);
            }
            if (evenement.type != Evenement.Type_Event.Indéfini && evenement.type != Evenement.Type_Event.Fin)
            {
                if (evenement.Conséquence!=null)
                {
                    Conséquence.Checked = true;
                    EventCible.SelectedItem = evenement.Conséquence.nom;
                }
                    
            }
            //Ajout des différentes listes
            //Ennemis
            Data = new String[niveau.ennemis.Count];
            for (int i = 0; i < niveau.ennemis.Count; i++)
                Data[i] = ((Ennemis)niveau.ennemis[i]).nomEditeur;
            CibleSpécifique1.Items.AddRange(Data);
            CibleSpécifique2.Items.AddRange(Data);
            CibleSpécifique3.Items.AddRange(Data);
            Data = new String[ListeEnnemis.Length - 1];
            for (int i = 0; i < ListeEnnemis.Length - 1; i++)
                Data[i] = Niveau.getNom(ListeEnnemis[i].identifiant, "BD_Ennemis.txt");
            CibleGénérale1.Items.AddRange(Data);
            CibleGénérale2.Items.AddRange(Data);
            CibleGénérale3.Items.AddRange(Data);
            //PNJ Neutres
            for (int i = 0; i < niveau.PNJneutres.Count; i++)
                Interlocuteur.Items.Add(((PNJ)niveau.PNJneutres[i]).nom);
            //Objets
            for (int i = 0; i < niveau.objets.Length; i++)
                ObjetAObtenir.Items.Add(niveau.objets[i].nom);
            //Téléportation
            XEmpCible.Minimum = 0;
            YEmpCible.Minimum = 0;
            XEmpSource.Minimum = 0;
            YEmpSource.Minimum = 0;

            XEmpCible.Maximum = niveau.NbBlocsX-1;
            YEmpCible.Maximum = niveau.NbBlocsY-1;
            XEmpSource.Maximum = niveau.NbBlocsX-1;
            YEmpSource.Maximum = niveau.NbBlocsY-1;
            switch (evenement.type)
            {
                case Evenement.Type_Event.Assassinat:
                    
                    if (!((Ennemis)((EvenementAssassinat)evenement).cibles[0]).nomEditeur.Equals("pure random"))
                    {
                        CibleSpécifique.Checked = true;
                        if(((EvenementAssassinat)evenement).cibles.Count>=1)
                            CibleSpécifique1.SelectedItem=((Ennemis)((EvenementAssassinat)evenement).cibles[0]).nomEditeur;
                        if (((EvenementAssassinat)evenement).cibles.Count >= 2)
                            CibleSpécifique2.SelectedItem = ((Ennemis)((EvenementAssassinat)evenement).cibles[1]).nomEditeur;
                        if (((EvenementAssassinat)evenement).cibles.Count >= 3)
                            CibleSpécifique3.SelectedItem = ((Ennemis)((EvenementAssassinat)evenement).cibles[2]).nomEditeur;
                    }
                    else
                    {
                        CibleGénéral.Checked = true;
                        if (((EvenementAssassinat)evenement).cibles.Count >= 1)
                        {
                            CibleGénérale1.SelectedItem = ((Ennemis)((EvenementAssassinat)evenement).cibles[0]).nomEditeur;
                            int nb = 1;
                            bool CG2 = true;
                            bool CG3 = false;
                            for (int i = 1; i < ((EvenementAssassinat)evenement).cibles.Count; i++)
                            {
                                if (((Ennemis)((EvenementAssassinat)evenement).cibles[i]).nomEditeur != ((Ennemis)((EvenementAssassinat)evenement).cibles[i - 1]).nomEditeur)
                                {
                                    if (CG2)
                                    {
                                        CG2 = false;
                                        NbCibleGénérale1.Value = nb;
                                        CibleGénérale2.SelectedItem = ((Ennemis)((EvenementAssassinat)evenement).cibles[i]).nomEditeur;
                                        nb = 1;
                                    }
                                    else
                                    {
                                        CG3 = true;
                                        NbCibleGénérale2.Value = nb;
                                        CibleGénérale3.SelectedItem = ((Ennemis)((EvenementAssassinat)evenement).cibles[i]).nomEditeur;
                                    }

                                }
                                else
                                    nb += 1;
                            }
                            if(CG3)
                                NbCibleGénérale3.Value = nb;
                        }
                    }
                    AssassinatEvent.Checked = true;
                    break;
                case Evenement.Type_Event.Dialogue:
                    Interlocuteur.SelectedItem = ((EvenementDialogue)evenement).PNJ.nom;
                    Dialogue.Text = ((EvenementDialogue)evenement).Dialogue;
                    DialogueEvent.Checked = true;
                    break;
                case Evenement.Type_Event.Objet:
                    ObjetAObtenir.SelectedItem = ((EvenementObjet)evenement).objet.nom;
                    ObjetEvent.Checked = true;
                    break;
                case Evenement.Type_Event.Porte:
                    XEmpSource.Value = (decimal)((EvenementPorte)evenement).position_source.X;
                    YEmpSource.Value = (decimal)((EvenementPorte)evenement).position_source.Y;
                    XEmpCible.Value = (decimal)((EvenementPorte)evenement).position_destination.X;
                    YEmpCible.Value = (decimal)((EvenementPorte)evenement).position_destination.Y;
                    TéléportationEvent.Checked = true;
                    break;
                case Evenement.Type_Event.Fin:
                    FinEvent.Checked = true;
                    break;
                case Evenement.Type_Event.Début:
                    AssassinatEvent.Enabled = false;
                    DialogueEvent.Enabled = false;
                    ObjetEvent.Enabled = false;
                    TéléportationEvent.Enabled = false;
                    FinEvent.Enabled = false;
                    Timer.Checked = false;
                    Timer.Enabled = false;
                    Supprimer.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        public Editer_Evenement(Evenement evenement, Niveau niveau, Case[] ListeEnnemis)
        {
            InitializeComponent();
            this.niveau = niveau;
            this.evenement = evenement;
            InitialiserValeursComposant(ListeEnnemis);
            Cursor.Show();
        }

        private void Editer_Evenement_Load(object sender, EventArgs e)
        {

        }

        private void Editer_Evenement_Load_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Editer_Evenement_Load_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void AssassinatEvent_CheckedChanged(object sender, EventArgs e)
        {
            if (AssassinatEvent.Checked)
            {
                ChoixCibles.Enabled = true;

            }
            else
            {
                ChoixCibles.Enabled = false;
                CibleGénéral.Checked = false;
                CibleSpécifique.Checked = false;
                CibleGénérale1.Enabled = false;
                CibleGénérale2.Enabled = false;
                CibleGénérale3.Enabled = false;
                CibleSpécifique1.Enabled = false;
                CibleSpécifique2.Enabled = false;
                CibleSpécifique3.Enabled = false;
                NbCibleGénérale1.Enabled = false;
                NbCibleGénérale2.Enabled = false;
                NbCibleGénérale3.Enabled = false;
            }
        }

        private void DialogueEvent_CheckedChanged(object sender, EventArgs e)
        {
            if (DialogueEvent.Checked)
            {
                Interlocuteur.Enabled = true;
                Dialogue.Enabled = true;
            }
            else
            {
                Interlocuteur.Enabled = false;
                Dialogue.Enabled = false;
            }
        }

        private void ObjetEvent_CheckedChanged(object sender, EventArgs e)
        {
            if (ObjetEvent.Checked)
            {
                ObjetAObtenir.Enabled = true;
            }
            else
            {
                ObjetAObtenir.Enabled = false;
            }
        }

        private void TéléportationEvent_CheckedChanged(object sender, EventArgs e)
        {
            if (TéléportationEvent.Checked)
            {
                XEmpCible.Enabled = true;
                XEmpSource.Enabled = true;
                YEmpCible.Enabled = true;
                YEmpSource.Enabled = true;
            }
            else
            {
                XEmpCible.Enabled = false;
                XEmpSource.Enabled = false;
                YEmpCible.Enabled = false;
                YEmpSource.Enabled = false;
            }
        }

        private void Timer_CheckedChanged(object sender, EventArgs e)
        {
            if(Timer.Checked)
            {
                secondes.Enabled = true;
                minutes.Enabled = true;
            }
            else
            {
                secondes.Enabled = false;
                minutes.Enabled = false;
            }
        }

        private void Conséquence_CheckedChanged(object sender, EventArgs e)
        {
            if (Conséquence.Checked)
                EventCible.Enabled = true;
            else
                EventCible.Enabled = false;
        }

        private void CibleSpécifique_CheckedChanged(object sender, EventArgs e)
        {
            if(CibleSpécifique.Checked)
            {
                CibleSpécifique1.Enabled = true;
                CibleSpécifique2.Enabled = true;
                CibleSpécifique3.Enabled = true;
            }
            else
            {
                CibleSpécifique1.Enabled = false;
                CibleSpécifique2.Enabled = false;
                CibleSpécifique3.Enabled = false;
            }
        }

        private void CibleGénéral_CheckedChanged(object sender, EventArgs e)
        {
            if (CibleGénéral.Checked)
            {
                CibleGénérale1.Enabled = true;
                CibleGénérale2.Enabled = true;
                CibleGénérale3.Enabled = true;
                NbCibleGénérale1.Enabled = true;
                NbCibleGénérale2.Enabled = true;
                NbCibleGénérale3.Enabled = true;
            }
            else
            {
                CibleGénérale1.Enabled = false;
                CibleGénérale2.Enabled = false;
                CibleGénérale3.Enabled = false;
                NbCibleGénérale1.Enabled = false;
                NbCibleGénérale2.Enabled = false;
                NbCibleGénérale3.Enabled = false;
            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Cursor.Hide();
            int i = 0;
            while (i < niveau.evenements.Count && ((Evenement)niveau.evenements[i]).type != Evenement.Type_Event.Indéfini)
                i++;
            if (i != niveau.evenements.Count)
                niveau.evenements.RemoveAt(i);
        }

        private bool check_nomEvent_unique()
        {
            if (NomEvent.Text.Equals(evenement.nom))
                return true;
            foreach (Evenement ev in niveau.evenements)
                if (ev.nom.Equals(NomEvent.Text))
                    return false;
            return true;
        }

        private void Sauver_Click(object sender, EventArgs e)
        {
            if(NomEvent.Text.Length>0)
            {
                if (check_nomEvent_unique())
                {
                    WarningNomPK.Visible = false;
                    if (AssassinatEvent.Checked)
                    {
                        if (CibleSpécifique.Checked && (CibleSpécifique1.SelectedItem != null || CibleSpécifique2.SelectedItem != null || CibleSpécifique3.SelectedItem != null))
                        {
                            EvenementAssassinat ev = new EvenementAssassinat();
                            ev.nom = NomEvent.Text;
                            if (Timer.Checked)
                                ev.timer = (int)minutes.Value * 60 + (int)secondes.Value;
                            else
                                ev.timer = -1;
                            if (Conséquence.Checked)
                                for (int i = 0; i < niveau.evenements.Count; i++)
                                {
                                    if (((Evenement)niveau.evenements[i]).nom.Equals(EventCible.GetItemText(EventCible.SelectedItem)))
                                        ev.Conséquence = (Evenement)niveau.evenements[i];
                                }
                            else
                                ev.Conséquence = null;
                            ArrayList array = new ArrayList();
                            if (CibleSpécifique1.SelectedItem != null)
                                for (int i = 0; i < niveau.ennemis.Count; i++)
                                {
                                    if (((Ennemis)niveau.ennemis[i]).nomEditeur.Equals(CibleSpécifique1.GetItemText(CibleSpécifique1.SelectedItem)))
                                        array.Add(((Ennemis)niveau.ennemis[i]));
                                }
                            if (CibleSpécifique2.SelectedItem != null)
                                for (int i = 0; i < niveau.ennemis.Count; i++)
                                {
                                    if (((Ennemis)niveau.ennemis[i]).nomEditeur.Equals(CibleSpécifique2.GetItemText(CibleSpécifique2.SelectedItem)))
                                        array.Add(((Ennemis)niveau.ennemis[i]));
                                }
                            if (CibleSpécifique3.SelectedItem != null)
                                for (int i = 0; i < niveau.ennemis.Count; i++)
                                {
                                    if (((Ennemis)niveau.ennemis[i]).nomEditeur.Equals(CibleSpécifique3.GetItemText(CibleSpécifique3.SelectedItem)))
                                        array.Add(((Ennemis)niveau.ennemis[i]));
                                }
                            ev.cibles = array;
                            ev.type = Evenement.Type_Event.Assassinat;
                            for (int i = 0; i < niveau.evenements.Count; i++)
                            {
                                if (((Evenement)niveau.evenements[i]).nom.Equals(evenement.nom))
                                {
                                    niveau.evenements.RemoveAt(i);
                                    niveau.evenements.Insert(i, ev);
                                }
                            }
                            this.Dispose();
                            this.Close();

                        }
                        else if (CibleGénéral.Checked && (NbCibleGénérale1.Value > 0 && CibleGénérale1.SelectedItem != null || NbCibleGénérale2.Value > 0 && CibleGénérale2.SelectedItem != null || NbCibleGénérale3.Value > 0 && CibleGénérale3.SelectedItem != null))
                        {
                            EvenementAssassinat ev = new EvenementAssassinat();
                            ev.nom = NomEvent.Text;
                            if (Timer.Checked)
                                ev.timer = (int)minutes.Value * 60 + (int)secondes.Value;
                            else
                                ev.timer = -1;
                            if (Conséquence.Checked)
                                for (int i = 0; i < niveau.evenements.Count; i++)
                                {
                                    if (((Evenement)niveau.evenements[i]).nom.Equals(EventCible.GetItemText(EventCible.SelectedItem)))
                                        ev.Conséquence = (Evenement)niveau.evenements[i];
                                }
                            else
                                ev.Conséquence = (Evenement)niveau.evenements[1];
                            ArrayList array = new ArrayList();
                            if (CibleGénérale1.SelectedItem != null)
                                for (int i = 0; i < NbCibleGénérale1.Value; i++)
                                {
                                    array.Add(new Ennemis(Niveau.getID(CibleGénérale1.GetItemText(CibleGénérale1.SelectedItem), "BD_Ennemis.txt"), "pure random"));
                                }
                            if (CibleSpécifique2.SelectedItem != null)
                                for (int i = 0; i < NbCibleGénérale2.Value; i++)
                                {
                                    array.Add(new Ennemis(Niveau.getID(CibleGénérale2.GetItemText(CibleGénérale2.SelectedItem), "BD_Ennemis.txt"), "pure random"));
                                }
                            if (CibleSpécifique3.SelectedItem != null)
                                for (int i = 0; i < NbCibleGénérale3.Value; i++)
                                {
                                    array.Add(new Ennemis(Niveau.getID(CibleGénérale3.GetItemText(CibleGénérale3.SelectedItem), "BD_Ennemis.txt"), "pure random"));
                                }
                            ev.cibles = array;
                            ev.type = Evenement.Type_Event.Assassinat;
                            for (int i = 0; i < niveau.evenements.Count; i++)
                            {
                                if (((Evenement)niveau.evenements[i]).nom.Equals(evenement.nom))
                                {
                                    niveau.evenements.RemoveAt(i);
                                    niveau.evenements.Insert(i, ev);
                                }
                            }
                            this.Dispose();
                            this.Close();
                        }
                        else
                        {
                            Warning.Visible = true;
                        }
                    }
                    else if (DialogueEvent.Checked && Interlocuteur.SelectedItem != null && Dialogue.Text.Length > 0)
                    {
                        EvenementDialogue ev = new EvenementDialogue();
                        ev.nom = NomEvent.Text;
                        if (Timer.Checked)
                            ev.timer = (int)minutes.Value * 60 + (int)secondes.Value;
                        else
                            ev.timer = -1;
                        if (Conséquence.Checked)
                            for (int i = 0; i < niveau.evenements.Count; i++)
                            {
                                if (((Evenement)niveau.evenements[i]).nom.Equals(EventCible.GetItemText(EventCible.SelectedItem)))
                                    ev.Conséquence = (Evenement)niveau.evenements[i];
                            }
                        else
                            ev.Conséquence = null;
                        foreach (PNJ pnj in niveau.PNJneutres)
                        {
                            if (pnj.nomEditeur.Equals(Interlocuteur.GetItemText(Interlocuteur.SelectedItem)))
                                ev.PNJ = pnj;
                        }
                        ev.Dialogue = Dialogue.Text;
                        ev.type = Evenement.Type_Event.Dialogue;
                        for (int i = 0; i < niveau.evenements.Count; i++)
                        {
                            if (((Evenement)niveau.evenements[i]).nom.Equals(evenement.nom))
                            {
                                niveau.evenements.RemoveAt(i);
                                niveau.evenements.Insert(i, ev);
                            }
                        }
                        this.Dispose();
                        this.Close();
                    }
                    else if (ObjetEvent.Checked && ObjetAObtenir.SelectedValue != null)
                    {
                        EvenementObjet ev = new EvenementObjet();
                        ev.nom = NomEvent.Text;
                        if (Timer.Checked)
                            ev.timer = (int)minutes.Value * 60 + (int)secondes.Value;
                        else
                            ev.timer = -1;
                        if (Conséquence.Checked)
                            for (int i = 0; i < niveau.evenements.Count; i++)
                            {
                                if (((Evenement)niveau.evenements[i]).nom.Equals(EventCible.GetItemText(EventCible.SelectedItem)))
                                    ev.Conséquence = (Evenement)niveau.evenements[i];
                            }
                        else
                            ev.Conséquence = null;
                        foreach (Objet objet in niveau.objets)
                        {
                            if (objet.nom.Equals(ObjetAObtenir.GetItemText(ObjetAObtenir.SelectedItem)))
                                ev.objet = objet;
                        }
                        ev.type = Evenement.Type_Event.Objet;
                        for (int i = 0; i < niveau.evenements.Count; i++)
                        {
                            if (((Evenement)niveau.evenements[i]).nom.Equals(evenement.nom))
                            {
                                niveau.evenements.RemoveAt(i);
                                niveau.evenements.Insert(i, ev);
                            }
                        }
                        this.Dispose();
                        this.Close();
                    }
                    else if (TéléportationEvent.Checked && !(XEmpCible.Value == XEmpSource.Value && YEmpCible.Value == YEmpSource.Value))
                    {
                        EvenementPorte ev = new EvenementPorte();
                        ev.nom = NomEvent.Text;
                        if (Timer.Checked)
                            ev.timer = (int)minutes.Value * 60 + (int)secondes.Value;
                        else
                            ev.timer = -1;
                        if (Conséquence.Checked)
                            for (int i = 0; i < niveau.evenements.Count; i++)
                            {
                                if (((Evenement)niveau.evenements[i]).nom.Equals(EventCible.GetItemText(EventCible.SelectedItem)))
                                    ev.Conséquence = (Evenement)niveau.evenements[i];
                            }
                        else
                            ev.Conséquence = null;
                        ev.position_source = new Vector2((float)XEmpSource.Value, (float)YEmpSource.Value);
                        ev.position_destination = new Vector2((float)XEmpCible.Value, (float)YEmpCible.Value);
                        ev.type = Evenement.Type_Event.Porte;
                        for (int i = 0; i < niveau.evenements.Count; i++)
                        {
                            if (((Evenement)niveau.evenements[i]).nom.Equals(evenement.nom))
                            {
                                niveau.evenements.RemoveAt(i);
                                niveau.evenements.Insert(i, ev);
                            }
                        }
                        this.Dispose();
                        this.Close();
                    }
                    else if (FinEvent.Checked)
                    {
                        EvenementPorte ev = new EvenementPorte();
                        ev.nom = NomEvent.Text;
                        ev.type = Evenement.Type_Event.Fin;
                        for (int i = 0; i < niveau.evenements.Count; i++)
                        {
                            if (((Evenement)niveau.evenements[i]).nom.Equals(evenement.nom))
                            {
                                niveau.evenements.RemoveAt(i);
                                niveau.evenements.Insert(i, ev);
                            }
                        }
                        this.Dispose();
                        this.Close();
                    }
                    else if (evenement.type == Evenement.Type_Event.Début)
                    {
                        if (Conséquence.Checked)
                            for (int i = 0; i < niveau.evenements.Count; i++)
                            {
                                if (((Evenement)niveau.evenements[i]).nom.Equals(EventCible.GetItemText(EventCible.SelectedItem)))
                                    ((Evenement)niveau.evenements[0]).Conséquence = (Evenement)niveau.evenements[i];
                            }
                        else
                            ((Evenement)niveau.evenements[0]).Conséquence = null;
                        this.Dispose();
                        this.Close();
                    }
                    else
                        Warning.Visible = true;
                }
                else
                    WarningNomPK.Visible = true;

            }
            else
                Warning.Visible = true;
        }

        private void FinEvent_CheckedChanged(object sender, EventArgs e)
        {
            if(FinEvent.Checked)
            {
                secondes.Enabled = false;
                minutes.Enabled = false;
                Timer.Enabled = false;
                Conséquence.Enabled = false;
                EventCible.Enabled = false;
            }
            else
            {
                Timer.Enabled = true;
                if(Timer.Checked)
                {
                    secondes.Enabled = true;
                    minutes.Enabled = true;
                }   
                Conséquence.Enabled = true;
                if(Conséquence.Checked)
                    EventCible.Enabled = true;
            }

        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < niveau.evenements.Count; i++)
            {
                if (((Evenement)niveau.evenements[i]).nom.Equals(evenement.nom))
                {
                    niveau.evenements.RemoveAt(i);
                }
                this.Dispose();
                this.Close();
            }
        }
    }
}
