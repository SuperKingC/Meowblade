using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class GvGMode3EventMissionConfigModel
{
	public string Key;

	public int IconIdx;

	public string Icon;

	public string UiIcon;

	public eGvGMode3CampMissionSubType SubType;

	public MissionBonus MissionBonus;

	public Dictionary<string, int> ShowBonus;

	public Dictionary<string, int> Cost;

	public string NPCTemplate;

	public SubTypeModel_BE BrawlSubTypeData;

	private string _bonusItemId;

	private int? _bonusNumber;

	private string _showBonusItemId;

	private int? _showBonusNumber;

	private List<IslandDisplayReward> _displayRewards;

	public string IconUrl => UiIcon.ToPublicResourceIcon();

	public string NpcIconUrl => Icon.ToPublicResourceIcon();

	public string BonusItemId => _bonusItemId ?? (_bonusItemId = MissionBonus?.Taker?.Keys.ToList()[0]);

	public int BonusNumber
	{
		get
		{
			int? bonusNumber = _bonusNumber;
			if (!bonusNumber.HasValue)
			{
				_bonusNumber = MissionBonus?.Taker?.Values.ToList()[0];
			}
			return _bonusNumber.GetValueOrDefault();
		}
	}

	public string ShowBonusItemId => _showBonusItemId ?? (_showBonusItemId = ShowBonus?.Keys.ToList()[0]);

	public int ShowBonusNumber
	{
		get
		{
			int? showBonusNumber = _showBonusNumber;
			if (!showBonusNumber.HasValue)
			{
				_showBonusNumber = ShowBonus?.Values.ToList()[0];
			}
			return _showBonusNumber.GetValueOrDefault();
		}
	}

	public KeyValuePair<string, int> FirstShowBonus => (ShowBonus == null) ? new KeyValuePair<string, int>(string.Empty, 0) : ShowBonus.ToList()[0];

	public string NameLevelOne => (Key + "_Name1").ToLanguage();

	public string NameLevelTwo => (Key + "_Name2").ToLanguage();

	public string DescLevelOne => (Key + "_Desc1").ToLanguage();

	public string DescLevelTwo => (Key + "_Desc2").ToLanguage();

	public string NpcDialogText1 => (Key + "_NPCDialog_Text1").ToLanguage();

	public string NpcShopText1 => (Key + "_NPCShop_Text1").ToLanguage();

	public string NpcShopText2 => (Key + "_NPCShop_Text2").ToLanguage();

	public string NpcShopText3 => (Key + "_NPCShop_Text3").ToLanguage();

	public string NpcShopText4 => (Key + "_NPCShop_Text4").ToLanguage();

	public string NpcShopText5 => (Key + "_NPCShop_Text5").ToLanguage();

	public List<KeyValuePair<string, int>> GetShowBonusList()
	{
		if (ShowBonus == null)
		{
			return new List<KeyValuePair<string, int>>();
		}
		List<KeyValuePair<string, int>> list = ShowBonus.ToList();
		list.RemoveAt(0);
		return list;
	}

	public List<IslandDisplayReward> DisplayRewards()
	{
		if (_displayRewards == null && !string.IsNullOrEmpty(NPCTemplate) && SubType.HasRandomEventReward())
		{
			GDEGvGIslandMapConfigData gDEGvGIslandMapConfigData = GDMgr.Get<GDEGvGIslandMapConfigData>(NPCTemplate) ?? throw new Exception("GDEGvGIslandMapConfigData error, Key=" + NPCTemplate);
			_displayRewards = (string.IsNullOrEmpty(gDEGvGIslandMapConfigData.DisplayReward) ? null : JsonHelper.ToObject<Dictionary<string, List<IslandDisplayReward>>>(gDEGvGIslandMapConfigData.DisplayReward)[IslandDisplayRewardType.RandomEvent.ToString()]);
		}
		return _displayRewards;
	}
}
