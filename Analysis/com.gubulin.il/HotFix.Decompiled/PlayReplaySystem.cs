using Shift.Legion.Common.Services;

public class PlayReplaySystem : BaseExecuteSystem
{
	private readonly ReplayPlayerService _replayPlayerService;

	public PlayReplaySystem(Contexts contexts)
		: base(contexts)
	{
		_replayPlayerService = contexts.Service<ReplayPlayerService>();
	}

	public override void Execute()
	{
		_replayPlayerService.PlayNextFrame();
		_replayPlayerService.DownloadNextFragment();
	}
}
