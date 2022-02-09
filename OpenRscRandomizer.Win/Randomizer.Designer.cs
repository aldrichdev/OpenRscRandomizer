
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
            this.cbxRandomizeNpcs = new System.Windows.Forms.CheckBox();
            this.cbxRandomizeNpcGrouply = new System.Windows.Forms.CheckBox();
            this.cbxRandomizeNpcsSingularly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbxRandomizeNpcs
            // 
            this.cbxRandomizeNpcs.AutoSize = true;
            this.cbxRandomizeNpcs.Enabled = false;
            this.cbxRandomizeNpcs.Location = new System.Drawing.Point(52, 77);
            this.cbxRandomizeNpcs.Name = "cbxRandomizeNpcs";
            this.cbxRandomizeNpcs.Size = new System.Drawing.Size(117, 19);
            this.cbxRandomizeNpcs.TabIndex = 0;
            this.cbxRandomizeNpcs.Text = "Randomize NPCs";
            this.cbxRandomizeNpcs.UseVisualStyleBackColor = true;
            // 
            // cbxRandomizeNpcGrouply
            // 
            this.cbxRandomizeNpcGrouply.AutoSize = true;
            this.cbxRandomizeNpcGrouply.Location = new System.Drawing.Point(84, 103);
            this.cbxRandomizeNpcGrouply.Name = "cbxRandomizeNpcGrouply";
            this.cbxRandomizeNpcGrouply.Size = new System.Drawing.Size(130, 19);
            this.cbxRandomizeNpcGrouply.TabIndex = 1;
            this.cbxRandomizeNpcGrouply.Text = "Randomize Grouply";
            this.cbxRandomizeNpcGrouply.UseVisualStyleBackColor = true;
            // 
            // cbxRandomizeNpcsSingularly
            // 
            this.cbxRandomizeNpcsSingularly.AutoSize = true;
            this.cbxRandomizeNpcsSingularly.Location = new System.Drawing.Point(84, 129);
            this.cbxRandomizeNpcsSingularly.Name = "cbxRandomizeNpcsSingularly";
            this.cbxRandomizeNpcsSingularly.Size = new System.Drawing.Size(140, 19);
            this.cbxRandomizeNpcsSingularly.TabIndex = 2;
            this.cbxRandomizeNpcsSingularly.Text = "Randomize Singularly";
            this.cbxRandomizeNpcsSingularly.UseVisualStyleBackColor = true;
            // 
            // Randomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxRandomizeNpcsSingularly);
            this.Controls.Add(this.cbxRandomizeNpcGrouply);
            this.Controls.Add(this.cbxRandomizeNpcs);
            this.Name = "Randomizer";
            this.Text = "Randomizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxRandomizeNpcs;
        private System.Windows.Forms.CheckBox cbxRandomizeNpcGrouply;
        private System.Windows.Forms.CheckBox cbxRandomizeNpcsSingularly;
    }
}