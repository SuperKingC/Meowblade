using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using UI.Tips;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_SideQuests : GComponent, IFairyComponent
{
	public Controller Type;

	public GImage back;

	public GImage n6;

	public GTextField n3;

	public GTextField n4;

	public GList Quests;

	public UI_btn_ReceiveSideQuestReward Receive;

	public GTextField n7;

	public GTextField n8;

	public const string URL = "ui://249h3k3dvihg1x";

	public static string Name = "UI_com_SideQuests";

	private bool IsEternalNight => Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress;

	public static string GetURL()
	{
		return "ui://249h3k3dvihg1x";
	}

	public static UI_com_SideQuests CreateInstance()
	{
		return (UI_com_SideQuests)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_SideQuests");
	}

	public static UI_com_SideQuests CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SideQuests).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg1x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://249h3k3dvihg1x".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://249h3k3dvihg1x".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Quests = (GList)((GComponent)this).GetChild("Quests");
		Receive = (UI_btn_ReceiveSideQuestReward)(object)((GComponent)this).GetChild("Receive");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://249h3k3dvihg1x".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://249h3k3dvihg1x".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
	}

	public void Destroy()
	{
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderSideMissions = (Action<List<CampSideMissionsUiModel>>)Delegate.Combine(instance.RenderSideMissions, new Action<List<CampSideMissionsUiModel>>(Render));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderSideMissions = (Action<List<CampSideMissionsUiModel>>)Delegate.Remove(instance.RenderSideMissions, new Action<List<CampSideMissionsUiModel>>(Render));
	}

	private void Render(List<CampSideMissionsUiModel> missions)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		missions.Sort((CampSideMissionsUiModel a, CampSideMissionsUiModel b) => a.DisplayMissionStatus - b.DisplayMissionStatus);
		CampSideMissionsUiModel canClaim = missions.Find((CampSideMissionsUiModel ms) => ms.DisplayMissionStatus == 0);
		((GObject)Receive).enabled = canClaim != null;
		((GObject)Receive).onClick.Set(new EventCallback0(ClaimBonus));
		CampSideMissionsUiModel expandedModel = null;
		Quests.SetVirtual();
		Quests.itemProvider = new ListItemProvider(GetListItemResource);
		Quests.itemRenderer = new ListItemRenderer(GroupRenderer);
		Quests.numItems = missions.Count;
		Type.selectedIndex = (IsEternalNight ? 1 : 0);
		void ClaimBonus()
		{
			if (canClaim != null)
			{
				Singleton<GvG3FlagShipMissionsManager>.Instance.ClaimMission(canClaim.DisplayMission.MUid);
			}
		}
		string GetListItemResource(int index)
		{
			CampSideMissionsUiModel campSideMissionsUiModel = missions[index];
			return campSideMissionsUiModel.Expanded ? "ui://GvG3MainStorylineQuest/btn_SideQuestExpanded" : "ui://GvG3MainStorylineQuest/btn_SideQuest";
		}
		void GroupRenderer(int index, GObject obj)
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Expected O, but got Unknown
			CampSideMissionsUiModel groupInfo = missions[index];
			if (groupInfo.Expanded && obj is UI_btn_SideQuestExpanded uI_btn_SideQuestExpanded)
			{
				((GObject)uI_btn_SideQuestExpanded).onClick.Clear();
				uI_btn_SideQuestExpanded.Quests.itemRenderer = new ListItemRenderer(MissionRenderer);
				uI_btn_SideQuestExpanded.Quests.numItems = groupInfo.SideMissions.Count;
				uI_btn_SideQuestExpanded.Quests.ResizeToFit(groupInfo.SideMissions.Count);
			}
			else if (obj is UI_btn_SideQuest uI_btn_SideQuest)
			{
				uI_btn_SideQuest.Type.selectedIndex = (IsEternalNight ? 1 : 0);
				uI_btn_SideQuest.Status.selectedIndex = groupInfo.DisplayMissionStatus;
				((GObject)uI_btn_SideQuest.QuestDesc).text = groupInfo.DisplayMission.Data.Desc;
				((GObject)uI_btn_SideQuest.AddCampEnergy).text = groupInfo.DisplayMission.AddCampEnergy.ToString();
				((GObject)uI_btn_SideQuest.BonusNumber).text = groupInfo.DisplayMission.BonusNumber.ToString();
				string oldItemId = groupInfo.DisplayMission.BonusItemId;
				FGUIManager.Instance.ItemIdReplace(ref oldItemId);
				uI_btn_SideQuest.RewardIcon.url = UiHelper.GetIcon(oldItemId).ToPublicResourceIcon();
				uI_btn_SideQuest.RewardIcon.InitMaterialIntroductionBtn(oldItemId);
				long num = ((groupInfo.DisplayMission.ProgressValue.Count <= 0) ? 0 : groupInfo.DisplayMission.ProgressValue[0]);
				long num2 = groupInfo.DisplayMission.CheckValues[0];
				((GProgressBar)uI_btn_SideQuest.Progress).value = (double)num / (double)num2 * 100.0;
				bool flag = groupInfo.DisplayMissionStatus == 0;
				if (flag)
				{
					((GProgressBar)uI_btn_SideQuest.Progress).value = 100.0;
				}
				((GObject)uI_btn_SideQuest.Progress.Progress).text = num.ShortNumberFormat() + "/" + num2.ShortNumberFormat();
				uI_btn_SideQuest.Progress.Status.selectedIndex = (flag ? 1 : 0);
				uI_btn_SideQuest.Selected.selectedIndex = ((index == Quests.selectedIndex) ? 1 : 0);
				((GObject)uI_btn_SideQuest).data = index;
				((GObject)uI_btn_SideQuest).onClick.Set(new EventCallback1(GroupUiOnChanged));
				if (Define.GvGMode3UnderTesting)
				{
					GTextField questDesc = uI_btn_SideQuest.QuestDesc;
					((GObject)questDesc).text = ((GObject)questDesc).text + $"({groupInfo.DisplayMission.MUid})";
				}
			}
			void MissionRenderer(int missionIndex, GObject missionUi)
			{
				if (missionUi is UI_com_SideQuest uI_com_SideQuest)
				{
					GvG3FlagShipMissionModel gvG3FlagShipMissionModel = groupInfo.SideMissions[missionIndex];
					uI_com_SideQuest.Status.selectedIndex = gvG3FlagShipMissionModel.UiStatus;
					uI_com_SideQuest.Claimed.selectedIndex = (gvG3FlagShipMissionModel.HasClaimed ? 1 : 0);
					((GObject)uI_com_SideQuest.QuestDesc).text = gvG3FlagShipMissionModel.Data.Desc;
					((GObject)uI_com_SideQuest.BonusNumber).text = gvG3FlagShipMissionModel.BonusNumber.ToString();
					string oldItemId2 = gvG3FlagShipMissionModel.BonusItemId;
					FGUIManager.Instance.ItemIdReplace(ref oldItemId2);
					uI_com_SideQuest.RewardIcon.url = UiHelper.GetIcon(oldItemId2).ToPublicResourceIcon();
					if (Define.GvGMode3UnderTesting)
					{
						GTextField questDesc2 = uI_com_SideQuest.QuestDesc;
						((GObject)questDesc2).text = ((GObject)questDesc2).text + $"({gvG3FlagShipMissionModel.MUid})";
					}
				}
			}
		}
		void GroupUiOnChanged(EventContext context)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			int num = (int)((GObject)context.sender).data;
			CampSideMissionsUiModel campSideMissionsUiModel = missions[num];
			if (campSideMissionsUiModel.CanClick)
			{
				if (expandedModel == null)
				{
					expandedModel = new CampSideMissionsUiModel
					{
						Expanded = true
					};
				}
				if (missions.Contains(expandedModel))
				{
					missions.Remove(expandedModel);
				}
				if (campSideMissionsUiModel.GroupId != expandedModel.GroupId)
				{
					expandedModel.GroupId = campSideMissionsUiModel.GroupId;
					expandedModel.SideMissions = campSideMissionsUiModel.SideMissions;
					missions.Insert(missions.IndexOf(campSideMissionsUiModel) + 1, expandedModel);
					Quests.selectedIndex = num;
				}
				else
				{
					expandedModel.GroupId = 0;
					Quests.selectedIndex = -1;
				}
				Quests.numItems = missions.Count;
			}
		}
	}
}
