using System.Collections.Generic;

namespace GameDataEditor;

public class GDETechnologyData
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

	public int Type => DC.IntArray[_intOffset];

	public string Icon => DC.StringArray[_stringOffset + 2];

	public string GainDescrible => DC.StringArray[_stringOffset + 3];

	public List<string> FrontTechs => DC.GetListStringArray(_listStringOffset);

	public string Level1Cost => DC.StringArray[_stringOffset + 4];

	public string Level2Cost => DC.StringArray[_stringOffset + 5];

	public string Level3Cost => DC.StringArray[_stringOffset + 6];

	public string Level4Cost => DC.StringArray[_stringOffset + 7];

	public string Level5Cost => DC.StringArray[_stringOffset + 8];

	public string Level6Cost => DC.StringArray[_stringOffset + 9];

	public string Level7Cost => DC.StringArray[_stringOffset + 10];

	public string Level8Cost => DC.StringArray[_stringOffset + 11];

	public string Level9Cost => DC.StringArray[_stringOffset + 12];

	public string Level10Cost => DC.StringArray[_stringOffset + 13];

	public GDETechnologyData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
