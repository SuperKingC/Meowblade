namespace GameDataEditor;

public class GDELotteryCaseData
{
	private int _stringOffset;

	private int _intOffset;

	private int _floatOffset;

	private int _boolOffset;

	private int _vector2Offset;

	private int _listStringOffset;

	private int _listIntOffset;

	public static DataContainer DC;

	public string Key => DC.StringArray[_stringOffset];

	public int Status => DC.IntArray[_intOffset];

	public int CaseType => DC.IntArray[_intOffset + 1];

	public int TotalDraw => DC.IntArray[_intOffset + 2];

	public string TotalCost => DC.StringArray[_stringOffset + 1];

	public string ActivityId => DC.StringArray[_stringOffset + 2];

	public string DrawOption => DC.StringArray[_stringOffset + 3];

	public string MinBonusItems => DC.StringArray[_stringOffset + 4];

	public int MinBonusQty => DC.IntArray[_intOffset + 3];

	public int TotalEffects => DC.IntArray[_intOffset + 4];

	public string PrizePoolCombo => DC.StringArray[_stringOffset + 5];

	public int Priority => DC.IntArray[_intOffset + 5];

	public bool IsFinalCase => DC.BoolArray[_boolOffset];

	public GDELotteryCaseData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
	{
		_stringOffset = stringOffset;
		_intOffset = intOffset;
		_floatOffset = floatOffset;
		_boolOffset = boolOffset;
		_vector2Offset = vector2Offset;
		_listStringOffset = listStringOffset;
		_listIntOffset = listIntOffset;
	}
}
