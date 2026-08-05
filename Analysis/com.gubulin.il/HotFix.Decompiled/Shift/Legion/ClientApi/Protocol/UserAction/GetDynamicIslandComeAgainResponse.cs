using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicIslandComeAgainResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(2)]
	public string Infos;

	private List<DynamicIslandComeAgainActivity> _islandComeAgainActivitiesInfo;

	public List<DynamicIslandComeAgainActivity> IslandComeAgainActivities
	{
		get
		{
			if (_islandComeAgainActivitiesInfo == null && !string.IsNullOrEmpty(Infos))
			{
				_islandComeAgainActivitiesInfo = new List<DynamicIslandComeAgainActivity>();
				List<string> list = JsonHelper.ToObject<List<string>>(Infos);
				foreach (string item in list)
				{
					_islandComeAgainActivitiesInfo.Add(JsonHelper.ToObject<DynamicIslandComeAgainActivity>(item));
				}
			}
			return _islandComeAgainActivitiesInfo;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_ACTIVITY_ISLAND_COME_AGAIN_REQUEST;
}
