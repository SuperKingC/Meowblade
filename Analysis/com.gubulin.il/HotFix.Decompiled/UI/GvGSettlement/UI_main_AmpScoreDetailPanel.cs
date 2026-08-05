using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGSettlement;

public class UI_main_AmpScoreDetailPanel : GComponent, IUiController
{
	public class QualityScoreData
	{
		public int Count;

		public int Score;
	}

	public GGraph back;

	public UI_com_AmpScoreDetailDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://91jxdrkacgcr2z";

	public static string Name = "UI_main_AmpScoreDetailPanel";

	public static string GetURL()
	{
		return "ui://91jxdrkacgcr2z";
	}

	public static UI_main_AmpScoreDetailPanel CreateInstance()
	{
		return (UI_main_AmpScoreDetailPanel)(object)UIPackage.CreateObject("GvGSettlement", "main_AmpScoreDetailPanel");
	}

	public static UI_main_AmpScoreDetailPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_AmpScoreDetailPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkacgcr2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_AmpScoreDetailDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		AmpConfigHelper.Init();
		((GObject)Dialog.n33).text = ((GObject)Dialog.n33).data.ToString();
		((GObject)Dialog.n35).text = ((GObject)Dialog.n35).data.ToString();
		((GObject)Dialog.n36).text = ((GObject)Dialog.n36).data.ToString();
		Render();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.CloseBtn).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.CloseBtn).onClick.Clear();
	}

	private void Render()
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		SkyIslandSettlement_AmplifierDetail amplifierDetail = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.AmplifierDetail;
		bool amplifierDetail_RewardIsClaimed = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.AmplifierDetail_RewardIsClaimed;
		List<BonusData> reward = new List<BonusData>();
		foreach (KeyValuePair<string, int> item in amplifierDetail.Reward)
		{
			reward.Add(new BonusData
			{
				ItemId = item.Key,
				Count = item.Value,
				IsClaimed = amplifierDetail_RewardIsClaimed
			});
		}
		((GObject)Dialog.Score).text = amplifierDetail.Score.ToString();
		Dialog.BonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderAmplifierBonusItem(i, (UI_com_BonusSlot2)(object)o, reward);
		};
		Dialog.BonusList.numItems = reward.Count;
		Dictionary<int, QualityScoreData> scoreData_Dict = new Dictionary<int, QualityScoreData>();
		foreach (KeyValuePair<string, int> item2 in amplifierDetail.AllCount)
		{
			int idx = int.Parse(item2.Key);
			int value = item2.Value;
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
			if (!scoreData_Dict.TryGetValue(amplifierModel.Quality, out var value2))
			{
				value2 = new QualityScoreData
				{
					Count = 0,
					Score = 0
				};
				scoreData_Dict.Add(amplifierModel.Quality, value2);
			}
			value2.Count += value;
			value2.Score += amplifierModel.SettlementScore * value;
		}
		Dialog.ScoreList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderAmpDetailSlot(i, (UI_com_AmpDetailSlot)(object)o, scoreData_Dict);
		};
		Dialog.ScoreList.numItems = Dialog.ScoreList.numItems;
	}

	private void RenderAmplifierBonusItem(int index, UI_com_BonusSlot2 slot, List<BonusData> reward)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		BonusData bonus = reward[index];
		slot.BonusItem.Icon.url = "ui://PublicResources/" + UiHelper.GetIcon(bonus.ItemId);
		slot.IsClaimed.selectedIndex = (bonus.IsClaimed ? 1 : 0);
		((GObject)slot.Count).text = "x" + bonus.Count.ShortNumberFormat();
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bonus.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void RenderAmpDetailSlot(int i, UI_com_AmpDetailSlot slot, Dictionary<int, QualityScoreData> scoreData_Dict)
	{
		int selectedIndex = slot.Quatity.selectedIndex;
		if (!scoreData_Dict.TryGetValue(selectedIndex, out var value))
		{
			value = new QualityScoreData
			{
				Count = 0,
				Score = 0
			};
		}
		((GObject)slot.Count).text = $"{value.Count}";
		((GObject)slot.Score).text = $"{value.Score}";
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}
}
