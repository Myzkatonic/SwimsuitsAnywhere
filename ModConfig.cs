using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SwimsuitsAnywhere
{
    public class ModConfig
    {
        public SButton ChangeKey { get; set; }
        public bool updateSprite { get; set; }

        public ModConfig()
        {
            this.ChangeKey = SButton.J;
            this.updateSprite = true;
        }
    }
}