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
        private PlayerEvents playerEvents;
        private ServerEvents serverEvents;

        /// <summary>
        /// Gets an instance of the <see cref="Methods"/> class.
        /// </summary>
        public Methods Methods { get; private set; }

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Methods = new Methods(this);

            playerEvents = new PlayerEvents(this);
            PlayerHandlers.Dying += playerEvents.OnDying;

            serverEvents = new ServerEvents(this);
            ServerHandlers.RoundEnded += serverEvents.OnRoundEnded;
            ServerHandlers.RoundStarted += serverEvents.OnRoundStarted;
            ServerHandlers.WaitingForPlayers += serverEvents.OnWaitingForPlayers;

            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            PlayerHandlers.Dying -= playerEvents.OnDying;
            playerEvents = null;

            ServerHandlers.RoundEnded -= serverEvents.OnRoundEnded;
            ServerHandlers.RoundStarted -= serverEvents.OnRoundStarted;
            ServerHandlers.WaitingForPlayers -= serverEvents.OnWaitingForPlayers;
            serverEvents = null;

            Methods = null;

            base.OnDisabled();
        }
    }
}