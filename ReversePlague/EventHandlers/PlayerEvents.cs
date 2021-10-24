// -----------------------------------------------------------------------
// <copyright file="PlayerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ReversePlague.EventHandlers
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains all methods which subscribe from <see cref="Exiled.Events.Handlers.Player"/>.
    /// </summary>
    public class PlayerEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public PlayerEvents(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnDying(DyingEventArgs)"/>
        public void OnDying(DyingEventArgs ev)
        {
            if (!ev.HitInformation.IsPlayer)
                return;

            if (ev.Target.IsScp)
                return;

            foreach (Player player in Player.List)
            {
                if (player.IsNpc() || player.Role != RoleType.Scp049)
                    continue;

                float distance = (ev.Target.Position - player.Position).magnitude;
                if (distance > plugin.Config.Range)
                    continue;

                ev.Target.DropItems();
                ev.Target.ClearInventory();
                ev.Target.SetRole(RoleType.Scp0492, SpawnReason.Revived, true);
            }
        }
    }
}