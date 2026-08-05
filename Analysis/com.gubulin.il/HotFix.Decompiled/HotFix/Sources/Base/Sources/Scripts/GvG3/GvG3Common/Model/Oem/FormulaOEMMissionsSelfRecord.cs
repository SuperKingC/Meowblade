using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using ProtoBuf;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;

[ProtoContract]
public class FormulaOEMMissionsSelfRecord
{
	[ProtoMember(1)]
	public int MUID;

	[ProtoMember(2)]
	public int UserId;

	[ProtoMember(3)]
	public int AmpIdx;

	[ProtoMember(4)]
	public int FinishCount;

	[ProtoMember(5)]
	public int TotalCount;

	[ProtoMember(6)]
	public int CloseTimestamp;

	[ProtoMember(7, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.FormulaOEMBonus")]
	public List<FormulaOEMBonus> Bonus;

	[ProtoMember(8)]
	public int MState;

	[ProtoIgnore]
	public int UiState
	{
		get
		{
			if (MissionCountdown <= 0)
			{
				return 2;
			}
			switch ((eMissionEntityState)MState)
			{
			case eMissionEntityState.Pending:
				return 0;
			case eMissionEntityState.FinishSucess:
			case eMissionEntityState.Closed:
				return 1;
			case eMissionEntityState.FinishFailed:
				return 2;
			default:
				return 0;
			}
		}
	}

	public int MissionCountdown => Mathf.Max(0, CloseTimestamp - (int)GameController.Instance.GetServerTime());

	public int UnclaimedCount
	{
		get
		{
			if (Bonus == null)
			{
				return 0;
			}
			int num = 0;
			foreach (FormulaOEMBonus bonu in Bonus)
			{
				if (!bonu.IsClaimed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public bool IsCompleted => UnclaimedCount <= 0 && UiState != 0;
}
