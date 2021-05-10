// -----------------------------------------------------------------------
// <copyright file="ServerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ReversePlague.EventHandlers
{
    using MEC;

    /// <summary>
    /// Contains all methods which subscribe from <see cref="Exiled.Events.Handlers.Server"/>.
    /// </summary>
    public static class ServerEvents
    {
        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnWaitingForPlayers"/>
        public static void OnWaitingForPlayers()
        {
            Methods.InfectedPlayers.Clear();
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public static void OnRoundStarted()
        {
            Timing.RunCoroutine(Methods.RunPlague());
        }
    }
}