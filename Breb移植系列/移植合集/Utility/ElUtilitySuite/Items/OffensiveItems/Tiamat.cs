﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using LeagueSharp.Common;

namespace ElUtilitySuite.Items.OffensiveItems
{
    internal class Tiamat : Item
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public override ItemId Id
        {
            get
            {
                return ItemId.Tiamat_Melee_Only;
            }
        }

        /// <summary>
        ///     Gets or sets the name of the item.
        /// </summary>
        /// <value>
        ///     The name of the item.
        /// </value>
        public override string Name
        {
            get
            {
                return "Tiamat";
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool getCheckBoxItem(string item)
        {
            return Menu[item].Cast<CheckBox>().CurrentValue;
        }

        public int getSliderItem(string item)
        {
            return Menu[item].Cast<Slider>().CurrentValue;
        }

        public bool getKeyBindItem(string item)
        {
            return Menu[item].Cast<KeyBind>().CurrentValue;
        }

        public override void CreateMenu()
        {
            Menu.AddGroupLabel("提亚马特");
            Menu.Add("Tiamatcombo", new CheckBox("连招使用"));
        }

        /// <summary>
        ///     Shoulds the use item.
        /// </summary>
        /// <returns></returns>
        public override bool ShouldUseItem()
        {
            return getCheckBoxItem("Tiamatcombo") && ComboModeActive && HeroManager.Enemies.Any(x => x.Distance(ObjectManager.Player) < 400 && !x.IsDead && !x.IsZombie);
        }

        #endregion
    }
}