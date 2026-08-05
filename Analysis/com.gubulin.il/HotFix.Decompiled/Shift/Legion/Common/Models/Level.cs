using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Level
{
	private readonly List<string> _subLevels;

	public readonly string LevelId;

	public string ChapterId;

	private EnemyTemplate _EnemyTemplate;

	public GDELevelData Data;

	public List<string> TitleBonus;

	public Dictionary<string, string> BonusDesc;

	public string FromUi;

	public Dictionary<string, object> FromUiParams;

	private Dictionary<int, KeyValuePair<string, int>> _EnemyConfigs;

	private List<Soldier> _enemiesInfo;

	private List<Soldier> _bossInfo = null;

	public Level ParentLevel;

	public List<List<string>> SoldierFilters;

	public List<string> LevelFilters;

	private Dictionary<string, float> _autoProduceBonus;

	public Chapter Chapter
	{
		get
		{
			Chapter value;
			return (!string.IsNullOrEmpty(ChapterId) && ChapterManager.Chapters.TryGetValue(ChapterId, out value)) ? value : null;
		}
	}

	public string Context => Data.Context;

	public string FormationContext
	{
		get
		{
			if (Chapter == null)
			{
				return ChapterType.StoryMain.ToString();
			}
			string text = Chapter.Type.ToString();
			if (text == ChapterType.StoryMain.ToString() || text == ChapterType.StorySub.ToString() || text == ChapterType.StoryTransition.ToString())
			{
				string text2 = "LevelAssistance_" + LevelId;
				GDELevelAssistanceData gDELevelAssistanceData = null;
				if (GDMgr.Has<GDELevelAssistanceData>(text2))
				{
					gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(text2);
				}
				text = ((gDELevelAssistanceData == null || !GameManagers.Instance.UserArchiveManager.IsNewGuideMode() || !gDELevelAssistanceData.EnableAssistance) ? ChapterType.StoryMain.ToString() : text2);
			}
			else if (text == ChapterType.RepeatableInstanceDefensive.ToString() || text == ChapterType.RepeatableInstanceOffensive.ToString())
			{
				text = ChapterType.RepeatableInstance.ToString();
			}
			return text;
		}
	}

	public int Difficult => Data.Difficult;

	public bool DynamicEnemy => Data.DynamicEnemy;

	public float EnemyPowerModifier => (Data.EnemyPowerModifier > 0f) ? Data.EnemyPowerModifier : 1f;

	public string FromEnemyTemplatePool => Data.FromEnemyTemplatePool;

	public EnemyTemplate EnemyTemplate
	{
		get
		{
			if (_EnemyTemplate == null && string.IsNullOrEmpty(FromEnemyTemplatePool))
			{
				if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
				{
					GDELevelAssistanceData gDELevelAssistanceData = null;
					if (GDMgr.Has<GDELevelAssistanceData>("LevelAssistance_" + LevelId))
					{
						gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>("LevelAssistance_" + LevelId);
					}
					if (gDELevelAssistanceData != null)
					{
						_EnemyTemplate = new EnemyTemplate
						{
							FormationId = gDELevelAssistanceData.BlueFormationId,
							Enemy1 = gDELevelAssistanceData.Enemy1,
							Enemy2 = gDELevelAssistanceData.Enemy2,
							Enemy3 = gDELevelAssistanceData.Enemy3,
							Enemy4 = gDELevelAssistanceData.Enemy4,
							Enemy5 = gDELevelAssistanceData.Enemy5,
							Enemy6 = gDELevelAssistanceData.Enemy6,
							Enemy7 = gDELevelAssistanceData.Enemy7,
							Enemy8 = gDELevelAssistanceData.Enemy8,
							Enemy9 = gDELevelAssistanceData.Enemy9,
							Enemy10 = gDELevelAssistanceData.Enemy10,
							Enemy11 = gDELevelAssistanceData.Enemy11,
							Enemy12 = gDELevelAssistanceData.Enemy12,
							Number1 = gDELevelAssistanceData.Number1,
							Number2 = gDELevelAssistanceData.Number2,
							Number3 = gDELevelAssistanceData.Number3,
							Number4 = gDELevelAssistanceData.Number4,
							Number5 = gDELevelAssistanceData.Number5,
							Number6 = gDELevelAssistanceData.Number6,
							Number7 = gDELevelAssistanceData.Number7,
							Number8 = gDELevelAssistanceData.Number8,
							Number9 = gDELevelAssistanceData.Number9,
							Number10 = gDELevelAssistanceData.Number10,
							Number11 = gDELevelAssistanceData.Number11,
							Number12 = gDELevelAssistanceData.Number12,
							EnemyPortrait = gDELevelAssistanceData.Icon
						};
					}
					else
					{
						_EnemyTemplate = new EnemyTemplate
						{
							FormationId = Data.BlueFormationId,
							Enemy1 = Data.Enemy1,
							Enemy2 = Data.Enemy2,
							Enemy3 = Data.Enemy3,
							Enemy4 = Data.Enemy4,
							Enemy5 = Data.Enemy5,
							Enemy6 = Data.Enemy6,
							Enemy7 = Data.Enemy7,
							Enemy8 = Data.Enemy8,
							Enemy9 = Data.Enemy9,
							Enemy10 = Data.Enemy10,
							Enemy11 = Data.Enemy11,
							Enemy12 = Data.Enemy12,
							Number1 = Data.Number1,
							Number2 = Data.Number2,
							Number3 = Data.Number3,
							Number4 = Data.Number4,
							Number5 = Data.Number5,
							Number6 = Data.Number6,
							Number7 = Data.Number7,
							Number8 = Data.Number8,
							Number9 = Data.Number9,
							Number10 = Data.Number10,
							Number11 = Data.Number11,
							Number12 = Data.Number12,
							EnemyPortrait = Data.Icon
						};
					}
				}
				else
				{
					_EnemyTemplate = new EnemyTemplate
					{
						FormationId = Data.BlueFormationId,
						Enemy1 = Data.Enemy1,
						Enemy2 = Data.Enemy2,
						Enemy3 = Data.Enemy3,
						Enemy4 = Data.Enemy4,
						Enemy5 = Data.Enemy5,
						Enemy6 = Data.Enemy6,
						Enemy7 = Data.Enemy7,
						Enemy8 = Data.Enemy8,
						Enemy9 = Data.Enemy9,
						Enemy10 = Data.Enemy10,
						Enemy11 = Data.Enemy11,
						Enemy12 = Data.Enemy12,
						Number1 = Data.Number1,
						Number2 = Data.Number2,
						Number3 = Data.Number3,
						Number4 = Data.Number4,
						Number5 = Data.Number5,
						Number6 = Data.Number6,
						Number7 = Data.Number7,
						Number8 = Data.Number8,
						Number9 = Data.Number9,
						Number10 = Data.Number10,
						Number11 = Data.Number11,
						Number12 = Data.Number12,
						EnemyPortrait = Data.Icon
					};
				}
			}
			return _EnemyTemplate;
		}
		set
		{
			_EnemyTemplate = value;
		}
	}

	public BattleMode BattleMode
	{
		get
		{
			if (Data.RedTeamBattleMode == 1 && Data.BlueTeamBattleMode != 1)
			{
				return BattleMode.DefenceMode;
			}
			if (Data.RedTeamBattleMode == 2 && Data.BlueTeamBattleMode == 1)
			{
				return BattleMode.MultiWaveAttackMode;
			}
			return BattleMode.RushMode;
		}
	}

	public bool AutoLottery => Data.AutoLottery;

	public bool IsTitled => TitleBonus.Count > 0;

	public Dictionary<int, KeyValuePair<string, int>> EnemyConfigs
	{
		get
		{
			if (_EnemyConfigs == null)
			{
				_EnemyConfigs = new Dictionary<int, KeyValuePair<string, int>>();
				if (Data != null)
				{
					int num = 1;
					object obj = Data.GetType().GetField($"Enemy{num}")?.GetValue(Data);
					while (obj != null)
					{
						FieldInfo field = Data.GetType().GetField($"Enemy{num}");
						if (field == null)
						{
							break;
						}
						obj = field.GetValue(Data);
						string text = obj.ToString();
						if (string.IsNullOrEmpty(text))
						{
							num++;
							continue;
						}
						object value = Data.GetType().GetField($"Number{num}")?.GetValue(Data);
						int num2 = Convert.ToInt32(value);
						if (num2 < 1)
						{
							num++;
						}
						else
						{
							EnemyConfigs.Add(num++, new KeyValuePair<string, int>(text, num2));
						}
					}
				}
			}
			return _EnemyConfigs;
		}
	}

	public List<Soldier> EnemiesInfo
	{
		get
		{
			if (_enemiesInfo == null)
			{
				_enemiesInfo = new List<Soldier>();
				foreach (KeyValuePair<string, int> value in EnemyConfigs.Values)
				{
					_enemiesInfo.Add(new Soldier(null, value.Key));
				}
			}
			return _enemiesInfo;
		}
	}

	public List<Soldier> BossInfo
	{
		get
		{
			if (_bossInfo == null)
			{
				_bossInfo = new List<Soldier>();
				if (!string.IsNullOrEmpty(Data.BlueTeamBoss))
				{
					_bossInfo.Add(new Soldier(null, Data.BlueTeamBoss));
				}
				foreach (Soldier item in EnemiesInfo)
				{
					if (item.Tags.Contains("敌方BOSS"))
					{
						_bossInfo.Add(item);
					}
				}
			}
			return _bossInfo;
		}
	}

	public string Name => Data.Name;

	public string Desc => Data.Desc;

	public int LevelIndex => ParentLevel?.SubLevels.IndexOf(LevelId) ?? 0;

	public List<string> SubLevels => _subLevels;

	public Dictionary<string, float> AutoProduceBonus
	{
		get
		{
			if (_autoProduceBonus == null)
			{
				_autoProduceBonus = new Dictionary<string, float>();
				if (!string.IsNullOrEmpty(Data.AutoProduceBonus))
				{
					_autoProduceBonus = JsonHelper.ToObject<Dictionary<string, float>>(Data.AutoProduceBonus);
				}
			}
			return _autoProduceBonus;
		}
	}

	public Level(GDELevelData data)
	{
		ChapterId = data.ChapterId;
		Data = data;
		LevelId = Data.Key;
		if (!string.IsNullOrEmpty(data.SoldierFilters))
		{
			SoldierFilters = JsonHelper.ToObject<List<List<string>>>(data.SoldierFilters);
		}
		if (!string.IsNullOrEmpty(data.LevelFilters))
		{
			LevelFilters = JsonHelper.ToObject<List<string>>(data.LevelFilters);
		}
		if (!string.IsNullOrEmpty(Data.ParentLevelId))
		{
			ChapterManager.Levels.TryGetValue(Data.ParentLevelId, out var level);
			if (level != null)
			{
				ParentLevel = level;
			}
			else
			{
				ILRuntimeDebug.LogError("Mismatched ParentLevel " + Data.ParentLevelId + " of " + LevelId);
			}
		}
		TitleBonus = new List<string>();
		string key = "LevelAssistance_" + LevelId;
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && GDMgr.Has<GDELevelAssistanceData>(key))
		{
			string titleBonus = GDMgr.Get<GDELevelAssistanceData>(key).TitleBonus;
			if (!string.IsNullOrEmpty(titleBonus))
			{
				TitleBonus.AddRange(titleBonus.Split(','));
			}
		}
		else if (!string.IsNullOrEmpty(data.TitleBonus))
		{
			TitleBonus.AddRange(data.TitleBonus.Split(','));
		}
		BonusDesc = new Dictionary<string, string>();
		if (!string.IsNullOrEmpty(data.BonusDesc))
		{
			foreach (KeyValuePair<string, string> item in JsonHelper.ToObject<Dictionary<string, string>>(data.BonusDesc))
			{
				BonusDesc.Add(item.Key, item.Value);
			}
		}
		if (string.IsNullOrEmpty(data.SubLevels))
		{
			_subLevels = new List<string>();
		}
		else
		{
			_subLevels = data.SubLevels.Split(',').ToList();
		}
	}

	public bool HasSubLevels()
	{
		if (_subLevels == null)
		{
			return false;
		}
		return _subLevels.Count > 0;
	}

	public Level GetNextSubLevel(int index)
	{
		int num = index + 1;
		if (num < 0 || num >= _subLevels.Count)
		{
			return null;
		}
		ChapterManager.Levels.TryGetValue(_subLevels[num], out var level);
		return level;
	}

	public Level GetSubLevel(int index)
	{
		if (index < 0 || index >= _subLevels.Count)
		{
			return null;
		}
		ChapterManager.Levels.TryGetValue(_subLevels[index], out var level);
		return level;
	}

	public Dictionary<string, float> FormattedAutoProduceBonus(GameManagers managers, Dictionary<string, float> buffer = null)
	{
		if (buffer == null)
		{
			buffer = new Dictionary<string, float>();
		}
		else
		{
			buffer.Clear();
		}
		float num = 1f + managers.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
		foreach (KeyValuePair<string, float> autoProduceBonu in AutoProduceBonus)
		{
			buffer[autoProduceBonu.Key] = AutoProduceBonus[autoProduceBonu.Key] * num;
		}
		return buffer;
	}

	public List<Modifier> LevelModifier(GameManagers managers, List<Modifier> buffer = null)
	{
		if (buffer == null)
		{
			buffer = new List<Modifier>();
		}
		else
		{
			buffer.Clear();
		}
		if (!string.IsNullOrEmpty(Data.LevelModifier))
		{
			foreach (Dictionary<string, object> item2 in JsonHelper.ToObject<List<Dictionary<string, object>>>(Data.LevelModifier))
			{
				if (!item2.TryGetValue("ModifierId", out var _))
				{
					continue;
				}
				item2.Remove("ModifierId");
				foreach (KeyValuePair<string, object> item3 in item2)
				{
					Modifier item = new Modifier(managers, item3.Key, item3.Value.ToString());
					buffer.Add(item);
				}
			}
		}
		return buffer;
	}

	public List<KeyValuePair<Bonus, int>> GetLevelBonus(GameManagers managers, List<KeyValuePair<Bonus, int>> buffer = null)
	{
		if (buffer == null)
		{
			buffer = new List<KeyValuePair<Bonus, int>>();
		}
		else
		{
			buffer.Clear();
		}
		List<Bonus> list = new List<Bonus>();
		if (managers.UserArchiveManager.IsLevelClaimed(LevelId))
		{
			ConfigDataManager.LevelBonuses.RepeatBonuses_TryGetValue(LevelId, out var config);
			if (!string.IsNullOrEmpty(config))
			{
				Dictionary<string, object> dictionary = JsonHelper.ToObject<Dictionary<string, object>>(config);
				foreach (string key in dictionary.Keys)
				{
					list.Add(Bonus.Get(key, dictionary[key]));
				}
			}
		}
		else
		{
			ConfigDataManager.LevelBonuses.Bonuses_TryGetValue(LevelId, out var config2);
			if (!string.IsNullOrEmpty(config2))
			{
				Dictionary<string, object> dictionary2 = JsonHelper.ToObject<Dictionary<string, object>>(config2);
				foreach (string key2 in dictionary2.Keys)
				{
					list.Add(Bonus.Get(key2, dictionary2[key2]));
				}
			}
		}
		if (list != null)
		{
			foreach (Bonus item in list)
			{
				if (item.Type == 3)
				{
					buffer.AddRange(managers.LotteryManager.GetLotteryAsListById(item.ItemId));
				}
				else
				{
					buffer.Add(new KeyValuePair<Bonus, int>(item, Item.IsShining(item.ItemId)));
				}
			}
		}
		return buffer;
	}

	public List<KeyValuePair<Bonus, int>> GetLevelLotteryBonus(GameManagers managers, List<KeyValuePair<Bonus, int>> buffer = null)
	{
		if (buffer == null)
		{
			buffer = new List<KeyValuePair<Bonus, int>>();
		}
		else
		{
			buffer.Clear();
		}
		List<BonusConfig> levelLotteryBonus = managers.UserArchiveManager.GetLevelLotteryBonus(this);
		if (levelLotteryBonus != null)
		{
			foreach (BonusConfig item in levelLotteryBonus)
			{
				buffer.Add(new KeyValuePair<Bonus, int>(Bonus.Get(item.ItemId, item.Qty, item.Type), item.IsShining));
			}
			return buffer;
		}
		List<Bonus> list = new List<Bonus>();
		if (managers.UserArchiveManager.IsLevelClaimed(LevelId))
		{
			ConfigDataManager.LevelBonuses.RepeatLottery_TryGetValue(LevelId, out var config);
			if (!string.IsNullOrEmpty(config))
			{
				Dictionary<string, object> dictionary = JsonHelper.ToObject<Dictionary<string, object>>(config);
				foreach (string key in dictionary.Keys)
				{
					list.Add(Bonus.Get(key, dictionary[key]));
				}
			}
		}
		else
		{
			ConfigDataManager.LevelBonuses.Lottery_TryGetValue(LevelId, out var config2);
			if (!string.IsNullOrEmpty(config2))
			{
				Dictionary<string, object> dictionary2 = JsonHelper.ToObject<Dictionary<string, object>>(config2);
				foreach (string key2 in dictionary2.Keys)
				{
					list.Add(Bonus.Get(key2, dictionary2[key2]));
				}
			}
		}
		if (list != null)
		{
			foreach (Bonus item2 in list)
			{
				if (item2.Type == 3)
				{
					buffer.AddRange(managers.LotteryManager.GetLotteryAsListById(item2.ItemId));
				}
				else
				{
					buffer.Add(new KeyValuePair<Bonus, int>(item2, Item.IsShining(item2.ItemId)));
				}
			}
		}
		return buffer;
	}

	public List<KeyValuePair<Bonus, int>> ReGetLotteryBonus(GameManagers managers, List<KeyValuePair<Bonus, int>> buffer = null)
	{
		ConfigDataManager.LevelBonuses.Bonuses_TryGetValue(LevelId, out var _);
		managers.UserArchiveManager.RemoveLevelLotteryBonus(this);
		return GetLevelLotteryBonus(managers, buffer);
	}

	public ActionResult ClaimLevelBonus(GameManagers managers, List<Bonus> allBonuses)
	{
		Dictionary<string, Bonus> dictionary = new Dictionary<string, Bonus>();
		foreach (Bonus allBonuse in allBonuses)
		{
			if (!dictionary.ContainsKey(allBonuse.ItemId))
			{
				dictionary.Add(allBonuse.ItemId, allBonuse);
			}
			else
			{
				dictionary[allBonuse.ItemId] = dictionary[allBonuse.ItemId].Merge(allBonuse);
			}
		}
		foreach (Bonus value in dictionary.Values)
		{
			value.Claim(managers);
		}
		managers.UserArchiveManager.AddClaimedLevel(LevelId);
		managers.Messenger.Broadcast("LEVEL_BONUS_CLAIMED", this);
		return new ActionResult
		{
			Result = true
		};
	}

	public void Accomplish(GameManagers managers)
	{
		managers.UserArchiveManager.UpdateLevelProgress(ChapterId, LevelId);
	}

	public Soldier GenerateLocalizedSoldier(GameManagers managers, string soldierId)
	{
		return GenerateLocalizedSoldier(managers, LevelId, soldierId);
	}

	public static Soldier GenerateLocalizedSoldier(GameManagers managers, string levelId, string soldierId)
	{
		Soldier soldier = managers.SoldierManager.Get(soldierId);
		ChapterManager.Levels.TryGetValue(levelId, out var level);
		if (level == null)
		{
			return null;
		}
		float percentFloatPayload = managers.ModifierManager.GetPercentFloatPayload("MapResistance", new string[2]
		{
			soldier.Id,
			soldier.Data.AiType
		});
		foreach (Modifier item in level.LevelModifier(managers))
		{
			if (item.ModifierId != "AttributeBundle")
			{
				continue;
			}
			if (item.PayloadDictionary.TryGetValue("Tags", out var value))
			{
				List<string> second = JsonHelper.ToObject<List<string>>(value.ToString());
				if (!soldier.Tags.Intersect(second).Any())
				{
					continue;
				}
			}
			foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
			{
				if (item2.Key == "Tags")
				{
					continue;
				}
				string text = item2.Value.ToString();
				if (text.IndexOf('%') == -1)
				{
					float num = NumericParser.Float(text);
					if (num < 0f)
					{
						num *= 1f - percentFloatPayload;
					}
					if (soldier.FixedBonusAttr.ContainsKey(item2.Key))
					{
						soldier.FixedBonusAttr[item2.Key] += num;
					}
					else
					{
						soldier.FixedBonusAttr.Add(item2.Key, num);
					}
				}
				else
				{
					float num2 = NumericParser.FloatPercent(text);
					if (num2 < 0f)
					{
						num2 *= 1f - percentFloatPayload;
					}
					if (soldier.PercentBonusAttr.ContainsKey(item2.Key))
					{
						soldier.PercentBonusAttr[item2.Key] += num2;
					}
					else
					{
						soldier.PercentBonusAttr.Add(item2.Key, num2);
					}
				}
			}
		}
		return soldier;
	}

	public bool PlayAfterClaim(GameManagers managers)
	{
		if (managers.UserArchiveManager.IsNewGuideMode())
		{
			return false;
		}
		if (string.IsNullOrEmpty(Data?.PlayAfterClaim))
		{
			return false;
		}
		string[] array = Data.PlayAfterClaim.Split(',');
		string[] array2 = array;
		foreach (string storyId in array2)
		{
			if (!managers.UserArchiveManager.IsNewGuideMode())
			{
				managers.StoryManager.ActivateStory(storyId);
			}
		}
		managers.Messenger.Broadcast("AFTER_LEVEL_BONUS_CLAIMED", this);
		return true;
	}

	public bool PlayAfterComplete(GameManagers managers)
	{
		if (!managers.UserArchiveManager.IsNewGuideMode())
		{
			return false;
		}
		if (string.IsNullOrEmpty(Data?.PlayAfterComplete))
		{
			return false;
		}
		string text = (GameManagers.Instance.UserArchiveManager.IsForeignNewGuideMode() ? Data.PlayAfterComplete_GuideForeign : Data.PlayAfterComplete);
		string[] array = text.Split(',');
		string[] array2 = array;
		foreach (string storyId in array2)
		{
			managers.StoryManager.ActivateStory(storyId);
		}
		return true;
	}

	public int GetTotalEnemies(GameManagers managers)
	{
		List<string> list = ((SubLevels.Count > 0) ? SubLevels : new List<string> { LevelId });
		int num = 0;
		List<int> list2 = null;
		foreach (string item in list)
		{
			ChapterManager.Levels.TryGetValue(item, out var level);
			int num2 = 0;
			foreach (KeyValuePair<string, int> value2 in level.EnemyConfigs.Values)
			{
				string key = value2.Key;
				int value = value2.Value;
				if (string.IsNullOrEmpty(key) || value < 1)
				{
					continue;
				}
				if (level.DynamicEnemy)
				{
					if (list2 == null)
					{
						list2 = LegionHelper.GetPlayerMaxPowerfulLegionLevelsInfo(managers);
					}
					int level2 = ((num2 < list2.Count) ? list2[num2] : list2.Last());
					num += Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(key, level2);
				}
				else
				{
					num += value;
				}
				num2++;
			}
		}
		return num;
	}

	public bool IsPerspective()
	{
		if (!Define.PostProcessingCameraEnabled())
		{
			return false;
		}
		return ChapterId == "C10000" || ChapterId == "C10001";
	}
}
