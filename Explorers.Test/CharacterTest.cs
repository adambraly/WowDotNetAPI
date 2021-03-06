﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher()
        {
            Character briandek = TestUtil.WowExplorer.GetCharacter("skullcrusher", "briandek");

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.Level == 85);
            Assert.IsTrue(briandek.@Class == 1);
        }

        [TestMethod]
        public void Get_Complex_Character_Briandek_From_Skullcrusher()
        {

            Character briandek = TestUtil.WowExplorer.GetCharacter("skullcrusher", "briandek",
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true);

            //iterate through stats
            //var statsList = briandek.stats;
            //foreach (KeyValuePair<string, object> stat in briandek.stats)
            //{
            //}

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.Level == 85);
            Assert.IsTrue(briandek.@Class == 1);

            Assert.IsTrue(briandek.Talents.Where(t => t.Selected).FirstOrDefault().Name.Equals("protection", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.Talents.ElementAt(1).Glyphs.Prime.ElementAt(0).Name.Equals("Glyph of Revenge", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(briandek.Appearance.HairVariation == 13);
            Assert.IsTrue(briandek.Companions.ElementAt(1) == 32298);
            Assert.IsTrue(briandek.Items.AverageItemLevelEquipped == 364);

            Assert.IsTrue(briandek.Mounts.Count() == 11);
        }
    }
}
