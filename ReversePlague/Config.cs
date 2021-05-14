// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ReversePlague
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the maximum distance that a Scp049 must be to an infected player for them to instantly become a Scp0492.
        /// </summary>
        [Description("The maximum distance that a Scp049 must be to an infected player for them to instantly become a Scp0492.")]
        public float Range { get; set; } = 5f;

        /// <summary>
        /// Gets or sets the seconds of delay between Scp049 healing applying to Scps.
        /// </summary>
        [Description("The seconds of delay between Scp049 healing applying to Scps.")]
        public float Interval { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the amount of health Scp049 will heal on the interval.
        /// </summary>
        [Description("The amount of health Scp049 will heal on the interval.")]
        public int Scp049HealAmount { get; set; } = 1;

        /// <summary>
        /// Gets or sets the amount of health all other Scps will gain on the interval.
        /// </summary>
        [Description("The amount of health all other Scps will gain on the interval.")]
        public int ScpHealAmount { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether tutorials will be healed like Scps.
        /// </summary>
        [Description("Whether tutorials will be healed like Scps.")]
        public bool TutorialHeal { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether tutorials can become infected.
        /// </summary>
        [Description("Whether tutorials can become infected.")]
        public bool TutorialInfect { get; set; } = true;
    }
}
