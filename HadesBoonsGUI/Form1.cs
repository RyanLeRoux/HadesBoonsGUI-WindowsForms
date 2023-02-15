using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Windows.Forms.DataVisualization.Charting;


namespace HadesBoonsGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ButtonControl();
        }

        private void ButtonControl()
        {
            AphroditeButton.Click += ButtonClick;
            AresButton.Click += ButtonClick;
            ArtemisButton.Click += ButtonClick;
            AthenaButton.Click += ButtonClick;
            DemeterButton.Click += ButtonClick;
            DionysusButton.Click += ButtonClick;
            PoseidonButton.Click += ButtonClick;
            ZeusButton.Click += ButtonClick;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            List<Gods> GodList = Gods.GodListMethod();
            Button button = sender as Button;
            int inp = button.TabIndex - 1;

            // Control the group box names
            TxtControl(GodList, inp);
            GrpBoxControl(GodList, inp);

            // Control the images displayed
            ImageControl(GodList, button, inp);

            // Graph Control
            SkillFrequencyPlot(GodList, inp);           
        }

        private void SkillFrequencyPlot(List<Gods> GodList, int inp)
        {
            Gods God = GodList[inp]; // Selected god
            int[] counts = SkillFrequencyCounts(GodList, inp);

            DuoLegChart.Series["SkillFrequency"].Points.Clear();
            for (int i = 0; i < God.SkillNames.Length; i++)
            {
                DuoLegChart.Series["SkillFrequency"].Points.AddXY(God.SkillNames[i], counts[i]);
                God.LegFrequencyColor(i, DuoLegChart);
            }
        }

        private int[] SkillFrequencyCounts(List<Gods> GodList, int inp)
        {
            Gods God = GodList[inp]; // Selected god
            int[] counts = new int[God.PlainSkills.Length];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = God.SkillFrequencyCount(i);
            }
            return counts;
        }

        private void ImageControl(List<Gods> GodList, Button button, int inp)
        {
            // Smaller icons for Gods
            List<Gods> unselectedGods = UnselectedGods(GodList, inp);
            List<PictureBox> smallpBoxes = new List<PictureBox>()
            {
                smallpBox1, smallpBox2, smallpBox3, smallpBox4, smallpBox5, smallpBox6, smallpBox7
            };
            for (int i = 0; i < smallpBoxes.Count; i++)
            {
                smallpBoxes[i].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(unselectedGods[i].Name + "_symbol");
            }

            // Main God Portrait
            pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(button.Text);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void GrpBoxControl(List<Gods> GodList, int inp)
        {
            List<GroupBox> grpBoxes = new List<GroupBox>()
            {
                grpBox1, grpBox2, grpBox3, grpBox4, grpBox5, grpBox6, grpBox7
            };
            for (int i = 0; i < grpBoxes.Count; i++)
            {
                grpBoxes[i].Text = GroupHeaderName(inp, GodList)[i];
            }
        }

        private void TxtControl(List<Gods> GodList, int inp)
        {
            List<TextBox> txtBoxes = new List<TextBox>()
            {
                txtBox1, txtBox2, txtBox3, txtBox4, txtBox5, txtBox6, txtBox7
            };
            
            for (int i = 0; i < txtBoxes.Count; i++)
            {
                txtBoxes[i].Text = GodStringOutput(inp, GodList)[i];
            }

            txtBoxPrereq.Text = String.Join(Environment.NewLine, GodList[inp].LegPreqs);
        }

        private static List<Gods> UnselectedGods(List<Gods> GodList, int inp)
        {
            List<Gods> unselectedGods = new List<Gods>();
            for (int i = 0; i < GodList.Count; i++)
            {
                if (inp != i)
                {
                    unselectedGods.Add(GodList[i]);
                }
            }

            return unselectedGods;
        }

        private string[] GroupHeaderName(int inp, List<Gods> GodList)
        {
            List<string> stringList = new List<string>();
            Gods God = GodList[inp]; // Selected god
            for (int i = 0; i < GodList.Count; i++)
            {
                Gods itGod = GodList[i]; // Iterate over other gods
                if (God.GodDuoNull(i)) //(God.Duos[i] != null)
                {
                    stringList.Add(God.Name + " - " + itGod.Name);
                }
            }
            return stringList.ToArray();
        }

        private string[] GodStringOutput(int inp, List<Gods> GodList)
        {
            List<string> stringsList1 = new List<string>();
            List<string> stringsList2 = new List<string>();
            Gods God = GodList[inp]; // Selected god
            for (int i = 0; i < GodList.Count; i++)
            {
                stringsList1.Clear();
                Gods itGod = GodList[i]; // Iterate over other gods
                if (God.GodDuoNull(i))//(God.Duos[i] != null)
                {
                    //stringsList1.Add(God.Name + " - " + itGod.Name);
                    stringsList1.AddRange(ComboSkills(inp, God, i, itGod));
                    stringsList2.Add(String.Join(Environment.NewLine, stringsList1.ToArray()));
                }
            }
            string[] stringArray = stringsList2.ToArray();
            return stringArray;
        }

        private static List<string> ComboSkills(int inp, Gods God, int i, Gods itGod)
        {
            List<string> stringsList = new List<string>();
            for (int j = 0; j < God.Duos[i].Length; j++)
            {
                stringsList.Add(
                    $"{God.DuoSkillComb(i, j)} (" +
                    $"{God.DuoLegComb(j)}) - " +
                    $"{itGod.DuoSkillComb(inp, j)} (" +  // Prints the skills that are required by both Gods 
                    $"{itGod.DuoLegComb(j)})");          // Checks What skills are legendary prerequisate for the other gods
            }
            return stringsList;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
