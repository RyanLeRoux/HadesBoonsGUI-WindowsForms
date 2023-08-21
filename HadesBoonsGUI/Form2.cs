using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace HadesBoonsGUI
{
    public partial class Form2 : Form
    {
        readonly List<Gods> GodList = Gods.GodListMethod();
        readonly List<Weapons> WeaponList = Weapons.WeaponsListMethod();
        private Weapons selectedWeapon = null;
        private Gods selectedGod;
        public List<Gods> GodSpells = new List<Gods>()
        {
            null, null, null, null, null, null
        };

        public Form2()
        {
            InitializeComponent();
            PopulateSkillComboBox();
            PopulateWeaponComboBox();
            
        }

        private void DuoCheck()
        {
            /*
                Takes all chosen skills and shows in
                textBox2 all possible duo skills
                that can be obtained
            */

            List<string> strList = new List<string>();

            for (int i = 0; i < GodSpells.Count - 1; i++)
            {
                if (GodSpells[i] == null) { continue; }
                Gods god = GodSpells[i];
                for (int j = i + 1; j < GodSpells.Count; j++)
                {
                    if (GodSpells[j] == null) { continue; }
                    Gods itgod = GodSpells[j];
                    if (god == itgod) { continue; }
                    if (god.Duos[itgod.Index][i] && itgod.Duos[god.Index][j])
                    {
                        string str;
                        if (god.Index < itgod.Index)
                        { 
                            str = $"{god.Name} - {itgod.Name}";
                            if (!strList.Contains(str)) { strList.Add(str); }
                            str = $"{god.DuoName[itgod.Index]}";
                            if (!strList.Contains(str)) { strList.Add(str); }
                        }
                        else
                        { 
                            str = $"{itgod.Name} - {god.Name}";
                            if (!strList.Contains(str)) { strList.Add(str); }
                            str = $"{itgod.DuoName[god.Index]}";
                            if (!strList.Contains(str)) { strList.Add(str); }
                        }
                    }
                }
            }

            textBox2.Clear();
            // Take list and print each element on new line in textBox
            textBox2.AppendText(string.Join(Environment.NewLine, strList));
        }

        // SKILLS

        private void SkillImageControl(int i, Gods selectedGod)
        {
            /*
             * Populates picture boxes next to drop down menus
             */
            List<PictureBox> skillpBoxes = new List<PictureBox>()
            {
                pictureBox1, pictureBox2, pictureBox3, 
                pictureBox4, pictureBox5, pictureBox6
            };
            skillpBoxes[i].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(
                selectedGod.Name + "_" + selectedGod.SkillNames[i]);
        }

        private void PopulateSkillComboBox()
        {
            // Fills all comboBoxes with name of God spells
            // TODO: Add unique cast names for Beowulf
            List<ComboBox> comboBoxSkills = new List<ComboBox>()
            {
                comboBoxAttack, comboBoxSpecial, comboBoxCast, 
                comboBoxDash, comboBoxWraith, comboBoxRevenge
            };

            for (int i = 0; i < comboBoxSkills.Count; i++)
            {
                comboBoxSkills[i].Items.Clear();
                foreach (var god in GodList)
                {
                    if (god.Skills[i] == "") { continue; }
                    comboBoxSkills[i].Items.Add(god.Skills[i]);
                }
                comboBoxSkills[i].SelectedIndex = -1;
            }

        }

        private void comboBoxAttack_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex;

            selectedGod = GodList[selectedIndex];
            GodSpells[0] = selectedGod;
            ChosenSkillSet(selectedGod, 0);
            //textBox2.Text = string.Join("\r\n ", GodSpells); //textBox2.Text = GodList[selectedIndex].Name;;

            DuoCheck();
            SkillImageControl(0, selectedGod);
        }

        private void comboBoxSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex;

            selectedGod = GodList[selectedIndex];
            GodSpells[1] = selectedGod;
            ChosenSkillSet(selectedGod, 1);

            DuoCheck();
            SkillImageControl(1, selectedGod);
        }

        private void comboBoxCast_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex;

            selectedGod = GodList[selectedIndex];
            GodSpells[2] = selectedGod;
            ChosenSkillSet(selectedGod, 2);

            DuoCheck();
            SkillImageControl(2, selectedGod);
        }

        private void comboBoxDash_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex;

            selectedGod = GodList[selectedIndex];
            GodSpells[3] = selectedGod;
            ChosenSkillSet(selectedGod, 3);

            DuoCheck();
            SkillImageControl(3, selectedGod);
        }

        private void comboBoxWraith_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex;

            selectedGod = GodList[selectedIndex];
            GodSpells[4] = GodList[selectedIndex];
            ChosenSkillSet(selectedGod, 4);

            DuoCheck();
            SkillImageControl(4, selectedGod);
        }

        private void comboBoxRevenge_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var selectedValue = comboBox.SelectedItem;

            foreach (var gods in GodList)
            {
                if (gods.Skills[5] == selectedValue.ToString())
                {
                    selectedGod = gods;
                    break;
                }
            }

            if (selectedGod != null)
            {
                textBox2.Text = selectedGod.Name;
                GodSpells[5] = selectedGod;
                ChosenSkillSet(selectedGod, 5);

                DuoCheck();
                SkillImageControl(5, selectedGod);
            }

            PopluatecheckedListBox1();

        }

        private void ChosenSkillSet(Gods selectedGod, int i)
        {
            /* 
             * Changes the ChosenSkills attribute for Gods
             * Resets not selected Gods ChosenSkills to false
             */
            foreach (Gods god in GodList)
            {
                if (selectedGod != god)
                {
                    god.ChosenSkills[i] = false;
                }
            }
            selectedGod.ChosenSkills[i] = true;
        }

        private void PopluatecheckedListBox1()
        {
            checkedListBox1.Items.Clear();
            if (selectedGod != null)
            {
                foreach (var LegPreq in selectedGod.LegPreqs)
                {
                    checkedListBox1.Items.Add(LegPreq);
                }
            }
            
        }

        // WEAPONS
        private void PopulateWeaponComboBox()
        {
            comboBoxWeapon.Items.Clear();

            foreach (Weapons weapon in WeaponList)
            {
                comboBoxWeapon.Items.Add(weapon.Name);
            }

            comboBoxWeapon.SelectedIndex = -1;

        }

        private void comboBoxWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            selectedWeapon = WeaponList[selectedIndex];

            textBox1.Text = selectedIndex.ToString();

            comboBoxAspect.Items.Clear();

            foreach (var aspect in WeaponList[selectedIndex].Aspect)
            {
                comboBoxAspect.Items.Add(aspect);
            }

            comboBoxAspect.SelectedIndex = -1;

            // Reset Skill selections
            /*textBox2.Clear();
            for (int i = 0; i < GodSpells.Count; i++)
            { GodSpells[i] = null; }
            PopulateSkillComboBox();
            BeoWulfCastFix();
            */
        }

        private void comboBoxAspect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset Skill selections
            //textBox2.Clear();
            //for (int i = 0; i < GodSpells.Count; i++)
            //{ GodSpells[i] = null; }
            //PopulateSkillComboBox();
            GodSpells[2] = null;
            DuoCheck();
            BeoWulfCastFix();
        }

        private void WeaponImageControl()
        {
            List<PictureBox> weaponpBoxes = new List<PictureBox>()
            {
                pictureBox7, pictureBox8
            };
        }

        private void BeoWulfCastFix()
        {
            List<string> BeowulfCasts = new List<string>()
            {
                "Passion Flare", "Slicing Flare", "Hunter's Flare",
                "Phalanx Flare", "Icy Flare", "Trippy Flare",
                "Flood Flare", "Thunder Flare"
            };
            if (selectedWeapon == WeaponList[2] && selectedWeapon.Aspect[3] == "Beowulf")
            {
                comboBoxCast.Items.Clear();
                foreach (var item in BeowulfCasts)
                {
                    comboBoxCast.Items.Add(item);
                }
                pictureBox3.Image = null;
            }

        }

    }
}
