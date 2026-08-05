using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.GvGOEMForge3;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_com_CampOEMMissions : GComponent
{
	public Controller RefreshController;

	public Controller HaveMission;

	public GImage n5;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public GImage n15;

	public GImage n18;

	public GImage n17;

	public GGroup n14;

	public GImage n6;

	public GList Missions;

	public UI_btn_Refresh Refresh;

	public GTextField Countdown;

	public GTextField n10;

	public const string URL = "ui://tt2iq07onhzvq";

	public static string Name = "UI_com_CampOEMMissions";

	private Coroutine _updateMissionState;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	public static string GetURL()
	{
		return "ui://tt2iq07onhzvq";
	}

	public static UI_com_CampOEMMissions CreateInstance()
	{
		return (UI_com_CampOEMMissions)(object)UIPackage.CreateObject("GvGExchange3", "com_CampOEMMissions");
	}

	public static UI_com_CampOEMMissions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampOEMMissions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzvq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RefreshController = ((GComponent)this).GetController("RefreshController");
		HaveMission = ((GComponent)this).GetController("HaveMission");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Missions = (GList)((GComponent)this).GetChild("Missions");
		Refresh = (UI_btn_Refresh)(object)((GComponent)this).GetChild("Refresh");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://tt2iq07onhzvq".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
	}

	public void Init()
	{
		Missions.SetVirtual();
		Singleton<GvG3FlagshipReqManager>.Instance.GetOemMissions();
	}

	public void Destroy()
	{
		if (_updateMissionState != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMissionState);
		}
	}

	private void Renderer(OemMissionsModel missionsModel)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		if (_updateMissionState != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMissionState);
		}
		RefreshController.selectedIndex = (missionsModel.CanRefresh(out var countdown) ? 1 : 0);
		((GObject)Countdown).text = UiHelper.ParseTimeShort(countdown);
		Missions.itemRenderer = new ListItemRenderer(MissionRenderer);
		Missions.numItems = missionsModel.Missions.Count;
		HaveMission.selectedIndex = ((missionsModel.Missions.Count <= 0) ? 1 : 0);
		_updateMissionState = FGUIManager.Instance.OpenIEnumerator(UpdateMissionsState());
		void MissionRenderer(int index, GObject obj)
		{
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			UI_com_OEMMission btn = obj as UI_com_OEMMission;
			if (btn != null)
			{
				OemMissionToProtocol oemMissionToProtocol = missionsModel.Missions[index];
				btn.Status.selectedIndex = oemMissionToProtocol.UiState;
				btn.DoubleRewards.selectedIndex = (oemMissionToProtocol.IsExtra ? 1 : 0);
				((GObject)btn.Countdown).text = UiHelper.ParseTimeShort(oemMissionToProtocol.MissionCountdown);
				RenderHelper_AmplifierIcon.RenderAmplifier(btn.Amplifier.AmplifierIcon, oemMissionToProtocol.AmpIdx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(btn.Amplifier.AffectedRange, oemMissionToProtocol.AmpIdx);
				GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", oemMissionToProtocol.GiverUserId, delegate(UserProfile profile)
				{
					((GObject)btn.UserName).text = FGUIManager.Instance.TruncateTextLength(profile.Name, 14, string.Empty);
				}));
				((GObject)btn).data = index;
				((GObject)btn).onClick.Set(new EventCallback1(ShowMissionDetail));
			}
		}
		void ShowMissionDetail(EventContext context)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			int index = (int)((GObject)context.sender).data;
			OemMissionToProtocol oemMissionToProtocol = missionsModel.Missions[index];
			if (oemMissionToProtocol.UiState != 1)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3OemForge.Name, new Dictionary<string, object> { { "OemMission", oemMissionToProtocol } });
			}
		}
		void UpdateMissionsCountdown()
		{
			for (int i = 0; i < ((GComponent)Missions).numChildren; i++)
			{
				int num = Missions.ChildIndexToItemIndex(i);
				if (((GComponent)Missions).GetChildAt(num) is UI_com_OEMMission uI_com_OEMMission)
				{
					OemMissionToProtocol oemMissionToProtocol = missionsModel.Missions[num];
					uI_com_OEMMission.Status.selectedIndex = oemMissionToProtocol.UiState;
					((GObject)uI_com_OEMMission.Countdown).text = UiHelper.ParseTimeShort(oemMissionToProtocol.MissionCountdown);
				}
			}
		}
		void UpdateMissionsRefreshCountdown()
		{
			RefreshController.selectedIndex = (missionsModel.CanRefresh(out var countdown2) ? 1 : 0);
			((GObject)Countdown).text = UiHelper.ParseTimeShort(countdown2);
		}
		IEnumerator UpdateMissionsState()
		{
			while (!((GObject)Missions).isDisposed)
			{
				yield return _perSecond;
				UpdateMissionsCountdown();
				UpdateMissionsRefreshCountdown();
			}
		}
	}

	public void RegisterUiEvent()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.UpdateOemMissions = (Action<OemMissionsModel>)Delegate.Combine(instance.UpdateOemMissions, new Action<OemMissionsModel>(Renderer));
		((GObject)Refresh).onClick.Set(new EventCallback0(RefreshOemMissions));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.UpdateOemMissions = (Action<OemMissionsModel>)Delegate.Remove(instance.UpdateOemMissions, new Action<OemMissionsModel>(Renderer));
		((GObject)Refresh).onClick.Clear();
	}

	private void RefreshOemMissions()
	{
		Singleton<GvG3FlagshipReqManager>.Instance.GetNewOemMissions();
	}
}
