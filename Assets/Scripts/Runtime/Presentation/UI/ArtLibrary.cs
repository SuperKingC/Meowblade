using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

namespace Meowblade
{
    /// <summary>
    /// Runtime art lookup kept in one place so generated concept derivatives can
    /// be replaced by production atlases without changing screen logic.
    /// </summary>
    public static class ArtLibrary
    {
        private static readonly Dictionary<string, Sprite> SpriteCache = new Dictionary<string, Sprite>();
        private static readonly string[] RequiredTexturePaths =
        {
            "Art/Backgrounds/home_workshop_temp_v01",
            "Art/Backgrounds/battle_alley_temp_v02",
            "Art/Characters/hero_cardboard_knight_temp_v01",
            "Art/Characters/hero_fish_hunter_temp_v01",
            "Art/Characters/hero_yarn_mage_temp_v01",
            "Art/Portraits/hero_cardboard_knight_portrait_v01",
            "Art/Portraits/hero_fish_hunter_portrait_v01",
            "Art/Portraits/hero_yarn_mage_portrait_v01",
            "Art/Portraits/kitten_cardboard_squad_portrait_temp_v01",
            "Art/Portraits/kitten_fish_squad_portrait_temp_v01",
            "Art/Portraits/kitten_yarn_squad_portrait_temp_v01",
            "Art/Portraits/enemy_cardboard_mouse_portrait_temp_v01",
            "Art/Portraits/enemy_tape_captain_portrait_temp_v01",
            "Art/Stations/station_cardboard_recycling_v01",
            "Art/Stations/station_dried_fish_kitchen_v01",
            "Art/Stations/station_mystic_parts_v01",
            "Art/UI/Resources/resource_cardboard_v01",
            "Art/UI/Resources/resource_dried_fish_v01",
            "Art/UI/Resources/resource_mystic_part_v01"
        };

        private static readonly Dictionary<HeroId, string> HeroSkeletonPaths =
            new Dictionary<HeroId, string>
            {
                { HeroId.CardboardKnight, "Art/SpineHeroes/CardboardKnight/cardboard_knight_SkeletonData" },
                { HeroId.FishHunter, "Art/SpineHeroes/FishHunter/fish_hunter_SkeletonData" },
                { HeroId.YarnMage, "Art/SpineHeroes/YarnMage/yarn_mage_SkeletonData" }
            };

        public static Sprite HomeBackground
        {
            get { return Load("Art/Backgrounds/home_workshop_temp_v01"); }
        }

        public static Sprite BattleBackground
        {
            get { return Load("Art/Backgrounds/battle_alley_temp_v02"); }
        }

        public static Sprite ResourceIcon(ResourceId resource)
        {
            switch (resource)
            {
                case ResourceId.Cardboard: return Load("Art/UI/Resources/resource_cardboard_v01");
                case ResourceId.DriedFish: return Load("Art/UI/Resources/resource_dried_fish_v01");
                case ResourceId.MysticPart: return Load("Art/UI/Resources/resource_mystic_part_v01");
                default: return null;
            }
        }

        public static Sprite StationThumbnail(StationId station)
        {
            switch (station)
            {
                case StationId.Cardboard: return Load("Art/Stations/station_cardboard_recycling_v01");
                case StationId.Fish: return Load("Art/Stations/station_dried_fish_kitchen_v01");
                case StationId.Parts: return Load("Art/Stations/station_mystic_parts_v01");
                default: return null;
            }
        }

        public static Sprite HeroSprite(HeroId hero)
        {
            switch (hero)
            {
                case HeroId.CardboardKnight: return Load("Art/Characters/hero_cardboard_knight_temp_v01");
                case HeroId.FishHunter: return Load("Art/Characters/hero_fish_hunter_temp_v01");
                case HeroId.YarnMage: return Load("Art/Characters/hero_yarn_mage_temp_v01");
                default: return null;
            }
        }

        public static SkeletonDataAsset HeroSkeletonData(HeroId hero)
        {
            string resourcePath;
            if (!HeroSkeletonPaths.TryGetValue(hero, out resourcePath))
            {
                return null;
            }

            return Resources.Load<SkeletonDataAsset>(resourcePath);
        }

        public static Sprite HeroPortrait(HeroId hero)
        {
            switch (hero)
            {
                case HeroId.CardboardKnight: return Load("Art/Portraits/hero_cardboard_knight_portrait_v01");
                case HeroId.FishHunter: return Load("Art/Portraits/hero_fish_hunter_portrait_v01");
                case HeroId.YarnMage: return Load("Art/Portraits/hero_yarn_mage_portrait_v01");
                default: return null;
            }
        }

        public static Sprite KittenPortrait(HeroId hero)
        {
            switch (hero)
            {
                case HeroId.CardboardKnight: return Load("Art/Portraits/kitten_cardboard_squad_portrait_temp_v01");
                case HeroId.FishHunter: return Load("Art/Portraits/kitten_fish_squad_portrait_temp_v01");
                case HeroId.YarnMage: return Load("Art/Portraits/kitten_yarn_squad_portrait_temp_v01");
                default: return null;
            }
        }

        public static Sprite EnemyPortrait(bool boss)
        {
            return boss
                ? Load("Art/Portraits/enemy_tape_captain_portrait_temp_v01")
                : Load("Art/Portraits/enemy_cardboard_mouse_portrait_temp_v01");
        }

        public static Sprite Load(string resourcePath)
        {
            if (string.IsNullOrEmpty(resourcePath))
            {
                return null;
            }

            Sprite cached;
            if (SpriteCache.TryGetValue(resourcePath, out cached))
            {
                return cached;
            }

            Sprite importedSprite = Resources.Load<Sprite>(resourcePath);
            if (importedSprite != null)
            {
                SpriteCache[resourcePath] = importedSprite;
                return importedSprite;
            }

            Texture2D texture = Resources.Load<Texture2D>(resourcePath);
            if (texture == null)
            {
                SpriteCache[resourcePath] = null;
                return null;
            }

            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0f, 0f, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                100f);
            sprite.name = resourcePath.Replace('/', '_');
            SpriteCache[resourcePath] = sprite;
            return sprite;
        }

        public static bool ValidateRuntimeAssets(out string issue)
        {
            for (int i = 0; i < RequiredTexturePaths.Length; i++)
            {
                Texture2D texture = Resources.Load<Texture2D>(RequiredTexturePaths[i]);
                if (texture == null)
                {
                    issue = "Missing runtime art: " + RequiredTexturePaths[i];
                    return false;
                }

                if (texture.width < 128 || texture.height < 128)
                {
                    issue = "Runtime art is below minimum dimensions: " + RequiredTexturePaths[i];
                    return false;
                }
            }

            issue = string.Empty;
            return true;
        }
    }
}
