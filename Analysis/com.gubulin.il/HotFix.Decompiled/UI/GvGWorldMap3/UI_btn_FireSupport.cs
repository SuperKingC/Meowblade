using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_btn_FireSupport : GButton
{
	public Controller button;

	public Controller State;

	public GImage n6;

	public GImage n5;

	public GImage n7;

	public GTextField TimeOfUsage;

	public GImage n10;

	public GTextField Countdown;

	public GImage n13;

	public const string URL = "ui://4eq8fgd2pets6sch";

	public static string Name = "UI_btn_FireSupport";

	private int CurIslandId;

	public static string GetURL()
	{
		return "ui://4eq8fgd2pets6sch";
	}

	public static UI_btn_FireSupport CreateInstance()
	{
		return (UI_btn_FireSupport)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_FireSupport");
	}

	public static UI_btn_FireSupport CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FireSupport).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2pets6sch", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		TimeOfUsage = (GTextField)((GComponent)this).GetChild("TimeOfUsage");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n13 = (GImage)((GComponent)this).GetChild("n13");
	}

	public void OnLoad(IslandStateModel islandState)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
		islandState.OnChangeEvent = (Action<IslandStateModel>)Delegate.Combine(islandState.OnChangeEvent, new Action<IslandStateModel>(OnChangeEvent));
	}

	public void OnUnload(IslandStateModel islandState)
	{
		((GObject)this).onClick.Clear();
		islandState.OnChangeEvent = (Action<IslandStateModel>)Delegate.Combine(islandState.OnChangeEvent, new Action<IslandStateModel>(OnChangeEvent));
		StartTimer(active: false);
	}

	private void OnChangeEvent(IslandStateModel islandState)
	{
		OnRender(islandState);
	}

	private void OnClick()
	{
		if (火力支援Helper.CheckCanUseSkill(CurIslandId))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_FireSupportConfirmPanel.Name, new Dictionary<string, object> { { "IslandId", CurIslandId } });
		}
	}

	public void OnRender(IslandStateModel islandState)
	{
		CurIslandId = islandState.IslandId;
		Update();
	}

	private void Update()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		((GObject)this).visible = 火力支援Helper.CanShowSkillBtnForIsland(CurIslandId);
		bool active = false;
		if (((GObject)this).visible)
		{
			int curTimeOfUsage = 火力支援Helper.CurTimeOfUsage;
			float total = 火力支援Helper.MaxTimeOfUsageModel.Total;
			string text = $"{curTimeOfUsage}/";
			string text2 = $"{total}";
			if (curTimeOfUsage == 0)
			{
				text = $"[color=#ff1a1a]{curTimeOfUsage}/[/color]";
			}
			if (火力支援Helper.MaxTimeOfUsageModel.HasExtra())
			{
				text2 = $"[color=#aef224]{total}[/color]";
			}
			((GObject)TimeOfUsage).text = text + text2;
			if (火力支援Helper.IsSkillBtnGrayedForIsland(CurIslandId))
			{
				State.selectedIndex = 0;
			}
			else if (火力支援Helper.IsSkillActiveForIsland(CurIslandId))
			{
				State.selectedIndex = 2;
				active = true;
			}
			else
			{
				State.selectedIndex = 1;
			}
		}
		StartTimer(active);
	}

	private void StartTimer(bool active)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		if (active)
		{
			if (!Timers.inst.Exists(new TimerCallback(UpdateCountdown)))
			{
				UpdateCountdown(null);
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateCountdown));
			}
		}
		else if (Timers.inst.Exists(new TimerCallback(UpdateCountdown)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateCountdown));
		}
	}

	private void UpdateCountdown(object param)
	{
		if (!((GObject)this).isDisposed)
		{
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(CurIslandId);
			if (!islandStateModel.Is火力支援Active)
			{
				StartTimer(active: false);
				Update();
			}
			else
			{
				int timestamp = (int)GameController.Instance.GetServerTime();
				((GObject)Countdown).text = UiHelper.ParseTime(islandStateModel.Event_火力支援.RemainingTime(timestamp));
			}
		}
	}
}
