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
        public string Name { get; }
        public int Index { get; }
        public string[] Skills { get; }
        public bool[][] Duos { get; }
        public bool[] Legendary { get; }
        public bool CanGetLegendary { get; set;  } // Checks whether God is able to get a legendary
        public string[] LegPreqs { get; }
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

        public static List<Gods> GodListMethod()
        {
            List<Gods> GodList = new List<Gods>
            {
                // Aphropdite
                new Gods(
                    "Aphrodite", 0,
                    new string[6]
                    {
                        "Heartbreak Strike",
                        "Heartbreak Flourish",
                        "Crush Shot",
                        "Passion Dance",
                        "Aphrodite's Aid",
                        "Wave of Despair"
                    },
                    new bool[][]
                    {
                        null,                                                    // self
                        new bool[] { true, true, true, true, false, false },     // Ares
                        new bool[] { true, true, true, true, false, false },     // Artemis
                        new bool[] { true, true, true, true, true, false },      // Athena
                        new bool[] { true, true, false, true, true, false },     // Demeter
                        new bool[] { true, true, true, true, false, false },     // Dionysus
                        new bool[] { true, true, true, true, true, false },      // Poseidon
                        new bool[] { true, true, true, true, true, false }       // Zeus
                    },
                    new bool[6]
                    {
                        true, true, true, true, false, false
                    },
                    new string[3]
                    {
                        "Empty Inside",
                        "Sweet Surrender",
                        "Broken Resolve"
                    }),

                // Ares
                new Gods(
                    "Ares", 1,
                    new string[6]
                    {
                       "Curse of Agony",
                       "Curse of Pain",
                       "Slicing Shot",
                       "Blade Dash",
                       "Ares' Aid",
                       "Curse of Vengeance"
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, false, false, false, false },    // Aphrodite
                        null,                                                     // Self
                        new bool[] { false, false, true, false, false, false },   // Artemis
                        new bool[] { true, true, false, false, false, false },    // Athena
                        new bool[] { false, false, true, false, false, false },   // Demeter
                        new bool[] { true, true, false, false, false, true },     // Dionysus
                        new bool[] { true, true, false, true, true, false },      // Poseidon
                        new bool[] { true, true, true, true, true, true }         // Zeus
                    },
                    new bool[6]
                    {
                        false, false, true, true, true, false
                    },
                    new string[2]
                    {
                        "Black Metal",
                        "Engulfing Vortex"
                    }),

                // Artemis
                new Gods(
                    "Artemis", 2,
                    new string[6]
                {
                    "Deadly Strike",
                    "Deadly Flourish",
                    "True Shot",
                    "Hunter Dash",
                    "Artemis' Aid",
                    ""
                },
                    new bool[][]
                    {
                        new bool[] {true, true, true, false, false, false },   // Aphrodite
                        new bool[] {true, true, false, true, true, false },    // Ares
                        null,                                                  // Self
                        new bool [] { true, true, true, false, true, false },   // Athena
                        new bool [] { true, true, false, true, true, false },  // Demeter
                        new bool [] { true, true, true, false, true, false },  // Dionysus
                        new bool [] { true, true, true, false, true, false },  // Poseidon
                        new bool [] { true, true, true, true, true, false },   // Zeus
                    },
                    new bool[6]
                {
                    false, false, false, false, false, false
                },
                    new string[3]
                    {
                      "Exit Wounds",
                      //"Hide Breaker",
                      //"Hunter's Mark",
                      //"Clean Kill",
                      "Support Fire",
                      "Pressure Points"
                    }),

                // Athena
                new Gods(
                    "Athena",3,
                    new string[6]
                    {
                        "Divine Strike",
                        "Divine Flourish",
                        "Phalanx Shot",
                        "Divine Dash",
                        "Athena's Aid",
                        "Holy Shield"
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, true, true, true, false },      // Aphrodite
                        new bool[] { true, true, false, false, false, false },   // Ares
                        new bool[] { true, true, false, false, false, false },   // Artemis
                        null,                                                    // self
                        new bool[] { true, true, true, true, true, false },      // Demeter
                        new bool[] { true, true, false, true, true, false },     // Dionysus
                        new bool[] { true, true, true, false, true, false },     // Poseidon
                        new bool[] { true, true, false, true, true, false }      // Zeus
                    },
                    new bool[6]
                    {
                        true, true, false, true, false, false
                    },
                    new string[1]
                    {
                        "Brilliant Riposte"
                    }),

                // Demeter
                new Gods(
                    "Demeter", 4,
                    new string[6]
                    {
                        "Frost Strike",
                        "Frost Flourish",
                        "Crystal Beam",
                        "Mistrel Dash",
                        "Demeter's Aid",
                        "Frozen Touch"
                    },
                    new bool[][]
                    {
                        new bool[] { false, false, true, false, false, false },  // Aphrodite
                        new bool[] { true, true, false, true, true, false },     // Ares
                        new bool[] { false, false, true, false, false, false },  // Artemis
                        new bool[] { true, true, true, true, true, false },      // Athena
                        null,                                                    // self
                        new bool[] { true, true, false, true, true, false },     // Dionysus
                        new bool[] { true, true, false, true, true, false },     // Poseidon
                        new bool[] { true, true, false, true, true, false }      // Zeus
                    },
                    new bool[6]
                    {
                        true, true, false, true, true, true
                    },
                    new string[3]
                    {
                        "Ravenous Will",
                        "Arctic Blast",
                        "Killing Freeze"
                    }),

                // Dionysus
                new Gods(
                    "Dionysus", 5,
                    new string[6]
                    {
                        "Drunken Strike",
                        "Drunken Flourish",
                        "Trippy Shot",
                        "Drunken Dash",
                        "Dionysus' Aid",
                        ""
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, false, true, true, false },     // Aphrodite
                        new bool[] { true, true, false, true, true, false },     // Ares
                        new bool[] { true, true, false, true, true, false },     // Artemis
                        new bool[] { true, true, false, true, true, false },     // Athena
                        new bool[] { false, false, true, false, false, false },  // Demeter
                        null,                                                    // self
                        new bool[] { true, true, true, true, true, false },      // Poseidon
                        new bool[] { false, false, true, false, false, false }   // Zeus
                    },
                    new bool[6]
                    {
                        true, true, true, true, true, false
                    },
                    new string[2]
                    {
                        "Trippy Shot",
                        "Any Other Skill Upgrade"
                        //"Peer Pressure",
                        //"Bad Influence",
                        //"Numbing Sensation"
                    }),

                // Poseidon
                new Gods(
                    "Poseidon", 6,
                    new string[6]
                    {
                        "Tempest Strike",
                        "Tempest Flourish",
                        "Flood Shot",
                        "Tidal Dash",
                        "Poseidon's Aid",
                        ""
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, true, true, true, false },      // Aphrodite
                        new bool[] { false, false, true, false, false, false },  // Ares
                        new bool[] { true, true, true, true, true, false },      // Artemis
                        new bool[] { true, true, true, false, true, false },     // Athena
                        new bool[] { false, false, true, false, false, false },  // Demeter
                        new bool[] { true, true, true, true, true, false },      // Dionysus
                        null,                                                    // self
                        new bool[] { true, true, true, false, true, false }      // Zeus
                    },
                    new bool[6]
                    {
                        true, true, true, true, true, false
                    },
                    new string[2]
                    {
                       "Breaking Wave",
                       "Typhoon's Fury"
                    }),

                // Zeus
                new Gods(
                    "Zeus", 7,
                    new string[6]
                    {
                        "Lightning Strike",
                        "Thunder Flourish",
                        "Electric Shot",
                        "Thunder Dash",
                        "Zeus' Aid",
                        "Heaven's Vengeance"
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, true, true, true, false },      // Aphrodite
                        new bool[] { true, true, true, true, true, false },      // Ares
                        new bool[] { true, true, true, true, true, false },      // Artemis
                        new bool[] { true, true, false, true, true, false },     // Athena
                        new bool[] { false, false, false, false, false, false }, // Demeter
                        new bool[] { true, true, false, true, true, false },     // Dionysus
                        new bool[] { true, true, true, true, true, false },      // Poseidon
                        null                                                     // self

                    },
                    new bool[6]
                    {
                        true, true, true, true, true, false
                    },
                    new string[3]
                    {
                        "Storm Lightning",
                        "High Voltage",
                        "Double Strike"
                    })
            };
            return GodList;
        }
    }
}
