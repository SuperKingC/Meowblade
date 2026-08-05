using System.Runtime.Serialization;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

public enum eBrawlEventSettleInfoType
{
	[EnumMember(Value = "0")]
	Self,
	[EnumMember(Value = "1")]
	SelfExtra,
	[EnumMember(Value = "2")]
	Camp,
	[EnumMember(Value = "3")]
	CampExtra,
	[EnumMember(Value = "4")]
	FinalSelf,
	[EnumMember(Value = "5")]
	FinalSelfExtra,
	[EnumMember(Value = "6")]
	FinalCamp,
	[EnumMember(Value = "7")]
	FinalCampExtra
}
