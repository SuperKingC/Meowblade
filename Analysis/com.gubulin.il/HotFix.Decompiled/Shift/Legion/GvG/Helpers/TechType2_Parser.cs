using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

namespace Shift.Legion.GvG.Helpers;

public class TechType2_Parser : TechEffectBase, ITechEffectParser
{
	public class ConfigData : OuterTechEffectConfig
	{
		public TypeEffect Effect;
	}

	public class TypeEffect
	{
		public Buff Base = new Buff();

		public Buff Additional = new Buff();

		public Dictionary<string, Buff> Special = new Dictionary<string, Buff>();
	}

	public class Buff
	{
		public List<float> Desc = new List<float>();
	}

	public class SpecialLevel
	{
		public int Level;

		public List<float> Desc;
	}

	private string Template1;

	private List<float> Base;

	private List<float> Additional;

	private List<SpecialLevel> SpecialBuffLevel;

	public TechType2_Parser(GDEItemData gdeData)
	{
		Template1 = ("GvGOuterTechEffect_" + gdeData.Key).ToLanguage();
		TypeEffect effect = gdeData.Effect.ToObject<ConfigData>().Effect;
		int count = effect.Base.Desc.Count;
		Base = effect.Base.Desc;
		Additional = effect.Additional.Desc;
		for (int i = 0; i < count; i++)
		{
			if (i == Additional.Count)
			{
				Additional.Add(0f);
			}
		}
		if (effect.Special.Count <= 0)
		{
			return;
		}
		SpecialBuffLevel = new List<SpecialLevel>();
		foreach (KeyValuePair<string, Buff> item in effect.Special)
		{
			int level = int.Parse(item.Key);
			List<float> desc = item.Value.Desc;
			for (int j = 0; j < count; j++)
			{
				if (j == desc.Count)
				{
					desc.Add(0f);
				}
			}
			SpecialBuffLevel.Add(new SpecialLevel
			{
				Level = level,
				Desc = desc
			});
		}
	}

	public string GetLevelDesc(int level)
	{
		float[] array = new float[Base.Count];
		if (level > 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Base[i] + (float)(level - 1) * Additional[i];
			}
			if (SpecialBuffLevel != null)
			{
				foreach (SpecialLevel item in SpecialBuffLevel)
				{
					if (item.Level <= level)
					{
						for (int j = 0; j < array.Length; j++)
						{
							array[j] += item.Desc[j];
						}
					}
				}
			}
		}
		object[] array2 = new object[Base.Count];
		for (int k = 0; k < array.Length; k++)
		{
			array2[k] = array[k];
		}
		return Template1.Format(array2);
	}
}
