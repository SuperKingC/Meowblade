using System;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

public static class RaceHelper
{
	public static int FactionToRaceID(string faction)
	{
		if (Enum.TryParse<int>(faction, out var result))
		{
			ILRuntimeDebug.LogError("[RaceHelper] FactionToRaceID 找不到 faction = " + faction + " 的配置");
			return -1;
		}
		return result;
	}

	public static string RaceIDToFaction(int raceId)
	{
		return $"{(eRace)raceId}";
	}

	public static string GetRaceName(int raceId)
	{
		string key = $"FACTION_RACE_{raceId}";
		GDELanguagesData gDELanguagesData = GDMgr.Get<GDELanguagesData>(key);
		if (gDELanguagesData == null)
		{
			ILRuntimeDebug.LogError($"[RaceHelper] RaceHelper找不到 raceId = {raceId} 的相关配置");
			return "";
		}
		return gDELanguagesData.Template;
	}

	public static string GetFactionName(string faction)
	{
		int raceId = FactionToRaceID(faction);
		return GetRaceName(raceId);
	}

	public static eRace FactionToRaceEnum(string faction)
	{
		return (eRace)Enum.Parse(typeof(eRace), faction);
	}
}
