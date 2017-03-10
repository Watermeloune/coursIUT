using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Resonance.Core;
using System;
using System.Collections;

namespace Resonance.Niveaux
{
    class Menu_Supérieur
    {
        public GameObject panneau_supérieur;
        public TextArea nom_niveau;
        public Bouton bouton_renommer;
        public Bouton Sauvegarde;
        public Texture2D Sauvegarde_Validation;
        public GameObject indicateur_position;
        public TextArea[] indicateur_position_data;
        public ListeEvènement evenements;
        public ListeEnnemis ennemis;
        public ListePNJ PNJs;
        public Editer_Evenement EdEv;
        public Editer_Ennemi EdEn;
        public Editer_PNJ EdPnj;
        public bool CliqEdEv;
        public bool CliqEdEn;
        public bool CliqEdpnj;
        public bool édition_nom;
        public void ChargerTexturesMenu(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            panneau_supérieur.Texture = content.Load<Texture2D>("Editeur - Panneau supérieur");
            nom_niveau.textfont = content.Load<SpriteFont>("PoliceEditeur");
            bouton_renommer.Texture = content.Load<Texture2D>("Bouton_renommer");
            Sauvegarde.Texture = content.Load<Texture2D>("sauvegarder_normal");
            Sauvegarde_Validation = content.Load<Texture2D>("sauvegarder_validation");
            indicateur_position.Texture = content.Load<Texture2D>("indicateur_position");
            indicateur_position_data[0].textfont = content.Load<SpriteFont>("PoliceEditeurListes");
            indicateur_position_data[1].textfont = content.Load<SpriteFont>("PoliceEditeurListes");
            indicateur_position.Position = new Vector2(0, panneau_supérieur.Texture.Height - indicateur_position.Texture.Height);
            indicateur_position_data[0].Position = new Vector2(102, indicateur_position.Position.Y);
            indicateur_position_data[1].Position = new Vector2(170, indicateur_position.Position.Y);
            Sauvegarde.longueur = Sauvegarde.Texture.Width;
            Sauvegarde.largeur = Sauvegarde.Texture.Height;
            PNJs.LoadListe(content);
            evenements.LoadListe(content);
            ennemis.LoadListe(content);
            ChargerProportionsBoutonRenommer();

        }
        public void ChargerProportionsBoutonRenommer()
        {
            bouton_renommer.Position = new Vector2(nom_niveau.Position.X + nom_niveau.textfont.MeasureString(nom_niveau.texte).X + 5, nom_niveau.Position.Y);
            bouton_renommer.longueur = bouton_renommer.Texture.Width;
            bouton_renommer.largeur = bouton_renommer.Texture.Height;
        }
        public void DessinerMenu(SpriteBatch spriteBatch)
        {
            panneau_supérieur.Draw(spriteBatch);
            nom_niveau.Draw(spriteBatch, 1);
            bouton_renommer.Draw(spriteBatch);
            Sauvegarde.Draw(spriteBatch);
            indicateur_position.Draw(spriteBatch);
            indicateur_position_data[0].Draw(spriteBatch,1);
            indicateur_position_data[1].Draw(spriteBatch,1);
            PNJs.DrawListe(spriteBatch);
            ennemis.DrawListe(spriteBatch);
            evenements.DrawListe(spriteBatch);
        }
        public void GetIndicateurPosition()
        {

        }
        public bool DansMenuSupérieur(Vector2 Position){
            return (Position.X > 0 && Position.Y > 0 && Position.X < panneau_supérieur.Texture.Width && Position.Y < panneau_supérieur.Texture.Height);
        }
        public Menu_Supérieur(String nom_niveau, Niveau niveau)
        {
            panneau_supérieur = new GameObject();
            this.nom_niveau = new TextArea(nom_niveau, Color.Black);
            this.bouton_renommer = new Bouton(Vector2.Zero);
            this.Sauvegarde = new Bouton(new Vector2(1600, 10));
            this.CliqEdEv = false;
            this.CliqEdEn = false;
            this.CliqEdpnj = false;
            this.PNJs = new ListePNJ(new Color(43, 30, 22), new Vector2(900, 80), niveau.PNJneutres);
            this.ennemis = new ListeEnnemis(new Color(43, 30, 22), new Vector2(550, 80), niveau.ennemis);
            this.evenements = new ListeEvènement(new Color(43, 30, 22), new Vector2(200, 80), niveau.evenements);
            édition_nom = false;
            panneau_supérieur.Position = new Vector2(0, 0);
            this.nom_niveau.Position = new Vector2(15, 15);
            indicateur_position_data = new TextArea[2];
            indicateur_position = new GameObject();
            indicateur_position_data[0] = new TextArea("0", Color.DarkRed);
            indicateur_position_data[1] = new TextArea("0", Color.DarkRed);
        }
    }
}
