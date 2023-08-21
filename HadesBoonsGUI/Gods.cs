using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace HadesBoonsGUI
{
    public class Gods
    {
        public string Name { get; }
        public int Index { get; }
        public string[] Skills { get; }
        public bool[][] Duos { get; }
        public bool[] Legendary { get; }
        public bool CanGetLegendary { get; set;  } // Checks whether God is able to get a legendary
        public string[] LegPreqs { get; }
        public string[] DuoName { get; }
        public string[] DuoDescription { get; }
        public bool[] ChosenSkills { get; set; } = new bool[] {
            false, false, false, false, false, false
        };
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
            string[] legPreqs,
            string[] duoName,
            string[] duoDescription)
        {
            Name = name;
            Index = index;
            Skills = skills;
            Duos = duos;
            Legendary = legendary;
            LegPreqs = legPreqs;
            DuoName = duoName;
            DuoDescription = duoDescription;
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
            { return false; }
            else
            { return true; }
        }

        public bool GodDuoNameNull(int i)
        {
            if (this.DuoName[i] == null)
            { return false; }
            else
            { return true; }
        }

        public bool GodDuoDescriptionNull(int i)
        {
            if (this.DuoDescription[i] == null)
            { return false; }
            else
            { return true; }
        }

        public int SkillFrequencyCount(int skill)
        {
            int count = 0;
            for (int i = 0; i < this.Duos.Length; i++)
            {
                if (this.GodDuoNull(i))
                {
                    if (this.Duos[i][skill])
                    { count++; }
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
                    },
                    new string[8]
                    {
                        null,      // self
                        "Curse of Longing",     // Ares
                        "Heart Rend",     // Artemis
                        "Parting Shot",      // Athena
                        "Cold Embrace",     // Demeter
                        "Low Tolerance",     // Dionysus
                        "Sweet Nectar",      // Poseidon
                        "Smoldering Air"       // Zeus
                    },
                    new string[8]
                    {
                        null,                                                                         // self
                        "Your Doom effects continuously strike Weak foes.",                           // Ares
                        "Your Critical effects deal even more damage to Weak foes. ",                 // Artemis
                        "Your Cast gains any bonuses you have for striking foes from behind.\r\n\r\n" +
                        "Cannot be combined with Trippy Shot",                                        // Athena
                        "Your Cast crystal fires its beam directly at you for +4 seconds. \r\n\r\n" +
                        "Cannot be combined with Crystal Clarity or Beowulf",                         // Demeter
                        "Your Hangover effects stack even more times against Weak foes. ",            // Dionysus
                        "Any Poms of Power you find are more effective. ",                            // Poseidon
                        "Your Call charges up automatically, but is capped at 25%.\r\n\r\n" +
                        "Cannot be combined with Sigil of the Dead",                                  // Zeus
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
                    },
                    new string[8]
                    {
                        null,                 // Aphrodite
                        null,                 // self
                        "Hunting Blades",     // Artemis
                        "Merciful End",       // Athena
                        "Freezing Vortex",    // Demeter
                        "Curse of Nausea",    // Dionysus
                        "Curse of Drowning",  // Poseidon
                        "Vengeful Mood"       // Zeus
                    },
                    new string[8]
                    {
                        null,                                                                    // Aphrodite
                        null,                                                                    // Self
                        "Your Cast creates a faster Blade Rift that seeks the nearest foe.\r\n\r\n"+
                        "Cannot be combined with Freezing Vortex or Beowulf",                    // Artemis
                        "Your attacks that can Deflect immediately activate Doom effects. ",     // Athena
                        "Your Cast inflicts Chill, but is smaller and moves slower.\r\n\r\n" +
                        "Cannot be combined with Hunting Blades",                                // Demeter
                        "Your Hangover effects deal damage faster. ",                            // Dionysus
                        "Your Cast is a pulse that deals damage to foes around you.\r\n\r\n" +
                        "Cannot be combined with Mirage Shot, Blizzard Shot or Hera",            // Poseidon
                        "Your Revenge attacks sometimes occur without taking damage. "           // Zeus
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
                        new bool [] { true, true, true, false, true, false },  // Athena
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
                    },
                    new string[8]
                    {
                        null,                 // Aphrodite
                        null,                 // Ares
                        null,                 // self
                        "Deadly Reversal",    // Athena
                        "Crystal Clarity",    // Demeter
                        "Splitting Headache", // Dionysus
                        "Mirage Shot",        // Poseidon
                        "Lightning Rod"       // Zeus
                    },
                    new string[8]
                    {
                        null,                                                                            // Aphrodite
                        null,                                                                            // Ares
                        null,                                                                            // Self
                        "After you Deflect, briefly gain +20% chance to deal Critical damage. ",         // Athena
                        "Your Cast is stronger and tracks foes more effectively.\r\n\r\n" +
                        "Cannot be combined with Cold Embrace or Beowulf",                               // Demeter
                        "Hangover-afflicted foes are more likely to take Critical damage. ",             // Dionysus
                        "Your Cast fires a second projectile, though it has reduced damage.\r\n\r\n" +
                        "Cannot be combined with Curse of Drowning",                                      // Poseidon
                        "Your collectible Cast Ammo strike nearby foes with lightning every 1 Sec.\r\n\r\n" +
                        "Requires the Infernal Soul Mirror Ability",                                      // Zeus
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
                    },
                    new string[8]
                    {
                        null,     // Aphrodite
                        null,     // Ares
                        null,     // Artemis
                        null,      // self
                        "Stubborn Roots",     // Demeter
                        "Calculated Risk",     // Dionysus
                        "Unshakable Mettle",      // Poseidon
                        "Lightning Phalanx"       // Zeus
                    },
                    new string[8]
                    {
                        null,                                                                     // Aphrodite
                        null,                                                                     // Ares
                        null,                                                                     // Artemis
                        null,                                                                     // self
                        "While you have no Death/Stubborn Defiance your Health slowly recovers.", // Demeter
                        "Your foes' ranged-attack projectiles are slower. ",                      // Dionysus
                        "You cannot be stunned, and resist some damage from Bosses. ",            // Poseidon
                        "Your Phalanx Shot Cast bounces between nearby foes. "                    // Zeus
                    }
                    ),

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
                    },
                    new string[8]
                    {
                        null,     // Aphrodite
                        null,     // Ares
                        null,     // Artemis
                        null,      // Athena
                        null,     // self
                        "Ice Wine",     // Dionysus
                        "Blizzard Shot",      // Poseidon
                        "Cold Fusion"       // Zeus
                    },
                    new string[8]
                    {
                        null,                                                                        // Aphrodite
                        null,                                                                        // Ares
                        null,                                                                        // Artemis
                        null,                                                                        // Athena
                        null,                                                                        // self
                        "Your Cast blasts an area with freezing Festive Fog that inflicts Chill.\r\n\r\n" +
                        "Cannot be combined with Blizzard Shot",                                     // Dionysus
                        "Your Cast moves slowly, piercing foes and firing shards around it.\r\n\r\n" +
                        "Cannot be combined with Curse of Drowning, Ice Wine or Beowulf",            // Poseidon
                        "Jolted status does not expire on your enemies' attacks.\r\n\r\n" +
                        "Requires Static Discharge"                                                  // Zeus
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
                    },
                    new string[8]
                    {
                        null,     // Aphrodite
                        null,     // Ares
                        null,     // Artemis
                        null,      // Athena
                        null,     // Demeter
                        null,     // self
                        "Exclusive Access",      // Poseidon
                        "Scintillating Feast"       // Zeus
                    },
                    new string[8]
                    {
                        null,                                                                // Aphrodite
                        null,                                                                // Ares
                        null,                                                                // Artemis
                        null,                                                                // Athena
                        null,                                                                // Demeter
                        null,                                                                // self
                        "Any Boons you find have superior effects.",                         // Poseidon
                        "Your Festive Fog effects also deal lightning damage periodically. " // Zeus
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
                    },
                    new string[8]
                    {
                        null,     // Aphrodite
                        null,     // Ares
                        null,     // Artemis
                        null,      // Athena
                        null,     // Demeter
                        null,     // Dionysus
                        null,      // self
                        "Sea Storm"       // Zeus
                    },
                    new string [8]
                    {
                        null,                                                                 // Aphrodite
                        null,                                                                 // Ares
                        null,                                                                 // Artemis
                        null,                                                                 // Athena
                        null,                                                                 // Demeter
                        null,                                                                 // Dionysus
                        null,                                                                 // self
                        "Your knock-away effects also cause foes to be struck by lightning. " // Zeus
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
                    },
                    new string[8]
                    {
                        null,     // Aphrodite
                        null,     // Ares
                        null,     // Artemis
                        null,      // Athena
                        null,     // Demeter
                        null,     // Dionysus
                        null,      // Poseidon
                        null       // self
                    },
                    new string[8]
                    {
                        null,      // Aphrodite
                        null,      // Ares
                        null,      // Artemis
                        null,     // Athena
                        null, // Demeter
                        null,     // Dionysus
                        null,      // Poseidon
                        null                                                     // self
                    })
            };
            return GodList;
        }
    }
}
