using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using Spine.Unity;
using UnityEngine;

namespace UI.LegendItemDungeon;

public class DetectorAnimator
{
	private readonly string SpineName = "icon_detector";

	private string AnimSkin = "skin12";

	private string AnimName = "idle";

	private const float SpineSize = 100f;

	public GGraph SpineGraph;

	private SkeletonAnimation animation;

	private float Strength = 0f;

	public void Init(GGraph graph, List<string> skeletonList)
	{
		SpineGraph = graph;
		animation = UiHelper.SpineLoad(SpineGraph, SpineName, 100f, AnimSkin, AnimName, skeletonList);
	}

	public void UpdateState()
	{
		if (Object.op_Implicit((Object)(object)((SkeletonRenderer)animation).skeletonDataAsset))
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, AnimSkin);
			animation.AnimationState.SetAnimation(0, AnimName, true);
		}
	}

	public void ChangeStrength(float strength, bool isMaxStrength)
	{
		AnimSkin = "skin";
		AnimName = "idle";
		Strength = strength;
		if (isMaxStrength)
		{
			AnimSkin += 12;
			AnimName = "detecting";
		}
		else if (strength <= 1f)
		{
			AnimSkin += 1;
		}
		else if (strength <= 8f)
		{
			AnimSkin += 2;
		}
		else if (strength <= 16f)
		{
			AnimSkin += 3;
		}
		else if (strength <= 24f)
		{
			AnimSkin += 4;
		}
		else if (strength <= 32f)
		{
			AnimSkin += 5;
		}
		else if (strength <= 40f)
		{
			AnimSkin += 6;
		}
		else if (strength <= 48f)
		{
			AnimSkin += 7;
		}
		else if (strength <= 56f)
		{
			AnimSkin += 8;
		}
		else if (strength <= 64f)
		{
			AnimSkin += 9;
		}
		else if (strength <= 72f)
		{
			AnimSkin += 10;
		}
		else
		{
			AnimSkin += 11;
		}
		UpdateState();
		LegendItemDungeonUiHelper.DetectorSkinName = AnimSkin;
	}
}
