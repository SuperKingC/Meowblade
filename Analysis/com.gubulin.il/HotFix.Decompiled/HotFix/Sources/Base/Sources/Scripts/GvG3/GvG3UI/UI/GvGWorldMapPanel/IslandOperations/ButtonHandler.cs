using System;
using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class ButtonHandler
{
	private readonly List<IConditionInfo> _conditions = new List<IConditionInfo>();

	private int _currentConditionIndex;

	private readonly Action _executeButtonAction;

	public ButtonHandler(Action executeAction)
	{
		_executeButtonAction = executeAction;
	}

	public void AddCondition(IConditionInfo condition)
	{
		_conditions.Add(condition);
	}

	public void AddCondition(List<IConditionInfo> conditions)
	{
		_conditions.AddRange(conditions);
	}

	public void OnClickButton()
	{
		_currentConditionIndex = 0;
		CheckAndExecuteButton();
	}

	protected void CheckAndExecuteButton()
	{
		if (_currentConditionIndex >= _conditions.Count)
		{
			_executeButtonAction?.Invoke();
			return;
		}
		IConditionInfo conditionInfo = _conditions[_currentConditionIndex];
		if (!conditionInfo.CheckCondition())
		{
			conditionInfo.ShowConfirmationDialog(ContinueCheckNextCondition, BreakCheckConditions);
		}
		else
		{
			ContinueCheckNextCondition();
		}
	}

	protected void ContinueCheckNextCondition()
	{
		_currentConditionIndex++;
		CheckAndExecuteButton();
	}

	protected void BreakCheckConditions()
	{
		_currentConditionIndex = 0;
	}
}
