using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPVPRankSeasonInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string _info;

	[ProtoMember(4)]
	public string _pvpRankProgress;

	[ProtoMember(5)]
	public string StoreActivity_Normal;

	[ProtoMember(6)]
	public string StoreActivity_TopTournament;

	[ProtoMember(7)]
	public List<string> CanChooseRSName;

	private SimpleDynamicPromotionActivity _storeActivity_TopTournament;

	private SimpleDynamicPromotionActivity _storeActivity_Normal;

	private tRankSeasonInfo _seasonInfo;

	private PvPRankProgress _rankProgress;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_SEASON_INFO_REQUEST;

	public SimpleDynamicPromotionActivity StoreActivityTopTournament
	{
		get
		{
			if (_storeActivity_TopTournament == null && !string.IsNullOrEmpty(StoreActivity_TopTournament))
			{
				_storeActivity_TopTournament = JsonHelper.ToObject<SimpleDynamicPromotionActivity>(StoreActivity_TopTournament);
			}
			return _storeActivity_TopTournament;
		}
	}

	public SimpleDynamicPromotionActivity StoreActivityNormal
	{
		get
		{
			if (_storeActivity_Normal == null && !string.IsNullOrEmpty(StoreActivity_Normal))
			{
				_storeActivity_Normal = JsonHelper.ToObject<SimpleDynamicPromotionActivity>(StoreActivity_Normal);
			}
			return _storeActivity_Normal;
		}
	}

	public tRankSeasonInfo SeasonInfo
	{
		get
		{
			if (_seasonInfo == null && !string.IsNullOrEmpty(_info))
			{
				_seasonInfo = JsonHelper.ToObject<tRankSeasonInfo>(_info);
			}
			return _seasonInfo;
		}
	}

	public PvPRankProgress RankProgress
	{
		get
		{
			if (_rankProgress == null && !string.IsNullOrEmpty(_pvpRankProgress))
			{
				_rankProgress = JsonHelper.ToObject<PvPRankProgress>(_pvpRankProgress);
			}
			return _rankProgress;
		}
	}
}
