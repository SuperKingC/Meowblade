using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideRewardPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_ServerWideRewardDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5hrekjdu8";

	public static string Name = "UI_ServerWideRewardPanel";

	private List<LeaderboardBonusConfig> _rankBonusList;

	public static string GetURL()
	{
		return "ui://82mo10n5hrekjdu8";
	}

	public static UI_ServerWideRewardPanel CreateInstance()
	{
		return (UI_ServerWideRewardPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideRewardPanel");
	}

	public static UI_ServerWideRewardPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideRewardPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hrekjdu8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ServerWideRewardDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("BonusList", out var value))
		{
			_rankBonusList = (List<LeaderboardBonusConfig>)value;
		}
		RenderTitle();
		RenderBonusList();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)mask).onClick.Clear();
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

	private void RenderTitle()
	{
		if (RankDataHelper.AllServersChampionshipInfo.IsRoundI())
		{
			((GObject)Dialog.title).text = LanguagesManager.GetDesc("ServerWideRewardPreviewTitle_Round1");
		}
		else
		{
			((GObject)Dialog.title).text = LanguagesManager.GetDesc("ServerWideRewardPreviewTitle_Round2");
		}
	}

	private void RenderBonusList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.ItemList.itemRenderer = new ListItemRenderer(_rankBonusRenderer);
		if (_rankBonusList == null)
		{
			ILRuntimeDebug.LogError("[ServerWideRewardPanel]Bonus List is null");
			Dialog.ItemList.numItems = 0;
		}
		else
		{
			Dialog.ItemList.numItems = _rankBonusList.Count;
		}
	}

	private void _rankBonusRenderer(int index, GObject gObject)
	{
		LeaderboardBonusConfig leaderboardBonusConfig = _rankBonusList[index];
		UI_RewardListItem uI_RewardListItem = (UI_RewardListItem)(object)gObject.asCom;
		int num = leaderboardBonusConfig.RankRange.FirstOrDefault();
		int num2 = leaderboardBonusConfig.RankRange.LastOrDefault();
		uI_RewardListItem.RankLevel.selectedIndex = 0;
		if (num == num2)
		{
			((GObject)uI_RewardListItem.title).text = $"{num}";
			switch (num)
			{
			case 1:
				uI_RewardListItem.RankLevel.selectedIndex = 3;
				break;
			case 2:
				uI_RewardListItem.RankLevel.selectedIndex = 2;
				break;
			case 3:
				uI_RewardListItem.RankLevel.selectedIndex = 1;
				break;
			}
		}
		else
		{
			((GObject)uI_RewardListItem.title).text = $"{num}~{num2}";
		}
		uI_RewardListItem.NoList.RemoveChildrenToPool();
		if (leaderboardBonusConfig.BonusItems == null || leaderboardBonusConfig.BonusItems.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, int> bonusItem2 in leaderboardBonusConfig.BonusItems)
		{
			UI_ItemButton bonusItem = (UI_ItemButton)(object)uI_RewardListItem.NoList.AddItemFromPool().asCom;
			string key = bonusItem2.Key;
			int value = bonusItem2.Value;
			_renderBonusItem(bonusItem, key, value);
		}
	}

	private void _renderBonusItem(UI_ItemButton bonusItem, string itemId, int qty)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		bonusItem.icon.url = UiHelper.GetItemIconPath(itemId);
		((GObject)bonusItem.title).text = $"{qty}";
		((GObject)bonusItem).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}
}
