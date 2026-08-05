using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;

namespace Shift.Legion.GvG.Helpers;

public class TechDefault_Parser : TechEffectBase, ITechEffectParser
{
	public string Text;

	public TechDefault_Parser(GDEItemData gdeData)
	{
		Text = ("GvGOuterTechEffect_" + gdeData.Key).ToLanguage();
	}

	public string GetLevelDesc(int level)
	{
		return Text;
	}
}
