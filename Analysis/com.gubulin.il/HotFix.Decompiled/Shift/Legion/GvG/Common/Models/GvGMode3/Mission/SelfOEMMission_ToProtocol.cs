using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

[ProtoContract]
public class SelfOEMMission_ToProtocol
{
	[ProtoMember(1)]
	public int MUID;

	[ProtoMember(2)]
	public int AmpIdx;

	[ProtoMember(4)]
	public int EndTimestamp = -1;

	[ProtoMember(6)]
	public int State;

	[ProtoMember(7)]
	public bool IsExpired;

	[ProtoMember(8)]
	public bool IsCritical = false;

	[ProtoMember(9)]
	public bool IsTitan = false;

	private int? _uiState;

	public int UiState
	{
		get
		{
			if (_uiState.HasValue)
			{
				return _uiState.Value;
			}
			if (MissionCountdown <= 0)
			{
				_uiState = 2;
			}
			else
			{
				switch ((eMissionEntityState)State)
				{
				case eMissionEntityState.Pending:
					_uiState = 0;
					break;
				case eMissionEntityState.FinishSucess:
				case eMissionEntityState.Closed:
					_uiState = 1;
					break;
				case eMissionEntityState.FinishFailed:
					_uiState = 2;
					break;
				default:
					_uiState = 0;
					break;
				}
			}
			return _uiState.Value;
		}
	}

	public int MissionCountdown => (!IsExpired) ? (EndTimestamp - (int)GameController.Instance.GetServerTime()) : 0;

	public void SyncState(int newState)
	{
		State = newState;
		_uiState = null;
	}
}
