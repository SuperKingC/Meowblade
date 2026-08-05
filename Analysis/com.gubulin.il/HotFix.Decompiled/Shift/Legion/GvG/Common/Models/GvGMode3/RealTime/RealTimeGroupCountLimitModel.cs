using System;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.RealTime;

[ProtoContract]
public class RealTimeGroupCountLimitModel
{
	private const string GroupCountLimitParTitle = "GroupCountLimitParTitle";

	private const string RealTimeGroupCountLimitPar1 = "RealTimeGroupCountLimitPar1";

	private const string RealTimeGroupCountLimitPar2 = "RealTimeGroupCountLimitPar2";

	private const string RealTimeGroupCountLimitPar3 = "RealTimeGroupCountLimitPar3";

	private const string RealTimeGroupCountLimitPar4 = "RealTimeGroupCountLimitPar4";

	private const string RealTimeGroupCountLimitPar5 = "RealTimeGroupCountLimitPar5";

	private const string RealTimeGroupCountLimitPar6 = "RealTimeGroupCountLimitPar6";

	private const string RealTimeGroupCountLimitPar7 = "RealTimeGroupCountLimitPar7";

	private const string RealTimeGroupCountLimitPar8 = "RealTimeGroupCountLimitPar8";

	[ProtoMember(1)]
	public int 基础 { get; set; } = 0;

	[ProtoMember(3)]
	public int 场外科技 { get; set; } = 0;

	[ProtoMember(5)]
	public int 船舱扩容 { get; set; } = 0;

	[ProtoMember(6)]
	public int 机械降神 { get; set; } = 0;

	[ProtoMember(7)]
	public int 指挥官 { get; set; } = 0;

	[ProtoMember(8)]
	public int 总司令 { get; set; } = 0;

	[ProtoMember(9)]
	public int 骑空领主 { get; set; } = 0;

	[ProtoMember(10)]
	public int 空域主宰 { get; set; } = 0;

	public int TotalLimit => ObserverConfigHelper.DefaultsConfig.MaxGroupCountLimit;

	public int FinalTotal => Mathf.Min(Total, TotalLimit);

	public int Total => 基础 + TotalBuff;

	public int TotalBuff => 场外科技 + 船舱扩容 + 机械降神 + 指挥官 + 总司令 + 骑空领主 + 空域主宰;

	public bool HasBuff => TotalBuff > 0;

	public string GetText()
	{
		if (Total <= 1)
		{
			return string.Empty;
		}
		string text = "GroupCountLimitParTitle".ToLanguage();
		if (场外科技 > 0)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar1".ToLanguage().Format(场外科技);
		}
		if (船舱扩容 > 0)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar2".ToLanguage().Format(船舱扩容);
		}
		if (机械降神 > 0)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar3".ToLanguage().Format(机械降神);
		}
		if (指挥官 > 0)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar4".ToLanguage().Format(指挥官);
		}
		if (总司令 > 0)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar5".ToLanguage().Format(总司令);
		}
		if (骑空领主 > 0)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar6".ToLanguage().Format(骑空领主);
		}
		if (空域主宰 > 0)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar7".ToLanguage().Format(空域主宰);
		}
		if (Total > TotalLimit)
		{
			text = text + Environment.NewLine + "RealTimeGroupCountLimitPar8".ToLanguage();
		}
		return text;
	}
}
