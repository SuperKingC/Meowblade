using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Meowblade.Tests
{
    public sealed class SpineHeroAnimationContractTests
    {
        private static readonly IReadOnlyDictionary<HeroId, string> HeroSkeletonJsonResourcePathsByHero =
            new Dictionary<HeroId, string>
            {
                { HeroId.CardboardKnight, "Art/SpineHeroes/CardboardKnight/cardboard_knight" },
                { HeroId.FishHunter, "Art/SpineHeroes/FishHunter/fish_hunter" },
                { HeroId.YarnMage, "Art/SpineHeroes/YarnMage/yarn_mage" }
            };

        private static readonly string[] RequiredAnimationNames =
        {
            "idle",
            "move",
            "attack",
            "skill",
            "hit",
            "retreat",
            "victory"
        };

        [Test]
        public void HeroSkeletonJson_LoadsEachHeroFromResources()
        {
            foreach (KeyValuePair<HeroId, string> expected in HeroSkeletonJsonResourcePathsByHero)
            {
                TextAsset json = Resources.Load<TextAsset>(expected.Value);
                Assert.That(json, Is.Not.Null, expected.Key.ToString());
                Assert.That(json.text, Does.Contain("\"animations\""), expected.Value);
            }
        }

        [Test]
        public void HeroSkeletonJson_DeclaresTheOfficialSpineClipContract()
        {
            foreach (KeyValuePair<HeroId, string> entry in HeroSkeletonJsonResourcePathsByHero)
            {
                TextAsset json = Resources.Load<TextAsset>(entry.Value);
                Assert.That(json, Is.Not.Null, entry.Key.ToString());

                foreach (string animationName in RequiredAnimationNames)
                {
                    string pattern = "\""+Regex.Escape(animationName)+"\"\\s*:";
                    Assert.That(
                        Regex.IsMatch(json.text, pattern),
                        Is.True,
                        $"{entry.Key}/{animationName}");
                }
            }
        }
    }
}
