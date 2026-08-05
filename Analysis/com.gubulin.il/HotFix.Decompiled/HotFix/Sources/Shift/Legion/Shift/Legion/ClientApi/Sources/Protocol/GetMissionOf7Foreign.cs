using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Helpers;
using UI.GameActivity;
using UI.ProgressionMission;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;

public class GetMissionOf7Foreign
{
	[ProtoContract]
	public class Request : IRequestPacket, IPacketBody
	{
		[ProtoMember(99)]
		public int MsgIndex { get; set; }

		[ProtoMember(1)]
		public string ActivityId { get; set; }

		public int PacketId => PacketIds.USER_ACTION_GET_MISSIONOF7FOREIGN_REQUEST;
	}

	[ProtoContract]
	public class Response : IPacketBody
	{
		[ProtoIgnore]
		private Dictionary<string, MissonOf7ForeignBonusClaimed> _bonusCache;

		[ProtoMember(1)]
		public int BeginTime { get; set; }

		[ProtoMember(2)]
		public int EndTime { get; set; }

		[ProtoMember(5)]
		public string Progress { get; set; }

		[ProtoMember(6)]
		public int Score { get; set; }

		[ProtoMember(999)]
		public int ErrorCode { get; set; }

		public Dictionary<string, MissonOf7ForeignBonusClaimed> BonusClaimedProgress
		{
			get
			{
				if (!string.IsNullOrEmpty(Progress) && _bonusCache == null)
				{
					Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(Progress);
					_bonusCache = new Dictionary<string, MissonOf7ForeignBonusClaimed>();
					foreach (KeyValuePair<string, string> item in dictionary)
					{
						_bonusCache.Add(item.Key, JsonHelper.ToObject<MissonOf7ForeignBonusClaimed>(item.Value));
					}
				}
				return _bonusCache;
			}
		}

		public int PacketId => PacketIds.USER_ACTION_GET_MISSIONOF7FOREIGN_REQUEST;

		public int GetCurrentDay()
		{
			int timestamp = (int)GameController.Instance.GetServerRealtimeSeconds();
			DateTimeOffset now = DateTimeHelper.ParseTimeStamp(timestamp);
			DateTimeOffset activityBeginAt = DateTimeHelper.ParseTimeStamp(BeginTime);
			int count = UI_ProgressionMissionPanel.MissionData.MissionConfig.Count;
			return UI_ActivityPanel.GetActivityCurrentDay(activityBeginAt, now, count);
		}
	}

	public class MissonOf7ForeignBonusClaimed
	{
		public ClaimedRecord Bonus { get; set; }

		public ClaimedRecord PayBonus { get; set; }
	}

	public class ClaimedRecord
	{
		public bool Claimed { get; set; }

		public int Timestamp { get; set; }
	}
}
