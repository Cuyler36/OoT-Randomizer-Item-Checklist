using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoT_Randomizer_Item_Checklist
{
    public static class ItemList
    {
        public static string[][] ItemPictureList = new string[][]
        {
            new string[] { "Kokiri Sword" },
            new string[] { "Master Sword" },
            new string[] { "Biggoron Sword" },
            new string[] { "Deku Shield" },
            new string[] { "Hylian Shield" },
            new string[] { "Mirror Shield" },
            new string[] { "Fairy Ocarina", "Ocarina of Time" },
            new string[] { "Gold Skulltula Token" }, // x100
            new string[] { "Slingshot" },
            new string[] { "Bomb Bag", "Big Bomb Bag", "Biggest Bomb Bag" },
            new string[] { "Bombchus" },
            new string[] { "Boomerang" },
            new string[] { "Hookshot", "Longshot" },
            new string[] { "Fairy Bow" },
            new string[] { "Megaton Hammer" },
            new string[] { "Bottle" }, // x4
            new string[] { "Weird Egg", "Cucco", "Keaton Mask", "Skull Mask", "Spooky Mask", "Bunny Hood", "Mask of Truth", "Goron Mask", "Zora Mask", "Gerudo Mask" },
            new string[] { "Iron Boots" },
            new string[] { "Hover Boots" },
            new string[] { "Goron Tunic" },
            new string[] { "Zora Tunic" },
            new string[] { "Fire Arrows" },
            new string[] { "Ice Arrows" },
            new string[] { "Light Arrows" },
            new string[] { "Kokiri's Emerald" },
            new string[] { "Goron's Ruby" },
            new string[] { "Zora's Sapphire" },
            new string[] { "Goron's Bracelet", "Silver Gauntlets", "Gold Gauntlets" },
            new string[] { "Silver Scale", "Golden Scale" },
            new string[] { "Din's Fire" },
            new string[] { "Farore's Wind" },
            new string[] { "Nayru's Love" },
            new string[] { "Forest Medallion" },
            new string[] { "Fire Medallion" },
            new string[] { "Water Medallion" },
            new string[] { "Spirit Medallion" },
            new string[] { "Shadow Medallion" },
            new string[] { "Light Medallion" },
            new string[] { "Lens of Truth" },
            new string[] { "Pocket Egg", "Pocket Cucco", "Cojiro", "Odd Mushroom", "Odd Potion", "Poacher's Saw", "Broken Goron Sword", "Prescription", "World's Finest Eyedrops", "Claim Check" },
            new string[] { "Stone of Agony" },
            new string[] { "Deku Seed Bag", "Big Deku Seed Bag", "Biggest Deku Seed Bag" },
            new string[] { "Quiver", "Big Quiver", "Biggest Quiver" },
            new string[] { "Adult Wallet", "Giant's Wallet" },
            new string[] { "Song" },
            new string[] { "Song" },
            new string[] { "Song" },
            new string[] { "Song" },
            new string[] { "Song" },
            new string[] { "Song" },
            new string[] { "Minuet of Forest" },
            new string[] { "Bolero of Fire" },
            new string[] { "Serenade of Water" },
            new string[] { "Nocturne of Shadow" },
            new string[] { "Requiem of Spirit" },
            new string[] { "Prelude of Light" },
        };

        public static int ItemCycleCount(int Item)
        {
            if (Item == 7)
            {
                return 100;
            }
            else if (Item == 15)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
    }
}
