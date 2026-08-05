using System.Collections.Generic;

namespace GameDataEditor;

public class GDELegendItemSetData
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

	public string SetName => DC.StringArray[_stringOffset + 1];

	public string SetDesc => DC.StringArray[_stringOffset + 2];

	public int SetPiecesQty => DC.IntArray[_intOffset];

	public List<string> SetPieces => DC.GetListStringArray(_listStringOffset);

	public List<string> SetFxEntries => DC.GetListStringArray(_listStringOffset + 1);

	public List<string> Tags => DC.GetListStringArray(_listStringOffset + 2);

	public GDELegendItemSetData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
