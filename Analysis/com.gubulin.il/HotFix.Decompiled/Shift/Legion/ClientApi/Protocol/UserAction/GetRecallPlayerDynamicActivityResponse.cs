using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetRecallPlayerDynamicActivityResponse : IPacketBody
{
	[ProtoMember(1)]
	public string JsonRecallInfo { get; set; }

	[ProtoMember(2)]
	public string JsonRecallActivityConfig { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> Bonus { get; set; }

	[ProtoMember(4)]
	public string ProgressDesc { get; set; }

	[ProtoMember(5)]
	public int InviterClaimCount { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_RECALLPLAYERACTIVITY;

	public PlayerReturnActivity PlayerReturnActivity
	{
		get
		{
			if (string.IsNullOrEmpty(JsonRecallInfo) || string.IsNullOrEmpty(JsonRecallActivityConfig))
			{
				ILRuntimeDebug.LogError("[GetRecallPlayerDynamicActivityResponse] 有数据是空的 JsonRecallInfo=" + JsonRecallInfo + " JsonRecallActivityConfig=" + JsonRecallActivityConfig);
				return null;
			}
			PlayerReturnActivity playerReturnActivity = new PlayerReturnActivity
			{
				PlayerInfo = JsonRecallInfo.ToObject<RecallInfo>(),
				Activity = JsonRecallActivityConfig.ToObject<SimpleDynamicRecallActivity>()
			};
			playerReturnActivity.PlayerInfo.Bonus = Bonus ?? new List<RItem>();
			playerReturnActivity.PlayerInfo.ProgressDesc = ProgressDesc ?? "ProgressDesc is null";
			playerReturnActivity.PlayerInfo.InviterClaimCount = InviterClaimCount;
			return playerReturnActivity;
		}
	}
}
