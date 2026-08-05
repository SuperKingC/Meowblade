using System;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class RealTimeCollectingEfficiencyModel
{
	[ProtoMember(1)]
	public float 强力矿镐;

	[ProtoMember(2)]
	public float 岛屿加成;

	[ProtoMember(3)]
	public float 原始积累;

	[ProtoMember(4)]
	public float 量变质变;

	[ProtoMember(5)]
	public float 熟能生巧;

	[ProtoMember(6)]
	public float 趁热打铁;

	[ProtoMember(7)]
	public float 勘探师;

	[ProtoMember(8)]
	public float 开拓者;

	[ProtoMember(9)]
	public float 地质学家;

	[ProtoMember(10)]
	public float 大探险家;

	[ProtoMember(11)]
	public float 军垦支援;

	private const string CollectingEfficiencyTitle = "GvGModel3RealTimeCollectingEfficiencyTitle";

	private const string RealTimeCollectingEfficiency1 = "GvGModel3RealTimeCollectingEfficiency1";

	private const string RealTimeCollectingEfficiency2 = "GvGModel3RealTimeCollectingEfficiency2";

	private const string RealTimeCollectingEfficiency3 = "GvGModel3RealTimeCollectingEfficiency3";

	private const string RealTimeCollectingEfficiency4 = "GvGModel3RealTimeCollectingEfficiency4";

	private const string RealTimeCollectingEfficiency5 = "GvGModel3RealTimeCollectingEfficiency5";

	private const string RealTimeCollectingEfficiency6 = "GvGModel3RealTimeCollectingEfficiency6";

	private const string RealTimeCollectingEfficiency7 = "GvGModel3RealTimeCollectingEfficiency7";

	private const string RealTimeCollectingEfficiency8 = "GvGModel3RealTimeCollectingEfficiency8";

	private const string RealTimeCollectingEfficiency9 = "GvGModel3RealTimeCollectingEfficiency9";

	private const string RealTimeCollectingEfficiency10 = "GvGModel3RealTimeCollectingEfficiency10";

	private const string RealTimeCollectingEfficiency11 = "GvGModel3RealTimeCollectingEfficiency11";

	public float Total => 强力矿镐 + 岛屿加成 + 原始积累 + 量变质变 + 熟能生巧 + 趁热打铁 + 勘探师 + 开拓者 + 地质学家 + 大探险家 + 军垦支援;

	public bool HasRealTimeCollectingEfficiency()
	{
		return 强力矿镐 > 0f || 岛屿加成 > 0f || 原始积累 > 0f || 量变质变 > 0f || 熟能生巧 > 0f || 趁热打铁 > 0f || 勘探师 > 0f || 开拓者 > 0f || 地质学家 > 0f || 大探险家 > 0f || 军垦支援 > 0f;
	}

	public string GetCollectingEfficiencyText()
	{
		if (!HasRealTimeCollectingEfficiency())
		{
			return string.Empty;
		}
		string text = "GvGModel3RealTimeCollectingEfficiencyTitle".ToLanguage();
		if (强力矿镐 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency1".ToLanguage(), new object[1] { $"{强力矿镐 * 100f:0.#}" });
		}
		if (岛屿加成 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency2".ToLanguage(), new object[1] { $"{岛屿加成 * 100f:0.#}" });
		}
		if (原始积累 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency3".ToLanguage(), new object[1] { $"{原始积累 * 100f:0.#}" });
		}
		if (量变质变 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency4".ToLanguage(), new object[1] { $"{量变质变 * 100f:0.#}" });
		}
		if (熟能生巧 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency5".ToLanguage(), new object[1] { $"{熟能生巧 * 100f:0.#}" });
		}
		if (趁热打铁 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency6".ToLanguage(), new object[1] { $"{趁热打铁 * 100f:0.#}" });
		}
		if (勘探师 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency7".ToLanguage(), new object[1] { $"{勘探师 * 100f:0.#}" });
		}
		if (开拓者 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency8".ToLanguage(), new object[1] { $"{开拓者 * 100f:0.#}" });
		}
		if (地质学家 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency9".ToLanguage(), new object[1] { $"{地质学家 * 100f:0.#}" });
		}
		if (大探险家 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency10".ToLanguage(), new object[1] { $"{大探险家 * 100f:0.#}" });
		}
		if (军垦支援 > 0f)
		{
			text = text + Environment.NewLine + string.Format("GvGModel3RealTimeCollectingEfficiency11".ToLanguage(), new object[1] { $"{军垦支援 * 100f:0.#}" });
		}
		return text;
	}

	public RealTimeCollectingEfficiencyModel Clone()
	{
		return new RealTimeCollectingEfficiencyModel
		{
			强力矿镐 = 强力矿镐,
			岛屿加成 = 岛屿加成,
			原始积累 = 原始积累,
			量变质变 = 量变质变,
			熟能生巧 = 熟能生巧,
			趁热打铁 = 趁热打铁,
			勘探师 = 勘探师,
			开拓者 = 开拓者,
			地质学家 = 地质学家,
			大探险家 = 大探险家,
			军垦支援 = 军垦支援
		};
	}
}
