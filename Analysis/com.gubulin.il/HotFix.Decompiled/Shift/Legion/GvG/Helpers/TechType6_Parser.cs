using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

namespace Shift.Legion.GvG.Helpers;

public class TechType6_Parser : TechEffectBase, ITechEffectParser
{
	public class ConfigData : OuterTechEffectConfig
	{
		public TypeEffect Effect;
	}

	public class TypeEffect
	{
		public bool IsPercent;

		public Reward Base = new Reward();

		public Reward Additional = new Reward();

		public Dictionary<string, Reward> Special = new Dictionary<string, Reward>();
	}

	public class Reward
	{
		public float Buff;
	}

	public class SpecialLevel
	{
		public int Level;

		public float Buff;
	}

	private List<SpecialLevel> SpecialLevels;

	private string Template1;

	private string TemplateKey;

	private float Base;

	private float Additional;

	public bool IsPercent;

	public TechType6_Parser(GDEItemData gdeData)
	{
		TemplateKey = "GvGOuterTechEffect_" + gdeData.Key;
		Template1 = ("GvGOuterTechEffect_" + gdeData.Key).ToLanguage();
		TypeEffect effect = gdeData.Effect.ToObject<ConfigData>().Effect;
		Base = effect.Base.Buff;
		Additional = effect.Additional.Buff;
		IsPercent = effect.IsPercent;
		if (effect.Special.Count <= 0)
		{
			return;
		}
		SpecialLevels = new List<SpecialLevel>();
		foreach (KeyValuePair<string, Reward> item in effect.Special)
		{
			SpecialLevels.Add(new SpecialLevel
			{
				Level = int.Parse(item.Key),
				Buff = item.Value.Buff
			});
		}
	}

	public float GetX(int level)
	{
		float num = 0f;
		if (level > 0)
		{
			num = Base + (float)(level - 1) * Additional;
			if (SpecialLevels != null)
			{
				num += SpecialLevels.Where((SpecialLevel item) => item.Level <= level).Sum((SpecialLevel item) => item.Buff);
			}
		}
		return num;
	}

	public string GetLevelDesc(int level)
	{
		string text = TemplateKey + $"_lv{level}";
		int num = ((!IsPercent) ? 1 : 100);
		if (LanguagesManager.HasTemplate(text))
		{
			return text.ToLanguage($"{GetX(level) * (float)num:0.#}");
		}
		return HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(Template1, $"{GetX(level) * (float)num:0.#}");
	}
}
