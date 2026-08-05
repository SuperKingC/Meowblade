namespace GameDataEditor;

public class GDEChapterData
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

	public string Levels => DC.StringArray[_stringOffset + 2];

	public string Desc => DC.StringArray[_stringOffset + 3];

	public string Image => DC.StringArray[_stringOffset + 4];

	public string DoneBonus => DC.StringArray[_stringOffset + 5];

	public string Region => DC.StringArray[_stringOffset + 6];

	public int RecommendPower => DC.IntArray[_intOffset];

	public int Type => DC.IntArray[_intOffset + 1];

	public int Levelship => DC.IntArray[_intOffset + 2];

	public bool Repeatable => DC.BoolArray[_boolOffset];

	public bool PreserveEnemy => DC.BoolArray[_boolOffset + 1];

	public string NextChapter => DC.StringArray[_stringOffset + 7];

	public GDEChapterData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
