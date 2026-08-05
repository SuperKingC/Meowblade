using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using Spine.Unity;

namespace UI.LegendItemDungeon;

public class GobinAnimater
{
	public GGraph spineGraph;

	private const float spineSize = 25f;

	private const string IdleAni = "idle_treasurequest";

	private const string RunAni = "run_treasurequest";

	private GobinState gobinState;

	private SkeletonAnimation animation;

	public void GobinInit(GGraph graph, List<string> skeletonList)
	{
		spineGraph = graph;
		gobinState = GobinState.Idle;
		animation = UiHelper.SpineLoad(spineGraph, "Goblinworker_SP_001", 25f, "skin_treasurequest", "idle_treasurequest", skeletonList, isMask: true);
	}

	public void ChangeState(GobinState newState)
	{
		gobinState = newState;
		switch (gobinState)
		{
		case GobinState.Idle:
			animation.AnimationName = "idle_treasurequest";
			break;
		case GobinState.LeftShift:
			animation.AnimationName = "run_treasurequest";
			((GObject)spineGraph).scaleX = 1f;
			break;
		case GobinState.RightShift:
			animation.AnimationName = "run_treasurequest";
			((GObject)spineGraph).scaleX = -1f;
			break;
		default:
			animation.AnimationName = "idle_treasurequest";
			break;
		}
	}
}
