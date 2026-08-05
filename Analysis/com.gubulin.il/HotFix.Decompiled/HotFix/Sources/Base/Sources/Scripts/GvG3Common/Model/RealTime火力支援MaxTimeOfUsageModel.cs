using System;
using HotFix.Sources.Base.Scripts.Helper;
using ILRuntime_LitJson;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class RealTime火力支援MaxTimeOfUsageModel
{
	[ProtoMember(1)]
	public int 基础;

	[ProtoMember(2)]
	public int 额外火力;

	[JsonIgnore]
	private const string RealTime火力支援MaxTimeOfUsageModelTitle = "RealTimeFireSupportMaxTimeOfUsageModelTitle";

	[JsonIgnore]
	private const string RealTime火力支援MaxTimeOfUsageModelPar1 = "RealTimeFireSupportMaxTimeOfUsageModelPar1";

	[JsonIgnore]
	public float Total => 基础 + 额外火力;

	public bool HasExtra()
	{
		return 额外火力 > 0;
	}

	public string GetText()
	{
		if (!HasExtra())
		{
			return string.Empty;
		}
		string text = "RealTimeFireSupportMaxTimeOfUsageModelTitle".ToLanguage();
		if (额外火力 > 0)
		{
			text = text + Environment.NewLine + "RealTimeFireSupportMaxTimeOfUsageModelPar1".ToLanguage().Format(额外火力);
		}
		return text;
	}

	public RealTime火力支援MaxTimeOfUsageModel Clone()
	{
		return new RealTime火力支援MaxTimeOfUsageModel
		{
			额外火力 = 额外火力
		};
	}
}
