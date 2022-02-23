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
        
        /* NOTE: Log in as MakeMeAdmin to teleport around. ("core" repo) */
        /* TODO List.
            1. Fix bug where clicking Yes with options selected does not change the text. 
                (Maybe reset all options when clicking no).
            2. Add Items and Scenery sections
                Items will have yes/no and also a checkbox to exclude quest items.
                Scenery will have yes/no and 3 rando options: 1) Singularly, 2) Grouply (by id), and 3) Smart Grouply 
                    (only place fishing spots where old fishing spots were, only place mining rocks where old ones were, etc)
        */

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

            // Reset all values to defaults.
            rbNpcsSingularly.Checked = false;
            rbNpcsGrouply.Checked = false;
            rbNpcsGrouplyByLocation.Checked = false;
            cbxExcludeNonAttackables.Checked = false;
            cbxExcludeAttackableQuestNpcs.Checked = false;
        }

        private void rbNpcsSingularly_CheckedChanged(object sender, EventArgs e)
        {
            var thisRadioButton = sender as RadioButton;
            if (thisRadioButton != null && thisRadioButton.Checked)
            {
                if (cbxExcludeNonAttackables.Checked)
                {
                    lblPreview.Text = "NPCs will be randomized one by one, excluding non-attackables. I.E. Falador chicken pen now contains greater demons, Death Wings and Bouncer, but bankers and shopkeepers stay where they are.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Non_Attackables;

                    if (cbxExcludeAttackableQuestNpcs.Checked)
                    {
                        lblPreview.Text = "NPCs will be randomized one by one, excluding non-attackables and attackable quest NPCs. I.E. Lumbridge cow pen now has muggers, thieves and dungeon rats, but bankers and Delrith stay where they are.";
                        pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Attackable_Quest_Npcs;
                    }
                }
                else if (cbxExcludeAttackableQuestNpcs.Checked)
                {
                    lblPreview.Text = "NPCs will be randomized one by one, excluding attackable quest NPCs. So Delrith will stay at the Chaos Druid circle, for example.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Attackable_Quest_Npcs;
                }
                else
                {
                    lblPreview.Text = "NPCs will be randomized one by one. Imagine the Lumbridge cow field with bankers, dragons and rats!";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Yes;
                }
            }
        }

        private void rbNpcsGrouply_CheckedChanged(object sender, EventArgs e)
        {
            var thisRadioButton = sender as RadioButton;
            if (thisRadioButton != null && thisRadioButton.Checked)
            {
                if (cbxExcludeNonAttackables.Checked)
                {
                    lblPreview.Text = "NPCs are randomized in groups, excluding non-attackables. I.E. Falador chicken pen now contains muggers, but bankers and shopkeepers stay where they are.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Non_Attackables;

                    if (cbxExcludeAttackableQuestNpcs.Checked)
                    {
                        lblPreview.Text = "NPCs are randomized in groups, excluding non-attackables and attackable quest NPCs. I.E. Lumbridge cow pen is now filled with guard dogs, bankers and Delrith stay where they are.";
                        pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Attackable_Quest_Npcs;
                    }
                }
                else if (cbxExcludeAttackableQuestNpcs.Checked)
                {
                    lblPreview.Text = "NPCs are randomized in groups, excluding attackable quest NPCs. I.E. Lumbridge goblin house now features Al Kharid warriors, but attackable quest NPCs (i.e. Delrith) stay where they are.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Attackable_Quest_Npcs;
                }
                else
                {
                    lblPreview.Text = "NPCs are randomized in groups. For example, all chickens could become red dragons, all bankers could become cows.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply;
                }
            }
        }

        private void rbNpcsGrouplyByLocation_CheckedChanged(object sender, EventArgs e)
        {
            var thisRadioButton = sender as RadioButton;
            if (thisRadioButton != null && thisRadioButton.Checked)
            {
                if (cbxExcludeNonAttackables.Checked)
                {
                    lblPreview.Text = "NPCs are randomized in groups by location (coming soon), excluding non-attackables. I.E. Falador chicken pen now contains muggers, but bankers and shopkeepers stay where they are.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Non_Attackables;

                    if (cbxExcludeAttackableQuestNpcs.Checked)
                    {
                        lblPreview.Text = "NPCs are randomized in groups, excluding non-attackables and attackable quest NPCs. I.E. Lumbridge cow pen is now filled with guard dogs, bankers and other non-attackables stay where they are, and attackable quest NPCs (i.e. Delrith) stay where they are.";
                        pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Attackable_Quest_Npcs;
                    }
                }
                else if (cbxExcludeAttackableQuestNpcs.Checked)
                {
                    lblPreview.Text = "NPCs are randomized in groups by location (coming soon), excluding attackable quest NPCs. I.E. Lumbridge goblin house now features Al Kharid warriors, but attackable quest NPCs (i.e. Delrith) stay where they are.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Attackable_Quest_Npcs;
                }
                else
                {
                    lblPreview.Text = "NPCs are randomized in groups by location (coming soon). For example, the chickens in the NW Lumbridge pen could become muggers, but the chickens in the NE pen could become white knights.";
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_By_Location;
                }
            }
        }

        private void cbxExcludeNonAttackables_CheckedChanged(object sender, EventArgs e)
        {
            var thisCheckbox = sender as CheckBox;
            if (thisCheckbox.Checked)
            {
                lblPreview.Text = "Non-attackable NPCs like bankers, shopkeepers, and quest NPCs will not be randomized.";
                
                if (rbNpcsSingularly.Checked)
                {
                    // Show a screenshot of all npcs except non-attackables being rando'd
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.
                        Resources.Npcs_Singularly_Exclude_Non_Attackables_Only;
                }
                else if (rbNpcsGrouply.Checked || rbNpcsGrouplyByLocation.Checked)
                {
                    // use your existing stream seed
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Non_Attackables;
                }
            }
            else
            {
                lblPreview.Text = "We will randomize non-attackable NPCs like bankers, shopkeepers, and quest NPCs.";

                if (rbNpcsSingularly.Checked)
                {
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.
                        Resources.Npcs_Yes;
                }
                else if (rbNpcsGrouply.Checked || rbNpcsGrouplyByLocation.Checked)
                {
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply;
                }
            }
        }

        private void cbxExcludeAttackableQuestNpcs_CheckedChanged(object sender, EventArgs e)
        {
            var thisCheckbox = sender as CheckBox;
            if (thisCheckbox.Checked)
            {
                lblPreview.Text = "Attackable quest NPCs like Delrith, Nezikchened, and others will not be randomized.";
                
                if (rbNpcsSingularly.Checked)
                {
                    if (cbxExcludeNonAttackables.Checked)
                    {
                        // Show a screenshot of all npcs except quest attackables and non-attackables being rando'd
                        pbPreview.Image = OpenRscRandomizer.Win.Properties.
                            Resources.Npcs_Singularly_Exclude_Attackable_Quest_Npcs_Exclude_Non_Attackables;
                    }
                    else
                    {
                        // TODO if they select singularly and check only this box it shows a moss giant, why???
                        // Show a screenshot of all npcs except quest attackables being rando'd
                        pbPreview.Image = OpenRscRandomizer.Win.Properties.
                            Resources.Npcs_Singularly_Exclude_Attackable_Quest_Npcs_Dont_Exclude_Non_Attackables_1;
                    }

                }
                else if (rbNpcsGrouply.Checked || rbNpcsGrouplyByLocation.Checked)
                {
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_Exclude_Attackable_Quest_Npcs;
                }
            }
            else
            {
                lblPreview.Text = "We will randomize attackable quest NPCs like Delrith, Nezikchened, and others.";

                if (rbNpcsSingularly.Checked)
                {
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Yes;
                }
                else if (rbNpcsGrouply.Checked)
                {
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply;
                }
                else if (rbNpcsGrouplyByLocation.Checked)
                {
                    pbPreview.Image = OpenRscRandomizer.Win.Properties.Resources.Npcs_Grouply_By_Location;
                }
            }
        }
    }
}
