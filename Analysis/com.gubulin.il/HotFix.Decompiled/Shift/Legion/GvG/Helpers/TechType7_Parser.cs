using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using UnityEngine;

namespace Shift.Legion.GvG.Helpers;

public class TechType7_Parser : TechEffectBase, ITechEffectParser
{
	public class ConfigData : OuterTechEffectConfig
	{
		public TypeEffect Effect;
	}

	public class TypeEffect
	{
		public Reward Base = new Reward();

		public CoolDown Additional = new CoolDown();

		public Dictionary<string, CoolDown> Special = new Dictionary<string, CoolDown>();
	}

	public class Reward
	{
		public int Period;
	}

	public class CoolDown
	{
		public int ReduceCD;
	}

	public class SpecialLevel
	{
		public int Level;

		public int ReduceCD;
	}

	private List<SpecialLevel> SpecialLevels;

	private string Template1;

	private int Base;

	private int AdditionalReduce;

	private const int SecondsInAnHour = 3600;

	public TechType7_Parser(GDEItemData gdeData)
	{
		Template1 = ("GvGOuterTechEffect_" + gdeData.Key).ToLanguage();
		TypeEffect effect = gdeData.Effect.ToObject<ConfigData>().Effect;
		Base = effect.Base.Period;
		AdditionalReduce = effect.Additional.ReduceCD;
		if (effect.Special.Count <= 0)
		{
			return;
		}
		SpecialLevels = new List<SpecialLevel>();
		foreach (KeyValuePair<string, CoolDown> item in effect.Special)
		{
			SpecialLevels.Add(new SpecialLevel
			{
				Level = int.Parse(item.Key),
				ReduceCD = item.Value.ReduceCD
			});
		}
	}

	public string GetLevelDesc(int level)
	{
		float num = 0f;
		if (level > 0)
		{
			num = (level - 1) * AdditionalReduce;
			if (SpecialLevels != null)
			{
				num += (float)SpecialLevels.Where((SpecialLevel item) => item.Level <= level).Sum((SpecialLevel item) => item.ReduceCD);
			}
		}
		int num2 = Mathf.FloorToInt(((float)Base - num) / 3600f);
		return Template1.Format(num2);
	}
}
