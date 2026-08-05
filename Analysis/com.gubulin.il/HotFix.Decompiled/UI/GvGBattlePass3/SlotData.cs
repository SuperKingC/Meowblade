using HotFix.Sources.Base.Scripts.Helper;

namespace UI.GvGBattlePass3;

public class SlotData
{
	public int Contribution = 0;

	public int NominalLevel = 1;

	public string icon_basic = "";

	public string icon_advanced = "";

	public string icon_premium = "";

	public int num_basic = 0;

	public int num_advanced = 0;

	public int num_premium = 0;

	public string id_basic = "";

	public string id_advanced = "";

	public string id_premium = "";

	public int state_basic = 0;

	public int state_advanced = 0;

	public int state_premium = 0;

	public int TargetScrollX = 0;

	public bool IsSpecialNode;

	public bool IsActualNode => NominalLevel > 0;

	public string NextLevelContributionTip(int score)
	{
		return string.Format("GvG3_NextLevel_Contribution_Tip".ToLanguage(), new object[2] { NominalLevel, score });
	}

	public bool BonusToBeClaimed(bool isAdvancedMode = false, bool premiumActivated = false)
	{
		if (!IsActualNode)
		{
			return false;
		}
		return state_basic == 1 || (isAdvancedMode && state_advanced == 1) || (premiumActivated && state_premium == 1);
	}
}
