using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class S2C_BroadcastBattleDamageInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long Frame;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.DamageInfo")]
		public List<DamageInfo> DamageInfos;

		private Dictionary<int, DamageInfo> _DamageInfos_Dict;

		public Dictionary<int, DamageInfo> DamageInfos_Dict
		{
			get
			{
				if (_DamageInfos_Dict == null)
				{
					_DamageInfos_Dict = new Dictionary<int, DamageInfo>();
					foreach (DamageInfo damageInfo in DamageInfos)
					{
						_DamageInfos_Dict.Add(damageInfo.EntityId, damageInfo);
					}
				}
				return _DamageInfos_Dict;
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BroadcastBattleDamageInfo()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BroadcastBattleDamageInfo;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		Request res = (Request)base.Req;
		if ((Object)(object)GvGWorldController.Instance != (Object)null && GvGWorldController.Instance.IsInitialized)
		{
			GvGWorldController.Instance.UpdateBattleDamageInfo(res);
		}
	}
}
