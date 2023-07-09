using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadesBoonsGUI
{
    internal class Weapons
    {
        public string Name { get; }
        public int Index { get; }
        public string[] Aspect { get; }

        public Weapons(
            string name,
            int index,
            string[] aspect)
        {
            Name = name;
            Index = index;
            Aspect = aspect;
        }

        public static List<Weapons> WeaponsListMethod()
        {
            List<Weapons> Weapons = new List<Weapons>()
            {
                new Weapons(
                    "Stygian Blade",
                    0, new string[4]
                    {
                        "Zagreus",
                        "Nemesis",
                        "Poseidon",
                        "Arthur"
                    }),

                new Weapons(
                    "Eternal Spear",
                    1, new string[4]
                    {
                        "Zagreus",
                        "Achilles",
                        "Hades",
                        "Guan Yu"
                    }),

                new Weapons(
                    "Shield of Chaos",
                    2, new string[4]
                    {
                        "Zagreus",
                        "Chaos",
                        "Zeus",
                        "Beowulf"
                    }),

                new Weapons(
                    "Heart-Seeking Bow",
                    3, new string[4]
                    {
                        "Zagreus",
                        "Chiron",
                        "Hera",
                        "Rama"
                    }),

                new Weapons(
                    "Twin Fists",
                    4, new string[4]
                    {
                        "Zagreus",
                        "Talos",
                        "Demeter",
                        "Gilgamesh"
                    }),

                new Weapons(
                    "Adamant Rail",
                    5, new string[4]
                    {
                        "Zagreus",
                        "Eris",
                        "Hestia",
                        "Lucifer"
                    })
            };
            return Weapons;
        }
    }
}
