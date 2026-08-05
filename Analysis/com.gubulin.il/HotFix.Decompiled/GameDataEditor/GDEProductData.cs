using System.Collections.Generic;

namespace GameDataEditor;

public class GDEProductData
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

	public string ItemId => DC.StringArray[_stringOffset + 1];

	public string MaterialIcon => DC.StringArray[_stringOffset + 2];

	public string ProductIcon => DC.StringArray[_stringOffset + 3];

	public float Time => DC.FloatArray[_floatOffset];

	public int SingleNumber => DC.IntArray[_intOffset];

	public bool Hide => DC.BoolArray[_boolOffset];

	public bool AddOn => DC.BoolArray[_boolOffset + 1];

	public int Weight => DC.IntArray[_intOffset + 1];

	public List<string> BuildType => DC.GetListStringArray(_listStringOffset);

	public int StuffNumber => DC.IntArray[_intOffset + 2];

	public string Stuff1 => DC.StringArray[_stringOffset + 4];

	public int Number1 => DC.IntArray[_intOffset + 3];

	public string Stuff2 => DC.StringArray[_stringOffset + 5];

	public int Number2 => DC.IntArray[_intOffset + 4];

	public string Stuff3 => DC.StringArray[_stringOffset + 6];

	public int Number3 => DC.IntArray[_intOffset + 5];

	public string Stuff4 => DC.StringArray[_stringOffset + 7];

	public int Number4 => DC.IntArray[_intOffset + 6];

	public string Stuff5 => DC.StringArray[_stringOffset + 8];

	public int Number5 => DC.IntArray[_intOffset + 7];

	public int GvGIslandStock => DC.IntArray[_intOffset + 8];

	public float GvGCollectingContributionPoint => DC.FloatArray[_floatOffset + 1];

	public GDEProductData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
