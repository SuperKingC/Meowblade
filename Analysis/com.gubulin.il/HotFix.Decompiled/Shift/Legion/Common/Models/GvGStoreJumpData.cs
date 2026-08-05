using System;
using System.Collections.Generic;
using ILRuntime_LitJson;
using Shift.Legion.Common.Services;

namespace Shift.Legion.Common.Models;

public class GvGStoreJumpData
{
	public string ItemId;

	public string Title;

	public string Cycle;

	public int NumLimit;

	public string JumpContext;

	public Dictionary<string, object> JumpContextParams;

	[JsonIgnore]
	public Func<bool> CheckGoToCondition { get; set; }

	public void GoToRelativeUi()
	{
		if (string.IsNullOrEmpty(JumpContext))
		{
			throw new Exception(ItemId + " 没有配置跳转界面");
		}
		if (CheckGoToCondition == null || CheckGoToCondition())
		{
			Contexts.sharedInstance.Service<IUiService>().OpenPanel(JumpContext, JumpContextParams);
		}
	}
}
