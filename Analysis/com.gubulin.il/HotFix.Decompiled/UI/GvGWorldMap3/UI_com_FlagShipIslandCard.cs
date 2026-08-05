using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGFlagship3;

namespace UI.GvGWorldMap3;

public class UI_com_FlagShipIslandCard : GComponent, IIslandCard
{
	public Controller Status;

	public Controller Camp;

	public Controller HasGreenChannel;

	public Controller IsGreenChannelActive;

	public GImage n17;

	public GImage n18;

	public GImage n26;

	public GImage n27;

	public GLoader n19;

	public UI_com_FlagshipSpineWrapper FlagshipSpineWrapper;

	public GLoader n21;

	public UI_com_FlagshipIslandFunctions IslandFunctions;

	public UI_com_FlagshipFunctions FlagshipFunctions;

	public UI_com_FlagshipInfo FlagshipInfo;

	public GTextField n22;

	public GTextField n23;

	public GTextField n24;

	public GTextField n25;

	public GLoader n43;

	public GTextField n13;

	public GGroup n35;

	public UI_btn_OpenGreenChannel OpenGreenChannelBtn;

	public GGroup n31;

	public GGroup n32;

	public UI_btn_EnterFlagship EnterFlagship;

	public GGroup n33;

	public UI_btn_EnterFlagship2 EnterFlagship2;

	public UI_btn_Operation_Goto02 BtnGoTo;

	public GImage n41;

	public GImage n42;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2h4tpef";

