using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Services;
using UI.GvGLoading;
using UI.Tips;

public class OpenLoadingUiCommandExecutor
{
	private readonly Contexts _contexts;

	public OpenLoadingUiCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(OpenLoadingUiCommand cmd)
	{
		bool flag = GameController.Contexts.Service<IUiService>().HasShowingUi(UI_main_GvGLoading2Panel.Name);
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Background", "ui://kt6rg65ojgn74r" },
			{
				"QueueType",
				_contexts.gameState.isLoadingShowAllSoldier
			},
			{
				"Direction",
				_contexts.gameState.loadingAnimationDirection.value
			},
			{ "MinTime", cmd.minTime },
			{ "Hide", flag }
		};
		_contexts.Service<IUiService>().OpenPanel(UI_LoadingPanel.Name, parameters, multiMode: true);
		_contexts.gameState.ReplaceLoadingPanelStatus(LoadingPanelStatus.Opening);
		ScriptApi.CreateTimer(_contexts, 1f, delegate
		{
			_contexts.gameState.ReplaceLoadingPanelStatus(LoadingPanelStatus.Showing);
		});
	}
}
