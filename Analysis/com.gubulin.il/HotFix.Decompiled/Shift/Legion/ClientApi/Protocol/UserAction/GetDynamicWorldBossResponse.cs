using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicWorldBossResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(2)]
	public string Infos;

	private List<SimpleDynamicCardPoolActivity> _worldBossActivitiesInfo;

	public List<SimpleDynamicCardPoolActivity> WorldBossActivities
	{
		get
		{
			if (_worldBossActivitiesInfo == null && !string.IsNullOrEmpty(Infos))
			{
				_worldBossActivitiesInfo = new List<SimpleDynamicCardPoolActivity>();
				List<string> list = JsonHelper.ToObject<List<string>>(Infos);
				foreach (string item in list)
				{
					_worldBossActivitiesInfo.Add(JsonHelper.ToObject<SimpleDynamicCardPoolActivity>(item));
				}
			}
			return _worldBossActivitiesInfo;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_ACTIVITY_WORLD_BOSS_REQUEST;
}
