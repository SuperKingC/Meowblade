using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

namespace Shift.Legion.GvG.Helpers;

public class TechType5_Parser : TechEffectBase, ITechEffectParser
{
	public class ConfigData : OuterTechEffectConfig
	{
		public TypeEffect Effect;
	}

	public class TypeEffect
	{
		public int SubType = 0;

		public object Base;

		public object Additional;
	}

	public class SubConfig1
	{
		public int Percent;
	}

	public class SubConfig2
	{
		public int Qty;
	}

	private readonly string Text;

	private int SubType;

	private object BaseConfig;

	private object AdditionalConfig;

	public TechType5_Parser(GDEItemData gdeData)
	{
		Text = ("GvGOuterTechEffect_" + gdeData.Key).ToLanguage();
		TypeEffect effect = gdeData.Effect.ToObject<ConfigData>().Effect;
		SubType = effect.SubType;
		switch (SubType)
		{
		case 1:
			BaseConfig = effect.Base?.TryGet<SubConfig1>("Config");
			AdditionalConfig = effect.Additional?.TryGet<SubConfig1>("Config");
			break;
		case 2:
			BaseConfig = effect.Base?.TryGet<SubConfig2>("Config");
			AdditionalConfig = effect.Additional?.TryGet<SubConfig2>("Config");
			break;
		}
	}

	public string GetLevelDesc(int level)
	{
		switch (SubType)
		{
		case 1:
		{
			int num3 = ((BaseConfig != null) ? ((SubConfig1)BaseConfig).Percent : 0);
			int num4 = ((AdditionalConfig != null) ? ((SubConfig1)AdditionalConfig).Percent : 0);
			return Text.Format(num3 + (level - 1) * num4);
		}
		case 2:
		{
			int num = ((BaseConfig != null) ? ((SubConfig2)BaseConfig).Qty : 0);
			int num2 = ((AdditionalConfig != null) ? ((SubConfig2)AdditionalConfig).Qty : 0);
			return Text.Format(num + (level - 1) * num2);
		}
		default:
			return Text;
		}
	}
}
