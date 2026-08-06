using System;
using System.Collections.Generic;
using NUnit.Framework;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Meowblade.Tests
{
    public sealed class SpineHeroAnimationContractTests
    {
        private static readonly IReadOnlyDictionary<HeroId, string> MinimalHeroSkeletonResourcePathsByHero =
            new Dictionary<HeroId, string>
            {
                { HeroId.CardboardKnight, "Art/SpineHeroes/CardboardKnight/cardboard_knight_SkeletonData" },
                { HeroId.FishHunter, "Art/SpineHeroes/FishHunter/fish_hunter_SkeletonData" },
                { HeroId.YarnMage, "Art/SpineHeroes/YarnMage/yarn_mage_SkeletonData" }
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
        public void HeroSkeletonData_LoadsEachHeroFromTheExpectedResourcePath()
        {
            foreach (KeyValuePair<HeroId, string> expected in MinimalHeroSkeletonResourcePathsByHero)
            {
                SkeletonDataAsset skeletonDataAsset = ArtLibrary.HeroSkeletonData(expected.Key);
                Assert.That(skeletonDataAsset, Is.Not.Null, expected.Key.ToString());

                UnityEngine.Object loadedAsset = Resources.Load(expected.Value);
                Assert.That(loadedAsset, Is.Not.Null, expected.Value);
            }
        }

        [Test]
        public void HeroSkeletonData_DeclaresTheOfficialSpineClipContract()
        {
            foreach (KeyValuePair<HeroId, string> entry in MinimalHeroSkeletonResourcePathsByHero)
            {
                SkeletonDataAsset skeletonDataAsset = ArtLibrary.HeroSkeletonData(entry.Key);
                Assert.That(skeletonDataAsset, Is.Not.Null, entry.Key.ToString());
                SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(true);
                Assert.That(skeletonData, Is.Not.Null, entry.Key.ToString());

                foreach (string animationName in RequiredAnimationNames)
                {
                    Spine.Animation animation = skeletonData.FindAnimation(animationName);
                    Assert.That(animation, Is.Not.Null, $"{entry.Key}/{animationName}");
                }
            }
        }
    }
}
