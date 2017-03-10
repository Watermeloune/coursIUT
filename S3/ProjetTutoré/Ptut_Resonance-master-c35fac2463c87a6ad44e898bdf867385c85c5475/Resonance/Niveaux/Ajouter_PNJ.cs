using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resonance.Niveaux
{
    public partial class Ajouter_PNJ : Form
    {
        OpenFileDialog OFD;
        String[] NomFichier;
        Button[] But_Parcourir;
        PictureBox[] Img_Liste;

        public void InitialiserComposants()
        {
            But_Parcourir = new Button[12];
            But_Parcourir[0] = Parcourir_Haut_Mv1;
            But_Parcourir[1] = Parcourir_Haut_Stat;
            But_Parcourir[2] = Parcourir_Haut_Mv2;
            But_Parcourir[3] = Parcourir_Droite_Mv1;
            But_Parcourir[4] = Parcourir_Droite_Stat;
            But_Parcourir[5] = Parcourir_Droite_Mv2;
            But_Parcourir[6] = Parcourir_Bas_Mv1;
            But_Parcourir[7] = Parcourir_Bas_Stat;
            But_Parcourir[8] = Parcourir_Bas_Mv2;
            But_Parcourir[9] = Parcourir_Gauche_Mv1;
            But_Parcourir[10] = Parcourir_Gauche_Stat;
            But_Parcourir[11] = Parcourir_Gauche_Mv2;
            Img_Liste = new PictureBox[12];
            Img_Liste[0] = Img_Haut_Mv1;
            Img_Liste[1] = Img_Haut_Stat;
            Img_Liste[2] = Img_Haut_Mv2;
            Img_Liste[3] = Img_Droite_Mv1;
            Img_Liste[4] = Img_Droite_Stat;
            Img_Liste[5] = Img_Droite_Mv2;
            Img_Liste[6] = Img_Bas_Mv1;
            Img_Liste[7] = Img_Bas_Stat;
            Img_Liste[8] = Img_Bas_Mv2;
            Img_Liste[9] = Img_Gauche_Mv1;
            Img_Liste[10] = Img_Gauche_Stat;
            Img_Liste[11] = Img_Gauche_Mv2;
            NomFichier = new String[12];
            for (int i = 0; i < NomFichier.Length; i++)
            {
                NomFichier[i] = null;
            }
        }
        public Ajouter_PNJ()
        {
            InitializeComponent();
            InitialiserComposants();
            StartPosition = FormStartPosition.CenterScreen;
            Cursor.Show();
            OFD = new OpenFileDialog();
            OFD.Multiselect = false;
            OFD.Filter = "Image|*.bmp;*.jpg;*.jpeg;*.jif;*.jfif;*.png;*.tif;*.tiff";
        }
        private void Ajouter_Bloc_Load(object sender, EventArgs e)
        {

        }

        private void Parcourir_Click(object sender, EventArgs e)
        {
            /*if(OFD.ShowDialog() == DialogResult.OK)
            {
                NomFichier = OFD.FileName;
                Sprite_Face.Load(NomFichier);
                if (Sprite_Face.Width == 50 && Sprite_Face.Height == 50)
                {
                    Emplacement.Text = NomFichier;
                }
                
                
            }*/
        }

        private void Titre_Emplacement_Click(object sender, EventArgs e)
        {

        }

        private void Warning_Click(object sender, EventArgs e)
        {
            
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            bool ext_valide = true;
            foreach(String nomfichier in NomFichier)
            {
                bool temp = false;
                foreach (String ext in new String[] { ".bmp",".jpg",".jpeg",".jif",".jfif",".png",".tif",".tiff" })
                {
                    if (ext.Equals(nomfichier.Substring(nomfichier.LastIndexOf('.'))))
                        temp = true;
                }
                if(temp == false)
                    ext_valide = false;
            }
            if (ext_valide && Nom.Text.Length > 0)
            {
                for(int i = 0; i < But_Parcourir.Length; i++)
                {
                    System.IO.File.Copy(NomFichier[i], String.Concat("Content\\PNJ\\", Nom.Text, Img_Liste[i].Name.Substring(Img_Liste[i].Name.IndexOf('_')) , NomFichier[i].Substring(NomFichier[i].LastIndexOf('.'))), true);
                }
                int nblignes = Editeur.Nombre_lignes_fichier("BD_PNJs.txt") + 1;
                String identifiant;
                if (nblignes < 100)
                    if (nblignes < 10)
                        identifiant = String.Concat("00", nblignes.ToString());
                    else
                        identifiant = String.Concat("0", nblignes.ToString());
                else
                    identifiant = nblignes.ToString();
                StreamWriter SR = new StreamWriter(String.Concat(Niveau.Root, "BD_PNJs.txt"), true);
                SR.Write(Environment.NewLine);
                SR.Write(String.Concat(identifiant, "=", Nom.Text));
                SR.Close();
                Cursor.Hide();
                this.Dispose();
            }
            else if (Nom.Text.Length > 0)
            {
                NomInvalide.Visible = false;
            }
            else
            {
                NomInvalide.Visible = true;
            }
            

        }

        private void Titre_Nom_Click(object sender, EventArgs e)
        {

        }

        private void Emplacement_TextChanged(object sender, EventArgs e)
        {

        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Cursor.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void Parcourir_Cliq(object sender, MouseEventArgs e)
        {
            int index = 0;
            for (int i = 0; i < But_Parcourir.Length; i++)
            {
                if (((Button)sender).Equals(But_Parcourir[i]))
                    index = i;
            }
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Img_Liste[index].Load(OFD.FileName);
                if (Img_Liste[index].Image.Width <= 50 && Img_Liste[index].Image.Height <= 100)
                {
                    Warning.ForeColor = Color.Black;
                    NomFichier[index] = OFD.FileName;
                }
                else
                {
                    Warning.ForeColor = Color.Red;
                    Img_Liste[index].Image.Dispose();
                    Img_Liste[index].Image = null;
                }
            }
            foreach(String NF in NomFichier)
            {
                Valider.Enabled = true;
                if(NF == null)
                {
                    Valider.Enabled = false;
                }
            }
        }
    }
}
