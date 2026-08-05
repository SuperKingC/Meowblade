namespace GameDataEditor;

public class GDEEnemyTemplatePoolData
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

	public string PoolId => DC.StringArray[_stringOffset + 1];

	public string BlueFormationId => DC.StringArray[_stringOffset + 2];

	public string Icon => DC.StringArray[_stringOffset + 3];

	public string Enemy1 => DC.StringArray[_stringOffset + 4];

	public int Number1 => DC.IntArray[_intOffset];

	public string Enemy2 => DC.StringArray[_stringOffset + 5];

	public int Number2 => DC.IntArray[_intOffset + 1];

	public string Enemy3 => DC.StringArray[_stringOffset + 6];

	public int Number3 => DC.IntArray[_intOffset + 2];

	public string Enemy4 => DC.StringArray[_stringOffset + 7];

	public int Number4 => DC.IntArray[_intOffset + 3];

	public string Enemy5 => DC.StringArray[_stringOffset + 8];

	public int Number5 => DC.IntArray[_intOffset + 4];

	public string Enemy6 => DC.StringArray[_stringOffset + 9];

	public int Number6 => DC.IntArray[_intOffset + 5];

	public string Enemy7 => DC.StringArray[_stringOffset + 10];

	public int Number7 => DC.IntArray[_intOffset + 6];

	public string Enemy8 => DC.StringArray[_stringOffset + 11];

	public int Number8 => DC.IntArray[_intOffset + 7];

	public string Enemy9 => DC.StringArray[_stringOffset + 12];

	public int Number9 => DC.IntArray[_intOffset + 8];

	public string Enemy10 => DC.StringArray[_stringOffset + 13];

	public int Number10 => DC.IntArray[_intOffset + 9];

	public string Enemy11 => DC.StringArray[_stringOffset + 14];

	public int Number11 => DC.IntArray[_intOffset + 10];

	public string Enemy12 => DC.StringArray[_stringOffset + 15];

	public int Number12 => DC.IntArray[_intOffset + 11];

	public GDEEnemyTemplatePoolData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
