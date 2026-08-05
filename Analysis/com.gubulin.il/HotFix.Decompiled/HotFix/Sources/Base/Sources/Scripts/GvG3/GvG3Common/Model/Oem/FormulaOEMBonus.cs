using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;

[ProtoContract]
public class FormulaOEMBonus
{
	public static Dictionary<int, float> ParDict = new Dictionary<int, float>
	{
		{ 29, 0.5f },
		{ 30, 0.25f },
		{ 31, 0.12f },
		{ 32, 0.06f },
		{ 33, 0.03f },
		{ 34, 0.02f },
		{ 35, 0.01f },
		{ 36, 0.006f },
		{ 37, 0.002f },
		{ 38, 0f }
	};

	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public int UserId { get; set; }

	[ProtoMember(3)]
	public int FinishTimestamp { get; set; }

	[ProtoMember(4)]
	public bool IsClaimed { get; set; }

	[ProtoMember(5)]
	public int ClaimedTimestamp { get; set; }

	[ProtoMember(6, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OEMTakerBonus")]
	public OEMTakerBonus Bonus { get; set; }

	[ProtoMember(7)]
	public int TotalFinishCount { get; set; }

	public int GetOEMBonuseDebuffRate()
	{
		float num = 0f;
		num = ((TotalFinishCount <= 28) ? 1f : ((TotalFinishCount < 29 || TotalFinishCount > 38) ? 0f : ParDict[TotalFinishCount]));
		return 100 - Mathf.RoundToInt(num * 100f);
	}

	public int GetOEMBonuseDebuffRateFloat(int originalValue)
	{
		float num = 0f;
		num = ((TotalFinishCount <= 28) ? 1f : ((TotalFinishCount < 29 || TotalFinishCount > 38) ? 0f : ParDict[TotalFinishCount]));
		return Mathf.RoundToInt(Mathf.Max((float)originalValue * num, 1f));
	}

	public bool IsDebuffed()
	{
		return TotalFinishCount > 28;
	}
}
