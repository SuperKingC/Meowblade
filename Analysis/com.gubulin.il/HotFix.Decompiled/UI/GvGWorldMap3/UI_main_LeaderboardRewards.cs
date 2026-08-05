using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_main_LeaderboardRewards : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_LeaderboardRankBonusDialog PopUp;

	public const string URL = "ui://4eq8fgd2cj8is7e";

	public static string Name = "UI_main_LeaderboardRewards";

	private string ConfigKey;

	private Dictionary<string, List<RankBonusData>> Config;

	private List<RankBonusData> DataList;

	public static string GetURL()
	{
		return "ui://4eq8fgd2cj8is7e";
	}

	public static UI_main_LeaderboardRewards CreateInstance()
	{
		return (UI_main_LeaderboardRewards)(object)UIPackage.CreateObject("GvGWorldMap3", "main_LeaderboardRewards");
	}

	public static UI_main_LeaderboardRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LeaderboardRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2cj8is7e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		PopUp = (UI_com_LeaderboardRankBonusDialog)(object)((GComponent)this).GetChild("PopUp");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		string iZConfigId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId;
		ConfigKey = "RankBonusConfig_" + iZConfigId;
		Config = ConfigKey.ToConfiguration<Dictionary<string, List<RankBonusData>>>();
		string text = parameters["LeaderboardType"].ToString();
		if (!Config.TryGetValue(text, out var value))
		{
			throw new Exception("[UI_main_LeaderboardRewards] type=" + text + " 类型的排行榜不在奖励配置中，请检查Configuration表" + ConfigKey + "的配置");
		}
		DataList = value;
		PopUp.RankBonusList.itemRenderer = new ListItemRenderer(RenderRankBonusListItem);
		PopUp.RankBonusList.numItems = DataList.Count;
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

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderRankBonusListItem(int index, GObject obj)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		if (!(obj is UI_com_LeaderboardRankBonusSlot uI_com_LeaderboardRankBonusSlot))
		{
			throw new Exception("slot type is not UI_com_LeaderboardRankBonusSlot,name=" + obj.name);
		}
		RankBonusData rankBonusData = DataList[index];
		int topThree = rankBonusData.GetRankingStyle();
		uI_com_LeaderboardRankBonusSlot.RankingTopThree.selectedIndex = topThree;
		((GObject)uI_com_LeaderboardRankBonusSlot.Ranking).text = $"{rankBonusData.MinRank}~{rankBonusData.MaxRank}";
		string text = rankBonusData.BonusItems.Keys.ToList()[0];
		FGUIManager.Instance.SetItemIconAndFrame(uI_com_LeaderboardRankBonusSlot.BonusBoxItem, text, null, "", frameVisible: false);
		((GObject)uI_com_LeaderboardRankBonusSlot.BonusBoxItem).data = text;
		((GObject)uI_com_LeaderboardRankBonusSlot.BonusBoxItem).onClick.Set(new EventCallback1(DisplayItemTip));
		List<Modifier> list = Item.Effect(GameManagers.Instance, text);
		List<KeyValuePair<string, object>> contentList = new List<KeyValuePair<string, object>>(list.Find((Modifier mod) => mod.ModifierId == "DisplayBonus").PayloadDictionary);
		uI_com_LeaderboardRankBonusSlot.ContentList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderBonusContentItem(i, o as UI_com_Item2, contentList, topThree);
		};
		uI_com_LeaderboardRankBonusSlot.ContentList.numItems = contentList.Count;
	}

	private static void RenderBonusContentItem(int index, UI_com_Item2 slot, List<KeyValuePair<string, object>> contentList, int topThree)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		KeyValuePair<string, object> keyValuePair = contentList[index];
		FGUIManager.Instance.SetItemIconAndFrame(slot.Icon, keyValuePair.Key);
		((GObject)slot.Num).text = $"{keyValuePair.Value}";
		slot.RankingTopThree.selectedIndex = topThree;
		((GObject)slot).data = keyValuePair.Key;
		((GObject)slot).onClick.Set(new EventCallback1(DisplayItemTip));
	}

	private static void DisplayItemTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		itemId.DisplayItemTip();
	}
}
