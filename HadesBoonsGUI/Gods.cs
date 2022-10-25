using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace HadesBoonsGUI
{
    internal class Gods
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public string[] Skills { get; set; }
        public bool[][] Duos { get; set; }
        public bool[] Legendary { get; set; }
        public bool CanGetLegendary { get; set; } // Checks whether God is able to get a legendary
        public string[] LegPreqs { get; set; }
        public string[] PlainSkills
        {
            get
            {
                string[] strings = new string[6] { "A", "S", "C", "D", "W", "R" };
                return strings;
            }
        }
        public string[] SkillNames
        {
            get
            {
                string[] strings = new string[6] { "Attack", "Special", "Cast", "Dash", "Wraith", "Revenge" };
                return strings;
            }
        }
        

        public Gods(
            string name,
            int index,
            string[] skills,
            bool[][] duos,
            bool[] legendary,
            string[] legPreqs)
        {
            Name = name;
            Index = index;
            Skills = skills;
            Duos = duos;
            Legendary = legendary;
            LegPreqs = legPreqs;
        }

        public string DuoSkillComb(int i, int j)
        {
            return Basics.StringBoolComb(this.Duos[i][j], this.PlainSkills[j]);
        }

        public string DuoLegComb(int i) // Duo Legendary Combo
        {
            return Basics.StringBoolComb(this.Legendary[i], this.PlainSkills[i]); ;
        }

        public bool GodDuoNull(int i)
        {
            if (this.Duos[i] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int SkillFrequencyCount(int skill)
        {
            int count = 0;
            for (int i = 0; i < this.Duos.Length; i++)
            {
                if (this.GodDuoNull(i))
                {
                    if (this.Duos[i][skill])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void LegFrequencyColor(int i, Chart chart)
        {
            if (this.Legendary[i])
            {
                chart.Series["SkillFrequency"].Points[i].Color = Color.Orange;
            }
        }

        // Messing around:

        public void SkillList() // Prints the skills and skill names of a God
        {
            IEnumerable<string> Skills_plainSkills = PlainSkills.Zip(Skills, (first, second) => first + " - " + second);
            foreach (string Skill in Skills_plainSkills)
            {
                Console.WriteLine(Skill);
            }
            Console.ReadLine();
        }
    }
}
