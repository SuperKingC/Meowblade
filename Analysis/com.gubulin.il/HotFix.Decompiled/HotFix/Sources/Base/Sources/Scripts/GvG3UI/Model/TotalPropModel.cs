using GameMaths;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class TotalPropModel
{
	public int Idx;

	public string EffectRange;

	public string PropName;

	public float Value;

	public ePropType DescType;

	public string PropKey;

	public string DescValue
	{
		get
		{
			if (DescType == ePropType.Add)
			{
				return $"{Value:0.##}";
			}
			if (DescType == ePropType.DRSum)
			{
				return $"{Mathf.RoundToInt((1f - Value) * 100f)}";
			}
			return $"{Value:0.##}";
		}
	}
}
