namespace CharacterCreator
{
    partial class CharacterCreator
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
            this.components = new System.ComponentModel.Container();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ddlProfession = new System.Windows.Forms.ComboBox();
            this.ddlRace = new System.Windows.Forms.ComboBox();
            this.txtProfession = new System.Windows.Forms.Label();
            this.txtRace = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.Label();
            this.txtNames = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dwStrength = new System.Windows.Forms.NumericUpDown();
            this.dwIntelligence = new System.Windows.Forms.NumericUpDown();
            this.dwAguility = new System.Windows.Forms.NumericUpDown();
            this.dwConstitution = new System.Windows.Forms.NumericUpDown();
            this.dwCharisma = new System.Windows.Forms.NumericUpDown();
            this.txtStrength = new System.Windows.Forms.Label();
            this.txtIntelligence = new System.Windows.Forms.Label();
            this.txtAguility = new System.Windows.Forms.Label();
            this.txtConstitution = new System.Windows.Forms.Label();
            this.txtCharisma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwAguility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwConstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwCharisma)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(103, 345);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OnOk);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // ddlProfession
            // 
            this.ddlProfession.FormattingEnabled = true;
            this.ddlProfession.Location = new System.Drawing.Point(169, 88);
            this.ddlProfession.Name = "ddlProfession";
            this.ddlProfession.Size = new System.Drawing.Size(121, 21);
            this.ddlProfession.TabIndex = 1;
            // 
            // ddlRace
            // 
            this.ddlRace.FormattingEnabled = true;
            this.ddlRace.Location = new System.Drawing.Point(169, 136);
            this.ddlRace.Name = "ddlRace";
            this.ddlRace.Size = new System.Drawing.Size(121, 21);
            this.ddlRace.TabIndex = 2;
            // 
            // txtProfession
            // 
            this.txtProfession.AutoSize = true;
            this.txtProfession.Location = new System.Drawing.Point(63, 91);
            this.txtProfession.Name = "txtProfession";
            this.txtProfession.Size = new System.Drawing.Size(59, 13);
            this.txtProfession.TabIndex = 13;
            this.txtProfession.Text = "Profession:";
            // 
            // txtRace
            // 
            this.txtRace.AutoSize = true;
            this.txtRace.Location = new System.Drawing.Point(86, 139);
            this.txtRace.Name = "txtRace";
            this.txtRace.Size = new System.Drawing.Size(36, 13);
            this.txtRace.TabIndex = 14;
            this.txtRace.Text = "Race:";
            // 
            // txtDesc
            // 
            this.txtDesc.AutoSize = true;
            this.txtDesc.Location = new System.Drawing.Point(59, 180);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(63, 13);
            this.txtDesc.TabIndex = 16;
            this.txtDesc.Text = "Description:";
            // 
            // txtNames
            // 
            this.txtNames.AutoSize = true;
            this.txtNames.Location = new System.Drawing.Point(84, 50);
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(38, 13);
            this.txtNames.TabIndex = 12;
            this.txtNames.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(169, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(169, 177);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(121, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dwStrength
            // 
            this.dwStrength.Location = new System.Drawing.Point(25, 280);
            this.dwStrength.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.dwStrength.Name = "dwStrength";
            this.dwStrength.Size = new System.Drawing.Size(46, 20);
            this.dwStrength.TabIndex = 5;
            this.dwStrength.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.dwStrength.ValueChanged += new System.EventHandler(this.dwStrength_ValueChanged);
            // 
            // dwIntelligence
            // 
            this.dwIntelligence.Location = new System.Drawing.Point(81, 280);
            this.dwIntelligence.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.dwIntelligence.Name = "dwIntelligence";
            this.dwIntelligence.Size = new System.Drawing.Size(41, 20);
            this.dwIntelligence.TabIndex = 6;
            this.dwIntelligence.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // dwAguility
            // 
            this.dwAguility.Location = new System.Drawing.Point(152, 280);
            this.dwAguility.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.dwAguility.Name = "dwAguility";
            this.dwAguility.Size = new System.Drawing.Size(38, 20);
            this.dwAguility.TabIndex = 7;
            this.dwAguility.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // dwConstitution
            // 
            this.dwConstitution.Location = new System.Drawing.Point(215, 280);
            this.dwConstitution.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.dwConstitution.Name = "dwConstitution";
            this.dwConstitution.Size = new System.Drawing.Size(46, 20);
            this.dwConstitution.TabIndex = 8;
            this.dwConstitution.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // dwCharisma
            // 
            this.dwCharisma.Location = new System.Drawing.Point(281, 280);
            this.dwCharisma.Name = "dwCharisma";
            this.dwCharisma.Size = new System.Drawing.Size(42, 20);
            this.dwCharisma.TabIndex = 9;
            // 
            // txtStrength
            // 
            this.txtStrength.AutoSize = true;
            this.txtStrength.Location = new System.Drawing.Point(24, 241);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(47, 13);
            this.txtStrength.TabIndex = 17;
            this.txtStrength.Text = "Strength";
            // 
            // txtIntelligence
            // 
            this.txtIntelligence.AutoSize = true;
            this.txtIntelligence.Location = new System.Drawing.Point(72, 241);
            this.txtIntelligence.Name = "txtIntelligence";
            this.txtIntelligence.Size = new System.Drawing.Size(61, 13);
            this.txtIntelligence.TabIndex = 18;
            this.txtIntelligence.Text = "Intelligence";
            // 
            // txtAguility
            // 
            this.txtAguility.AutoSize = true;
            this.txtAguility.Location = new System.Drawing.Point(150, 241);
            this.txtAguility.Name = "txtAguility";
            this.txtAguility.Size = new System.Drawing.Size(40, 13);
            this.txtAguility.TabIndex = 19;
            this.txtAguility.Text = "Aguility";
            // 
            // txtConstitution
            // 
            this.txtConstitution.AutoSize = true;
            this.txtConstitution.Location = new System.Drawing.Point(199, 241);
            this.txtConstitution.Name = "txtConstitution";
            this.txtConstitution.Size = new System.Drawing.Size(62, 13);
            this.txtConstitution.TabIndex = 20;
            this.txtConstitution.Text = "Constitution";
            // 
            // txtCharisma
            // 
            this.txtCharisma.AutoSize = true;
            this.txtCharisma.Location = new System.Drawing.Point(278, 241);
            this.txtCharisma.Name = "txtCharisma";
            this.txtCharisma.Size = new System.Drawing.Size(50, 13);
            this.txtCharisma.TabIndex = 21;
            this.txtCharisma.Text = "Charisma";
            // 
            // CharacterCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 441);
            this.Controls.Add(this.txtCharisma);
            this.Controls.Add(this.txtConstitution);
            this.Controls.Add(this.txtAguility);
            this.Controls.Add(this.txtIntelligence);
            this.Controls.Add(this.txtStrength);
            this.Controls.Add(this.dwCharisma);
            this.Controls.Add(this.dwConstitution);
            this.Controls.Add(this.dwAguility);
            this.Controls.Add(this.dwIntelligence);
            this.Controls.Add(this.dwStrength);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNames);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtRace);
            this.Controls.Add(this.txtProfession);
            this.Controls.Add(this.ddlRace);
            this.Controls.Add(this.ddlProfession);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterCreator";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwAguility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwConstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwCharisma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox ddlProfession;
        private System.Windows.Forms.ComboBox ddlRace;
        private System.Windows.Forms.Label txtProfession;
        private System.Windows.Forms.Label txtRace;
        private System.Windows.Forms.Label txtDesc;
        private System.Windows.Forms.Label txtNames;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown dwCharisma;
        private System.Windows.Forms.NumericUpDown dwConstitution;
        private System.Windows.Forms.NumericUpDown dwAguility;
        private System.Windows.Forms.NumericUpDown dwIntelligence;
        private System.Windows.Forms.NumericUpDown dwStrength;
        private System.Windows.Forms.Label txtCharisma;
        private System.Windows.Forms.Label txtConstitution;
        private System.Windows.Forms.Label txtAguility;
        private System.Windows.Forms.Label txtIntelligence;
        private System.Windows.Forms.Label txtStrength;
    }
}