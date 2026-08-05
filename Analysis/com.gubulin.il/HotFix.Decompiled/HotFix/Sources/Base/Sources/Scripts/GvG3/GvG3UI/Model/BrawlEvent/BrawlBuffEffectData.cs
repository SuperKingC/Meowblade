namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlEvent;

public class BrawlBuffEffectData
{
	public enum EffectType
	{
		Ability,
		Score
	}

	public class EffectData
	{
		public string AbilityId;

		public float ExtraScore;
	}

	public int Type { get; set; }

	public int Limit { get; set; }

	public EffectData Effect { get; set; }

	public EffectType GetEffectType()
	{
		if (Type == 1 || Type == 2)
		{
			return EffectType.Ability;
		}
		return EffectType.Score;
	}
}
