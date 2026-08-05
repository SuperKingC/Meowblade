using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicSigninActivityItemsResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public string SimpleDynamicSigninActivityData;

	private List<SimpleDynamicSigninActivity> _dynamicSigninActivitiesInfo;

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_SIGNIN_ACTIVITIES_ITEMS_REQUEST;

	public List<SimpleDynamicSigninActivity> DynamicSigninActivities
	{
		get
		{
			if (_dynamicSigninActivitiesInfo == null && !string.IsNullOrEmpty(SimpleDynamicSigninActivityData))
			{
				_dynamicSigninActivitiesInfo = JsonHelper.ToObject<List<SimpleDynamicSigninActivity>>(SimpleDynamicSigninActivityData);
				foreach (SimpleDynamicSigninActivity item in _dynamicSigninActivitiesInfo)
				{
					GameManagers.Instance.UserArchiveManager.SetActivityProgress(JsonHelper.ToObject<ActivityConfig>(item.Progress));
				}
			}
			return _dynamicSigninActivitiesInfo;
		}
	}
}
