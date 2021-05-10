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
        /// Gets all of the players who are infected.
        /// </summary>
        internal static List<Player> InfectedPlayers { get; } = new List<Player>();

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
                scp049.ReferenceHub.playerStats.HealHPAmount((int)scp049.Health + (Plugin.Instance.Config.Scp049HealAmount * multiplier));
                foreach (Player player in Player.List)
                {
                    if (!player.IsScp &&
                        (player.Role != RoleType.Tutorial || !Plugin.Instance.Config.TutorialHeal) &&
                        !player.IsScp035())
                        continue;

                    if (Vector3.Distance(scp049.Position, player.Position) > Plugin.Instance.Config.Range)
                        continue;

                    player.ReferenceHub.playerStats.HealHPAmount((int)player.Health + (Plugin.Instance.Config.ScpHealAmount * multiplier));
                }
            }
        }
    }
}