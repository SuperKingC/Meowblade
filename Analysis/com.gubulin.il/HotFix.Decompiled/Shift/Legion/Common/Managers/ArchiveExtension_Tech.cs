using System.Collections.Generic;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Tech
{
	private const string Key = "TECHNOLOGY_LEVEL";

	public static Dictionary<string, int> GetAllTechLevel(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, int>>("TECHNOLOGY_LEVEL");
	}

	public static int GetTechLevel(this UserArchiveManager manager, string techId)
	{
		return manager.GetValueOfDictConfig<int>("TECHNOLOGY_LEVEL", techId);
	}

	public static void SetTechLevel(this UserArchiveManager manager, string techId, int level)
	{
		manager.SetValueOfDictConfig("TECHNOLOGY_LEVEL", techId, level);
	}

	public static int GetArtifactLevel(this UserArchiveManager manager, TechnologyType type)
	{
		return type switch
		{
			TechnologyType.Dominion => manager.GetTechLevel(TechnologyManager.DominionArtifactKey), 
			TechnologyType.Doom => manager.GetTechLevel(TechnologyManager.DoomArtifactKey), 
			TechnologyType.Slavery => manager.GetTechLevel(TechnologyManager.SlaveryArtifactKey), 
			_ => 0, 
		};
	}

	public static int GetDoomArtifactLevel(this UserArchiveManager manager)
	{
		return manager.GetTechLevel(TechnologyManager.DoomArtifactKey);
	}

	public static int GetSlaveryArtifactLevel(this UserArchiveManager manager)
	{
		return manager.GetTechLevel(TechnologyManager.SlaveryArtifactKey);
	}

	public static int GetDominionArtifactLevel(this UserArchiveManager manager)
	{
		return manager.GetTechLevel(TechnologyManager.DominionArtifactKey);
	}
}
