using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SwimsuitsAnywhere
{
    public class ModEntry : Mod, IAssetLoader
    {

        private ModConfig Config;
        private SButton ChangeKey;
        private bool updateSprite;

        public bool CanLoad<T>(IAssetInfo asset)
        {
            if (updateSprite &&
                asset.AssetNameEquals("Characters/Farmer/pants") ||
                asset.AssetNameEquals("Characters/Farmer/farmer_base") ||
                asset.AssetNameEquals("Characters/Farmer/farmer_base_bald") ||
                asset.AssetNameEquals("Characters/Farmer/farmer_girl_base") ||
                asset.AssetNameEquals("Characters/Farmer/farmer_girl_base_bald"))
            {
                return true;
            }

            return false;
        }

        public T Load<T>(IAssetInfo asset)
        {
            if (updateSprite)
            {
                string nameOfAsset = asset.AssetName;
                switch (nameOfAsset)
                {
                    case "Characters/Farmer/pants":
                        return this.Helper.Content.Load<T>("assets/pants.png", ContentSource.ModFolder);
                    case "Characters/Farmer/farmer_base":
                        return this.Helper.Content.Load<T>("assets/farmer_base.png", ContentSource.ModFolder);
                    case "Characters/Farmer/farler_base_bald":
                        return this.Helper.Content.Load<T>("assets/farmer_base_bald.png", ContentSource.ModFolder);
                    case "Characters/Farmer/farmer_girl_base":
                        return this.Helper.Content.Load<T>("assets/farmer_girl_base.png", ContentSource.ModFolder);
                    case "Characters/Farmer/farmer_girl_base_bald":
                        return this.Helper.Content.Load<T>("assets/farmer_girl_base_bald.png", ContentSource.ModFolder);
                    default:
                        throw new InvalidOperationException($"Unexpected asset '{asset.AssetName}'.");
                } 
            }
            throw new InvalidOperationException($"Unexpected asset '{asset.AssetName}'.");
        }

        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();
            ChangeKey = this.Config.ChangeKey;
            updateSprite = this.Config.updateSprite;

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (e.Button == ChangeKey && !Game1.player.bathingClothes)
            {
                Game1.player.changeIntoSwimsuit();
            }
            else if (e.Button == ChangeKey && Game1.player.bathingClothes)
            {
                Game1.player.changeOutOfSwimSuit();
            }
        }
    }
}