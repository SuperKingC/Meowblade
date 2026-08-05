using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.Tips;

namespace UI.GvG3Leaderboard;

public class UI_com_BonusInfoDialog : GComponent
{
	public GImage n191;

	public GImage n205;

	public GList RankBonusList;

	public GTextField n202;

	public GTextField n203;

	public GTextField n204;

	public const string URL = "ui://ylvfgf90k1k96f";

	public static string Name = "UI_com_BonusInfoDialog";

	private bool IsInit = false;

	private string ConfigKey;

	private Dictionary<string, List<RankBonusData>> Config;

	private List<RankBonusData> DataList;

	public static string GetURL()
	{
		return "ui://ylvfgf90k1k96f";
	}

	public static UI_com_BonusInfoDialog CreateInstance()
	{
		return (UI_com_BonusInfoDialog)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_BonusInfoDialog");
	}

	public static UI_com_BonusInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BonusInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90k1k96f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n205 = (GImage)((GComponent)this).GetChild("n205");
		RankBonusList = (GList)((GComponent)this).GetChild("RankBonusList");
		n202 = (GTextField)((GComponent)this).GetChild("n202");
		string id = "ui://ylvfgf90k1k96f".Replace("ui://", "") + "-" + ((GObject)n202).id;
		((GObject)n202).text = LanguagesManager.GetDesc(id);
		n203 = (GTextField)((GComponent)this).GetChild("n203");
		string id2 = "ui://ylvfgf90k1k96f".Replace("ui://", "") + "-" + ((GObject)n203).id;
		((GObject)n203).text = LanguagesManager.GetDesc(id2);
		n204 = (GTextField)((GComponent)this).GetChild("n204");
		string id3 = "ui://ylvfgf90k1k96f".Replace("ui://", "") + "-" + ((GObject)n204).id;
		((GObject)n204).text = LanguagesManager.GetDesc(id3);
	}

	private void Init(string iZConfigId)
	{
		if (!IsInit)
		{
			IsInit = true;
			string text = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId;
			if (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement)
			{
				text = iZConfigId;
			}
			ConfigKey = "RankBonusConfig_" + text;
			Config = ConfigKey.ToConfiguration<Dictionary<string, List<RankBonusData>>>();
		}
	}

	public void Open(eLeaderboardType type, string iZConfigId)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		Init(iZConfigId);
		string key = $"{type}";
		if (!Config.TryGetValue(key, out var value))
		{
			throw new Exception($"[UI_com_BonusInfoDialog] type={type} 类型的排行榜不在奖励配置中，请检查Configuration表{ConfigKey}的配置");
		}
		DataList = value;
		RankBonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderRankBonusListItem(i, o as UI_com_RankBonusSlot);
		};
		RankBonusList.numItems = DataList.Count;
	}

	private void RenderRankBonusListItem(int index, UI_com_RankBonusSlot slot)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		RankBonusData rankBonusData = DataList[index];
		int topThree = rankBonusData.GetRankingStyle();
		slot.RankingTopThree.selectedIndex = topThree;
		((GObject)slot.Ranking).text = $"{rankBonusData.MinRank}~{rankBonusData.MaxRank}";
		string itemId = rankBonusData.BonusItems.Keys.ToList()[0];
		FGUIManager.Instance.SetItemIconAndFrame(slot.BonusBoxItem, itemId, null, "", frameVisible: false);
		List<Modifier> list = Item.Effect(GameManagers.Instance, itemId);
		if (list == null)
		{
			slot.ContentList.numItems = 0;
			return;
		}
		List<KeyValuePair<string, object>> contentList = new List<KeyValuePair<string, object>>(list.Find((Modifier mod) => mod.ModifierId == "DisplayBonus").PayloadDictionary);
		slot.ContentList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderBonusContentItem(i, o as UI_com_Item2, contentList, topThree);
		};
		slot.ContentList.numItems = contentList.Count;
	}

	private void RenderBonusContentItem(int index, UI_com_Item2 slot, List<KeyValuePair<string, object>> contentList, int topThree)
	{
		KeyValuePair<string, object> keyValuePair = contentList[index];
		FGUIManager.Instance.SetItemIconAndFrame(slot.Icon, keyValuePair.Key);
		((GObject)slot.Num).text = $"{keyValuePair.Value}";
		slot.RankingTopThree.selectedIndex = topThree;
		slot.Icon.InitMaterialIntroductionBtn(keyValuePair.Key);
	}
}
