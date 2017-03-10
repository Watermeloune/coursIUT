namespace Resonance.Niveaux
{
    partial class Editer_Ennemi
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
            this.nomEditeur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.armé = new System.Windows.Forms.CheckBox();
            this.Portée = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Dégats = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.Fréquence = new System.Windows.Forms.NumericUpDown();
            this.armes = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.Sauver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Portée)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dégats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fréquence)).BeginInit();
            this.SuspendLayout();
            // 
            // nomEditeur
            // 
            this.nomEditeur.Location = new System.Drawing.Point(54, 37);
            this.nomEditeur.Name = "nomEditeur";
            this.nomEditeur.Size = new System.Drawing.Size(100, 20);
            this.nomEditeur.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type :";
            // 
            // armé
            // 
            this.armé.AutoSize = true;
            this.armé.Location = new System.Drawing.Point(16, 66);
            this.armé.Name = "armé";
            this.armé.Size = new System.Drawing.Size(50, 17);
            this.armé.TabIndex = 4;
            this.armé.Text = "Arme";
            this.armé.UseVisualStyleBackColor = true;
            this.armé.CheckedChanged += new System.EventHandler(this.armé_CheckedChanged);
            // 
            // Portée
            // 
            this.Portée.Enabled = false;
            this.Portée.Location = new System.Drawing.Point(150, 101);
            this.Portée.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Portée.Name = "Portée";
            this.Portée.Size = new System.Drawing.Size(50, 20);
            this.Portée.TabIndex = 5;
            this.Portée.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Portée :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dégâts :";
            // 
            // Dégats
            // 
            this.Dégats.Enabled = false;
            this.Dégats.Location = new System.Drawing.Point(150, 127);
            this.Dégats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Dégats.Name = "Dégats";
            this.Dégats.Size = new System.Drawing.Size(50, 20);
            this.Dégats.TabIndex = 7;
            this.Dégats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fréquence de tir :";
            // 
            // Fréquence
            // 
            this.Fréquence.Enabled = false;
            this.Fréquence.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.Fréquence.Location = new System.Drawing.Point(150, 153);
            this.Fréquence.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.Fréquence.Name = "Fréquence";
            this.Fréquence.Size = new System.Drawing.Size(50, 20);
            this.Fréquence.TabIndex = 9;
            this.Fréquence.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // armes
            // 
            this.armes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.armes.Enabled = false;
            this.armes.FormattingEnabled = true;
            this.armes.Location = new System.Drawing.Point(79, 64);
            this.armes.Name = "armes";
            this.armes.Size = new System.Drawing.Size(121, 21);
            this.armes.TabIndex = 11;
            // 
            // type
            // 
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(54, 10);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(100, 21);
            this.type.TabIndex = 12;
            // 
            // Sauver
            // 
            this.Sauver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sauver.Location = new System.Drawing.Point(79, 191);
            this.Sauver.Name = "Sauver";
            this.Sauver.Size = new System.Drawing.Size(121, 30);
            this.Sauver.TabIndex = 46;
            this.Sauver.Text = "Sauvegarder";
            this.Sauver.UseVisualStyleBackColor = true;
            this.Sauver.Click += new System.EventHandler(this.Sauver_Click);
            // 
            // Editer_Ennemi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.Sauver);
            this.Controls.Add(this.type);
            this.Controls.Add(this.armes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Fréquence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Dégats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Portée);
            this.Controls.Add(this.armé);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomEditeur);
            this.Name = "Editer_Ennemi";
            this.Text = "Editer Ennemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.Editer_Ennemi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Portée)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dégats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fréquence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomEditeur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox armé;
        private System.Windows.Forms.NumericUpDown Portée;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Dégats;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Fréquence;
        private System.Windows.Forms.ComboBox armes;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Button Sauver;
    }
}