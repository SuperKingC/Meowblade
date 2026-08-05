using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class IslandOperationButtonHandlers
{
	private readonly Dictionary<string, ButtonHandler> _buttonHandlers = new Dictionary<string, ButtonHandler>(6);

	public void AddButtonHandlers(string actionType, ButtonHandler buttonHandler)
	{
		_buttonHandlers[actionType] = buttonHandler;
	}

	public void ExecuteButtonClick(string actionType)
	{
		if (_buttonHandlers.TryGetValue(actionType, out var value))
		{
			value.OnClickButton();
		}
	}
}
