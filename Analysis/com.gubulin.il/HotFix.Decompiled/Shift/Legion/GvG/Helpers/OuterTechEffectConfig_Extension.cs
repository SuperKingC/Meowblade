using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

namespace Shift.Legion.GvG.Helpers;

public static class OuterTechEffectConfig_Extension
{
	public static ITechEffectParser GetEffectParser(this eOuterTechType type, GDEItemData gdeData)
	{
		return type switch
		{
			eOuterTechType.NextReset => new TechType1_Parser(gdeData), 
			eOuterTechType.SoldierAbility => new TechType2_Parser(gdeData), 
			eOuterTechType.AddResourceOnce => new TechType3_Parser(gdeData), 
			eOuterTechType.AddResourcePeriod => new TechType4_Parser(gdeData), 
			eOuterTechType.AddTriggerEvent => new TechType5_Parser(gdeData), 
			eOuterTechType.AddGvGAttribute => new TechType6_Parser(gdeData), 
			eOuterTechType.AddReductCDResourcePeriod => new TechType7_Parser(gdeData), 
			eOuterTechType.SoldierAttr => new TechType99_Parser(gdeData), 
			_ => new TechDefault_Parser(gdeData), 
		};
	}
}
