namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public interface IBrawlClaimedUiInfo
{
	int DayIndex { get; }

	string Date { get; }

	int ClaimedStatus { get; }

	int IsGenerated { get; }

	void SetClaimed();
}
