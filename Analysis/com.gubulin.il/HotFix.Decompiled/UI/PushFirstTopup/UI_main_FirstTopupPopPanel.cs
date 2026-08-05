using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GameActivity;
using UnityEngine;

namespace UI.PushFirstTopup;

public class UI_main_FirstTopupPopPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_FirstTopupDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://r9ncs56ehni6v44c";

	public static string Name = "UI_main_FirstTopupPopPanel";

	public const string FirstRechargeActivityId = "FirstRecharge1";

	public const string PackageName = "PushFirstTopup";

	private static bool HaveCalledThisFunction;

	private Mission _firstTopUpMission;

	private Activity _firstTopUpActivity;

	public static string GetURL()
	{
		return "ui://r9ncs56ehni6v44c";
	}

	public static UI_main_FirstTopupPopPanel CreateInstance()
	{
		return (UI_main_FirstTopupPopPanel)(object)UIPackage.CreateObject("PushFirstTopup", "main_FirstTopupPopPanel");
	}

	public static UI_main_FirstTopupPopPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FirstTopupPopPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_FirstTopupDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public static bool TryShow()
	{
		if (HaveCalledThisFunction)
		{
			return false;
		}
		HaveCalledThisFunction = true;
		if (!CheckWillShow())
		{
			return false;
		}
		UnityUiService.Instance.OpenPanel(Name, new Dictionary<string, object>());
		return true;
	}

	private static bool CheckWillShow()
	{
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return false;
		}
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level <= 0)
		{
			return false;
		}
		Dictionary<string, List<string>> levelProgress = GameManagers.Instance.UserArchiveManager.GetLevelProgress();
		if (!levelProgress.TryGetValue("C1001", out var value) || !value.Contains("P105"))
		{
			return false;
		}
		Activity activity = ActivityManager.Activities["FirstRecharge1"];
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)activity.ContentPayload(GameManagers.Instance).Values.First();
		Mission mission = missionSerialActivityPayload.Missions(GameManagers.Instance).First();
		MissionStatus status = mission.MissionState(GameManagers.Instance).Status;
		if (status != MissionStatus.Undergoing && status != MissionStatus.Completed && status != MissionStatus.Pending)
		{
			return false;
		}
		return true;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Dialog.RechargeBtn).onClick.Set(new EventCallback1(OnClickClaimBtn));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.RechargeBtn).onClick.Clear();
		((GObject)Mask).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
	}

	public void OnShow()
	{
		RefreshPage(showAnim: true);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void OnMissionChanged(Mission mission)
	{
		RefreshPage(showAnim: false);
	}

	private async void RefreshPage(bool showAnim)
	{
		if (!ActivityManager.Activities.TryGetValue("FirstRecharge1", out var activity))
		{
			End();
			return;
		}
		MissionSerialActivityPayload payload = (MissionSerialActivityPayload)activity.ContentPayload(GameManagers.Instance).Values.First();
		Mission mission = payload.Missions(GameManagers.Instance).First();
		_firstTopUpActivity = activity;
		_firstTopUpMission = mission;
		UI_com_FirstTopupDialog rewardPanel = Dialog;
		List<string> checkingActivities = new List<string> { activity.ActivityId };
		if (activity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			await GameManagers.Instance.ActivityManager.ReviewActivities(checkingActivities);
		}
		switch (mission.MissionState(GameManagers.Instance).Status)
		{
		case MissionStatus.Undergoing:
			rewardPanel.BtnStatus.selectedIndex = 0;
			break;
		case MissionStatus.Completed:
			rewardPanel.BtnStatus.selectedIndex = 1;
			break;
		case MissionStatus.Claimed:
			rewardPanel.BtnStatus.selectedIndex = 2;
			break;
		default:
			End();
			return;
		}
		((GObject)rewardPanel.MainReward.price).text = LanguagesManager.GetDesc("CsharpCodeZhTcText210");
		((GObject)rewardPanel.MainReward.num).text = $"{mission.BonusList.First().Qty}";
		rewardPanel.MainReward.num.strokeColor = new Color(0f, 0f, 0f, 0.55f);
		string mainItemId = mission.BonusList.First().ItemId;
		rewardPanel.MainReward.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(mainItemId);
		((GObject)rewardPanel.MainReward.icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(mainItemId, 2);
		});
		rewardPanel.rewardList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			Bonus bonus = mission.BonusList[index + 1];
			string itemId = bonus.ItemId;
			UI_RechargeReward uI_RechargeReward = (UI_RechargeReward)(object)item;
			((GObject)uI_RechargeReward.price).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, itemId);
			((GObject)uI_RechargeReward.num).text = bonus.Qty.ShortNumberFormat() ?? "";
			((GComponent)uI_RechargeReward).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			((GObject)((GComponent)uI_RechargeReward).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, 2);
			});
		};
		rewardPanel.rewardList.numItems = mission.BonusList.Count - 1;
		((GObject)rewardPanel.RechargeBtn).data = mission;
		if (showAnim)
		{
			ShowDialog.Play();
		}
	}

	private void OnClickClaimBtn(EventContext context)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		Mission mission = (Mission)((GObject)context.sender).data;
		if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
		{
			UI_ActivityPanel.OnClickGoTopUp();
		}
		else
		{
			if (mission.MissionState(GameManagers.Instance).Status != MissionStatus.Completed)
			{
				return;
			}
			ILRequestHelper<MissionClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id), delegate(MissionClaimResponse response)
			{
				if (!response.Result)
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText222") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText223") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
					List<Bonus> list = new List<Bonus>();
					Dictionary<string, float> dictionary = new Dictionary<string, float>();
					foreach (ModelsBonus bonus2 in response.BonusList)
					{
						Bonus bonus = Bonus.Get(bonus2.ItemId, bonus2.Qty, bonus2.Type, bonus2.IsShining);
						bonus.Claim(GameManagers.Instance, dictionary, null, forceClaim: true, broadcastInform: false);
						list.Add(bonus);
					}
					FGUIManager.Instance.OpenTakeItemsPanelForPack(LanguagesManager.GetDesc("CsharpCodeZhTcText211"), list, dictionary.ToList(), "ui://Tips/艺术字-确认黄-text", this);
					ThinkingDataHelper.Instance.FirstpayRewardTrack();
					RefreshPage(showAnim: false);
				}
			}, 1f);
		}
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
