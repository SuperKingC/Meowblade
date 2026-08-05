using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class BroadcastGroupDetailInfo
{
	[ProtoMember(1)]
	public string _jsonSoldierDetail;

	private Dictionary<string, int> _SoldierDetail;

	public Dictionary<string, int> SoldierDetail
	{
		get
		{
			if (_SoldierDetail == null && !string.IsNullOrEmpty(_jsonSoldierDetail))
			{
				_SoldierDetail = JsonHelper.ToObject<Dictionary<string, int>>(_jsonSoldierDetail);
			}
			return _SoldierDetail;
		}
		set
		{
			_SoldierDetail = value;
			_jsonSoldierDetail = JsonHelper.ToJson(_SoldierDetail);
		}
	}
}
