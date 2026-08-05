using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.UiParam;
using Spine.Unity;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGVideos;

public class SkeletonAnimationUiWrapper
{
	private SkeletonAnimation _skeletonAnimation;

	private SkeletonAnimationLoadParams _loadParams;

	public SkeletonAnimationUiWrapper(SkeletonAnimationLoadParams loadParams)
	{
		_loadParams = loadParams;
		UiHelper.LoadSpine_AB(_loadParams.Graph, _loadParams.Name, _loadParams.Scale, LoadSkeletonAnimationOnSuccess);
	}

	public void PlayAnimation(string aniName)
	{
		SkeletonAnimation skeletonAnimation = _skeletonAnimation;
		if (skeletonAnimation != null)
		{
			skeletonAnimation.AnimationState.SetAnimation(0, aniName, true);
		}
	}

	public void RemoveSpine()
	{
		_skeletonAnimation = null;
		SpawnManager.Instance.UnloadAnimation(_loadParams?.Name);
		SkeletonAnimationLoadParams loadParams = _loadParams;
		if (loadParams != null)
		{
			GGraph graph = loadParams.Graph;
			if (graph != null)
			{
				DisplayObject displayObject = ((GObject)graph).displayObject;
				if (displayObject != null)
				{
					displayObject.Dispose();
				}
			}
		}
		_loadParams = null;
	}

	private void LoadSkeletonAnimationOnSuccess(SkeletonAnimation animation)
	{
		if (!((GObject)_loadParams.Graph).isDisposed)
		{
			_skeletonAnimation = animation;
			SetSkin(_loadParams.Skin);
			PlayAnimation(_loadParams.InitialAnimationName);
		}
	}

	private void SetSkin(string skinName)
	{
		SpineHelper.SetSkin((ISkeletonAnimation)(object)_skeletonAnimation, skinName);
	}
}
