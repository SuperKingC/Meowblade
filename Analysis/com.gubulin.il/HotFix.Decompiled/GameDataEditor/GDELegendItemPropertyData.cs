using System.Collections.Generic;

namespace GameDataEditor;

public class GDELegendItemPropertyData
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

	public string DescTemplateId => DC.StringArray[_stringOffset + 1];

	public string AbilityId => DC.StringArray[_stringOffset + 2];

	public int Priority => DC.IntArray[_intOffset];

	public string Payload => DC.StringArray[_stringOffset + 3];

	public string EvoId => DC.StringArray[_stringOffset + 4];

	public string Rarity5Property => DC.StringArray[_stringOffset + 5];

	public string Rarity6Property => DC.StringArray[_stringOffset + 6];

	public string Identity => DC.StringArray[_stringOffset + 7];

	public List<string> BluePrintExcludeIdentity => DC.GetListStringArray(_listStringOffset);

	public List<string> ExtraBluePrintExcludeIdentity => DC.GetListStringArray(_listStringOffset + 1);

	public List<string> Tags => DC.GetListStringArray(_listStringOffset + 2);

	public bool Reforgeable => DC.BoolArray[_boolOffset];

	public string EnableFilters => DC.StringArray[_stringOffset + 8];

	public GDELegendItemPropertyData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
