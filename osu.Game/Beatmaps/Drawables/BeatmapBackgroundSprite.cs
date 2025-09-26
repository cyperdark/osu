// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace osu.Game.Beatmaps.Drawables
{
    public partial class BeatmapBackgroundSprite : Sprite
    {
        private readonly IWorkingBeatmap working;

        private readonly string fallbackTextureName;

        public BeatmapBackgroundSprite(IWorkingBeatmap working, string fallbackTextureName = @"Backgrounds/bg1")
        {
            ArgumentNullException.ThrowIfNull(working);

            this.working = working;
            this.fallbackTextureName = fallbackTextureName;
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textures)
        {
            if (working.Beatmap.BeatmapInfo.BackgroundHidden)
                Texture = textures.Get(fallbackTextureName);
            else
                Texture = working.GetBackground() ?? textures.Get(fallbackTextureName);
        }
    }
}
