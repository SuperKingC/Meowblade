using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Meowblade
{
    public static class SpineHeroFactory
    {
        public static SpineCharacterAnimator CreateBattleCharacter(
            RectTransform parent,
            HeroId hero,
            Sprite fallback,
            Vector2 size)
        {
            GameObject motionObject = new GameObject("MotionRoot", typeof(RectTransform));
            RectTransform motionRoot = motionObject.GetComponent<RectTransform>();
            motionRoot.SetParent(parent, false);
            motionRoot.anchorMin = Vector2.zero;
            motionRoot.anchorMax = Vector2.one;
            motionRoot.offsetMin = Vector2.zero;
            motionRoot.offsetMax = Vector2.zero;
            motionRoot.sizeDelta = size;

            SkeletonGraphic graphic = motionObject.AddComponent<SkeletonGraphic>();
            graphic.raycastTarget = false;
            graphic.SkeletonDataAsset = ArtLibrary.HeroSkeletonData(hero);

            SkeletonAnimation skeletonAnimation = motionObject.AddComponent<SkeletonAnimation>();
            graphic.Animation = skeletonAnimation;
            skeletonAnimation.Initialize(false);

            Image fallbackImage = motionObject.AddComponent<Image>();
            fallbackImage.sprite = fallback;
            fallbackImage.preserveAspect = true;
            fallbackImage.raycastTarget = false;

            SpineCharacterAnimator animator = motionObject.AddComponent<SpineCharacterAnimator>();
            animator.Configure(graphic, skeletonAnimation, fallbackImage);
            return animator;
        }
    }
}
