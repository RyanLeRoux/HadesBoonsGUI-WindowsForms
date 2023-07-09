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
        public Form2()
        {
            InitializeComponent();
            PopulateWeaponComboBox();
            PopulateSkillComboBox();
        }

        // List<Gods> GodList = Gods.GodListMethod();
        private void PopulateAttackComboBox()
        {
            // Clear the combo box
            comboBoxAttack.Items.Clear();

            List<Gods> GodList = Gods.GodListMethod();
            // Iterate over each object in GodsList and add the first skill to the combo box
            foreach (Gods god in GodList)
            {
                comboBoxAttack.Items.Add(god.Skills[0]);
            }

            comboBoxAttack.SelectedIndex = -1;
        }

        private void PopulateWeaponComboBox()
        {
            comboBoxWeapon.Items.Clear();

            List<Weapons> WeaponList = Weapons.WeaponsListMethod();
            foreach (Weapons weapon in WeaponList)
            {
                comboBoxWeapon.Items.Add(weapon.Name);
            } 

            comboBoxWeapon.SelectedIndex = -1;
        }

        private void PopulateSkillComboBox()
        {
            List<Gods> GodList = Gods.GodListMethod();
            List<ComboBox> comboBoxes = new List<ComboBox>()
            {
                comboBoxAttack, comboBoxSpecial, comboBoxCast, comboBoxDash, comboBoxWraith, comboBoxRevenge
            };

            for (int i = 0; i < comboBoxes.Count; i++)
            {
                comboBoxes[i].Items.Clear();

                foreach (Gods god in GodList)
                {
                    // Skip over skills that are not present
                    if (god.Skills[i] == "")
                    {
                        continue;
                    }
                    comboBoxes[i].Items.Add(god.Skills[i]);
                }

                comboBoxes[i].SelectedIndex = -1;
            }



        }

        private void comboBoxWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;

            textBox1.Text = selectedIndex.ToString();

            comboBoxAspect.Items.Clear();

            List<Weapons> WeaponList = Weapons.WeaponsListMethod();
            foreach (var aspect in WeaponList[selectedIndex].Aspect)
            {
                comboBoxAspect.Items.Add(aspect);
            }
            

            comboBoxAspect.SelectedIndex = -1;
        }
    }
}
