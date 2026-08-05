using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.GvG.Common.Enums;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

public class ContributionPointsChanged
{
	public int ContributionKey;

	public float ChangedValue;

	public float Per;

	public string Desc => $"GvG3Contribution_{(eContributionKey)ContributionKey}".ToLanguage();

	public string Icon => $"GvG3Contribution_{(eContributionKey)ContributionKey}";
}
