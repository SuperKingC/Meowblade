using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankLastTurnResultResponse : IPacketBody
{
	public class TopTournamentRankModel
	{
		public int UserId;

		public int Score;

		public int PlayOffScore;

		public int MaxCombatPower;

		public string PlayOffWin;

		public string PlayOffFailed;

		private List<RankChangeRecord> _PlayOffRecords = null;

		public List<RankChangeRecord> GetPlayOffRecord()
		{
			if (_PlayOffRecords != null)
			{
				return _PlayOffRecords;
			}
			_PlayOffRecords = new List<RankChangeRecord>();
			List<string> list = JsonHelper.ToObject<List<string>>(PlayOffWin);
			List<string> list2 = JsonHelper.ToObject<List<string>>(PlayOffFailed);
			Dictionary<string, List<RankChangeRecord>> dictionary = new Dictionary<string, List<RankChangeRecord>>();
			foreach (string item in list)
			{
				string[] array = item.Split('#');
				string text = array[0];
				string json = array[1];
				string[] array2 = text.Split('_');
				int num = int.Parse(array2[5]);
				int num2 = int.Parse(array2[6]);
				string key = ((num2 == UserId) ? (num2 + "+" + num) : (num + "+" + num2));
				int winner = ((num == UserId) ? 200 : 100);
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<RankChangeRecord> { null, null });
				}
				RankChangeRecord value = new RankChangeRecord
				{
					HostId = num2,
					ChallengerId = num,
					BattleId = text,
					Winner = winner,
					KingPoints = JsonHelper.ToObject<List<int>>(json)
				};
				if (num2 == UserId)
				{
					dictionary[key][1] = value;
				}
				else
				{
					dictionary[key][0] = value;
				}
			}
			foreach (string item2 in list2)
			{
				string[] array3 = item2.Split('#');
				string text2 = array3[0];
				string json2 = array3[1];
				string[] array4 = text2.Split('_');
				int num3 = int.Parse(array4[5]);
				int num4 = int.Parse(array4[6]);
				string key2 = ((num4 == UserId) ? (num4 + "+" + num3) : (num3 + "+" + num4));
				int winner2 = ((num3 == UserId) ? 100 : 200);
				if (!dictionary.ContainsKey(key2))
				{
					dictionary.Add(key2, new List<RankChangeRecord> { null, null });
				}
				RankChangeRecord value2 = new RankChangeRecord
				{
					HostId = num4,
					ChallengerId = num3,
					BattleId = text2,
					Winner = winner2,
					KingPoints = JsonHelper.ToObject<List<int>>(json2)
				};
				if (num4 == UserId)
				{
					dictionary[key2][1] = value2;
				}
				else
				{
					dictionary[key2][0] = value2;
				}
			}
			foreach (List<RankChangeRecord> value3 in dictionary.Values)
			{
				_PlayOffRecords.AddRange(value3);
			}
			return _PlayOffRecords;
		}
	}

	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string _jsonData;

	private List<TopTournamentRankModel> _Data;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<TopTournamentRankModel> Data
	{
		get
		{
			if (_Data == null && !string.IsNullOrEmpty(_jsonData))
			{
				_Data = JsonHelper.ToObject<List<TopTournamentRankModel>>(_jsonData);
			}
			return _Data;
		}
		set
		{
			_Data = value;
			_jsonData = JsonHelper.ToJson(_Data);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_LAST_TURN_RESULT_REQUEST;
}
