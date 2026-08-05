using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class InformConfig
{
	public string Context;

	public string InformUi;

	public Dictionary<string, object> UiParams;

	public object Clone()
	{
		InformConfig informConfig = new InformConfig
		{
			UiParams = new Dictionary<string, object>(),
			Context = Context,
			InformUi = InformUi
		};
		foreach (KeyValuePair<string, object> uiParam in UiParams)
		{
			informConfig.UiParams.Add(uiParam.Key, uiParam.Value);
		}
		return informConfig;
	}
}
