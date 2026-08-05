using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

namespace Shift.Legion.GvG.Helpers;

public class TechType3_Parser : TechEffectBase, ITechEffectParser
{
	public class ConfigData : OuterTechEffectConfig
	{
		public TypeEffect Effect;
	}

	public class TypeEffect
	{
		public Dictionary<string, int> Base = new Dictionary<string, int>();

		public Dictionary<string, int> Additional = new Dictionary<string, int>();

		public Dictionary<string, Dictionary<string, int>> Special = new Dictionary<string, Dictionary<string, int>>();
	}

	public class SpecialLevel
	{
		public int Level;

		public int Count;
	}

	private string Template1;

	private string Template2;

	private string BaseItemId;

	private int Base;

	private int Additional;

	private Dictionary<string, List<SpecialLevel>> ItemSpecialLevel;

	public TechType3_Parser(GDEItemData gdeData)
	{
		Template1 = ("GvGOuterTechEffect_" + gdeData.Key + "_1").ToLanguage();
		TypeEffect effect = gdeData.Effect.ToObject<ConfigData>().Effect;
		KeyValuePair<string, int> keyValuePair = effect.Base.First();
		BaseItemId = keyValuePair.Key;
		Base = keyValuePair.Value;
		Additional = effect.Additional.Sum((KeyValuePair<string, int> kv) => kv.Value);
		if (effect.Special.Count <= 0)
		{
			return;
		}
		Template2 = ("GvGOuterTechEffect_" + gdeData.Key + "_2").ToLanguage();
		ItemSpecialLevel = new Dictionary<string, List<SpecialLevel>>();
		foreach (KeyValuePair<string, Dictionary<string, int>> item in effect.Special)
		{
			int level = int.Parse(item.Key);
			foreach (KeyValuePair<string, int> item2 in item.Value)
			{
				if (!ItemSpecialLevel.ContainsKey(item2.Key))
				{
					ItemSpecialLevel.Add(item2.Key, new List<SpecialLevel>());
				}
				ItemSpecialLevel[item2.Key].Add(new SpecialLevel
				{
					Level = level,
					Count = item2.Value
				});
			}
		}
		if (ItemSpecialLevel.Count > 2)
		{
			ILRuntimeDebug.LogError("[TechType3_Parser] ItemId=" + gdeData.Key + " 配置错误，存在2个以上物品：" + ItemSpecialLevel.Keys.ToList().ToJson() + ", Effect=" + gdeData.Effect);
		}
	}

	public string GetLevelDesc(int level)
	{
		int num = 0;
		int num2 = 0;
		if (level > 0)
		{
			num = Base + (level - 1) * Additional;
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
		if (num2 > 0)
		{
			return Template2.Format(num, num2);
		}
		return Template1.Format(num);
	}
}
