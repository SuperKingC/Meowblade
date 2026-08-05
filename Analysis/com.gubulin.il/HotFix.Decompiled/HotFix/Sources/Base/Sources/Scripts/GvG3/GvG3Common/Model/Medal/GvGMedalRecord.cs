using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;
using ILRuntime_LitJson;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;

public class GvGMedalRecord
{
	[JsonIgnore]
	private GvGMedalConfig _config;

	public string MedalId { get; set; }

	public string MedalType { get; set; }

	public int Level { get; set; }

	public bool IsShowing { get; set; }

	public List<MedalRecord> Records { get; set; } = new List<MedalRecord>();

	[JsonIgnore]
	public GvGMedalConfig Config => _config ?? (_config = new GvGMedalConfig(MedalId));

	[JsonIgnore]
	public int Rank { get; set; }

	[JsonIgnore]
	public bool Activated { get; set; }

	[JsonIgnore]
	public MedalUiState UiState => IsShowing ? MedalUiState.Displaying : MedalUiState.None;
}
