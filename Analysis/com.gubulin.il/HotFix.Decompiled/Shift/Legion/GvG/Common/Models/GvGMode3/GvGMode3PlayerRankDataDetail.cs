using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using ILRuntime_LitJson;
using ProtoBuf;
using Shift.Legion.GvG.Common.Enums;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3PlayerRankDataDetail
{
	[ProtoMember(1)]
	public int Key;

	[ProtoMember(2)]
	public long Value;

	[ProtoMember(3)]
	public string Other;

	[ProtoIgnore]
	[JsonIgnore]
	private List<FinalProgressBossDamageRecord> _FinalProgressDetail;

	[ProtoIgnore]
	[JsonIgnore]
	public BrawlEventIZRankDetailInfo _BrawlEventIZRankDetail;

	[ProtoIgnore]
	[JsonIgnore]
	public string ContributionSource => $"GvG3Contribution_{(eContributionKey)Key}".ToLanguage();

	[ProtoIgnore]
	[JsonIgnore]
	public string ContributionValue => Value.ToString();

	[ProtoIgnore]
	[JsonIgnore]
	public List<FinalProgressBossDamageRecord> FinalProgressDetail
	{
		get
		{
			if (_FinalProgressDetail != null)
			{
				return _FinalProgressDetail;
			}
			_FinalProgressDetail = Other.ToObject<List<FinalProgressBossDamageRecord>>();
			return _FinalProgressDetail;
		}
	}

	[ProtoIgnore]
	[JsonIgnore]
	public BrawlEventIZRankDetailInfo BrawlEventIZRankDetail
	{
		get
		{
			if (_BrawlEventIZRankDetail != null)
			{
				return _BrawlEventIZRankDetail;
			}
			_BrawlEventIZRankDetail = Other.ToObject<BrawlEventIZRankDetailInfo>();
			return _BrawlEventIZRankDetail;
		}
	}
}
