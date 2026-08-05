using System.Collections.Generic;
using HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;

[ProtoContract]
public class C2S_GetFinalProgressInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class FinalProgressBossInfo
	{
		[ProtoMember(1)]
		public long BossHp;

		[ProtoMember(2)]
		public long BossCanRebornCnt;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Ability")]
		public List<Ability> BossBuff;

		[ProtoMember(4)]
		public int NextRebornTimestamp;

		[ProtoMember(5)]
		public long BossMaxHp;

		[ProtoMember(6)]
		public float BossAttack;

		[ProtoMember(7)]
		public float BossDefense;

		[ProtoMember(8)]
		public string SoldierId;

		[ProtoMember(9)]
		public bool EnterBossNearDeath;

		[ProtoIgnore]
		private string _bossIcon;

		[ProtoIgnore]
		public bool Resurrecting => NextRebornTimestamp > 0;

		[ProtoIgnore]
		public string BossIcon
		{
			get
			{
				if (string.IsNullOrEmpty(_bossIcon))
				{
					_bossIcon = GameManagers.Instance.SoldierManager.Get(SoldierId).GetGvG3SoldierIconUrl();
				}
				return _bossIcon;
			}
		}
	}

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

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress.FinalProgressBossInfo")]
		public FinalProgressBossInfo BossInfo;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Ability")]
		public List<Ability> PlayerBuff;

		[ProtoMember(4)]
		public string CurMissionConfgiId;

		[ProtoMember(5)]
		public long CampShadowEnergy;

		[ProtoMember(6)]
		public int SelfShadowStoneCount;
	}

	public C2S_GetFinalProgressInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetFinalProgressInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
