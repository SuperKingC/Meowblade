using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicDiscountActivityItemsResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public string simpleDynamicPromotionActivityData;

	private List<SimpleDynamicPromotionActivity> _dynamicPromotionActivitiesInfo;

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_DISCOUNT_ACTIVITIES_ITEMS_REQUEST;

	public List<SimpleDynamicPromotionActivity> DynamicPromotionActivities
	{
		get
		{
			if (_dynamicPromotionActivitiesInfo == null && !string.IsNullOrEmpty(simpleDynamicPromotionActivityData))
			{
				_dynamicPromotionActivitiesInfo = JsonHelper.ToObject<List<SimpleDynamicPromotionActivity>>(simpleDynamicPromotionActivityData);
			}
			return _dynamicPromotionActivitiesInfo;
		}
	}
}
