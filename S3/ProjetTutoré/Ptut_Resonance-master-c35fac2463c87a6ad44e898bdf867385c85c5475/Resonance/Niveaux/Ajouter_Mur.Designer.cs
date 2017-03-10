namespace Resonance.Niveaux
{
    partial class Ajouter_Mur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Parcourir = new System.Windows.Forms.Button();
            this.Emplacement = new System.Windows.Forms.TextBox();
            this.Titre_Emplacement = new System.Windows.Forms.Label();
            this.Warning = new System.Windows.Forms.Label();
            this.Image = new System.Windows.Forms.PictureBox();
            this.Valider = new System.Windows.Forms.Button();
            this.Titre_Nom = new System.Windows.Forms.Label();
            this.Nom = new System.Windows.Forms.TextBox();
            this.EmplacementInvalide = new System.Windows.Forms.Label();
            this.NomInvalide = new System.Windows.Forms.Label();
            this.DimensionsInvalides = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Parcourir
            // 
            this.Parcourir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parcourir.Location = new System.Drawing.Point(313, 29);
            this.Parcourir.Name = "Parcourir";
            this.Parcourir.Size = new System.Drawing.Size(65, 31);
            this.Parcourir.TabIndex = 0;
            this.Parcourir.Text = "Parcourir";
            this.Parcourir.UseVisualStyleBackColor = true;
            this.Parcourir.Click += new System.EventHandler(this.Parcourir_Click);
            // 
            // Emplacement
            // 
            this.Emplacement.AccessibleName = "Emplacement";
            this.Emplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emplacement.Location = new System.Drawing.Point(15, 31);
            this.Emplacement.Name = "Emplacement";
            this.Emplacement.Size = new System.Drawing.Size(292, 23);
            this.Emplacement.TabIndex = 1;
            this.Emplacement.TextChanged += new System.EventHandler(this.Emplacement_TextChanged);
            // 
            // Titre_Emplacement
            // 
            this.Titre_Emplacement.AutoSize = true;
            this.Titre_Emplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre_Emplacement.Location = new System.Drawing.Point(12, 9);
            this.Titre_Emplacement.Name = "Titre_Emplacement";
            this.Titre_Emplacement.Size = new System.Drawing.Size(143, 15);
            this.Titre_Emplacement.TabIndex = 2;
            this.Titre_Emplacement.Text = "Emplacement du fichier :";
            this.Titre_Emplacement.Click += new System.EventHandler(this.Titre_Emplacement_Click);
            // 
            // Warning
            // 
            this.Warning.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Warning.Location = new System.Drawing.Point(12, 63);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(366, 23);
            this.Warning.TabIndex = 0;
            this.Warning.Text = "Attention l\'image doit être de dimensions inférieure à 50x50";
            this.Warning.Click += new System.EventHandler(this.Warning_Click);
            // 
            // Image
            // 
            this.Image.Location = new System.Drawing.Point(257, 100);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(50, 50);
            this.Image.TabIndex = 3;
            this.Image.TabStop = false;
            // 
            // Valider
            // 
            this.Valider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valider.Location = new System.Drawing.Point(313, 105);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(65, 31);
            this.Valider.TabIndex = 4;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // Titre_Nom
            // 
            this.Titre_Nom.AutoSize = true;
            this.Titre_Nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre_Nom.Location = new System.Drawing.Point(12, 86);
            this.Titre_Nom.Name = "Titre_Nom";
            this.Titre_Nom.Size = new System.Drawing.Size(82, 15);
            this.Titre_Nom.TabIndex = 5;
            this.Titre_Nom.Text = "Nom du mur :";
            this.Titre_Nom.Click += new System.EventHandler(this.Titre_Nom_Click);
            // 
            // Nom
            // 
            this.Nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nom.Location = new System.Drawing.Point(15, 110);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(236, 23);
            this.Nom.TabIndex = 6;
            // 
            // EmplacementInvalide
            // 
            this.EmplacementInvalide.AutoSize = true;
            this.EmplacementInvalide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmplacementInvalide.ForeColor = System.Drawing.Color.Crimson;
            this.EmplacementInvalide.Location = new System.Drawing.Point(161, 11);
            this.EmplacementInvalide.Name = "EmplacementInvalide";
            this.EmplacementInvalide.Size = new System.Drawing.Size(108, 13);
            this.EmplacementInvalide.TabIndex = 7;
            this.EmplacementInvalide.Text = "Informations invalides";
            this.EmplacementInvalide.Visible = false;
            // 
            // NomInvalide
            // 
            this.NomInvalide.AutoSize = true;
            this.NomInvalide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomInvalide.ForeColor = System.Drawing.Color.Crimson;
            this.NomInvalide.Location = new System.Drawing.Point(100, 88);
            this.NomInvalide.Name = "NomInvalide";
            this.NomInvalide.Size = new System.Drawing.Size(108, 13);
            this.NomInvalide.TabIndex = 8;
            this.NomInvalide.Text = "Informations invalides";
            this.NomInvalide.Visible = false;
            // 
            // DimensionsInvalides
            // 
            this.DimensionsInvalides.AutoSize = true;
            this.DimensionsInvalides.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimensionsInvalides.ForeColor = System.Drawing.Color.Crimson;
            this.DimensionsInvalides.Location = new System.Drawing.Point(231, 83);
            this.DimensionsInvalides.Name = "DimensionsInvalides";
            this.DimensionsInvalides.Size = new System.Drawing.Size(105, 13);
            this.DimensionsInvalides.TabIndex = 9;
            this.DimensionsInvalides.Text = "Dimensions invalides";
            this.DimensionsInvalides.Visible = false;
            // 
            // Ajouter_Mur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 162);
            this.Controls.Add(this.DimensionsInvalides);
            this.Controls.Add(this.NomInvalide);
            this.Controls.Add(this.EmplacementInvalide);
            this.Controls.Add(this.Nom);
            this.Controls.Add(this.Titre_Nom);
            this.Controls.Add(this.Valider);
            this.Controls.Add(this.Image);
            this.Controls.Add(this.Warning);
            this.Controls.Add(this.Titre_Emplacement);
            this.Controls.Add(this.Emplacement);
            this.Controls.Add(this.Parcourir);
            this.Name = "Ajouter_Mur";
            this.Text = "Ajouter un mur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.Ajouter_Bloc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Parcourir;
        private System.Windows.Forms.TextBox Emplacement;
        private System.Windows.Forms.Label Titre_Emplacement;
        private System.Windows.Forms.Label Warning;
        private System.Windows.Forms.PictureBox Image;
        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.Label Titre_Nom;
        private System.Windows.Forms.TextBox Nom;
        private System.Windows.Forms.Label EmplacementInvalide;
        private System.Windows.Forms.Label NomInvalide;
        private System.Windows.Forms.Label DimensionsInvalides;
    }
}