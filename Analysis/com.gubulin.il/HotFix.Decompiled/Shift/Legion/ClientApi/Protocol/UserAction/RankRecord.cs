using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class RankRecord
{
	private RankBattleConfig _rankBattleConfig;

	private RankBattleConfigDetail _rankBattleConfigDetails;

	public int Rank { get; set; }

	public int Status { get; set; }

	public int UserId { get; set; }

	public string BattleConfig { get; set; }

	public RankBattleConfig RankBattleConfig
	{
		get
		{
			if (_rankBattleConfig == null && !string.IsNullOrEmpty(BattleConfig))
			{
				_rankBattleConfig = JsonHelper.ToObject<RankBattleConfig>(BattleConfig);
			}
			return _rankBattleConfig;
		}
	}

	public string BattleConfigDetail { get; set; }

	public RankBattleConfigDetail RankBattleConfigDetails
	{
		get
		{
			if (_rankBattleConfigDetails == null && !string.IsNullOrEmpty(BattleConfigDetail))
			{
				_rankBattleConfigDetails = JsonHelper.ToObject<RankBattleConfigDetail>(BattleConfigDetail);
			}
			return _rankBattleConfigDetails;
		}
	}

	public string LastChallengeBattleId { get; set; }

	public string LastRequestAt { get; set; }

	public string LastChallengeAt { get; set; }

	public string LastChallengeFinishAt { get; set; }
}
