using System;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

[ProtoContract]
public class RealTimeCombatPowerModel
{
	[ProtoMember(1)]
	public bool 场外科技 = false;

	[ProtoMember(2)]
	public bool 元魔献祭 = false;

	[ProtoMember(3)]
	public bool 增幅器 = false;

	private const string RealTimeCombatPowerTitle = "GvGModel3RealTimeCombatPowerTitle";

	private const string RealTimeCombatPower1 = "GvGModel3RealTimeCombatPower1";

	private const string RealTimeCombatPower2 = "GvGModel3RealTimeCombatPower2";

	private const string RealTimeCombatPower3 = "GvGModel3RealTimeCombatPower3";

	public bool Total => 场外科技 || 元魔献祭 || 增幅器;

	public string GetRealTimeCombatPowerText()
	{
		if (!Total)
		{
			return string.Empty;
		}
		string text = "GvGModel3RealTimeCombatPowerTitle".ToLanguage();
		if (场外科技)
		{
			text = text + Environment.NewLine + "GvGModel3RealTimeCombatPower1".ToLanguage();
		}
		if (元魔献祭)
		{
			text = text + Environment.NewLine + "GvGModel3RealTimeCombatPower2".ToLanguage();
		}
		if (增幅器)
		{
			text = text + Environment.NewLine + "GvGModel3RealTimeCombatPower3".ToLanguage();
		}
		return text;
	}

	public RealTimeCombatPowerModel Clone()
	{
		return new RealTimeCombatPowerModel
		{
			场外科技 = 场外科技,
			元魔献祭 = 元魔献祭,
			增幅器 = 增幅器
		};
	}
}
