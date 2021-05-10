// -----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ReversePlague
{
    using Exiled.API.Features;

    /// <summary>
    /// Contains various extension methods for ease of use.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets a value which indicates whether the <see cref="Player"/> is considered to be a NPC.
        /// </summary>
        /// <param name="player">The player to check.</param>
        /// <returns>Whether the <see cref="Player"/> is a NPC.</returns>
        public static bool IsNpc(this Player player) => player.SessionVariables.ContainsKey("IsNPC");

        /// <summary>
        /// Gets a value which indicates whether the <see cref="Player"/> is considered to be a Scp035.
        /// </summary>
        /// <param name="player">The player to check.</param>
        /// <returns>Whether the <see cref="Player"/> is a Scp035.</returns>
        public static bool IsScp035(this Player player) => player.SessionVariables.ContainsKey("IsScp035");
    }
}