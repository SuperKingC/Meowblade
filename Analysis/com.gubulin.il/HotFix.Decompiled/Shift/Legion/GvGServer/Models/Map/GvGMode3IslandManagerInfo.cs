using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;

namespace Shift.Legion.GvGServer.Models.Map;

public class GvGMode3IslandManagerInfo
{
	public int UserCount;

	public int UserMinCount;

	public int UserMaxCount;

	public Dictionary<string, GvGMode3CampInfo> CampInfos;

	public GvGMode3IZInfo IZInfo;

	public string GetCampName(int campId)
	{
		if (CampInfos != null && CampInfos.TryGetValue($"{campId}", out var value))
		{
			return value.NameKey.ToLanguage();
		}
		ILRuntimeDebug.LogError($"[GvGMode3IslandManagerInfo] GetCampName campId={campId} 找不到阵营名 CampInfos is null: {CampInfos == null}");
		return "";
	}

	public GvGMode3CampInfo GetCampInfo(int campId)
	{
		if (CampInfos != null && CampInfos.TryGetValue($"{campId}", out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError($"[GvGMode3IslandManagerInfo] GetCampInfo campId={campId} 找不到阵营信息 CampInfos is null: {CampInfos == null}");
		return null;
	}
}
