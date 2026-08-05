using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.GvGTalent;
using UI.Tips;
using UnityEngine;

namespace UI.GvG3SupplyDepot;

public class UI_com_DailyReward : GComponent, IFairyComponent
{
	public GTextField n1;

	public UI_com_Contribution Contributions;

	public UI_com_DailySupply DailySupply;

	public const string URL = "ui://pobej4q7mo53d";

	public static string Name = "UI_com_DailyReward";

	private const int DailySupplyTalentIdx = 232;

	private const int ContributionBoxRewardMaxCount = 5;

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	public Action ShowContributionBoxConfigAction = delegate
	{
	};

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://pobej4q7mo53d";
	}

	public static UI_com_DailyReward CreateInstance()
	{
		return (UI_com_DailyReward)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_DailyReward");
	}

	public static UI_com_DailyReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DailyReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://pobej4q7mo53d".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		Contributions = (UI_com_Contribution)(object)((GComponent)this).GetChild("Contributions");
		DailySupply = (UI_com_DailySupply)(object)((GComponent)this).GetChild("DailySupply");
	}

	public void Destroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init()
	{
		Singleton<GvG3SupplyDepotManager>.Instance.GetContributionItemInfo();
		UpdateCountdown();
	}

	public void RegisterUiEvent()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		GvG3SupplyDepotManager instance = Singleton<GvG3SupplyDepotManager>.Instance;
		instance.UpdateUi = (Action)Delegate.Combine(instance.UpdateUi, new Action(Render));
		((GObject)Contributions.Receive).onClick.Set(new EventCallback0(ClaimContributionReward));
		((GObject)Contributions.BoxDetail).onClick.Set(new EventCallback0(ShowContributionBoxConfig));
		((GObject)DailySupply.Activate).onClick.Set(new EventCallback0(GotoActivateTalent));
		((GObject)DailySupply.Receive).onClick.Set(new EventCallback0(ClaimDailySupplyBox));
		SharedMessenger.AddListener<int>("GVG3_TALENT_ACTIVATED", OnTalentActivated);
	}

	public void UnregisterUiEvent()
	{
		GvG3SupplyDepotManager instance = Singleton<GvG3SupplyDepotManager>.Instance;
		instance.UpdateUi = (Action)Delegate.Remove(instance.UpdateUi, new Action(Render));
		((GObject)Contributions.Receive).onClick.Clear();
		((GObject)Contributions.BoxDetail).onClick.Clear();
		((GObject)DailySupply.Activate).onClick.Clear();
		((GObject)DailySupply.Receive).onClick.Clear();
		SharedMessenger.RemoveListener<int>("GVG3_TALENT_ACTIVATED", OnTalentActivated);
	}

	private void Render()
	{
		ContributionsRenderer();
		DailySupplyRenderer();
	}

	private void UpdateCountdown()
	{
		DateTimeOffset dateTimeOffset = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0);
		_updateCountdown = FGUIManager.Instance.OpenIEnumerator(UpdateFoodRefreshCountdown(DateTimeHelper.GetTimeStamp(dateTimeOffset)));
	}

	private IEnumerator UpdateFoodRefreshCountdown(int nextDayRefreshTimestamp)
	{
		while (!((GObject)this).isDisposed)
		{
			string countdownText = UiHelper.ParseTimeShort(nextDayRefreshTimestamp - CurrentTimestamp);
			if (Contributions.Type.selectedIndex == 1)
			{
				((GObject)Contributions.Countdown).text = countdownText;
			}
			if (DailySupply.Type.selectedIndex == 2)
			{
				((GObject)DailySupply.Countdown).text = countdownText;
			}
			yield return _perSecond;
		}
	}

	private void ContributionsRenderer()
	{
		int num = (int)Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.TotalContributionScore_NoBattlePass;
		bool flag = Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.YesterdayClaimed || Singleton<WorldStateManager>.Instance.Data.UserPlayDays == 1;
		Contributions.Type.selectedIndex = (flag ? 1 : 0);
		Contributions.BoxIcon.url = Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.ContributionBoxIcon;
		((GObject)Contributions.TotalContribution).text = num.ToString();
		ContributionItemsRenderer(out var hasContributions);
		if (!flag)
		{
			ContributionBoxDetail();
		}
		else
		{
			Contributions.ScoreToday.selectedIndex = ((!hasContributions) ? 1 : 0);
		}
	}

	private void ContributionBoxDetail()
	{
		List<string> contributionBoxItems = Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.ContributionBoxItems;
		for (int i = 0; i < 5; i++)
		{
			GObject val = ((GComponent)Contributions).GetChild($"Item{i}") ?? throw new Exception($"ContributionBoxDetail:Item{i} RewardItem is non-existent");
			if (val is UI_com_RewardItem uI_com_RewardItem)
			{
				if (i >= contributionBoxItems.Count)
				{
					val.visible = false;
					continue;
				}
				val.visible = true;
				uI_com_RewardItem.icon.url = UiHelper.GetIcon(contributionBoxItems[i]).ToPublicResourceIcon();
				uI_com_RewardItem.icon.InitMaterialIntroductionBtn(contributionBoxItems[i]);
			}
		}
	}

	private void ContributionItemsRenderer(out bool hasContributions)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		List<Contribution> infos = Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.ContributionInfo_NoBattlePass.ToList();
		infos.Sort(ContributionInfoSort);
		Contributions.Contributions.itemRenderer = new ListItemRenderer(ItemRenderer);
		Contributions.Contributions.numItems = infos.Count;
		hasContributions = infos.Count > 0;
		void ItemRenderer(int index, GObject obj)
		{
			if (obj is UI_com_ContributionDetail uI_com_ContributionDetail)
			{
				Contribution contribution = infos[index];
				((GObject)uI_com_ContributionDetail.Desc).text = ("GvG3Contribution_" + contribution.Key).ToLanguage();
				((GObject)uI_com_ContributionDetail.Score).text = $"{contribution.Value}";
			}
		}
	}

	public static int ContributionInfoSort(Contribution a, Contribution b)
	{
		return (a.Value > b.Value) ? (-1) : ((a.Value < b.Value) ? 1 : 0);
	}

	private void ClaimContributionReward()
	{
		Singleton<GvG3SupplyDepotManager>.Instance.ClaimYesterdayContributionItems();
	}

	private void ShowContributionBoxConfig()
	{
		ShowContributionBoxConfigAction?.Invoke();
	}

	private void DailySupplyRenderer()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		DailySupply.Type.selectedIndex = Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.DailySupplyStatus();
		DailySupply.BoxIcon.url = UiHelper.GetIcon(Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.DailySupplyBoxItemId).ToPublicResourceIcon();
		((GObject)DailySupply.BoxIcon).onClick.Set(new EventCallback0(ShowDailySupplyBoxDetail));
		static void ShowDailySupplyBoxDetail()
		{
			FGUIManager.Instance.ItemTip(Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.DailySupplyBoxItemId, 1, noCheckBtn: true);
		}
	}

	private void GotoActivateTalent()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGTalentPanel.Name, new Dictionary<string, object>
		{
			{ "AreaIdx", -2 },
			{ "TalentIdx", 232 }
		});
	}

	private void OnTalentActivated(int talentIdx)
	{
		if (talentIdx == 232)
		{
			Singleton<GvG3SupplyDepotManager>.Instance.GetContributionItemInfo();
		}
	}

	private void ClaimDailySupplyBox()
	{
		Singleton<GvG3SupplyDepotManager>.Instance.GetTalentDailySupplyBox(PlayGetDailySupplyBoxSfx);
	}

	private void PlayGetDailySupplyBoxSfx()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		((GObject)DailySupply.TalentIcon).SetPivot(0.5f, 0.5f, true);
		Vector2 startPos = ((GObject)DailySupply.TalentIcon).LocalToGlobal(new Vector2(((GObject)DailySupply.TalentIcon).width, ((GObject)DailySupply.TalentIcon).height) / 2f);
		Vector2 endPos = ((GObject)DailySupply.GetDaukyBonusSfxEndPos).LocalToGlobal(new Vector2(((GObject)DailySupply.GetDaukyBonusSfxEndPos).width, ((GObject)DailySupply.GetDaukyBonusSfxEndPos).height) / 2f);
		UnityUiService.Instance.ShowGetBonusItemSfx(startPos, endPos);
	}
}
