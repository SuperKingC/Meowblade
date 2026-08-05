using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using UI.PublicResources;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class RenderHelper_RaceTypeIcon
{
	public static void RenderRaceType(GComponent comp, eRace race)
	{
		UI_com_RaceType uI_com_RaceType = (UI_com_RaceType)(object)comp;
		if (race == eRace.全种族)
		{
			uI_com_RaceType.IsAll.selectedIndex = 1;
			return;
		}
		uI_com_RaceType.IsAll.selectedIndex = 0;
		uI_com_RaceType.Type.selectedIndex = (int)race;
	}

	public static void RenderShipRaceType(GComponent comp, eRace race)
	{
		if (comp is UI_com_ShipRaceType)
		{
			UI_com_ShipRaceType uI_com_ShipRaceType = (UI_com_ShipRaceType)(object)comp;
			if (race == eRace.NPC || race == eRace.Invalid)
			{
				((GObject)uI_com_ShipRaceType.RaceIcon).visible = false;
				return;
			}
			((GObject)uI_com_ShipRaceType.RaceIcon).visible = true;
			uI_com_ShipRaceType.RaceIcon.url = race.ToRaceIconUrl();
		}
	}

	public static void RenderAmplifierAffectedRace(GComponent comp, AmplifierModel ampConfig)
	{
		RenderRaceType(comp, ampConfig.AffectedRace);
	}

	public static void RenderAmplifierAffectedRace(GComponent comp, int idx)
	{
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		RenderRaceType(comp, amplifierModel.AffectedRace);
	}
}
