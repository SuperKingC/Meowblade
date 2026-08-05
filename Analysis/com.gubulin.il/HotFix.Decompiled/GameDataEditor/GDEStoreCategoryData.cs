using System.Collections.Generic;

namespace GameDataEditor;

public class GDEStoreCategoryData
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

	public int Category => DC.IntArray[_intOffset];

	public string Name => DC.StringArray[_stringOffset + 1];

	public string Desc => DC.StringArray[_stringOffset + 2];

	public List<string> Tags => DC.GetListStringArray(_listStringOffset);

	public string PhaseEndAt => DC.StringArray[_stringOffset + 3];

	public List<string> ExpoIcon => DC.GetListStringArray(_listStringOffset + 1);

	public List<string> ExpoName => DC.GetListStringArray(_listStringOffset + 2);

	public List<string> ExpoDesc => DC.GetListStringArray(_listStringOffset + 3);

	public GDEStoreCategoryData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
