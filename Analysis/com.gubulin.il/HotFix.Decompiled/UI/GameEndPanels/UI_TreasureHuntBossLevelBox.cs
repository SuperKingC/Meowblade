using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Spine.Unity;
using UI.LegendItemDungeon;
using UnityEngine;

namespace UI.GameEndPanels;

public class UI_TreasureHuntBossLevelBox : GComponent
{
	public GMovieClip AdvancedBox;

	public GGraph shiningSfxBack;

	public GGraph DetectorSpineBack;

	public UI_OpenTreasureHuntBossLevelBox OpenBox;

	public Transition DetectorDisappear;

	public const string URL = "ui://hda5vzklnm994r";

	public static string Name = "UI_TreasureHuntBossLevelBox";

	private const string DetectorSpineName = "icon_detector";

	private const string DetectorIdleName = "finish_idle";

	private const string DetectorDisappearName = "finish_disappear";

	private const string TreasureOpenSfxName = "treasure_open";

	private const float SpineSize = 100f;

	private SkeletonAnimation animation;

	private string DetectorSkinName;

	private bool Playing;

	private Action action;

	private List<string> skeletonList = new List<string>();

	public static string GetURL()
	{
		return "ui://hda5vzklnm994r";
	}

	public static UI_TreasureHuntBossLevelBox CreateInstance()
	{
		return (UI_TreasureHuntBossLevelBox)(object)UIPackage.CreateObject("GameEndPanels", "TreasureHuntBossLevelBox");
	}

	public static UI_TreasureHuntBossLevelBox CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TreasureHuntBossLevelBox).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklnm994r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		DetectorSpineBack = (GGraph)((GComponent)this).GetChild("DetectorSpineBack");
		OpenBox = (UI_OpenTreasureHuntBossLevelBox)(object)((GComponent)this).GetChild("OpenBox");
		DetectorDisappear = ((GComponent)this).GetTransition("DetectorDisappear");
	}

	public void Init(Action action)
	{
		Playing = false;
		this.action = action;
		DetectorSkinName = ((!string.IsNullOrEmpty(LegendItemDungeonUiHelper.DetectorSkinName)) ? LegendItemDungeonUiHelper.DetectorSkinName : "skin11");
		animation = UiHelper.SpineLoad(DetectorSpineBack, "icon_detector", 100f, DetectorSkinName, "finish_idle", skeletonList);
		((GObject)this).visible = true;
	}

	public void Play()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		if (!Playing && animation != null)
		{
			Playing = true;
			animation.AnimationName = "finish_disappear";
			AdvancedBox.playing = true;
			AdvancedBox.SetPlaySettings(0, -1, 1, -1);
			DetectorDisappear.Play();
			DetectorDisappear.SetHook("treasure_open", new TransitionHook(PlayTreasureOpenSfx));
			DetectorDisappear.SetHook("BoxDisappear", new TransitionHook(ShowBonus));
		}
	}

	private void PlayTreasureOpenSfx()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		AdvancedBox.playing = false;
		FGUIManager.Instance.AddTextSpecialEffects(shiningSfxBack, "treasure_open", new Vector3(40f, 40f, 40f));
	}

	private void ShowBonus()
	{
		action?.Invoke();
	}

	public void End()
	{
		for (int i = 0; i < skeletonList.Count; i++)
		{
			SpawnManager.Instance.UnloadAnimation(skeletonList[i], isMask: true);
		}
	}
}
