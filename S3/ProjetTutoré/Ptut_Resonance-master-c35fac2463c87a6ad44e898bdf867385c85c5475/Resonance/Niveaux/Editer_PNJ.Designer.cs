namespace Resonance.Niveaux
{
    partial class Editer_PNJ
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
            this.type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nomEditeur = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Dialogue = new System.Windows.Forms.RichTextBox();
            this.déclencheur = new System.Windows.Forms.CheckBox();
            this.event_déclencheur = new System.Windows.Forms.ComboBox();
            this.Sauver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // type
            // 
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(72, 18);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(100, 21);
            this.type.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nom :";
            // 
            // nomEditeur
            // 
            this.nomEditeur.Location = new System.Drawing.Point(72, 45);
            this.nomEditeur.Name = "nomEditeur";
            this.nomEditeur.Size = new System.Drawing.Size(100, 20);
            this.nomEditeur.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(11, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Dialogue :";
            // 
            // Dialogue
            // 
            this.Dialogue.Location = new System.Drawing.Point(72, 106);
            this.Dialogue.Name = "Dialogue";
            this.Dialogue.Size = new System.Drawing.Size(233, 128);
            this.Dialogue.TabIndex = 31;
            this.Dialogue.Text = "";
            // 
            // déclencheur
            // 
            this.déclencheur.AutoSize = true;
            this.déclencheur.Location = new System.Drawing.Point(14, 71);
            this.déclencheur.Name = "déclencheur";
            this.déclencheur.Size = new System.Drawing.Size(146, 17);
            this.déclencheur.TabIndex = 33;
            this.déclencheur.Text = "Apparition sur évènement";
            this.déclencheur.UseVisualStyleBackColor = true;
            this.déclencheur.CheckedChanged += new System.EventHandler(this.déclencheur_CheckedChanged);
            // 
            // event_déclencheur
            // 
            this.event_déclencheur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.event_déclencheur.Enabled = false;
            this.event_déclencheur.FormattingEnabled = true;
            this.event_déclencheur.Location = new System.Drawing.Point(166, 71);
            this.event_déclencheur.Name = "event_déclencheur";
            this.event_déclencheur.Size = new System.Drawing.Size(139, 21);
            this.event_déclencheur.TabIndex = 34;
            this.event_déclencheur.SelectedIndexChanged += new System.EventHandler(this.event_déclencheur_SelectedIndexChanged);
            // 
            // Sauver
            // 
            this.Sauver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sauver.Location = new System.Drawing.Point(95, 240);
            this.Sauver.Name = "Sauver";
            this.Sauver.Size = new System.Drawing.Size(121, 30);
            this.Sauver.TabIndex = 47;
            this.Sauver.Text = "Sauvegarder";
            this.Sauver.UseVisualStyleBackColor = true;
            this.Sauver.Click += new System.EventHandler(this.Sauver_Click);
            // 
            // Editer_PNJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 280);
            this.Controls.Add(this.Sauver);
            this.Controls.Add(this.event_déclencheur);
            this.Controls.Add(this.déclencheur);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Dialogue);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomEditeur);
            this.Name = "Editer_PNJ";
            this.Text = "Editer personnage neutre/allié";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.Editer_PNJ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nomEditeur;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox Dialogue;
        private System.Windows.Forms.CheckBox déclencheur;
        private System.Windows.Forms.ComboBox event_déclencheur;
        private System.Windows.Forms.Button Sauver;
    }
}