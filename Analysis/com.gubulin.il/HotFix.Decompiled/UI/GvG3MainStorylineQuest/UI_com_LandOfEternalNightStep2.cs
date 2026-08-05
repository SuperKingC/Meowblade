using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvGBrawlFight;
using UI.Tips;
using UnityEngine;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_LandOfEternalNightStep2 : GComponent, IFairyComponent
{
	public Controller Step;

	public Controller isEnrolled;

	public GLoader Icon;

	public GImage n2;

	public GList Steps;

	public GImage n4;

	public GLoader n5;

	public GImage n66;

	public GTextField n7;

	public GTextField n28;

	public UI_btn_Submit goEnrollBtn;

	public GImage n57;

	public GTextField n58;

	public GImage n60;

	public GTextField Countdown3;

	public GGroup n62;

	public GImage n51;

	public GTextField n47;

	public GImage n48;

	public GImage n52;

	public GImage n53;

	public GImage n54;

	public GImage n55;

	public GImage n63;

	public GGroup n65;

	public GGroup n36;

	public GTextField n26;

	public GTextField n45;

	public GTextField TestingMuId;

	public const string URL = "ui://249h3k3diemus5s";

	public static string Name = "UI_com_LandOfEternalNightStep2";

	private bool _countDownCoroutineStarted;

	private bool Activated => Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed;

	public static string GetURL()
	{
		return "ui://249h3k3diemus5s";
	}

	public static UI_com_LandOfEternalNightStep2 CreateInstance()
	{
		return (UI_com_LandOfEternalNightStep2)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_LandOfEternalNightStep2");
	}

	public static UI_com_LandOfEternalNightStep2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfEternalNightStep2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3diemus5s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Step = ((GComponent)this).GetController("Step");
		isEnrolled = ((GComponent)this).GetController("isEnrolled");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Steps = (GList)((GComponent)this).GetChild("Steps");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://249h3k3diemus5s".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id2 = "ui://249h3k3diemus5s".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id2);
		goEnrollBtn = (UI_btn_Submit)(object)((GComponent)this).GetChild("goEnrollBtn");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GTextField)((GComponent)this).GetChild("n58");
		string id3 = "ui://249h3k3diemus5s".Replace("ui://", "") + "-" + ((GObject)n58).id;
		((GObject)n58).text = LanguagesManager.GetDesc(id3);
		n60 = (GImage)((GComponent)this).GetChild("n60");
		Countdown3 = (GTextField)((GComponent)this).GetChild("Countdown3");
		string id4 = "ui://249h3k3diemus5s".Replace("ui://", "") + "-" + ((GObject)Countdown3).id;
		((GObject)Countdown3).text = LanguagesManager.GetDesc(id4);
		n62 = (GGroup)((GComponent)this).GetChild("n62");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id5 = "ui://249h3k3diemus5s".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id5);
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n65 = (GGroup)((GComponent)this).GetChild("n65");
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id6 = "ui://249h3k3diemus5s".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id6);
		n45 = (GTextField)((GComponent)this).GetChild("n45");
		string id7 = "ui://249h3k3diemus5s".Replace("ui://", "") + "-" + ((GObject)n45).id;
		((GObject)n45).text = LanguagesManager.GetDesc(id7);
		TestingMuId = (GTextField)((GComponent)this).GetChild("TestingMuId");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
		RefreshEnrollState();
	}

	public void RegisterUiEvent()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderMainMissions = (Action<CampMainMissionUiModel>)Delegate.Combine(instance.RenderMainMissions, new Action<CampMainMissionUiModel>(UpdateUi));
		((GObject)goEnrollBtn).onClick.Set(new EventCallback0(OnClickGoEnroll));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderMainMissions = (Action<CampMainMissionUiModel>)Delegate.Remove(instance.RenderMainMissions, new Action<CampMainMissionUiModel>(UpdateUi));
		((GObject)goEnrollBtn).onClick.Clear();
	}

	private void UpdateUi(CampMainMissionUiModel model)
	{
		Render(model);
	}

	private void UpdateUi()
	{
		Render(Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightMainMission);
	}

	private void Render(CampMainMissionUiModel model)
	{
		if (Activated)
		{
			int step = model.Step;
			Step.selectedIndex = (Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement ? 2 : (step - 1));
			Steps.selectedIndex = Step.selectedIndex;
			if (Step.selectedIndex == 0 && !_countDownCoroutineStarted)
			{
				_countDownCoroutineStarted = true;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CountDownCoroutine());
			}
		}
	}

	private IEnumerator CountDownCoroutine()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		int beginDay = WorldMapConfigHelper.Configs.TryGetBrawlEvent(101).Day;
		long getEventStart = GvGMode3BrawlEvent_BaseInfo.GetAllowRegisterTimeStart(beginDay);
		while (!((GObject)this).isDisposed)
		{
			int currentTime = DateTimeHelper.ServerNowTimestamp;
			long timeRemaining = getEventStart - currentTime;
			timeRemaining = ((timeRemaining < 0) ? 0 : timeRemaining);
			((GObject)Countdown3).text = UiHelper.ParseTime((int)timeRemaining);
			if (timeRemaining <= 0)
			{
				break;
			}
			yield return wait;
		}
	}

	private void RefreshEnrollState()
	{
		Task<C2S_BrawlEvent_GetInfo.Response> task = UI_main_BrawlFightEnroll.GetBrawlEventInfo();
		task.GetAwaiter().OnCompleted(delegate
		{
			if (!((GObject)this).isDisposed)
			{
				C2S_BrawlEvent_GetInfo.Response result = task.Result;
				if (result.ErrorCode == 0)
				{
					List<BE_SignUpDataModel_ToProtocol> selfSignUpDatas = result.SelfSignUpDatas;
					bool flag = selfSignUpDatas != null && selfSignUpDatas.Count > 0;
					isEnrolled.SetSelectedIndex(flag ? 1 : 0);
				}
			}
		});
	}

	private void OnAbilityItemClick(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		if (val.data is ItemAbility itemAbility)
		{
			Vector2 val2 = default(Vector2);
			((Vector2)(ref val2))._002Ector(960f, 680f);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
			{
				{ "Pos", val2 },
				{ "Data", itemAbility.AbilityData },
				{ "Limit", 0 },
				{ "State", true },
				{ "GList", null },
				{ "SkillIconUrl", itemAbility.Icon },
				{ "Level", itemAbility.AbilityLevel }
			});
		}
	}

	private void CheckEternalNightBoss()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.TryPlayEternalNightUiTransitions(inform: true);
	}

	private void OnClickGoEnroll()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(UI_main_FlagShipMissions.Name);
		int ourFlagShipStayIslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
		GvGWorldMapController.Instance.FocusIslandById(ourFlagShipStayIslandId);
	}
}
