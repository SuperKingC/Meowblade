namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class GvGMode3DefenderZoneNpc
{
	public string GroupId { get; set; }

	public float[] BornPos { get; set; }

	public string TemplatePool { get; set; }

	public int TeamCount { get; set; } = 1;

	public bool CanReborn { get; set; } = false;

	public int RebornCnt { get; set; } = -1;

	public int RebornCooldown { get; set; } = -1;

	public int CombatPowerPerTeam { get; set; } = 0;

	public float CombatPowerRate { get; set; } = -1f;

	public string Icon { get; set; } = string.Empty;

	public float IconSize { get; set; } = 1f;
}
