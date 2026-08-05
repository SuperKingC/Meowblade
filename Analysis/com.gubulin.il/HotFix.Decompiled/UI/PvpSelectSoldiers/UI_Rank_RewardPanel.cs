using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_Rank_RewardPanel : GButton, IUiController
{
	public GGraph Mask;

	public GImage Background;

	public GImage TextRewardPreview;

	public UI_ListGroup GroupList;

	public UI_SeasonRewardPreview SeasonReward;

	public GTextField n22;

	public const string URL = "ui://82mo10n5pswlda9";

	public static string Name = "UI_Rank_RewardPanel";

	private List<tRankBaseBonus> ScoreBonus => RankDataHelper.RankStartGameInfo.ScoreBonus;

	private GList RankList => GroupList.ScoreBonuses.RanKList;

	public static string GetURL()
	{
		return "ui://82mo10n5pswlda9";
	}

	public static UI_Rank_RewardPanel CreateInstance()
	{
		return (UI_Rank_RewardPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "Rank_RewardPanel");
	}

	public static UI_Rank_RewardPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Rank_RewardPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5pswlda9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Background = (GImage)((GComponent)this).GetChild("Background");
		TextRewardPreview = (GImage)((GComponent)this).GetChild("TextRewardPreview");
		GroupList = (UI_ListGroup)(object)((GComponent)this).GetChild("GroupList");
		SeasonReward = (UI_SeasonRewardPreview)(object)((GComponent)this).GetChild("SeasonReward");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id = "ui://82mo10n5pswlda9".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		SeasonReward.RenderReward();
		if (RankDataHelper.IsServerWideBattle)
		{
		}
	}

	public void OnShow()
	{
		GList asList = ((GComponent)GroupList).GetChild("PointList").asList;
		List<tRankBaseBonus> rankBonus = RankDataHelper.RankStartGameInfo.RankBonus;
		for (int i = 0; i <= 7; i++)
		{
			Dictionary<string, object> bonus = rankBonus[i].Bonus;
			foreach (string key in bonus.Keys)
			{
				GComponent asCom = ((GComponent)asList).GetChildAt(i).asCom;
				GList asList2 = asCom.GetChild("PointList").asList;
				GObject gobj = asList2.AddItemFromPool(UI_ItemButton.GetURL());
				Render(gobj, key, (int)bonus[key]);
			}
		}
		RenderScoreBonus();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderScoreBonus()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		RankDataHelper.ScoreBonusSort(ScoreBonus);
		RankList.SetVirtual();
		RankList.itemProvider = new ListItemProvider(ScoreBonusProvider);
		RankList.itemRenderer = new ListItemRenderer(ScoreBonusRenderer);
		RankList.numItems = ScoreBonus.Count;
	}

	private string ScoreBonusProvider(int index)
	{
		tRankBaseBonus tRankBaseBonus = ScoreBonus[index];
		return (tRankBaseBonus.StartIdx != tRankBaseBonus.EndIdx) ? "ui://82mo10n5pmghdnk" : "ui://82mo10n5pmghdnj";
	}

	private void ScoreBonusRenderer(int index, GObject obj)
	{
		tRankBaseBonus tRankBaseBonus = ScoreBonus[index];
		if (tRankBaseBonus.StartIdx != tRankBaseBonus.EndIdx)
		{
			OtherScoreBonusRenderer(tRankBaseBonus, obj as UI_RankNo);
		}
		else
		{
			TopThreeScoreBonusRenderer(tRankBaseBonus, obj as UI_RankTopThree);
		}
	}

	private void TopThreeScoreBonusRenderer(tRankBaseBonus bonus, UI_RankTopThree ui)
	{
		ui.RankType.SetSelectedIndex(bonus.StartIdx - 1);
		ui.NoList.RemoveChildrenToPool();
		foreach (KeyValuePair<string, object> bonu in bonus.Bonus)
		{
			GObject gobj = ui.NoList.AddItemFromPool(UI_ItemButton.GetURL());
			Render(gobj, bonu.Key, (int)bonu.Value);
		}
	}

	private void OtherScoreBonusRenderer(tRankBaseBonus bonus, UI_RankNo ui)
	{
		((GObject)ui.StartIndex).text = bonus.StartIdx.ToString();
		((GObject)ui.EndIndex).text = bonus.EndIdx.ToString();
		ui.NoList.RemoveChildrenToPool();
		foreach (KeyValuePair<string, object> bonu in bonus.Bonus)
		{
			GObject gobj = ui.NoList.AddItemFromPool(UI_ItemButton.GetURL());
			Render(gobj, bonu.Key, (int)bonu.Value);
		}
	}

	private void Render(GObject gobj, string key, int value)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		GComponent asCom = gobj.asCom;
		((GObject)asCom).onClick.Set((EventCallback0)delegate
		{
			ItemTip(key);
		});
		asCom.GetChild("title").text = value.ShortNumberFormat().ToString();
		GLoader asLoader = asCom.GetChild("icon").asLoader;
		FGUIManager.Instance.SetItemIconAndFrame(asLoader, key, null, "", frameVisible: false);
	}

	private void ItemTip(string itemId)
	{
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
	}
}
