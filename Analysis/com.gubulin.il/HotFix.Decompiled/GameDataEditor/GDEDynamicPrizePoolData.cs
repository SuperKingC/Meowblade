namespace GameDataEditor;

public class GDEDynamicPrizePoolData
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

	public bool Replacement => DC.BoolArray[_boolOffset];

	public string Content => DC.StringArray[_stringOffset + 1];

	public string Schedule => DC.StringArray[_stringOffset + 2];

	public string Rarity => DC.StringArray[_stringOffset + 3];

	public GDEDynamicPrizePoolData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
