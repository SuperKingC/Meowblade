using System.Collections.Generic;
using Shift.Legion.GvG.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class ShipConfigModel
{
	public string DefaultName;

	public string RaceInfo_LangId;

	public int DefaultSkinId;

	public Dictionary<string, int> Requirement;

	public Dictionary<string, int> RebuildRequirement;

	public int BuildTime;

	public EntityChk Chk;
}
