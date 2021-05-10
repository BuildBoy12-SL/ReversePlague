// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ReversePlague
{
    using System;
    using Exiled.API.Features;
    using ReversePlague.EventHandlers;
    using PlayerHandlers = Exiled.Events.Handlers.Player;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            PlayerHandlers.Dying += PlayerEvents.OnDying;
            PlayerHandlers.Hurting += PlayerEvents.OnHurting;
            ServerHandlers.RoundStarted += ServerEvents.OnRoundStarted;
            ServerHandlers.WaitingForPlayers += ServerEvents.OnWaitingForPlayers;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            PlayerHandlers.Dying -= PlayerEvents.OnDying;
            PlayerHandlers.Hurting -= PlayerEvents.OnHurting;
            ServerHandlers.RoundStarted -= ServerEvents.OnRoundStarted;
            ServerHandlers.WaitingForPlayers -= ServerEvents.OnWaitingForPlayers;
            base.OnDisabled();
        }
    }
}