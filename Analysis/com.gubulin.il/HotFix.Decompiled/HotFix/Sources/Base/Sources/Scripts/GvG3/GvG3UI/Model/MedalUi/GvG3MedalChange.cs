namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;

public class GvG3MedalChange
{
	public string MedalId { get; private set; }

	public bool Display { get; private set; }

	public GvG3MedalChange(string medalId, bool display)
	{
		MedalId = medalId;
		Display = display;
	}
}
