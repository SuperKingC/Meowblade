namespace GameDataEditor;

public class GDETechnologyEffectData
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

	public string TechId => DC.StringArray[_stringOffset + 1];

	public int Level => DC.IntArray[_intOffset];

	public string ModifierId => DC.StringArray[_stringOffset + 2];

	public string Payload => DC.StringArray[_stringOffset + 3];

	public string Desc => DC.StringArray[_stringOffset + 4];

	public string NextDesc => DC.StringArray[_stringOffset + 5];

	public GDETechnologyEffectData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
