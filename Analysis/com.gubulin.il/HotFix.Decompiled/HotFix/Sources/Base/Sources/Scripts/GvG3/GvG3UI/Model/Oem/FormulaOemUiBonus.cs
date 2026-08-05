using ILRuntime_LitJson;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.Oem;

public class FormulaOemUiBonus
{
	[JsonIgnore]
	private int? _bonusType;

	public FormulaOemBonusType Type { get; set; }

	public string Key { get; set; }

	public float Value { get; set; }

	[JsonIgnore]
	public int BonusType
	{
		get
		{
			int? bonusType = _bonusType;
			if (!bonusType.HasValue)
			{
				_bonusType = (int)Type;
			}
			return _bonusType.Value;
		}
	}
}
