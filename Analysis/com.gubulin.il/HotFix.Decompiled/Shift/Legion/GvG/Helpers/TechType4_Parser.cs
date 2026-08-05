using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using UnityEngine;

namespace Shift.Legion.GvG.Helpers;

public class TechType4_Parser : TechEffectBase, ITechEffectParser
{
	public class ConfigData : OuterTechEffectConfig
	{
		public TypeEffect Effect;
	}

	public class TypeEffect
	{
		public Reward Base = new Reward();

		public Reward Additional = new Reward();

		public Dictionary<string, Reward> Special = new Dictionary<string, Reward>();
	}

	public class Reward
	{
		public string ItemId;

		public int Period = -1;

		public int Quantity;
	}

	public class SpecialLevel
	{
		public int Level;

		public float Count;
	}

	private Dictionary<string, List<SpecialLevel>> ItemSpecialLevel;

	private string Template1;

	private string Template2;

	private string BaseItemId;

	private float Base;

	private float Additional;

	private const int DisplayPeriod = 21600;

	public TechType4_Parser(GDEItemData gdeData)
	{
		Template1 = ("GvGOuterTechEffect_" + gdeData.Key + "_1").ToLanguage();
		TypeEffect effect = gdeData.Effect.ToObject<ConfigData>().Effect;
		BaseItemId = effect.Base.ItemId;
		Base = (float)effect.Base.Quantity * (21600f / (float)effect.Base.Period);
		Additional = (float)effect.Additional.Quantity * (21600f / (float)effect.Additional.Period);
		if (effect.Special.Count <= 0)
		{
			return;
		}
		Template2 = ("GvGOuterTechEffect_" + gdeData.Key + "_2").ToLanguage();
		ItemSpecialLevel = new Dictionary<string, List<SpecialLevel>>();
		foreach (KeyValuePair<string, Reward> item in effect.Special)
		{
			Reward value = item.Value;
			int level = int.Parse(item.Key);
			if (!ItemSpecialLevel.ContainsKey(value.ItemId))
			{
				ItemSpecialLevel.Add(value.ItemId, new List<SpecialLevel>());
			}
			ItemSpecialLevel[value.ItemId].Add(new SpecialLevel
			{
				Level = level,
				Count = (float)value.Quantity * (21600f / (float)value.Period)
			});
		}
		if (ItemSpecialLevel.Count > 2)
		{
			ILRuntimeDebug.LogError("[TechType4_Parser] ItemId=" + gdeData.Key + " 配置错误，存在2个以上物品：" + ItemSpecialLevel.Keys.ToList().ToJson() + ", Effect=" + gdeData.Effect);
		}
	}

	public string GetLevelDesc(int level)
	{
		float num = 0f;
		float num2 = 0f;
		if (level > 0)
		{
			num = Base + (float)(level - 1) * Additional;
			if (ItemSpecialLevel != null)
			{
				foreach (KeyValuePair<string, List<SpecialLevel>> item in ItemSpecialLevel)
				{
					if (item.Key == BaseItemId)
					{
						num += item.Value.Where((SpecialLevel item) => item.Level <= level).Sum((SpecialLevel item) => item.Count);
					}
					else
					{
						num2 += item.Value.Where((SpecialLevel item) => item.Level <= level).Sum((SpecialLevel item) => item.Count);
					}
				}
			}
		}
		if (num2 > 0f)
		{
			return Template2.Format(Mathf.FloorToInt(num), Mathf.FloorToInt(num2));
		}
		return Template1.Format(Mathf.FloorToInt(num));
	}
}
