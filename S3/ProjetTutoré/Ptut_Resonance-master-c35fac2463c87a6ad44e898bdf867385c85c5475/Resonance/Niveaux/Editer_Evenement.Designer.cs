namespace Resonance.Niveaux
{
    partial class Editer_Evenement
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
            this.AssassinatEvent = new System.Windows.Forms.RadioButton();
            this.TéléportationEvent = new System.Windows.Forms.RadioButton();
            this.ObjetEvent = new System.Windows.Forms.RadioButton();
            this.DialogueEvent = new System.Windows.Forms.RadioButton();
            this.Timer = new System.Windows.Forms.CheckBox();
            this.minutes = new System.Windows.Forms.NumericUpDown();
            this.secondes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NomEvent = new System.Windows.Forms.TextBox();
            this.CibleGénérale2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CibleGénérale1 = new System.Windows.Forms.ComboBox();
            this.CibleSpécifique = new System.Windows.Forms.RadioButton();
            this.CibleGénéral = new System.Windows.Forms.RadioButton();
            this.NbCibleGénérale2 = new System.Windows.Forms.NumericUpDown();
            this.NbCibleGénérale1 = new System.Windows.Forms.NumericUpDown();
            this.NbCibleGénérale3 = new System.Windows.Forms.NumericUpDown();
            this.CibleGénérale3 = new System.Windows.Forms.ComboBox();
            this.CibleSpécifique1 = new System.Windows.Forms.ComboBox();
            this.CibleSpécifique2 = new System.Windows.Forms.ComboBox();
            this.CibleSpécifique3 = new System.Windows.Forms.ComboBox();
            this.EventCible = new System.Windows.Forms.ComboBox();
            this.Conséquence = new System.Windows.Forms.CheckBox();
            this.Dialogue = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Interlocuteur = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ObjetAObtenir = new System.Windows.Forms.ComboBox();
            this.FinEvent = new System.Windows.Forms.RadioButton();
            this.XEmpSource = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.XEmpCible = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.YEmpSource = new System.Windows.Forms.NumericUpDown();
            this.YEmpCible = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChoixCibles = new System.Windows.Forms.GroupBox();
            this.Sauver = new System.Windows.Forms.Button();
            this.Supprimer = new System.Windows.Forms.Button();
            this.Warning = new System.Windows.Forms.Label();
            this.WarningNomPK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbCibleGénérale2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbCibleGénérale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbCibleGénérale3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XEmpSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XEmpCible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YEmpSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YEmpCible)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ChoixCibles.SuspendLayout();
            this.SuspendLayout();
            // 
            // AssassinatEvent
            // 
            this.AssassinatEvent.AutoSize = true;
            this.AssassinatEvent.Location = new System.Drawing.Point(23, 19);
            this.AssassinatEvent.Name = "AssassinatEvent";
            this.AssassinatEvent.Size = new System.Drawing.Size(75, 17);
            this.AssassinatEvent.TabIndex = 0;
            this.AssassinatEvent.TabStop = true;
            this.AssassinatEvent.Text = "Assassinat";
            this.AssassinatEvent.UseVisualStyleBackColor = true;
            this.AssassinatEvent.CheckedChanged += new System.EventHandler(this.AssassinatEvent_CheckedChanged);
            // 
            // TéléportationEvent
            // 
            this.TéléportationEvent.AutoSize = true;
            this.TéléportationEvent.Location = new System.Drawing.Point(23, 322);
            this.TéléportationEvent.Name = "TéléportationEvent";
            this.TéléportationEvent.Size = new System.Drawing.Size(87, 17);
            this.TéléportationEvent.TabIndex = 2;
            this.TéléportationEvent.TabStop = true;
            this.TéléportationEvent.Text = "Téléportation";
            this.TéléportationEvent.UseVisualStyleBackColor = true;
            this.TéléportationEvent.CheckedChanged += new System.EventHandler(this.TéléportationEvent_CheckedChanged);
            // 
            // ObjetEvent
            // 
            this.ObjetEvent.AutoSize = true;
            this.ObjetEvent.Location = new System.Drawing.Point(23, 218);
            this.ObjetEvent.Name = "ObjetEvent";
            this.ObjetEvent.Size = new System.Drawing.Size(120, 17);
            this.ObjetEvent.TabIndex = 3;
            this.ObjetEvent.TabStop = true;
            this.ObjetEvent.Text = "Obtention d\'un objet";
            this.ObjetEvent.UseVisualStyleBackColor = true;
            this.ObjetEvent.CheckedChanged += new System.EventHandler(this.ObjetEvent_CheckedChanged);
            // 
            // DialogueEvent
            // 
            this.DialogueEvent.AutoSize = true;
            this.DialogueEvent.Location = new System.Drawing.Point(23, 108);
            this.DialogueEvent.Name = "DialogueEvent";
            this.DialogueEvent.Size = new System.Drawing.Size(67, 17);
            this.DialogueEvent.TabIndex = 4;
            this.DialogueEvent.TabStop = true;
            this.DialogueEvent.Text = "Dialogue";
            this.DialogueEvent.UseVisualStyleBackColor = true;
            this.DialogueEvent.CheckedChanged += new System.EventHandler(this.DialogueEvent_CheckedChanged);
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Location = new System.Drawing.Point(62, 48);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(52, 17);
            this.Timer.TabIndex = 6;
            this.Timer.Text = "Timer";
            this.Timer.UseVisualStyleBackColor = true;
            this.Timer.CheckedChanged += new System.EventHandler(this.Timer_CheckedChanged);
            // 
            // minutes
            // 
            this.minutes.Enabled = false;
            this.minutes.Location = new System.Drawing.Point(120, 47);
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(38, 20);
            this.minutes.TabIndex = 7;
            // 
            // secondes
            // 
            this.secondes.Enabled = false;
            this.secondes.Location = new System.Drawing.Point(193, 47);
            this.secondes.Name = "secondes";
            this.secondes.Size = new System.Drawing.Size(44, 20);
            this.secondes.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nom de l\'évènement : ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NomEvent
            // 
            this.NomEvent.Location = new System.Drawing.Point(159, 17);
            this.NomEvent.Name = "NomEvent";
            this.NomEvent.Size = new System.Drawing.Size(158, 20);
            this.NomEvent.TabIndex = 12;
            // 
            // CibleGénérale2
            // 
            this.CibleGénérale2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CibleGénérale2.Enabled = false;
            this.CibleGénérale2.FormattingEnabled = true;
            this.CibleGénérale2.Location = new System.Drawing.Point(503, 139);
            this.CibleGénérale2.Name = "CibleGénérale2";
            this.CibleGénérale2.Size = new System.Drawing.Size(121, 21);
            this.CibleGénérale2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(165, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Objet à obtenir :";
            // 
            // CibleGénérale1
            // 
            this.CibleGénérale1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CibleGénérale1.Enabled = false;
            this.CibleGénérale1.FormattingEnabled = true;
            this.CibleGénérale1.Location = new System.Drawing.Point(333, 140);
            this.CibleGénérale1.Name = "CibleGénérale1";
            this.CibleGénérale1.Size = new System.Drawing.Size(121, 21);
            this.CibleGénérale1.TabIndex = 15;
            // 
            // CibleSpécifique
            // 
            this.CibleSpécifique.AutoSize = true;
            this.CibleSpécifique.Location = new System.Drawing.Point(15, 19);
            this.CibleSpécifique.Name = "CibleSpécifique";
            this.CibleSpécifique.Size = new System.Drawing.Size(109, 17);
            this.CibleSpécifique.TabIndex = 16;
            this.CibleSpécifique.TabStop = true;
            this.CibleSpécifique.Text = "Cibles spécifiques";
            this.CibleSpécifique.UseVisualStyleBackColor = true;
            this.CibleSpécifique.CheckedChanged += new System.EventHandler(this.CibleSpécifique_CheckedChanged);
            // 
            // CibleGénéral
            // 
            this.CibleGénéral.AutoSize = true;
            this.CibleGénéral.Location = new System.Drawing.Point(15, 52);
            this.CibleGénéral.Name = "CibleGénéral";
            this.CibleGénéral.Size = new System.Drawing.Size(102, 17);
            this.CibleGénéral.TabIndex = 17;
            this.CibleGénéral.TabStop = true;
            this.CibleGénéral.Text = "Cibles générales";
            this.CibleGénéral.UseVisualStyleBackColor = true;
            this.CibleGénéral.CheckedChanged += new System.EventHandler(this.CibleGénéral_CheckedChanged);
            // 
            // NbCibleGénérale2
            // 
            this.NbCibleGénérale2.Enabled = false;
            this.NbCibleGénérale2.Location = new System.Drawing.Point(460, 140);
            this.NbCibleGénérale2.Name = "NbCibleGénérale2";
            this.NbCibleGénérale2.Size = new System.Drawing.Size(37, 20);
            this.NbCibleGénérale2.TabIndex = 18;
            // 
            // NbCibleGénérale1
            // 
            this.NbCibleGénérale1.Enabled = false;
            this.NbCibleGénérale1.Location = new System.Drawing.Point(290, 141);
            this.NbCibleGénérale1.Name = "NbCibleGénérale1";
            this.NbCibleGénérale1.Size = new System.Drawing.Size(37, 20);
            this.NbCibleGénérale1.TabIndex = 19;
            // 
            // NbCibleGénérale3
            // 
            this.NbCibleGénérale3.Enabled = false;
            this.NbCibleGénérale3.Location = new System.Drawing.Point(630, 138);
            this.NbCibleGénérale3.Name = "NbCibleGénérale3";
            this.NbCibleGénérale3.Size = new System.Drawing.Size(37, 20);
            this.NbCibleGénérale3.TabIndex = 20;
            // 
            // CibleGénérale3
            // 
            this.CibleGénérale3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CibleGénérale3.Enabled = false;
            this.CibleGénérale3.FormattingEnabled = true;
            this.CibleGénérale3.Location = new System.Drawing.Point(673, 138);
            this.CibleGénérale3.Name = "CibleGénérale3";
            this.CibleGénérale3.Size = new System.Drawing.Size(121, 21);
            this.CibleGénérale3.TabIndex = 21;
            // 
            // CibleSpécifique1
            // 
            this.CibleSpécifique1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CibleSpécifique1.Enabled = false;
            this.CibleSpécifique1.FormattingEnabled = true;
            this.CibleSpécifique1.Location = new System.Drawing.Point(290, 106);
            this.CibleSpécifique1.Name = "CibleSpécifique1";
            this.CibleSpécifique1.Size = new System.Drawing.Size(121, 21);
            this.CibleSpécifique1.TabIndex = 22;
            // 
            // CibleSpécifique2
            // 
            this.CibleSpécifique2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CibleSpécifique2.Enabled = false;
            this.CibleSpécifique2.FormattingEnabled = true;
            this.CibleSpécifique2.Location = new System.Drawing.Point(417, 106);
            this.CibleSpécifique2.Name = "CibleSpécifique2";
            this.CibleSpécifique2.Size = new System.Drawing.Size(121, 21);
            this.CibleSpécifique2.TabIndex = 23;
            // 
            // CibleSpécifique3
            // 
            this.CibleSpécifique3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CibleSpécifique3.Enabled = false;
            this.CibleSpécifique3.FormattingEnabled = true;
            this.CibleSpécifique3.Location = new System.Drawing.Point(544, 106);
            this.CibleSpécifique3.Name = "CibleSpécifique3";
            this.CibleSpécifique3.Size = new System.Drawing.Size(121, 21);
            this.CibleSpécifique3.TabIndex = 24;
            // 
            // EventCible
            // 
            this.EventCible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventCible.Enabled = false;
            this.EventCible.FormattingEnabled = true;
            this.EventCible.Location = new System.Drawing.Point(676, 17);
            this.EventCible.Name = "EventCible";
            this.EventCible.Size = new System.Drawing.Size(181, 21);
            this.EventCible.TabIndex = 25;
            // 
            // Conséquence
            // 
            this.Conséquence.AutoSize = true;
            this.Conséquence.Location = new System.Drawing.Point(578, 19);
            this.Conséquence.Name = "Conséquence";
            this.Conséquence.Size = new System.Drawing.Size(92, 17);
            this.Conséquence.TabIndex = 26;
            this.Conséquence.Text = "Conséquence";
            this.Conséquence.UseVisualStyleBackColor = true;
            this.Conséquence.CheckedChanged += new System.EventHandler(this.Conséquence_CheckedChanged);
            // 
            // Dialogue
            // 
            this.Dialogue.Enabled = false;
            this.Dialogue.Location = new System.Drawing.Point(443, 210);
            this.Dialogue.Name = "Dialogue";
            this.Dialogue.Size = new System.Drawing.Size(414, 78);
            this.Dialogue.TabIndex = 27;
            this.Dialogue.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(165, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Interlocuteur :";
            // 
            // Interlocuteur
            // 
            this.Interlocuteur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Interlocuteur.Enabled = false;
            this.Interlocuteur.FormattingEnabled = true;
            this.Interlocuteur.Location = new System.Drawing.Point(243, 210);
            this.Interlocuteur.Name = "Interlocuteur";
            this.Interlocuteur.Size = new System.Drawing.Size(133, 21);
            this.Interlocuteur.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(382, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Dialogue :";
            // 
            // ObjetAObtenir
            // 
            this.ObjetAObtenir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjetAObtenir.Enabled = false;
            this.ObjetAObtenir.FormattingEnabled = true;
            this.ObjetAObtenir.Location = new System.Drawing.Point(253, 325);
            this.ObjetAObtenir.Name = "ObjetAObtenir";
            this.ObjetAObtenir.Size = new System.Drawing.Size(121, 21);
            this.ObjetAObtenir.TabIndex = 31;
            // 
            // FinEvent
            // 
            this.FinEvent.AutoSize = true;
            this.FinEvent.Location = new System.Drawing.Point(23, 425);
            this.FinEvent.Name = "FinEvent";
            this.FinEvent.Size = new System.Drawing.Size(39, 17);
            this.FinEvent.TabIndex = 32;
            this.FinEvent.TabStop = true;
            this.FinEvent.Text = "Fin";
            this.FinEvent.UseVisualStyleBackColor = true;
            this.FinEvent.CheckedChanged += new System.EventHandler(this.FinEvent_CheckedChanged);
            // 
            // XEmpSource
            // 
            this.XEmpSource.Enabled = false;
            this.XEmpSource.Location = new System.Drawing.Point(283, 427);
            this.XEmpSource.Name = "XEmpSource";
            this.XEmpSource.Size = new System.Drawing.Size(84, 20);
            this.XEmpSource.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(165, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Emplacement source :";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(165, 456);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Emplacement cible :";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // XEmpCible
            // 
            this.XEmpCible.Enabled = false;
            this.XEmpCible.Location = new System.Drawing.Point(283, 453);
            this.XEmpCible.Name = "XEmpCible";
            this.XEmpCible.Size = new System.Drawing.Size(84, 20);
            this.XEmpCible.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(373, 434);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "x";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(373, 456);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "x";
            // 
            // YEmpSource
            // 
            this.YEmpSource.Enabled = false;
            this.YEmpSource.Location = new System.Drawing.Point(391, 427);
            this.YEmpSource.Name = "YEmpSource";
            this.YEmpSource.Size = new System.Drawing.Size(84, 20);
            this.YEmpSource.TabIndex = 39;
            // 
            // YEmpCible
            // 
            this.YEmpCible.Enabled = false;
            this.YEmpCible.Location = new System.Drawing.Point(391, 453);
            this.YEmpCible.Name = "YEmpCible";
            this.YEmpCible.Size = new System.Drawing.Size(84, 20);
            this.YEmpCible.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(481, 434);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(481, 460);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "y";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AssassinatEvent);
            this.groupBox1.Controls.Add(this.DialogueEvent);
            this.groupBox1.Controls.Add(this.ObjetEvent);
            this.groupBox1.Controls.Add(this.TéléportationEvent);
            this.groupBox1.Controls.Add(this.FinEvent);
            this.groupBox1.Location = new System.Drawing.Point(15, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 515);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action:";
            // 
            // ChoixCibles
            // 
            this.ChoixCibles.Controls.Add(this.CibleSpécifique);
            this.ChoixCibles.Controls.Add(this.CibleGénéral);
            this.ChoixCibles.Enabled = false;
            this.ChoixCibles.Location = new System.Drawing.Point(160, 89);
            this.ChoixCibles.Name = "ChoixCibles";
            this.ChoixCibles.Size = new System.Drawing.Size(127, 89);
            this.ChoixCibles.TabIndex = 44;
            this.ChoixCibles.TabStop = false;
            // 
            // Sauver
            // 
            this.Sauver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sauver.Location = new System.Drawing.Point(676, 495);
            this.Sauver.Name = "Sauver";
            this.Sauver.Size = new System.Drawing.Size(160, 30);
            this.Sauver.TabIndex = 45;
            this.Sauver.Text = "Sauvegarder";
            this.Sauver.UseVisualStyleBackColor = true;
            this.Sauver.Click += new System.EventHandler(this.Sauver_Click);
            // 
            // Supprimer
            // 
            this.Supprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supprimer.Location = new System.Drawing.Point(676, 429);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Size = new System.Drawing.Size(160, 30);
            this.Supprimer.TabIndex = 46;
            this.Supprimer.Text = "Supprimer l\'évènement";
            this.Supprimer.UseVisualStyleBackColor = true;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // Warning
            // 
            this.Warning.AutoSize = true;
            this.Warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Warning.ForeColor = System.Drawing.Color.Crimson;
            this.Warning.Location = new System.Drawing.Point(597, 528);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(273, 15);
            this.Warning.TabIndex = 47;
            this.Warning.Text = "Veuillez renseigner tous les champs nécessaires";
            this.Warning.Visible = false;
            // 
            // WarningNomPK
            // 
            this.WarningNomPK.AutoSize = true;
            this.WarningNomPK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningNomPK.ForeColor = System.Drawing.Color.Crimson;
            this.WarningNomPK.Location = new System.Drawing.Point(324, 20);
            this.WarningNomPK.Name = "WarningNomPK";
            this.WarningNomPK.Size = new System.Drawing.Size(193, 13);
            this.WarningNomPK.TabIndex = 48;
            this.WarningNomPK.Text = "Le nom de l\'évènement doit être unique";
            this.WarningNomPK.Visible = false;
            // 
            // Editer_Evenement
            // 
            this.ClientSize = new System.Drawing.Size(882, 597);
            this.Controls.Add(this.WarningNomPK);
            this.Controls.Add(this.Warning);
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.Sauver);
            this.Controls.Add(this.ChoixCibles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.YEmpCible);
            this.Controls.Add(this.YEmpSource);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.XEmpCible);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.XEmpSource);
            this.Controls.Add(this.ObjetAObtenir);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Interlocuteur);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Dialogue);
            this.Controls.Add(this.Conséquence);
            this.Controls.Add(this.EventCible);
            this.Controls.Add(this.CibleSpécifique3);
            this.Controls.Add(this.CibleSpécifique2);
            this.Controls.Add(this.CibleSpécifique1);
            this.Controls.Add(this.CibleGénérale3);
            this.Controls.Add(this.NbCibleGénérale3);
            this.Controls.Add(this.NbCibleGénérale1);
            this.Controls.Add(this.NbCibleGénérale2);
            this.Controls.Add(this.CibleGénérale1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CibleGénérale2);
            this.Controls.Add(this.NomEvent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secondes);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.Timer);
            this.Name = "Editer_Evenement";
            this.Text = "Editer Evenement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.Editer_Evenement_Load_2);
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbCibleGénérale2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbCibleGénérale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbCibleGénérale3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XEmpSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XEmpCible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YEmpSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YEmpCible)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ChoixCibles.ResumeLayout(false);
            this.ChoixCibles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton AssassinatEvent;
        private System.Windows.Forms.RadioButton TéléportationEvent;
        private System.Windows.Forms.RadioButton ObjetEvent;
        private System.Windows.Forms.RadioButton DialogueEvent;
        private System.Windows.Forms.CheckBox Timer;
        private System.Windows.Forms.NumericUpDown minutes;
        private System.Windows.Forms.NumericUpDown secondes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NomEvent;
        private System.Windows.Forms.ComboBox CibleGénérale2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CibleGénérale1;
        private System.Windows.Forms.RadioButton CibleSpécifique;
        private System.Windows.Forms.RadioButton CibleGénéral;
        private System.Windows.Forms.NumericUpDown NbCibleGénérale2;
        private System.Windows.Forms.NumericUpDown NbCibleGénérale1;
        private System.Windows.Forms.NumericUpDown NbCibleGénérale3;
        private System.Windows.Forms.ComboBox CibleGénérale3;
        private System.Windows.Forms.ComboBox CibleSpécifique1;
        private System.Windows.Forms.ComboBox CibleSpécifique2;
        private System.Windows.Forms.ComboBox CibleSpécifique3;
        private System.Windows.Forms.ComboBox EventCible;
        private System.Windows.Forms.CheckBox Conséquence;
        private System.Windows.Forms.RichTextBox Dialogue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Interlocuteur;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ObjetAObtenir;
        private System.Windows.Forms.RadioButton FinEvent;
        private System.Windows.Forms.NumericUpDown XEmpSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown XEmpCible;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown YEmpSource;
        private System.Windows.Forms.NumericUpDown YEmpCible;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ChoixCibles;
        private System.Windows.Forms.Button Sauver;
        private System.Windows.Forms.Button Supprimer;
        private System.Windows.Forms.Label Warning;
        private System.Windows.Forms.Label WarningNomPK;
    }
}