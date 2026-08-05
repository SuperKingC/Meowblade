using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_DestroyShip : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string ShipId;

		private Dictionary<string, int> _Order;

		[ProtoMember(3)]
		public string _jsonOrder { get; set; }

		public Dictionary<string, int> Order
		{
			get
			{
				if (_Order == null && !string.IsNullOrEmpty(_jsonOrder))
				{
					_Order = JsonHelper.ToObject<Dictionary<string, int>>(_jsonOrder);
				}
				return _Order;
			}
			set
			{
				_Order = value;
				_jsonOrder = JsonHelper.ToJson(_Order);
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_DestroyShip()
	{
		base.PackageId = SocketManager.ePackageId.S2C_DestroyShip;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
