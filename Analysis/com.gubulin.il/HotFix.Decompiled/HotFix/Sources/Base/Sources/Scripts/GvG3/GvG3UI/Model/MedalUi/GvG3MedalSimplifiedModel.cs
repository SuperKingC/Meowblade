using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;

public class GvG3MedalSimplifiedModel
{
	public string MedalId { get; }

	public GvGMedalConfig Config { get; }

	public int MedalLevel { get; }

	public int State => (!string.IsNullOrEmpty(MedalId)) ? 1 : 0;

	public GvG3MedalSimplifiedModel(string medalId, GvGMedalConfig config, int medalLevel)
	{
		MedalId = medalId;
		Config = config;
		MedalLevel = medalLevel;
	}
}
