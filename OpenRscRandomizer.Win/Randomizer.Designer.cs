
namespace OpenRscRandomizer.Win
{
    partial class Randomizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Randomizer));
            this.lblRandomizeNpcs = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.rbNpcsYes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNpcsNo = new System.Windows.Forms.RadioButton();
            this.cbxExcludeNonAttackables = new System.Windows.Forms.CheckBox();
            this.cbxExcludeAttackableQuestNpcs = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbNpcsGrouplyByLocation = new System.Windows.Forms.RadioButton();
            this.rbNpcsGrouply = new System.Windows.Forms.RadioButton();
            this.rbNpcsSingularly = new System.Windows.Forms.RadioButton();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.lblPreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRandomizeNpcs
            // 
            this.lblRandomizeNpcs.AutoSize = true;
            this.lblRandomizeNpcs.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRandomizeNpcs.Location = new System.Drawing.Point(21, 163);
            this.lblRandomizeNpcs.Name = "lblRandomizeNpcs";
            this.lblRandomizeNpcs.Size = new System.Drawing.Size(144, 18);
            this.lblRandomizeNpcs.TabIndex = 3;
            this.lblRandomizeNpcs.Text = "Randomize NPCs";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(141, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(510, 126);
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // rbNpcsYes
            // 
            this.rbNpcsYes.AutoSize = true;
            this.rbNpcsYes.Location = new System.Drawing.Point(17, 23);
            this.rbNpcsYes.Name = "rbNpcsYes";
            this.rbNpcsYes.Size = new System.Drawing.Size(42, 19);
            this.rbNpcsYes.TabIndex = 5;
            this.rbNpcsYes.Text = "Yes";
            this.rbNpcsYes.UseVisualStyleBackColor = true;
            this.rbNpcsYes.CheckedChanged += new System.EventHandler(this.rbNpcsYes_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNpcsNo);
            this.groupBox1.Controls.Add(this.rbNpcsYes);
            this.groupBox1.Location = new System.Drawing.Point(21, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 53);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rbNpcsNo
            // 
            this.rbNpcsNo.AutoSize = true;
            this.rbNpcsNo.Location = new System.Drawing.Point(65, 23);
            this.rbNpcsNo.Name = "rbNpcsNo";
            this.rbNpcsNo.Size = new System.Drawing.Size(41, 19);
            this.rbNpcsNo.TabIndex = 6;
            this.rbNpcsNo.Text = "No";
            this.rbNpcsNo.UseVisualStyleBackColor = true;
            this.rbNpcsNo.CheckedChanged += new System.EventHandler(this.rbNpcsNo_CheckedChanged);
            // 
            // cbxExcludeNonAttackables
            // 
            this.cbxExcludeNonAttackables.AutoSize = true;
            this.cbxExcludeNonAttackables.Enabled = false;
            this.cbxExcludeNonAttackables.Location = new System.Drawing.Point(38, 306);
            this.cbxExcludeNonAttackables.Name = "cbxExcludeNonAttackables";
            this.cbxExcludeNonAttackables.Size = new System.Drawing.Size(159, 19);
            this.cbxExcludeNonAttackables.TabIndex = 7;
            this.cbxExcludeNonAttackables.Text = "Exclude Non-Attackables";
            this.cbxExcludeNonAttackables.UseVisualStyleBackColor = true;
            this.cbxExcludeNonAttackables.CheckedChanged += new System.EventHandler(this.cbxExcludeNonAttackables_CheckedChanged);
            // 
            // cbxExcludeAttackableQuestNpcs
            // 
            this.cbxExcludeAttackableQuestNpcs.AutoSize = true;
            this.cbxExcludeAttackableQuestNpcs.Enabled = false;
            this.cbxExcludeAttackableQuestNpcs.Location = new System.Drawing.Point(38, 332);
            this.cbxExcludeAttackableQuestNpcs.Name = "cbxExcludeAttackableQuestNpcs";
            this.cbxExcludeAttackableQuestNpcs.Size = new System.Drawing.Size(192, 19);
            this.cbxExcludeAttackableQuestNpcs.TabIndex = 8;
            this.cbxExcludeAttackableQuestNpcs.Text = "Exclude Attackable Quest NPCs";
            this.cbxExcludeAttackableQuestNpcs.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbNpcsGrouplyByLocation);
            this.groupBox2.Controls.Add(this.rbNpcsGrouply);
            this.groupBox2.Controls.Add(this.rbNpcsSingularly);
            this.groupBox2.Location = new System.Drawing.Point(21, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 52);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // rbNpcsGrouplyByLocation
            // 
            this.rbNpcsGrouplyByLocation.AutoSize = true;
            this.rbNpcsGrouplyByLocation.Enabled = false;
            this.rbNpcsGrouplyByLocation.Location = new System.Drawing.Point(173, 19);
            this.rbNpcsGrouplyByLocation.Name = "rbNpcsGrouplyByLocation";
            this.rbNpcsGrouplyByLocation.Size = new System.Drawing.Size(132, 19);
            this.rbNpcsGrouplyByLocation.TabIndex = 2;
            this.rbNpcsGrouplyByLocation.TabStop = true;
            this.rbNpcsGrouplyByLocation.Text = "Grouply by Location";
            this.rbNpcsGrouplyByLocation.UseVisualStyleBackColor = true;
            this.rbNpcsGrouplyByLocation.CheckedChanged += new System.EventHandler(this.rbNpcsGrouplyByLocation_CheckedChanged);
            // 
            // rbNpcsGrouply
            // 
            this.rbNpcsGrouply.AutoSize = true;
            this.rbNpcsGrouply.Enabled = false;
            this.rbNpcsGrouply.Location = new System.Drawing.Point(100, 19);
            this.rbNpcsGrouply.Name = "rbNpcsGrouply";
            this.rbNpcsGrouply.Size = new System.Drawing.Size(67, 19);
            this.rbNpcsGrouply.TabIndex = 1;
            this.rbNpcsGrouply.TabStop = true;
            this.rbNpcsGrouply.Text = "Grouply";
            this.rbNpcsGrouply.UseVisualStyleBackColor = true;
            this.rbNpcsGrouply.CheckedChanged += new System.EventHandler(this.rbNpcsGrouply_CheckedChanged);
            // 
            // rbNpcsSingularly
            // 
            this.rbNpcsSingularly.AutoSize = true;
            this.rbNpcsSingularly.Enabled = false;
            this.rbNpcsSingularly.Location = new System.Drawing.Point(17, 19);
            this.rbNpcsSingularly.Name = "rbNpcsSingularly";
            this.rbNpcsSingularly.Size = new System.Drawing.Size(77, 19);
            this.rbNpcsSingularly.TabIndex = 0;
            this.rbNpcsSingularly.TabStop = true;
            this.rbNpcsSingularly.Text = "Singularly";
            this.rbNpcsSingularly.UseVisualStyleBackColor = true;
            this.rbNpcsSingularly.CheckedChanged += new System.EventHandler(this.rbNpcsSingularly_CheckedChanged);
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(397, 228);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(379, 156);
            this.pbPreview.TabIndex = 10;
            this.pbPreview.TabStop = false;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(397, 165);
            this.lblPreview.MaximumSize = new System.Drawing.Size(379, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(182, 15);
            this.lblPreview.TabIndex = 11;
            this.lblPreview.Text = "Select an option to see a preview.";
            // 
            // Randomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbxExcludeAttackableQuestNpcs);
            this.Controls.Add(this.cbxExcludeNonAttackables);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblRandomizeNpcs);
            this.Name = "Randomizer";
            this.Text = "Randomizer";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRandomizeNpcs;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.RadioButton rbNpcsYes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNpcsNo;
        private System.Windows.Forms.CheckBox cbxExcludeNonAttackables;
        private System.Windows.Forms.CheckBox cbxExcludeAttackableQuestNpcs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbNpcsGrouplyByLocation;
        private System.Windows.Forms.RadioButton rbNpcsGrouply;
        private System.Windows.Forms.RadioButton rbNpcsSingularly;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Label lblPreview;
    }
}