namespace GameDataEditor;

public class GDEBattleAudioConfigData
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

	public int Priority => DC.IntArray[_intOffset];

	public int MaxCount => DC.IntArray[_intOffset + 1];

	public bool PlayInOrder => DC.BoolArray[_boolOffset];

	public string DelayTime => DC.StringArray[_stringOffset + 2];

	public GDEBattleAudioConfigData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
