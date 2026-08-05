using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Scripts.Utils;

public class SpineHelper
{
	public static void SetSkin(ISkeletonAnimation animation, string skin)
	{
		object obj;
		if (animation == null)
		{
			obj = null;
		}
		else
		{
			Skeleton skeleton = animation.Skeleton;
			obj = ((skeleton != null) ? skeleton.Data : null);
		}
		SkeletonData val = (SkeletonData)obj;
		if (val == null)
		{
			return;
		}
		if (animation.Skeleton.Data.FindSkin(skin) == null)
		{
			if (animation.Skeleton.Data.DefaultSkin != null)
			{
				SetSkin(animation, animation.Skeleton.Data.DefaultSkin.Name);
			}
			else if (animation.Skeleton.Data.Skins.Items.Length != 0)
			{
				SetSkin(animation, animation.Skeleton.Data.Skins.Items[0].Name);
			}
			Debug.LogWarning((object)("没有 " + skin + " 皮肤"));
			return;
		}
		animation.Skeleton.SetSkin(skin);
		animation.Skeleton.SetToSetupPose();
		animation.Skeleton.UpdateCache();
		IAnimationStateComponent val2 = (IAnimationStateComponent)(object)((animation is IAnimationStateComponent) ? animation : null);
		if (val2 != null)
		{
			val2.AnimationState.Apply(animation.Skeleton);
		}
	}
}
