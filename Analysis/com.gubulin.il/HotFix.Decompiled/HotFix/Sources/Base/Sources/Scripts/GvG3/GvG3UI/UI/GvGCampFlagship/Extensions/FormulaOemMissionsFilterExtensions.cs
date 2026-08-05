using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.Extensions;

public static class FormulaOemMissionsFilterExtensions
{
	public static FormulaOemMissionsFilter CreateDefaultFilter()
	{
		return new FormulaOemMissionsFilter
		{
			Quality = 0,
			Race = -1,
			Soldier = null,
			Prop = null,
			HasTitanTalent = false
		};
	}

	public static bool IsDefaultFilter(this FormulaOemMissionsFilter filter)
	{
		if (filter.Quality != 0)
		{
			return false;
		}
		if (filter.Race != -1)
		{
			return false;
		}
		if (filter.HasTitanTalent)
		{
			return false;
		}
		if (filter.Prop != null)
		{
			return false;
		}
		if (filter.Soldier != null)
		{
			return false;
		}
		return true;
	}
}
