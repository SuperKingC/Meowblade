using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ILRuntime_LitJson;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;

public class C2S_GetPreventionInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<string> ShipIds;

		[ProtoMember(2)]
		public List<int> ShipEntityIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string JsonEnemyShipData;

		private List<EnemyShipData> _EnemyShipDatas;

		[JsonIgnore]
		public List<EnemyShipData> EnemyShipData
		{
			get
			{
				if (_EnemyShipDatas == null && !string.IsNullOrEmpty(JsonEnemyShipData))
				{
					_EnemyShipDatas = JsonHelper.ToObject<List<EnemyShipData>>(JsonEnemyShipData);
				}
				return _EnemyShipDatas;
			}
			set
			{
				_EnemyShipDatas = value;
				JsonEnemyShipData = JsonHelper.ToJson(_EnemyShipDatas);
			}
		}

		public static Response EmptyData => new Response
		{
			_EnemyShipDatas = new List<EnemyShipData>()
		};
	}

	public class EnemyShipData
	{
		public int CampId;

		public int EntityId;

		public string ShipId;

		public FlightSchedule FlightSchedule;

		private ShipController.FlyingLine[] _caches;

		private void Init()
		{
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			_caches = new ShipController.FlyingLine[FlightSchedule.Route.Length];
			int num = _caches.Length - 1;
			int[] route = FlightSchedule.Route;
			float num2 = 0f;
			for (int i = 0; i < num; i++)
			{
				NavLineConfigData navLineConfigData = WorldMapConfigHelper.Configs.TryGetNavLine(route[i], route[i + 1]);
				IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(route[i]);
				ShipController.FlyingLine flyingLine = new ShipController.FlyingLine
				{
					MoveDirection = navLineConfigData.Dir,
					LineStart = islandConfigData.Position,
					DistFromStartToLineHead = num2,
					DistFromStartToLineTail = num2 + navLineConfigData.Props.Len
				};
				_caches[i] = flyingLine;
				num2 = flyingLine.DistFromStartToLineTail;
				if (i == num - 1)
				{
					IslandConfigData islandConfigData2 = WorldMapConfigHelper.Configs.TryGetIsland(route[i + 1]);
					ShipController.FlyingLine flyingLine2 = new ShipController.FlyingLine
					{
						MoveDirection = navLineConfigData.Dir,
						LineStart = islandConfigData2.Position,
						DistFromStartToLineHead = num2,
						DistFromStartToLineTail = num2
					};
					_caches[num] = flyingLine2;
				}
			}
		}

		public Vector3 GetTargetIslandPos()
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			int islandId = FlightSchedule.Route[^1];
			IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandId);
			return islandConfigData.Position;
		}

		public Vector3 GetShipRealtimePos(double serverRealtime)
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			if (_caches == null)
			{
				Init();
			}
			float num = (float)(serverRealtime - (double)FlightSchedule.TimeStamp);
			if (num <= 0f)
			{
				return _caches[0].LineStart;
			}
			float num2 = (float)FlightSchedule.DistanceTraveled / 1000f;
			int num3 = _caches.Length - 1;
			ShipController.FlyingLine flyingLine = _caches[num3];
			float distFromStartToLineHead = flyingLine.DistFromStartToLineHead;
			int num4 = FlightSchedule.EndTime - FlightSchedule.TimeStamp;
			float num5 = (distFromStartToLineHead - num2) / (float)num4;
			float num6 = num2 + num5 * num;
			ShipController.FlyingLine flyingLine2 = null;
			int num7 = 0;
			ShipController.FlyingLine[] caches = _caches;
			foreach (ShipController.FlyingLine flyingLine3 in caches)
			{
				if (num6 >= flyingLine3.DistFromStartToLineHead && flyingLine3.DistFromStartToLineTail >= num6)
				{
					flyingLine2 = flyingLine3;
					break;
				}
				num7++;
			}
			if (flyingLine2 == null)
			{
				return flyingLine.LineStart;
			}
			float num8 = num6 - flyingLine2.DistFromStartToLineHead;
			float num9 = flyingLine2.DistFromStartToLineTail - flyingLine2.DistFromStartToLineHead;
			float num10 = num8 / num9;
			ShipController.FlyingLine flyingLine4 = _caches[num7 + 1];
			return (flyingLine4.LineStart - flyingLine2.LineStart) * num10 + flyingLine2.LineStart;
		}
	}

	public C2S_GetPreventionInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetPreventionInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
