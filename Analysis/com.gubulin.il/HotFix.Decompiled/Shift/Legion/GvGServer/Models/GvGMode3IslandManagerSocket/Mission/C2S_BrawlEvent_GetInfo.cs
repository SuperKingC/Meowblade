using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;
using UI.GvGBrawlFight;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_BrawlEvent_GetInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int StepIdx;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent.BE_SignUpDataModel_ToProtocol")]
		public List<BE_SignUpDataModel_ToProtocol> SelfSignUpDatas;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent.BrawlEventSettleClaimedInfo")]
		public List<BrawlEventSettleClaimedInfo> ClaimedInfos;

		[ProtoMember(6)]
		public int AllowRegisterTimeStart;

		[ProtoMember(7)]
		public int AllowRegisterTimeEnd;

		[ProtoMember(8)]
		public int FightingTimeEnd;

		[ProtoMember(9)]
		public long NormalPlayerScore;

		[ProtoMember(10)]
		public long FinalPlayScore;

		[ProtoMember(11)]
		public int MaxHasBeginSignUp;

		[ProtoMember(12, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent.BE_SignUpDataModel_ToProtocol3")]
		public List<BE_SignUpDataModel_ToProtocol3> AllIslandDatas;

		[ProtoMember(13)]
		public int MaxCanRecordInLeaderboard;

		public int GetFightingTimeEnd
		{
			get
			{
				if (UI_main_BrawlFightEnroll.IsDebugOpen())
				{
					int day = UI_main_BrawlFightEnroll.WhatDayIsToday();
					return (int)GvGMode3BrawlEvent_BaseInfo.GetFightingEndTime(day);
				}
				return FightingTimeEnd;
			}
		}

		public int GetAllowRegisterTimeEnd
		{
			get
			{
				if (UI_main_BrawlFightEnroll.IsDebugOpen())
				{
					int day = UI_main_BrawlFightEnroll.WhatDayIsToday();
					return (int)GvGMode3BrawlEvent_BaseInfo.GetAllowRegisterTimeEnd(day);
				}
				return AllowRegisterTimeEnd;
			}
		}

		public Stage GetStage()
		{
			long brawlEventTime = UI_main_BrawlFightEnroll.GetBrawlEventTime();
			int num = UI_main_BrawlFightEnroll.WhatDayIsToday();
			int brawlEventFinalEndDay = WorldMapConfigHelper.Configs.BrawlEventFinalEndDay;
			if (num > brawlEventFinalEndDay)
			{
				return Stage.Finished;
			}
			List<BE_SignUpDataModel_ToProtocol> selfSignUpDatas = SelfSignUpDatas;
			bool flag = selfSignUpDatas != null && selfSignUpDatas.Count > 0;
			int getAllowRegisterTimeEnd = GetAllowRegisterTimeEnd;
			int getFightingTimeEnd = GetFightingTimeEnd;
			if (brawlEventTime < getAllowRegisterTimeEnd)
			{
				if (flag)
				{
					return Stage.Enrolled;
				}
				if (num == 1)
				{
					return Stage.EnrollFirstDay;
				}
				return Stage.Enroll;
			}
			if (brawlEventTime < getFightingTimeEnd)
			{
				return Stage.WaitStart;
			}
			return Stage.Fighting;
		}

		public void UpdateAllIslandDatas(int islandId, int current, int maxCount)
		{
			if (AllIslandDatas == null)
			{
				AllIslandDatas = new List<BE_SignUpDataModel_ToProtocol3>();
			}
			foreach (BE_SignUpDataModel_ToProtocol3 allIslandData in AllIslandDatas)
			{
				if (allIslandData.IslandId == islandId)
				{
					allIslandData.CurCnt = current;
					allIslandData.MaxCnt = maxCount;
					return;
				}
			}
			AllIslandDatas.Add(new BE_SignUpDataModel_ToProtocol3
			{
				IslandId = islandId,
				CurCnt = current,
				MaxCnt = maxCount
			});
		}

		public bool HasReplayYesterdayFight()
		{
			int num = UI_main_BrawlFightEnroll.WhatDayIsToday();
			int num2 = num - 1;
			int brawlEventFinalEndDay = WorldMapConfigHelper.Configs.BrawlEventFinalEndDay;
			return num2 >= 1 && num2 <= brawlEventFinalEndDay;
		}

		public eRace GetEnrollRaceIdOnIsland(int islandData)
		{
			if (SelfSignUpDatas == null)
			{
				return eRace.Invalid;
			}
			foreach (BE_SignUpDataModel_ToProtocol selfSignUpData in SelfSignUpDatas)
			{
				if (selfSignUpData.IslandId == islandData)
				{
					return (eRace)selfSignUpData.ShipRace;
				}
			}
			return eRace.Invalid;
		}

		public bool IsAnyShipEnrolled()
		{
			List<BE_SignUpDataModel_ToProtocol> selfSignUpDatas = SelfSignUpDatas;
			return selfSignUpDatas != null && selfSignUpDatas.Count > 0;
		}

		public bool HasUnClaimedReward()
		{
			if (ClaimedInfos != null)
			{
				foreach (BrawlEventSettleClaimedInfo claimedInfo in ClaimedInfos)
				{
					if (!claimedInfo.IsClaimed && claimedInfo.MessageId > 0 && claimedInfo.Day <= MaxCanRecordInLeaderboard)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public enum Stage
	{
		EnrollFirstDay,
		Enroll,
		Enrolled,
		WaitStart,
		Fighting,
		Finished
	}

	public C2S_BrawlEvent_GetInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BrawlEvent_GetInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
