using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace Meowblade.Tests
{
    public sealed class SpineAssetContractTests
    {
        private static readonly IReadOnlyDictionary<HeroId, string> ExpectedSkeletonPaths =
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
        public void HeroSkeletonData_MapsEveryHeroToTheExpectedResourcePath()
        {
            IDictionary reflectedPaths = GetHeroSkeletonPathMap();

            foreach (KeyValuePair<HeroId, string> expected in ExpectedSkeletonPaths)
            {
                Assert.That(reflectedPaths.Contains(expected.Key), Is.True, expected.Key.ToString());
                Assert.That(reflectedPaths[expected.Key], Is.EqualTo(expected.Value), expected.Key.ToString());

                object runtimeAsset = InvokeHeroSkeletonData(expected.Key);
                Assert.That(runtimeAsset, Is.Not.Null, expected.Key.ToString());

                UnityEngine.Object loadedAsset = Resources.Load(expected.Value);
                Assert.That(loadedAsset, Is.Not.Null, expected.Value);
                Assert.That(runtimeAsset, Is.SameAs(loadedAsset), expected.Key.ToString());
            }
        }

        [Test]
        public void HeroSkeletonData_DeclaresAllRequiredAnimationNames()
        {
            foreach (KeyValuePair<HeroId, string> entry in ExpectedSkeletonPaths)
            {
                object skeletonDataAsset = InvokeHeroSkeletonData(entry.Key);
                Assert.That(skeletonDataAsset, Is.Not.Null, entry.Key.ToString());

                object skeletonData = InvokeGetSkeletonData(skeletonDataAsset);
                Assert.That(skeletonData, Is.Not.Null, entry.Key.ToString());

                foreach (string animationName in RequiredAnimationNames)
                {
                    object animation = InvokeFindAnimation(skeletonData, animationName);
                    Assert.That(animation, Is.Not.Null, $"{entry.Key}/{animationName}");
                }
            }
        }

        private static IDictionary GetHeroSkeletonPathMap()
        {
            FieldInfo field = typeof(ArtLibrary).GetField(
                "HeroSkeletonPaths",
                BindingFlags.Static | BindingFlags.NonPublic);

            Assert.That(field, Is.Not.Null, "ArtLibrary.HeroSkeletonPaths field missing.");

            object value = field.GetValue(null);
            Assert.That(value, Is.Not.Null, "ArtLibrary.HeroSkeletonPaths field value missing.");

            IDictionary dictionary = value as IDictionary;
            Assert.That(dictionary, Is.Not.Null, "ArtLibrary.HeroSkeletonPaths is not an IDictionary.");
            return dictionary;
        }

        private static object InvokeHeroSkeletonData(HeroId hero)
        {
            MethodInfo method = typeof(ArtLibrary).GetMethod(
                "HeroSkeletonData",
                BindingFlags.Public | BindingFlags.Static);

            Assert.That(method, Is.Not.Null, "ArtLibrary.HeroSkeletonData method missing.");
            return method.Invoke(null, new object[] { hero });
        }

        private static object InvokeGetSkeletonData(object skeletonDataAsset)
        {
            MethodInfo method = skeletonDataAsset.GetType().GetMethod(
                "GetSkeletonData",
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new[] { typeof(bool) },
                null);

            Assert.That(method, Is.Not.Null, "SkeletonDataAsset.GetSkeletonData(bool) method missing.");
            return method.Invoke(skeletonDataAsset, new object[] { true });
        }

        private static object InvokeFindAnimation(object skeletonData, string animationName)
        {
            MethodInfo method = skeletonData.GetType().GetMethod(
                "FindAnimation",
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new[] { typeof(string) },
                null);

            Assert.That(method, Is.Not.Null, "SkeletonData.FindAnimation(string) method missing.");
            return method.Invoke(skeletonData, new object[] { animationName });
        }
    }
}
