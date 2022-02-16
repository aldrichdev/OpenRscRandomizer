using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenRscRandomizer.Win
{
    public partial class Randomizer : Form
    {
        public Randomizer()
        {
            InitializeComponent();
        }

        private void rbNpcsYes_CheckedChanged(object sender, EventArgs e)
        {
            // Update preview image and description
            
            // If "Yes" is the only box/setting checked:
            if (!rbNpcsSingularly.Checked && !rbNpcsGrouply.Checked && !rbNpcsGrouplyByLocation.Checked &&
                !cbxExcludeNonAttackables.Checked && !cbxExcludeAttackableQuestNpcs.Checked)
            {
                lblPreview.Text = "Random NPC locations!";
                pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Yes;
                rbNpcsSingularly.Checked = true;
            }

            // Enable all NPC-specific controls
            rbNpcsSingularly.Enabled = true;
            rbNpcsGrouply.Enabled = true;
            rbNpcsGrouplyByLocation.Enabled = true;
            cbxExcludeNonAttackables.Enabled = true;
            cbxExcludeAttackableQuestNpcs.Enabled = true;
        }

        private void rbNpcsNo_CheckedChanged(object sender, EventArgs e)
        {
            // Update previews
            lblPreview.Text = "NPC locations will not be randomized.";
            pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_No;

            // Disable all NPC-specific controls
            rbNpcsSingularly.Enabled = false;
            rbNpcsGrouply.Enabled = false;
            rbNpcsGrouplyByLocation.Enabled = false;
            cbxExcludeNonAttackables.Enabled = false;
            cbxExcludeAttackableQuestNpcs.Enabled = false;
        }

        private void rbNpcsSingularly_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: Add exclude checkbox checks here and customize text
            lblPreview.Text = "NPCs will be randomized one by one. Imagine the Lumbridge cow field with knights, dragons and rats!";
            pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Yes;
        }

        private void rbNpcsGrouply_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: Add exclude checkbox checks here and customize text
            lblPreview.Text = "NPCs are randomized in groups. For example, all chickens could become red dragons, all bankers could become cows.";
            pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply;
        }

        private void rbNpcsGrouplyByLocation_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: Add exclude checkbox checks here and customize text
            lblPreview.Text = "NPCs are randomized in groups by location (coming soon). For example, the chickens in the NW Lumbridge pen could become muggers, but the chickens in the NE pen could become white knights.";
            pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_By_Location;
        }

        private void cbxExcludeNonAttackables_CheckedChanged(object sender, EventArgs e)
        {
            lblPreview.Text = "Non-attackable NPCs like bankers, shopkeepers, and quest NPCs will not be randomized.";

            if (rbNpcsSingularly.Checked)
            {
                // Show a screenshot of all npcs except non-attackables being rando'd   
            } else if (rbNpcsGrouply.Checked)
            {
                // use your existing stream seed
            } else if (rbNpcsGrouplyByLocation.Checked)
            {
                // Same for grouply location
            }


        }
    }
}
