using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

[ProtoContract]
public class FlagShipReqMission_ToProtocol
{
	[ProtoMember(1)]
	public int Uid;

	[ProtoMember(2)]
	public string MissionConfigId;

	[ProtoMember(3)]
	public int FinishCount;

	[ProtoMember(4)]
	public int FinishMaxCount;

	[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> Requirements;

	[ProtoMember(6, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> Rewards;

	[ProtoMember(7)]
	public long FlagShipReqFormulaId;

	private string _missionName;

	public string MissionName
	{
		get
		{
			if (string.IsNullOrEmpty(_missionName))
			{
				_missionName = $"GvG3FlagshipMission_{FlagShipReqFormulaId}".ToLanguage();
			}
			return _missionName;
		}
	}

	public void UpdateFinishCount(int finishCount)
	{
		FinishCount = finishCount;
	}
}
