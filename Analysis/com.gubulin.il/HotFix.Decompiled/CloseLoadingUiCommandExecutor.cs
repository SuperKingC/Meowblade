using System;
using Shift.Legion.Common.Enums;

public class CloseLoadingUiCommandExecutor
{
	private readonly Contexts _contexts;

	public CloseLoadingUiCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		GameStateContext gameState = _contexts.gameState;
		gameState.ReplaceLoadingPanelStatus(LoadingPanelStatus.Closing);
		if (gameState.hasLoadingPanel)
		{
			gameState.loadingPanel.value.LoadComplete().Then((Action)delegate
			{
				gameState.ReplaceLoadingPanelStatus(LoadingPanelStatus.Closed);
			});
		}
		else
		{
			ILRuntimeDebug.LogError("gameState.hasLoadingPanel == false!");
		}
	}
}
