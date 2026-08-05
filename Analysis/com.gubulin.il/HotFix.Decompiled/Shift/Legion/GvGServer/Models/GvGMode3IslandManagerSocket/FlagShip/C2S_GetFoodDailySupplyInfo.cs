using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_GetFoodDailySupplyInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int FlagShipMaxFood;

		[ProtoMember(3)]
		public int FlagShipCurFood;

		[ProtoMember(4)]
		public string jsonCurShipFood;

		[ProtoMember(5)]
		public int ShipMaxFood;

		private Dictionary<string, int> _curShipFood;

		public Dictionary<string, int> CurShipFood
		{
			get
			{
				if (_curShipFood == null && !string.IsNullOrEmpty(jsonCurShipFood))
				{
					_curShipFood = JsonHelper.ToObject<Dictionary<string, int>>(jsonCurShipFood);
				}
				return _curShipFood;
			}
		}
	}

	public C2S_GetFoodDailySupplyInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetFoodDailySupplyInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
