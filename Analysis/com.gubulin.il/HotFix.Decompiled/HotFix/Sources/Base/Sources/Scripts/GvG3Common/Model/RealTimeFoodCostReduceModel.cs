using System;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class RealTimeFoodCostReduceModel
{
	[ProtoMember(1)]
	public float 场外科技;

	[ProtoMember(2)]
	public float 扩散增幅;

	[ProtoMember(3)]
	public float 支援报酬;

	[ProtoMember(6)]
	public float 船体改造;

	private const string RealTimeFoodCostReduceTitle = "GvGModel3RealTimeFoodCostReduceTitle";

	private const string RealTimeFoodCostReduce1 = "RealTimeFoodCostReduce1";

	private const string RealTimeFoodCostReduce2 = "RealTimeFoodCostReduce2";

	private const string RealTimeFoodCostReduce3 = "RealTimeFoodCostReduce3";

	private const string RealTimeFoodCostReduce4 = "RealTimeFoodCostReduce4";

	private const string RealTimeFoodCostReduce6 = "RealTimeFoodCostReduce6";

	public float Total => 场外科技 + 扩散增幅 + 支援报酬 + 船体改造;

	public string GetEfficiencyText()
	{
		if (Total <= 0f)
		{
			return string.Empty;
		}
		string text = "GvGModel3RealTimeFoodCostReduceTitle".ToLanguage();
		if (场外科技 > 0f)
		{
			text = text + Environment.NewLine + string.Format("RealTimeFoodCostReduce1".ToLanguage(), new object[1] { Convert.ToInt32(场外科技 * 100f) });
		}
		if (扩散增幅 > 0f)
		{
			text = text + Environment.NewLine + string.Format("RealTimeFoodCostReduce2".ToLanguage(), new object[1] { Convert.ToInt32(扩散增幅 * 100f) });
		}
		if (支援报酬 > 0f)
		{
			text = text + Environment.NewLine + string.Format("RealTimeFoodCostReduce3".ToLanguage(), new object[1] { Convert.ToInt32(支援报酬 * 100f) });
		}
		if (船体改造 > 0f)
		{
			text = text + Environment.NewLine + string.Format("RealTimeFoodCostReduce6".ToLanguage(), new object[1] { Convert.ToInt32(船体改造 * 100f) });
		}
		return text;
	}

	public RealTimeFoodCostReduceModel Clone()
	{
		return new RealTimeFoodCostReduceModel
		{
			场外科技 = 场外科技,
			扩散增幅 = 扩散增幅,
			支援报酬 = 支援报酬,
			船体改造 = 船体改造
		};
	}
}
