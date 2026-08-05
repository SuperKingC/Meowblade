namespace UI.WeekActivityPass;

public class SlotData
{
	public int Index;

	public int Level = 0;

	public string icon_basic = "";

	public string icon_advanced = "";

	public string icon_premium = "";

	public int num_basic = 0;

	public int num_advanced = 0;

	public int num_premium = 0;

	public string id_basic = "";

	public string id_advanced = "";

	public string id_premium = "";

	public BonusStatus state_basic = BonusStatus.INACTIVE;

	public BonusStatus state_advanced = BonusStatus.INACTIVE;

	public BonusStatus state_premium = BonusStatus.INACTIVE;

	public int TargetScrollX = 0;

	public bool IsSpecialNode;
}
