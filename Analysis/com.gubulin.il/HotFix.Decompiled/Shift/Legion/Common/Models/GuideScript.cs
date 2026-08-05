using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using GameMaths;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class GuideScript
{
	public Dictionary<string, object> configParams;

	public GuideScript(string scriptId)
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		GDEGuideScriptData gDEGuideScriptData = GDMgr.Get<GDEGuideScriptData>(scriptId);
		configParams = new Dictionary<string, object>();
		if (!string.IsNullOrEmpty(gDEGuideScriptData?.GuiderInfo))
		{
			configParams.Add("Guider", JsonHelper.ToObject<Dictionary<string, string>>(gDEGuideScriptData.GuiderInfo));
		}
		if (!string.IsNullOrEmpty(gDEGuideScriptData?.TipInfo))
		{
			configParams.Add("Tip", JsonHelper.ToObject<Dictionary<string, string>>(gDEGuideScriptData.TipInfo));
		}
		if (!string.IsNullOrEmpty(gDEGuideScriptData?.Highlight))
		{
			configParams.Add("Highlight", gDEGuideScriptData.Highlight.Split(',').ToList());
		}
		if (!string.IsNullOrEmpty(gDEGuideScriptData?.Background))
		{
			configParams.Add("Background", JsonHelper.ToObject<Dictionary<string, object>>(gDEGuideScriptData.Background));
		}
		configParams.Add("OffsetPos", Vector2.op_Implicit(gDEGuideScriptData.OffsetPos));
		configParams.Add("OffsetSize", Vector2.op_Implicit(gDEGuideScriptData.OffsetSize));
	}
}
