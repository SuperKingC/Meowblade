namespace GameDataEditor;

public class GDEGvGTalentConfigData
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

	public int Idx => DC.IntArray[_intOffset];

	public string ParentTalent => DC.StringArray[_stringOffset + 1];

	public int Type => DC.IntArray[_intOffset + 1];

	public int Quality => DC.IntArray[_intOffset + 2];

	public string Icon => DC.StringArray[_stringOffset + 2];

	public string Border => DC.StringArray[_stringOffset + 3];

	public string Name => DC.StringArray[_stringOffset + 4];

	public string Desc => DC.StringArray[_stringOffset + 5];

	public string EffectType => DC.StringArray[_stringOffset + 6];

	public string Effect => DC.StringArray[_stringOffset + 7];

	public GDEGvGTalentConfigData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
