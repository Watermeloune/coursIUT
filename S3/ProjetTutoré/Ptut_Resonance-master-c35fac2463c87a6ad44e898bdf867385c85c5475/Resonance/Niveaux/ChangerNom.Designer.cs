namespace Resonance.Niveaux
{
    partial class ChangerNom
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
            this.NewNomNiveau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Valider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewNomNiveau
            // 
            this.NewNomNiveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.NewNomNiveau.Location = new System.Drawing.Point(12, 35);
            this.NewNomNiveau.Name = "NewNomNiveau";
            this.NewNomNiveau.Size = new System.Drawing.Size(144, 24);
            this.NewNomNiveau.TabIndex = 0;
            this.NewNomNiveau.TextChanged += new System.EventHandler(this.NewNomNiveau_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nouveau nom du niveau :";
            // 
            // Valider
            // 
            this.Valider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Valider.Location = new System.Drawing.Point(178, 35);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(75, 23);
            this.Valider.TabIndex = 2;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // ChangerNom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 73);
            this.Controls.Add(this.Valider);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewNomNiveau);
            this.Name = "ChangerNom";
            this.Text = "ChangerNom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.ChangerNom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewNomNiveau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Valider;
    }
}