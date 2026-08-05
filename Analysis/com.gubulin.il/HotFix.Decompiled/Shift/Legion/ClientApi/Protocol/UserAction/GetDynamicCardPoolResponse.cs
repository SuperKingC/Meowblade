using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicCardPoolResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(2)]
	public string Infos;

	private List<SimpleDynamicCardPoolActivity> _dynamicCardPoolActivitiesInfo;

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_ACTIVITY_UISHOW_CARD_POOL_REQUEST;

	public List<SimpleDynamicCardPoolActivity> DynamicCardPoolActivities
	{
		get
		{
			if (_dynamicCardPoolActivitiesInfo == null && !string.IsNullOrEmpty(Infos))
			{
				_dynamicCardPoolActivitiesInfo = new List<SimpleDynamicCardPoolActivity>();
				List<string> list = JsonHelper.ToObject<List<string>>(Infos);
				foreach (string item in list)
				{
					_dynamicCardPoolActivitiesInfo.Add(JsonHelper.ToObject<SimpleDynamicCardPoolActivity>(item));
				}
			}
			return _dynamicCardPoolActivitiesInfo;
		}
	}
}
