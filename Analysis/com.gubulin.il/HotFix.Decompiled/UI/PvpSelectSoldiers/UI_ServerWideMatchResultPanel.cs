using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideMatchResultPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_ServerWideMatchResultDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5svvbjdu4";

	public static string Name = "UI_ServerWideMatchResultPanel";

	public const string ParamKeyStageStatus = "StageStatus";

	public const string ParamKeyWarStageLotterySettlement = "WarStageLotterySettlement";

	private StageStatus _stageStatus;

	private WarStageLotterySettlement _settlement;

	public static string GetURL()
	{
		return "ui://82mo10n5svvbjdu4";
	}

	public static UI_ServerWideMatchResultPanel CreateInstance()
	{
		return (UI_ServerWideMatchResultPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideMatchResultPanel");
	}

	public static UI_ServerWideMatchResultPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideMatchResultPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5svvbjdu4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ServerWideMatchResultDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters != null)
		{
			if (parameters.ContainsKey("StageStatus"))
			{
				_stageStatus = (StageStatus)parameters["StageStatus"];
			}
			if (parameters.ContainsKey("WarStageLotterySettlement"))
			{
				_settlement = parameters["WarStageLotterySettlement"] as WarStageLotterySettlement;
			}
		}
		if (_settlement == null)
		{
			End();
			return;
		}
		SetListCountByStage();
		SetTitle();
		SetBetStatistics();
		PopulateBetSettingList();
		SetRewardDisplay();
		Dialog.Appear1.Play((PlayCompleteCallback)delegate
		{
			Dialog.Appear2.Play();
		});
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ConfirmBtn).onClick.Clear();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void SetListCountByStage()
	{
		int selectedIndex;
		switch (_stageStatus)
		{
		case StageStatus.Round1_Stage128:
		case StageStatus.Round2_Stage128:
			selectedIndex = 0;
			break;
		case StageStatus.Round1_Stage64:
		case StageStatus.Round2_Stage64:
			selectedIndex = 1;
			break;
		case StageStatus.Round1_Stage32:
		case StageStatus.Round2_Stage32:
			selectedIndex = 2;
			break;
		case StageStatus.Round1_Stage16:
		case StageStatus.Round2_Stage16:
			selectedIndex = 3;
			break;
		default:
			selectedIndex = 0;
			break;
		}
		Dialog.ListCount.selectedIndex = selectedIndex;
	}

	private void SetTitle()
	{
		string stageDescription = GetStageDescription();
		if (!string.IsNullOrEmpty(stageDescription))
		{
			((GObject)Dialog.title).text = stageDescription;
		}
	}

	private string GetStageDescription()
	{
		switch (_stageStatus)
		{
		case StageStatus.Round1_Stage128:
		case StageStatus.Round2_Stage128:
			return "ServerWideMatchResultTitle128".ToLanguage();
		case StageStatus.Round1_Stage64:
		case StageStatus.Round2_Stage64:
			return "ServerWideMatchResultTitle64".ToLanguage();
		case StageStatus.Round1_Stage32:
		case StageStatus.Round2_Stage32:
			return "ServerWideMatchResultTitle32".ToLanguage();
		case StageStatus.Round1_Stage16:
		case StageStatus.Round2_Stage16:
			return "ServerWideMatchResultTitle16".ToLanguage();
		default:
			return "ServerWideMatchResultTitleDefault".ToLanguage();
		}
	}

	private void SetBetStatistics()
	{
		if (_settlement != null)
		{
			((GObject)Dialog.BetCountText).text = _settlement.TotalLotteryCnt.ToString();
			((GObject)Dialog.BingoCountText).text = _settlement.TotalWinCnt.ToString();
			float winRate = _settlement.WinRate;
			((GObject)Dialog.BingoRateText).text = $"{winRate * 100f:F0}%";
		}
	}

	private void PopulateBetSettingList()
	{
		if (_settlement?.WarGroupLotterySettlements == null)
		{
			return;
		}
		GList targetBetSettingList = GetTargetBetSettingList();
		if (targetBetSettingList == null)
		{
			return;
		}
		Dictionary<int, WarGroupLotterySettlement> dictionary = new Dictionary<int, WarGroupLotterySettlement>();
		foreach (WarGroupLotterySettlement warGroupLotterySettlement in _settlement.WarGroupLotterySettlements)
		{
			dictionary[warGroupLotterySettlement.GroupIndex] = warGroupLotterySettlement;
		}
		Dictionary<int, List<int>> cachedWarGroupPlayers = GetCachedWarGroupPlayers();
		int userId = GameController.Contexts.gameState.user.value.UserId;
		for (int i = 0; i < targetBetSettingList.numItems; i++)
		{
			GObject childAt = ((GComponent)targetBetSettingList).GetChildAt(i);
			if (childAt == null)
			{
				continue;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (dictionary.TryGetValue(i, out var value))
			{
				if (value.WinUserIds != null && value.WinUserIds.Count > 0)
				{
					flag = true;
				}
				if (value.LossUserIds != null && value.LossUserIds.Count > 0)
				{
					flag2 = true;
				}
			}
			if (cachedWarGroupPlayers != null && cachedWarGroupPlayers.TryGetValue(i, out var value2))
			{
				flag3 = value2.Contains(userId);
			}
			GComponent asCom = childAt.asCom;
			if (asCom != null)
			{
				asCom.GetController("IsBingo").selectedIndex = (flag ? 1 : 0);
				asCom.GetController("HasBet").selectedIndex = (flag2 ? 1 : 0);
				asCom.GetController("IsMeIn").selectedIndex = (flag3 ? 1 : 0);
			}
			childAt.touchable = false;
		}
	}

	private Dictionary<int, List<int>> GetCachedWarGroupPlayers()
	{
		if (RankDataHelper.AllServersChampionshipInfo?.MatchInfoDict != null && RankDataHelper.AllServersChampionshipInfo.MatchInfoDict.TryGetValue(_stageStatus, out var value))
		{
			return value.WarGroupPlayers;
		}
		return null;
	}

	private GList GetTargetBetSettingList()
	{
		switch (_stageStatus)
		{
		case StageStatus.Round1_Stage128:
		case StageStatus.Round2_Stage128:
			return Dialog.BetSettingList1;
		case StageStatus.Round1_Stage64:
		case StageStatus.Round2_Stage64:
			return Dialog.BetSettingList2;
		case StageStatus.Round1_Stage32:
		case StageStatus.Round2_Stage32:
			return Dialog.BetSettingList3;
		case StageStatus.Round1_Stage16:
		case StageStatus.Round2_Stage16:
			return Dialog.BetSettingList4;
		default:
			return null;
		}
	}

	private void SetRewardDisplay()
	{
		if (_settlement?.RItemBonus == null || _settlement.RItemBonus.Count == 0)
		{
			return;
		}
		string lotteryRewardItemId = RankDataHelper.GetLotteryRewardItemId(_stageStatus);
		if (!string.IsNullOrEmpty(lotteryRewardItemId))
		{
			Dialog.BetRewardCountLabel.RewardItemIcon.url = UiHelper.GetItemIconPath(lotteryRewardItemId);
		}
		int num = 0;
		foreach (RItem rItemBonu in _settlement.RItemBonus)
		{
			num += rItemBonu.cnt;
		}
		((GObject)Dialog.BetRewardCountLabel.CountText).text = $"x{num}";
	}
}
