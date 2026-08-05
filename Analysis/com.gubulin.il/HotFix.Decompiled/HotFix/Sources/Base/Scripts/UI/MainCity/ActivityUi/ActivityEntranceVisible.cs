using System.Collections.Generic;

namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public class ActivityEntranceVisible
{
	public Dictionary<ActivityEntranceMode, bool> Visible = new Dictionary<ActivityEntranceMode, bool>(2);

	public Dictionary<ActivityEntranceMode, List<string>> OriginData;

	public List<string> GetVisibleUis(ActivityEntranceMode mode)
	{
		return OriginData[mode];
	}
}
