using System;
using EloBuddy;
using EloBuddy.SDK;
using ExorAIO.Utilities;
using LeagueSharp.Common;
using SharpDX;

namespace ExorAIO.Champions.Olaf
{
    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Logics
    {
        /// <summary>
        ///     Called when the game updates itself.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void Combo(EventArgs args)
        {
            if (Bools.HasSheenBuff() ||
                !Targets.Target.IsValidTarget() ||
                Bools.IsSpellShielded(Targets.Target))
            {
                return;
            }

            /// <summary>
            ///     The Combo W Logic.
            /// </summary>
            if (Variables.W.IsReady() && ObjectManager.Player.CountEnemiesInRange(Variables.AARange + 125) > 0 && Variables.getCheckBoxItem(Variables.WMenu, "wspell.combo"))
            {
                Variables.W.Cast();
            }

            /// <summary>
            ///     The Q Combo Logic.
            /// </summary>
            if (Variables.Q.IsReady() && Targets.Target.IsValidTarget(Variables.Q.Range) && Variables.getCheckBoxItem(Variables.QMenu, "qspell.combo"))
            {
                var castPosition = Variables.Q.GetPrediction(Targets.Target);
                var castPosition2 = castPosition.CastPosition.LSExtend(ObjectManager.Player.Position, -100);

                if (ObjectManager.Player.LSDistance(Targets.Target.ServerPosition) >= 350)
                {
                    Variables.Q.Cast(castPosition2);
                }
                else
                {
                    Variables.Q.Cast(castPosition.CastPosition);
                }
            }
        }
    }
}
