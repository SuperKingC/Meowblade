using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.GvGPlayerCommand3;

namespace UI.GvGWorldMap3;

public class UI_btn_IslandCommand : GButton
{
	public Controller Type;

	public Controller ContributionLevel;

	public GImage n15;

	public GImage n27;

	public GImage n28;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GImage n14;

	public GTextField n4;

	public GTextField Countdown;

	public GImage n16;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GImage n20;

	public GImage n21;

	public GImage n22;

	public GImage n23;

	public GImage n24;

	public GImage n25;

	public GGroup n26;

	public const string URL = "ui://4eq8fgd2jxsodp";

	public static string Name = "UI_btn_IslandCommand";

	private int _islandId;

	private IEvent_PlayerCommand _command;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodp";
	}

	public static UI_btn_IslandCommand CreateInstance()
	{
		return (UI_btn_IslandCommand)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_IslandCommand");
	}

	public static UI_btn_IslandCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		ContributionLevel = ((GComponent)this).GetController("ContributionLevel");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4eq8fgd2jxsodp".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GGroup)((GComponent)this).GetChild("n26");
	}

	public void OnClose()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdatePlayerCommand = (Action<IEvent_PlayerCommand>)Delegate.Remove(instance.UpdatePlayerCommand, new Action<IEvent_PlayerCommand>(Render));
		if (Timers.inst.Exists(new TimerCallback(UpdateCountdown)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateCountdown));
		}
		_command = null;
		((GObject)this).onClick.Clear();
	}

	public void OnLoad(int islandId)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		_islandId = islandId;
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdatePlayerCommand = (Action<IEvent_PlayerCommand>)Delegate.Combine(instance.UpdatePlayerCommand, new Action<IEvent_PlayerCommand>(Render));
		if (!Timers.inst.Exists(new TimerCallback(UpdateCountdown)))
		{
			Timers.inst.Add(1f, 0, new TimerCallback(UpdateCountdown));
		}
		((GObject)this).onClick.Set(new EventCallback0(OpenCommandPanel));
	}

	private void OpenCommandPanel()
	{
		if (_command != null)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_CancelCommand.Name, new Dictionary<string, object> { { "PlayerCommand", _command } });
		}
		else if (Singleton<WorldStateManager>.Instance.TryGetIsland(_islandId).ShieldState.HasShield())
		{
			"PlayerCommandOnShieldTip".ToShowLanguageTip();
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_PlayerCommand.Name, new Dictionary<string, object> { { "IslandId", _islandId } });
		}
	}

	private void UpdateCountdown(object param)
	{
		if (!((GObject)this).isDisposed && _command != null)
		{
			((GObject)Countdown).text = UiHelper.ParseTimeShort(_command.RemainingTime(CurrentTimestamp));
		}
	}

	private void Render(IEvent_PlayerCommand command)
	{
		_command = command;
		if (_command == null)
		{
			Type.selectedIndex = 0;
			return;
		}
		Type.selectedIndex = GetTypeIndex(_command.EventType);
		ContributionLevel.SetSelectedIndex(_command.ContribLevel);
		static int GetTypeIndex(eIslandEvent commandEventType)
		{
			return commandEventType switch
			{
				eIslandEvent.PlayerCommand_Attack => 1, 
				eIslandEvent.PlayerCommand_Defense => 2, 
				eIslandEvent.PlayerCommand_Search => 3, 
				_ => 1, 
			};
		}
	}
}
