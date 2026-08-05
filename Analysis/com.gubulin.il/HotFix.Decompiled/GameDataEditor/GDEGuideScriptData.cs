using GameMaths;

namespace GameDataEditor;

public class GDEGuideScriptData
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

	public string GuiderInfo => DC.StringArray[_stringOffset + 1];

	public string TipInfo => DC.StringArray[_stringOffset + 2];

	public string Highlight => DC.StringArray[_stringOffset + 3];

	public string Background => DC.StringArray[_stringOffset + 4];

	public Vector2 OffsetPos => DataContainer.Vector2(DC.Vector2Array[_vector2Offset]);

	public Vector2 OffsetSize => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 1]);

	public GDEGuideScriptData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
