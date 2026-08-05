using System.Collections.Generic;
using Shift.Legion.GvG.Common.Enums;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class GvGMode3CampMissionConfigModel
{
	public string Key;

	public int GroupId;

	public eGvGMode3CampMissionType Type;

	public string Icon;

	public string Desc;

	public int Progress;

	public int Step;

	public List<string> Tags;

	public int Timer;

	public EntityCheck SucessCheckValue;

	public Dictionary<string, object> TriggerOnAccept;

	public Dictionary<string, object> TriggerOnFinish;

	public MissionBonus MissionBonus;

	public Dictionary<string, int> ShowBonus;

	public int CollectShadowEnergy;
}
