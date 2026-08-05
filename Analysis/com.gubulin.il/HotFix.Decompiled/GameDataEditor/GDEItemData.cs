namespace GameDataEditor;

public class GDEItemData
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

	public string Name => DC.StringArray[_stringOffset + 1];

	public string Icon => DC.StringArray[_stringOffset + 2];

	public int ItemType => DC.IntArray[_intOffset];

	public string Tags => DC.StringArray[_stringOffset + 3];

	public int Rarity => DC.IntArray[_intOffset + 1];

	public int Shining => DC.IntArray[_intOffset + 2];

	public string AccessPath => DC.StringArray[_stringOffset + 4];

	public string PostScript => DC.StringArray[_stringOffset + 5];

	public string Effect => DC.StringArray[_stringOffset + 6];

	public GDEItemData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
