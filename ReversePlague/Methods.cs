// -----------------------------------------------------------------------
// <copyright file="Methods.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ReversePlague
{
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using MEC;
    using UnityEngine;

    /// <summary>
    /// Contains various methods primarily for abstraction.
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Handles the timer of healing all applicable players.
        /// </summary>
        /// <returns>An internal delay.</returns>
        public static IEnumerator<float> RunPlague()
        {
            while (Round.IsStarted)
            {
                HealScps(Player.Get(RoleType.Scp0492).Count());
                yield return Timing.WaitForSeconds(Plugin.Instance.Config.Interval);
            }
        }

        private static void HealScps(int multiplier)
        {
            foreach (Player scp049 in Player.Get(RoleType.Scp049))
            {
                scp049.Heal(Plugin.Instance.Config.Scp049HealAmount * multiplier);
                foreach (Player player in Player.List)
                {
                    if (!player.IsScp && !player.IsScp035())
                        continue;

                    float distance = (scp049.Position - player.Position).magnitude;
                    if (distance > Plugin.Instance.Config.Range)
                        continue;

                    player.Heal(Plugin.Instance.Config.ScpHealAmount * multiplier);
                }
            }
        }
    }
}