using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.OuterTechConfigs;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models.OuterTech;
using Shift.Legion.GvG.Helpers;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

public static class OuterTechHelper
{
	private class 魔的第八天Effect
	{
		public class InnerEffect
		{
			public Base Base;

			public Additional Additional;
		}

		public class Base
		{
			public Config Config;

			public int TriggerDay;
		}

		public class Additional
		{
			public Config Config;
		}

		public class Config
		{
			public float Percent;

			public int Value;
		}

		public InnerEffect Effect;
	}

	public class 魔的第八天Config
	{
		public float ReturnPercent = -1f;

		public int Value;

		public int TriggerDay;
	}

	public class 战时扩编Effect
	{
		public class InnerEffect
		{
			public AddAttribute Base { get; set; } = new AddAttribute();

			public AddAttribute Additional { get; set; } = new AddAttribute();

			public Dictionary<string, AddAttribute> Special { get; set; } = new Dictionary<string, AddAttribute>();

			public Dictionary<string, float> GetAllGvGAttributeBuff(int count)
			{
				Dictionary<string, float> dictionary = new Dictionary<string, float> { { Base.OuterTechName, Base.Buff } };
				if (dictionary.ContainsKey(Additional.OuterTechName))
				{
					dictionary[Additional.OuterTechName] += Additional.Buff * (float)(count - 1);
				}
				else
				{
					dictionary.Add(Additional.OuterTechName, Additional.Buff * (float)(count - 1));
				}
				foreach (KeyValuePair<string, AddAttribute> item in Special)
				{
					if (count >= int.Parse(item.Key))
					{
						if (dictionary.ContainsKey(item.Value.OuterTechName))
						{
							dictionary[item.Value.OuterTechName] += item.Value.Buff;
						}
						else
						{
							dictionary.Add(item.Value.OuterTechName, item.Value.Buff);
						}
					}
				}
				return dictionary;
			}
		}

		public class AddAttribute
		{
			public string OuterTechName;

			public float Buff;
		}

		public InnerEffect Effect;
	}

	public class Jump努力加餐饭Cost
	{
		public bool Use努力加餐饭 { get; set; }

		public string 努力加餐饭CostItemId { get; set; }

		public int 努力加餐饭CostValue { get; set; }

		public StockChangeRecord[] CreateStockChangeRecord(int timeChanged)
		{
			if (!Use努力加餐饭)
			{
				return null;
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int> { { 努力加餐饭CostItemId, 努力加餐饭CostValue } };
			return dictionary.ToStockChangeRecords(StockInContext.AutoFill, "", -timeChanged);
		}
	}

	private class 努力加餐饭Effect
	{
		public class InnerEffect
		{
			public Base Base;

			public Additional Additional;
		}

		public class Base
		{
			public int LimitTimes;

			public Config Config;
		}

		public class Additional
		{
			public int LimitTimes;
		}

		public class Config
		{
			public Dictionary<string, float> Items;
		}

		public InnerEffect Effect;
	}

	public class 努力加餐饭Config
	{
		public int MaxUseTimes;

		public string CosumeItemId;

		public float Coefficient;

		public int GetCosumeCount(int foodCount)
		{
			return Mathf.CeilToInt(Coefficient * (float)foodCount);
		}
	}

	private class 深层共鸣Effect
	{
		public class InnerEffect
		{
			public Base Base;
		}

		public class Base
		{
			public Config Config;
		}

		public class Config
		{
			public int ReducePoint;
		}

		public InnerEffect Effect;
	}

	private class 绿色通道Effect
	{
		public class InnerEffect
		{
			public Base Base;

			public Additional Additional;
		}

		public class Base
		{
			public int LimitTimes;
		}

		public class Additional
		{
			public int LimitTimes;
		}

		public InnerEffect Effect;
	}

	public const string o16加8 = "I67301";

	public const string o魔的第八天 = "I67501";

	public const string o努力加餐饭 = "I67502";

	public const string o绿色通道 = "I67505";

	public const string o深层共鸣 = "I67602";

	public const string o开局一艘飞空艇 = "I67603";

