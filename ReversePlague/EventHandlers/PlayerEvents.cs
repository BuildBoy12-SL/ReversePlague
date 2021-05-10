// -----------------------------------------------------------------------
// <copyright file="PlayerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ReversePlague.EventHandlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using UnityEngine;

    /// <summary>
    /// Contains all methods which subscribe from <see cref="Exiled.Events.Handlers.Player"/>.
    /// </summary>
    public static class PlayerEvents
    {
        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnDying(DyingEventArgs)"/>
        public static void OnDying(DyingEventArgs ev)
        {
            if (!ev.HitInformation.IsPlayer)
                return;

            if (!Methods.InfectedPlayers.Contains(ev.Target))
                return;

            Methods.InfectedPlayers.Remove(ev.Target);
            foreach (Player player in Player.List)
            {
                if (player.Role != RoleType.Scp049 || player.IsNpc())
                    continue;

                if (Vector3.Distance(ev.Target.Position, player.Position) > Plugin.Instance.Config.Range)
                    continue;

                ev.Target.DropItems();
                ev.Target.SetRole(RoleType.Scp0492, true);
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnHurting(HurtingEventArgs)"/>
        public static void OnHurting(HurtingEventArgs ev)
        {
            Team team = ev.Target.Team;
            if (team == Team.SCP || team == Team.RIP || (team == Team.TUT && Plugin.Instance.Config.TutorialInfect))
                return;

            if (!Methods.InfectedPlayers.Contains(ev.Target))
                Methods.InfectedPlayers.Add(ev.Target);
        }
    }
}