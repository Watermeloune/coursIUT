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
    public partial class Ajouter_Bloc : Form
    {
        OpenFileDialog OFD;
        String NomFichier;
        public Ajouter_Bloc()
        {
            InitializeComponent();
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
            if(OFD.ShowDialog() == DialogResult.OK)
            {
                NomFichier = OFD.FileName;
                Image.Load(NomFichier);
                if (Image.Width == 50 && Image.Height == 50)
                {
                    Emplacement.Text = NomFichier;
                }
                
                
            }
        }

        private void Titre_Emplacement_Click(object sender, EventArgs e)
        {

        }

        private void Warning_Click(object sender, EventArgs e)
        {
            
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            bool ext_valide = false;
            
            foreach (String ext in new String[] { ".bmp",".jpg",".jpeg",".jif",".jfif",".png",".tif",".tiff" })
            {
                if (ext == NomFichier.Substring(NomFichier.LastIndexOf('.')))
                    ext_valide = true;
            }
            if (File.Exists(Emplacement.Text) && ext_valide && Nom.Text.Length > 0)
            {
                Image.Load(NomFichier);
                if (Image.Image.Width == 50 && Image.Image.Height == 50)
                {
                    System.IO.File.Copy(NomFichier, String.Concat("Content\\Blocs\\", Nom.Text, NomFichier.Substring(NomFichier.LastIndexOf('.'))), true);
                    int nblignes = Editeur.Nombre_lignes_fichier("BD_Blocs.txt") + 1;
                    String identifiant;
                    if (nblignes < 100)
                        if (nblignes < 10)
                            identifiant = String.Concat("00", nblignes.ToString());
                        else
                            identifiant = String.Concat("0", nblignes.ToString());
                    else
                        identifiant = nblignes.ToString();
                    StreamWriter SR = new StreamWriter(String.Concat(Niveau.Root, "BD_Blocs.txt"), true);
                    SR.Write(Environment.NewLine);
                    SR.Write(String.Concat(identifiant, "=", Nom.Text));
                    SR.Close();
                    Cursor.Hide();
                    this.Dispose();
                }
                else
                    DimensionsInvalides.Visible = true;
            }
            else if (Nom.Text.Length > 0)
            {
                EmplacementInvalide.Visible = true;
                NomInvalide.Visible = false;
            }
            else if(File.Exists(Emplacement.Text) && ext_valide)
            {
                EmplacementInvalide.Visible = false;
                NomInvalide.Visible = true;
                Image.Load(NomFichier);
                if (!(Image.Width == 50 && Image.Height == 50))
                {
                    DimensionsInvalides.Visible = true;
                }
            }
            else
            {
                EmplacementInvalide.Visible = true;
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
    }
}