	public const string o蓝图分解 = "I67507";

	public const string o万用系统 = "I67506";

	public const string o战时扩编 = "I67408";

	public const string o划算交易 = "I67206";

	public const string o专业技师 = "I67207";

	public const string o军垦支援 = "I67409";

	public const string o领空主权 = "I67410";

	public const string o旗舰特权 = "I67411";

	public const string o代理作战 = "I67508";

	public const string o天空熔炉 = "I67509";

	public const string o远程通信 = "I67510";

	public const string o邪魔外道 = "I67604";

	public const string o蛰伏 = "I67605";

	public static Lazy<魔的第八天Config> 魔的第八天 = new Lazy<魔的第八天Config>(Get魔的第八天Config);

	private static 努力加餐饭Config _努力加餐饭Config;

	private static int _深层共鸣ReducePoint = -1;

	private static int _绿色通道MaxUseTime = -1;

	public static Lazy<蓝图分解Config> 蓝图分解Config = new Lazy<蓝图分解Config>(Get蓝图分解Config);

	public static bool Is绿色通道Active => Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67505".IsActive() && GetTechState().o绿色通道_EndTime > (int)GameController.Instance.GetServerTime();

	public static bool Is蓝图分解Active => Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67507".IsActive();

	public static bool IsActive(this string techId)
	{
		return new TechData(techId).Level > 0;
	}

	public static TechData GetTechData(this string techId)
	{
		return new TechData(techId);
	}

	public static OuterTechModel GetTechState()
	{
		return Singleton<WorldStateManager>.Instance.Data.OuterTechModel;
	}

	public static float Get_16加8DiscountRate()
	{
		TechData techData = "I67301".GetTechData();
		TechType6_Parser techType6_Parser = (TechType6_Parser)techData.TechEffectParser;
		return techType6_Parser.GetX(techData.Level);
	}

	private static 魔的第八天Config Get魔的第八天Config()
	{
		TechData techData = "I67501".GetTechData();
		string effect = techData.ConfigData.Effect;
		魔的第八天Effect 魔的第八天Effect = effect.ToObject<魔的第八天Effect>();
		魔的第八天Effect.Base obj = 魔的第八天Effect.Effect.Base;
		魔的第八天Effect.Additional additional = 魔的第八天Effect.Effect.Additional;
		int level = techData.Level;
		float returnPercent = 0f;
		if (level > 0)
		{
			returnPercent = obj.Config.Percent + additional.Config.Percent * (float)(level - 1);
		}
		return new 魔的第八天Config
		{
			ReturnPercent = returnPercent,
			Value = obj.Config.Value,
			TriggerDay = obj.TriggerDay
		};
	}

	public static int Calculate战时扩编SoldierStockLimitIncrease()
	{
		TechData techData = "I67408".GetTechData();
		战时扩编Effect 战时扩编Effect = JsonHelper.ToObject<战时扩编Effect>(techData.ConfigData.Effect);
		float num = 0f;
		Dictionary<string, float> allGvGAttributeBuff = 战时扩编Effect.Effect.GetAllGvGAttributeBuff(techData.Level);
		if (allGvGAttributeBuff.TryGetValue(408.ToString(), out var value))
		{
			num = value;
		}
		return (int)num;
	}

	public static 努力加餐饭Config Get_努力加餐饭Config()
	{
		if (_努力加餐饭Config != null)
		{
			return _努力加餐饭Config;
		}
		TechData techData = "I67502".GetTechData();
		string effect = techData.ConfigData.Effect;
		努力加餐饭Effect 努力加餐饭Effect = effect.ToObject<努力加餐饭Effect>();
		int level = techData.Level;
		Dictionary<string, float>.Enumerator enumerator = 努力加餐饭Effect.Effect.Base.Config.Items.GetEnumerator();
		enumerator.MoveNext();
		float value = enumerator.Current.Value;
		_努力加餐饭Config = new 努力加餐饭Config
		{
			MaxUseTimes = 0,
			CosumeItemId = enumerator.Current.Key,
			Coefficient = value
		};
		if (level > 0)
		{
			_努力加餐饭Config.MaxUseTimes = 努力加餐饭Effect.Effect.Base.LimitTimes + 努力加餐饭Effect.Effect.Additional.LimitTimes * (level - 1);
		}
		return _努力加餐饭Config;
	}

