using System;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.RealTime;

[ProtoContract]
public class RealTimeFoodOnBoardModel
{
	private const string FoodOnBoardLimitParTitle = "FoodOnBoardLimitParTitle";

	private const string RealTimeFoodOnBoardLimitPar1 = "RealTimeFoodOnBoardLimitPar1";

	private const string RealTimeFoodOnBoardLimitPar2 = "RealTimeFoodOnBoardLimitPar2";

	[ProtoMember(1)]
	public float 场外科技Buff;

	[ProtoMember(3)]
	public float 有备无患Buff;

	[ProtoMember(8)]
	public int MetaBase;

	[ProtoMember(9)]
	public int TalentBase;

	public int Base => MetaBase + TalentBase;

	public float Buff => 场外科技Buff + 有备无患Buff;

	public int Total => (int)Math.Ceiling((float)Base * (1f + Buff));

	public bool HasBuff => Buff > 0f;

	public string GetText()
	{
		if (!HasBuff)
		{
			return string.Empty;
		}
		string text = "FoodOnBoardLimitParTitle".ToLanguage();
		if (场外科技Buff > 0f)
		{
			text = text + Environment.NewLine + HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("RealTimeFoodOnBoardLimitPar1".ToLanguage(), $"{场外科技Buff * 100f:0.#}");
		}
		if (有备无患Buff > 0f)
		{
			text = text + Environment.NewLine + HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("RealTimeFoodOnBoardLimitPar2".ToLanguage(), $"{有备无患Buff * 100f:0.#}");
		}
		return text;
	}
}
