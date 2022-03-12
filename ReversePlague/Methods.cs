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

    /// <summary>
    /// Contains various methods primarily for abstraction.
    /// </summary>
    public class Methods
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="Methods"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public Methods(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Handles the timer of healing all applicable players.
        /// </summary>
        /// <returns>An internal delay.</returns>
        public IEnumerator<float> RunPlague()
        {
            while (Round.IsStarted)
            {
                HealScps();
                yield return Timing.WaitForSeconds(plugin.Config.Interval);
            }
        }

        private void HealScps()
        {
            float multiplier = Player.List.Count(player => player.Role == RoleType.Scp0492 && !player.SessionVariables.ContainsKey("IsNPC"));
            if (multiplier == 0)
                return;

            foreach (Player scp049 in Player.Get(RoleType.Scp049))
            {
                if (scp049.IsNpc())
                    continue;

                scp049.Heal(plugin.Config.Scp049HealAmount * multiplier);
                foreach (Player player in Player.List)
                {
                    if (player.IsNpc())
                        continue;

                    if (!player.IsScp && !player.IsScp035())
                        continue;

                    if (player.Role == RoleType.Scp049)
                        continue;

                    float distance = (scp049.Position - player.Position).magnitude;
                    if (distance > plugin.Config.Range)
                        continue;

                    player.Heal(plugin.Config.ScpHealAmount * multiplier);
                }
            }
        }
    }
}