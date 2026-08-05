namespace GameDataEditor;

public class GDEInfoEvoData
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

	public string Name1 => DC.StringArray[_stringOffset + 1];

	public string Extra1 => DC.StringArray[_stringOffset + 2];

	public string Name2 => DC.StringArray[_stringOffset + 3];

	public string Extra2 => DC.StringArray[_stringOffset + 4];

	public string Name3 => DC.StringArray[_stringOffset + 5];

	public string Extra3 => DC.StringArray[_stringOffset + 6];

	public string Name4 => DC.StringArray[_stringOffset + 7];

	public string Extra4 => DC.StringArray[_stringOffset + 8];

	public string Name5 => DC.StringArray[_stringOffset + 9];

	public string Extra5 => DC.StringArray[_stringOffset + 10];

	public string Name6 => DC.StringArray[_stringOffset + 11];

	public string Extra6 => DC.StringArray[_stringOffset + 12];

	public string Name7 => DC.StringArray[_stringOffset + 13];

	public string Extra7 => DC.StringArray[_stringOffset + 14];

	public string Name8 => DC.StringArray[_stringOffset + 15];

	public string Extra8 => DC.StringArray[_stringOffset + 16];

	public string Name9 => DC.StringArray[_stringOffset + 17];

	public string Extra9 => DC.StringArray[_stringOffset + 18];

	public string Name10 => DC.StringArray[_stringOffset + 19];

	public string Extra10 => DC.StringArray[_stringOffset + 20];

	public GDEInfoEvoData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
