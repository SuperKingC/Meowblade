using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using ProtoBuf;
using Shift.Legion.Common.Helpers;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class RealTimeAmplifierTalentModel
{
	[ProtoMember(2)]
	public float 配方改良_AmpConsumeDiscountRate;

	[ProtoMember(3)]
	public float 精益求精_ExtraAmpForgeHighQualityRate;

	[ProtoMember(4)]
	public float 场外_ExtraAmpForgeHighQualityRate;

	[ProtoMember(5)]
	public int 飞艇改良_ExtraAmplifierCountLimit;

	[ProtoMember(6)]
	public int 场外_ExtraAmplifierCountLimit;

	[ProtoMember(7)]
	public int AmplifierCountLimit;

	public float AmpConsumeDiscountRate => 配方改良_AmpConsumeDiscountRate;

	public float ExtraAmpForgeHighQualityRate => 精益求精_ExtraAmpForgeHighQualityRate + 场外_ExtraAmpForgeHighQualityRate;

	public int ExtraAmplifierCountLimit => 飞艇改良_ExtraAmplifierCountLimit + 场外_ExtraAmplifierCountLimit;

	public string AmpConsumeDiscountRate_Tip
	{
		get
		{
			string text = "";
			if (配方改良_AmpConsumeDiscountRate > 0f)
			{
				text += $"\n{Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(231).Name}:-{配方改良_AmpConsumeDiscountRate}%";
			}
			if (!string.IsNullOrEmpty(text))
			{
				text = "GvGModel3TalentTipTitle".ToLanguage() + text;
			}
			return text;
		}
	}

	public string ExtraAmpForgeHighQualityRate_Tip
	{
		get
		{
			string text = "";
			if (精益求精_ExtraAmpForgeHighQualityRate > 0f)
			{
				text += $"\n{Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(221).Name}:+{精益求精_ExtraAmpForgeHighQualityRate}%";
			}
			if (!string.IsNullOrEmpty(text))
			{
				text = "GvGModel3TalentTipTitle".ToLanguage() + text;
			}
			return text;
		}
	}

	public string ExtraAmplifierCountLimit_Tip
	{
		get
		{
			string text = "";
			if (飞艇改良_ExtraAmplifierCountLimit > 0)
			{
				text += $"\n{Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(233).Name}:+{飞艇改良_ExtraAmplifierCountLimit}";
			}
			if (!string.IsNullOrEmpty(text))
			{
				text = "GvGModel3TalentTipTitle".ToLanguage() + text;
			}
			return text;
		}
	}
}
