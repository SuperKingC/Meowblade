using System.Collections.Generic;

namespace GameDataEditor;

public class GDELegendItemData
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

	public string Icon => DC.StringArray[_stringOffset + 2];

	public string Desc => DC.StringArray[_stringOffset + 3];

	public List<string> Tags => DC.GetListStringArray(_listStringOffset);

	public int Rarity => DC.IntArray[_intOffset];

	public string EvoId => DC.StringArray[_stringOffset + 4];

	public int ExpProvide => DC.IntArray[_intOffset + 1];

	public string SetId => DC.StringArray[_stringOffset + 5];

	public string Identity => DC.StringArray[_stringOffset + 6];

	public string EnhanceConfig => DC.StringArray[_stringOffset + 7];

	public string EnhanceCostPerExp => DC.StringArray[_stringOffset + 8];

	public string ChangePropertyCost => DC.StringArray[_stringOffset + 9];

	public string ReforgeCost => DC.StringArray[_stringOffset + 10];

	public string ReforgeLockCost => DC.StringArray[_stringOffset + 11];

	public GDELegendItemData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