	public static string Name = "UI_com_FlagShipIslandCard";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpef";
	}

	public static UI_com_FlagShipIslandCard CreateInstance()
	{
		return (UI_com_FlagShipIslandCard)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FlagShipIslandCard");
	}

	public static UI_com_FlagShipIslandCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagShipIslandCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpef", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Camp = ((GComponent)this).GetController("Camp");
		HasGreenChannel = ((GComponent)this).GetController("HasGreenChannel");
		IsGreenChannelActive = ((GComponent)this).GetController("IsGreenChannelActive");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n19 = (GLoader)((GComponent)this).GetChild("n19");
		FlagshipSpineWrapper = (UI_com_FlagshipSpineWrapper)(object)((GComponent)this).GetChild("FlagshipSpineWrapper");
		n21 = (GLoader)((GComponent)this).GetChild("n21");
		IslandFunctions = (UI_com_FlagshipIslandFunctions)(object)((GComponent)this).GetChild("IslandFunctions");
		FlagshipFunctions = (UI_com_FlagshipFunctions)(object)((GComponent)this).GetChild("FlagshipFunctions");
		FlagshipInfo = (UI_com_FlagshipInfo)(object)((GComponent)this).GetChild("FlagshipInfo");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id = "ui://4eq8fgd2h4tpef".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id);
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id2 = "ui://4eq8fgd2h4tpef".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id2);
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id3 = "ui://4eq8fgd2h4tpef".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id3);
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id4 = "ui://4eq8fgd2h4tpef".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id4);
		n43 = (GLoader)((GComponent)this).GetChild("n43");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id5 = "ui://4eq8fgd2h4tpef".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id5);
		n35 = (GGroup)((GComponent)this).GetChild("n35");
		OpenGreenChannelBtn = (UI_btn_OpenGreenChannel)(object)((GComponent)this).GetChild("OpenGreenChannelBtn");
		n31 = (GGroup)((GComponent)this).GetChild("n31");
		n32 = (GGroup)((GComponent)this).GetChild("n32");
		EnterFlagship = (UI_btn_EnterFlagship)(object)((GComponent)this).GetChild("EnterFlagship");
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		EnterFlagship2 = (UI_btn_EnterFlagship2)(object)((GComponent)this).GetChild("EnterFlagship2");
		BtnGoTo = (UI_btn_Operation_Goto02)(object)((GComponent)this).GetChild("BtnGoTo");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void OnClose(IslandStateModel islandState)
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUIClose);
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.UpdateFlagShipIslandCardOnArrival = (Action<IslandStateModel>)Delegate.Remove(instance.UpdateFlagShipIslandCardOnArrival, new Action<IslandStateModel>(Update));
		((GObject)EnterFlagship).onClick.Clear();
		((GObject)EnterFlagship2).onClick.Clear();
		((GObject)OpenGreenChannelBtn).onClick.Clear();
		((GObject)BtnGoTo).onClick.Clear();
		FlagshipFunctions.OnClose();
		IslandFunctions.OnClose();
		FlagshipSpineWrapper.OnClose();
		if (Timers.inst.Exists(new TimerCallback(UpdateGreenChannelCoolDown)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateGreenChannelCoolDown));
		}
	}

	public void OnLoad(IslandStateModel islandState)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUIClose);
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.UpdateFlagShipIslandCardOnArrival = (Action<IslandStateModel>)Delegate.Combine(instance.UpdateFlagShipIslandCardOnArrival, new Action<IslandStateModel>(Update));
		((GObject)EnterFlagship).onClick.Set(new EventCallback0(OpenFlagshipPanel));
		((GObject)EnterFlagship2).onClick.Set(new EventCallback0(OpenFlagshipPanel));
		((GObject)OpenGreenChannelBtn).onClick.Set(new EventCallback0(OpenGreenChannelPanel));
		((GObject)BtnGoTo).onClick.Set(new EventCallback0(OnGoTo));
		FlagshipFunctions.OnLoad();
		IslandFunctions.OnLoad();
	}

	public void Render(IslandStateModel islandState)
	{
		Camp.SetSelectedIndex(islandState.CampId);
		IslandFuncStatus islandFuncStatus = SetStatus(islandState);
		IslandFunctions.OnRender(islandState, islandFuncStatus);
		FlagshipInfo.OnRender(islandState.CampId);
		FlagshipFuncStatus status = ((islandFuncStatus != IslandFuncStatus.Unavailable) ? FlagshipFuncStatus.Available : FlagshipFuncStatus.Unavailable);
		FlagshipFunctions.OnRender(status);
		FlagshipSpineWrapper.OnRender(islandState.CampId);
		if (Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67505".IsActive())
		{
			HasGreenChannel.selectedIndex = 1;
			UpdateGreenChannelState();
		}
		else
		{
			IsGreenChannelActive.selectedIndex = 0;
			HasGreenChannel.selectedIndex = 0;
		}
	}

	private void UpdateGreenChannelState()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		int num = (int)GameController.Instance.GetServerTime();
		if (OuterTechHelper.GetTechState().o绿色通道_EndTime > num)
		{
			IsGreenChannelActive.selectedIndex = 1;
			UpdateGreenChannelCoolDown();
			if (!Timers.inst.Exists(new TimerCallback(UpdateGreenChannelCoolDown)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateGreenChannelCoolDown));
			}
			return;
		}
		IsGreenChannelActive.selectedIndex = 0;
		int 绿色通道MaxUseTime = OuterTechHelper.Get_绿色通道MaxUseTime();
		int o绿色通道_LimitTime = OuterTechHelper.GetTechState().o绿色通道_LimitTime;
		string arg = ((o绿色通道_LimitTime > 0) ? "#009900" : "#990000");
		((GObject)OpenGreenChannelBtn.Count).text = $"[color={arg}]{o绿色通道_LimitTime}[/color]/{绿色通道MaxUseTime}";
		if (Timers.inst.Exists(new TimerCallback(UpdateGreenChannelCoolDown)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateGreenChannelCoolDown));
		}
	}

	private void UpdateGreenChannelCoolDown(object param = null)
	{
		int num = OuterTechHelper.GetTechState().o绿色通道_EndTime - (int)GameController.Instance.GetServerTime();
		if (num <= 0)
		{
			UpdateGreenChannelState();
			GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string> { UI_main_GvGWorldMap3.Name }, toBackupStack: false);
		}
		((GObject)EnterFlagship2.CoolDown).text = UiHelper.ParseTimeShort(Mathf.Max(0, num)) ?? "";
	}

	public void Update(IslandStateModel islandState)
	{
		IslandFuncStatus islandFuncStatus = SetStatus(islandState);
		IslandFunctions.OnRender(islandState, islandFuncStatus);
		FlagshipFuncStatus status = ((islandFuncStatus != IslandFuncStatus.Unavailable) ? FlagshipFuncStatus.Available : FlagshipFuncStatus.Unavailable);
		FlagshipFunctions.OnRender(status);
	}

	private IslandFuncStatus SetStatus(IslandStateModel islandState)
	{
		string shipIdStaySomeIsland = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipIdStaySomeIsland(islandState.IslandId);
		IslandFuncStatus islandFuncStatus = (string.IsNullOrEmpty(shipIdStaySomeIsland) ? IslandFuncStatus.Unavailable : IslandFuncStatus.Available);
		Status.SetSelectedIndex((int)(islandFuncStatus - 1));
		return islandFuncStatus;
	}

	private void OnUIClose(string uiName)
	{
		if (uiName == UI_main_GvGFlagshipPanel.Name)
		{
			FlagshipInfo.OnRender();
		}
		if (uiName == UI_main_GreenChannelConfirmPanel.Name)
		{
			UpdateGreenChannelState();
		}
	}

	private void OpenFlagshipPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGFlagshipPanel.Name, null);
	}

	private void OnGoTo()
	{
		SharedMessenger.Broadcast("ON_ISLAND_ACTION_EXECUTE", 1);
	}

	private void OpenGreenChannelPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GreenChannelConfirmPanel.Name, null);
	}
}
