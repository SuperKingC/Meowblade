using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class GvGConfig
{
	public float start_waiting_time;

	public float speed;

	public float phase1_queeze_time;

	public float phase2_speed_power;

	public float phase2_3_waiting_time;

	public float phase3_speed_power;

	public Dictionary<string, GvGWorldBossInfo> WorldBossInfos;
}
