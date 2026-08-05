using ProtoBuf;

namespace GvG2.Common.Models;

[ProtoContract]
public class IslandSummary
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2)]
	public int IslandState;

	[ProtoMember(4)]
	public int IslandAllowFightingTimestamp;

	[ProtoMember(5)]
	public int IslandCloseTimestamp;

	[ProtoMember(6)]
	public int IslandScore;

	[ProtoMember(7)]
	public string ServerURL;

	[ProtoMember(8)]
	public int Pid = -1;

	[ProtoMember(9)]
	public int ExternalSocketPort = -1;

	public eIslandState IslandUIState
	{
		get
		{
			eIslandState islandState = (eIslandState)IslandState;
			if (islandState == eIslandState.WaitingFight && GameController.Instance.GetServerTime() >= IslandAllowFightingTimestamp)
			{
				return eIslandState.Fighting;
			}
			return islandState;
		}
	}
}
