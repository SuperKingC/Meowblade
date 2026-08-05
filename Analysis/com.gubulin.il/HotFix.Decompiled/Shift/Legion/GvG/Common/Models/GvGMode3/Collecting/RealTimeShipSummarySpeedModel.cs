using System;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;

[ProtoContract]
public class RealTimeShipSummarySpeedModel
{
	[ProtoMember(2)]
	public float 兵贵神速;

	[ProtoMember(3)]
	public float 其疾如风;

	[ProtoMember(4)]
	public float 量变质变;

	[ProtoMember(5)]
	public float 扩散增幅;

	[ProtoMember(6)]
	public float 勘探师;

	[ProtoMember(7)]
	public float 开拓者;

	[ProtoMember(8)]
	public float 地质学家;

	[ProtoMember(9)]
	public float 大探险家;

	[ProtoMember(10)]
	public float 扬帆起航;

	[ProtoMember(11)]
	public float 军垦支援;

	[ProtoMember(1)]
	public float 启动;

	[ProtoMember(12)]
	public float 领空主权;

	private const string RealTimeShipSummarySpeedTitle = "GvGModel3RealTimeShipSummarySpeedTitle";

	private const string RealTimeShipSummarySpeed1 = "GvGModel3RealTimeShipSummarySpeed1";

	private const string RealTimeShipSummarySpeed2 = "GvGModel3RealTimeShipSummarySpeed2";

	private const string RealTimeShipSummarySpeed3 = "GvGModel3RealTimeShipSummarySpeed3";

	private const string RealTimeShipSummarySpeed4 = "GvGModel3RealTimeShipSummarySpeed4";

	private const string RealTimeShipSummarySpeed5 = "GvGModel3RealTimeShipSummarySpeed5";

	private const string RealTimeShipSummarySpeed6 = "GvGModel3RealTimeShipSummarySpeed6";

	private const string RealTimeShipSummarySpeed7 = "GvGModel3RealTimeShipSummarySpeed7";

	private const string RealTimeShipSummarySpeed8 = "GvGModel3RealTimeShipSummarySpeed8";

	private const string RealTimeShipSummarySpeed9 = "GvGModel3RealTimeShipSummarySpeed9";

	private const string RealTimeShipSummarySpeed10 = "GvGModel3RealTimeShipSummarySpeed10";

	private const string RealTimeShipSummarySpeed11 = "GvGModel3RealTimeShipSummarySpeed11";

	private const string RealTimeShipSummarySpeed12 = "GvGModel3RealTimeShipSummarySpeed12";

	public float Total => 1f + 启动 + 兵贵神速 + 其疾如风 + 量变质变 + 扩散增幅 + 勘探师 + 开拓者 + 地质学家 + 大探险家 + 扬帆起航 + 军垦支援 + 领空主权;

	public string GetEfficiencyText()
	{
		if (Total <= 1f)
		{
			return string.Empty;
		}
		string text = "GvGModel3RealTimeShipSummarySpeedTitle".ToLanguage();
		if (启动 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed1".ToLanguage(), new object[1] { $"{启动 * 100f:0.#}" });
		}
		if (兵贵神速 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed2".ToLanguage(), new object[1] { $"{兵贵神速 * 100f:0.#}" });
		}
		if (其疾如风 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed3".ToLanguage(), new object[1] { $"{其疾如风 * 100f:0.#}" });
		}
		if (量变质变 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed4".ToLanguage(), new object[1] { $"{量变质变 * 100f:0.#}" });
		}
		if (扩散增幅 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed5".ToLanguage(), new object[1] { $"{扩散增幅 * 100f:0.#}" });
		}
		if (勘探师 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed6".ToLanguage(), new object[1] { $"{勘探师 * 100f:0.#}" });
		}
		if (开拓者 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed7".ToLanguage(), new object[1] { $"{开拓者 * 100f:0.#}" });
		}
		if (地质学家 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed8".ToLanguage(), new object[1] { $"{地质学家 * 100f:0.#}" });
		}
		if (大探险家 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed9".ToLanguage(), new object[1] { $"{大探险家 * 100f:0.#}" });
		}
		if (扬帆起航 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed10".ToLanguage(), new object[1] { $"{扬帆起航 * 100f:0.#}" });
		}
		if (军垦支援 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed11".ToLanguage(), new object[1] { $"{军垦支援 * 100f:0.#}" });
		}
		if (领空主权 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeShipSummarySpeed12".ToLanguage(), new object[1] { $"{领空主权 * 100f:0.#}" });
		}
		return text;
	}

	public RealTimeShipSummarySpeedModel Clone()
	{
		return new RealTimeShipSummarySpeedModel
		{
			启动 = 启动,
			兵贵神速 = 兵贵神速,
			其疾如风 = 其疾如风,
			量变质变 = 量变质变,
			扩散增幅 = 扩散增幅,
			勘探师 = 勘探师,
			开拓者 = 开拓者,
			地质学家 = 地质学家,
			大探险家 = 大探险家,
			扬帆起航 = 扬帆起航,
			军垦支援 = 军垦支援
		};
	}
}