	public static int Get_深层共鸣ReducePoint()
	{
		if (_深层共鸣ReducePoint > -1)
		{
			return _深层共鸣ReducePoint;
		}
		string effect = "I67602".GetTechData().ConfigData.Effect;
		深层共鸣Effect 深层共鸣Effect = effect.ToObject<深层共鸣Effect>();
		_深层共鸣ReducePoint = 深层共鸣Effect.Effect.Base.Config.ReducePoint;
		return _深层共鸣ReducePoint;
	}

	public static int Get_绿色通道MaxUseTime()
	{
		if (_绿色通道MaxUseTime > -1)
		{
			return _绿色通道MaxUseTime;
		}
		TechData techData = "I67505".GetTechData();
		string effect = techData.ConfigData.Effect;
		绿色通道Effect 绿色通道Effect = effect.ToObject<绿色通道Effect>();
		int level = techData.Level;
		_绿色通道MaxUseTime = 0;
		if (level > 0)
		{
			_绿色通道MaxUseTime = 绿色通道Effect.Effect.Base.LimitTimes + 绿色通道Effect.Effect.Additional.LimitTimes * (level - 1);
		}
		return _绿色通道MaxUseTime;
	}

	private static 蓝图分解Config Get蓝图分解Config()
	{
		TechData techData = "I67507".GetTechData();
		string effect = techData.ConfigData.Effect;
		蓝图分解Effect 蓝图分解Effect = effect.ToObject<蓝图分解Effect>();
		return 蓝图分解Effect.Effect.Base.Config;
	}

	public static int CalculateCountFromAbilityLevel(SoldierOuterTechEffectConfig config, int targetLevel)
	{
		OuterTechEffect_SoldierAbility effect = config.Effect;
		int limit = config.Limit;
		List<int> list = effect.Special?.Keys.Select(int.Parse).ToList() ?? new List<int>();
		list.Sort();
		int[] array = new int[list.Count + 1];
		for (int i = 0; i < list.Count; i++)
		{
			string key = list[i].ToString();
			array[i + 1] = array[i] + effect.Special[key].Level;
		}
		int level = effect.Base.Level;
		int num = effect.Additional?.Level ?? 0;
		for (int num2 = list.Count; num2 >= 0; num2--)
		{
			int num3 = array[num2];
			int num4;
			int val;
			if (num2 == 0)
			{
				num4 = 1;
				val = ((list.Count > 0) ? (list[0] - 1) : int.MaxValue);
			}
			else
			{
				num4 = list[num2 - 1];
				val = ((num2 < list.Count) ? (list[num2] - 1) : int.MaxValue);
			}
			val = Math.Min(val, limit);
			if (num == 0)
			{
				if (targetLevel == level + num3 && num4 <= val)
				{
					return Math.Min(num4, limit);
				}
			}
			else
			{
				int num5 = targetLevel - level - num3;
				if (num5 >= 0 && num5 % num == 0)
				{
					int num6 = num5 / num + 1;
					if (num6 >= num4 && num6 <= val)
					{
						return Math.Min(num6, limit);
					}
				}
			}
		}
		int num7 = level + array[list.Count];
		if (num == 0 && num7 == targetLevel)
		{
			return limit;
		}
		return -1;
	}

	public static bool IsO邪魔外道Active()
	{
		OuterTechModel techState = GetTechState();
		return techState.o邪魔外道_LimitTime > 0;
	}

	public static bool IsO远程通信Active()
	{
		return GameManagers.Instance.StockController.GetStock("I67510") > 0;
	}

	public static bool IsO蛰伏Active()
	{
		return GameManagers.Instance.StockController.GetStock("I67605") > 0;
	}

	public static bool IsO军垦支援扩展Active()
	{
		return GameManagers.Instance.StockController.GetStock("I67409") >= 4;
	}
}
