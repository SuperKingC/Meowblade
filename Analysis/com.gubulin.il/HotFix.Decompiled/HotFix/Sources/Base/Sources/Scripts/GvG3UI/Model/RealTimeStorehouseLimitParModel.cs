using System;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

[ProtoContract]
public class RealTimeStorehouseLimitParModel
{
	[ProtoMember(1)]
	public float 场外科技;

	[ProtoMember(2)]
	public float 仓储管理;

	private const string StorehouseLimitParTitle = "GvGModel3RealTimeStorehouseLimitParTitle";

	private const string RealTimeStorehouseLimitPar1 = "GvGModel3RealTimeStorehouseLimitPar1";

	private const string RealTimeStorehouseLimitPar2 = "GvGModel3RealTimeStorehouseLimitPar2";

	public float Total => 场外科技 + 仓储管理 + 1f;

	public string GetStorehouseLimitParText()
	{
		if (Total <= 1f)
		{
			return string.Empty;
		}
		string text = "GvGModel3RealTimeStorehouseLimitParTitle".ToLanguage();
		if (场外科技 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeStorehouseLimitPar1".ToLanguage(), new object[1] { Convert.ToInt32(场外科技 * 100f) });
		}
		if (仓储管理 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeStorehouseLimitPar2".ToLanguage(), new object[1] { Convert.ToInt32(仓储管理 * 100f) });
		}
		return text;
	}
}
