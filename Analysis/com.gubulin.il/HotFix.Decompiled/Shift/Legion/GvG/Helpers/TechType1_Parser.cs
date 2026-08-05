using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

namespace Shift.Legion.GvG.Helpers;

public class TechType1_Parser : TechEffectBase, ITechEffectParser
{
	public class ConfigData : OuterTechEffectConfig
	{
		public TypeEffect Effect;
	}

	public class TypeEffect
	{
		public SubEffect Base = new SubEffect();

		public SubEffect Additional = new SubEffect();
	}

	public class SubEffect
	{
		public int LimitTimes;
	}

	private readonly string Text;

	private int Base;

	private int Additional;

	public TechType1_Parser(GDEItemData gdeData)
	{
		TypeEffect effect = gdeData.Effect.ToObject<ConfigData>().Effect;
		Text = ("GvGOuterTechEffect_" + gdeData.Key).ToLanguage();
		Base = effect.Base.LimitTimes;
		Additional = effect.Additional.LimitTimes;
	}

	public int GetX(int level)
	{
		int result = 0;
		if (level > 0)
		{
			result = Base + (level - 1) * Additional;
		}
		return result;
	}

	public string GetLevelDesc(int level)
	{
		int x = GetX(level);
		return HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(Text, $"{x}");
	}
}
