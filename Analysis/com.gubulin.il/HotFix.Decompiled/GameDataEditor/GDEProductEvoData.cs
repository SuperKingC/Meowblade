namespace GameDataEditor;

public class GDEProductEvoData
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

	public string Level1 => DC.StringArray[_stringOffset + 1];

	public string Demand1 => DC.StringArray[_stringOffset + 2];

	public string FragBonus1 => DC.StringArray[_stringOffset + 3];

	public string FragDemand1 => DC.StringArray[_stringOffset + 4];

	public string Level2 => DC.StringArray[_stringOffset + 5];

	public string Demand2 => DC.StringArray[_stringOffset + 6];

	public string FragBonus2 => DC.StringArray[_stringOffset + 7];

	public string FragDemand2 => DC.StringArray[_stringOffset + 8];

	public string Level3 => DC.StringArray[_stringOffset + 9];

	public string Demand3 => DC.StringArray[_stringOffset + 10];

	public string FragBonus3 => DC.StringArray[_stringOffset + 11];

	public string FragDemand3 => DC.StringArray[_stringOffset + 12];

	public string Level4 => DC.StringArray[_stringOffset + 13];

	public string Demand4 => DC.StringArray[_stringOffset + 14];

	public string FragBonus4 => DC.StringArray[_stringOffset + 15];

	public string FragDemand4 => DC.StringArray[_stringOffset + 16];

	public string Level5 => DC.StringArray[_stringOffset + 17];

	public string Demand5 => DC.StringArray[_stringOffset + 18];

	public string FragBonus5 => DC.StringArray[_stringOffset + 19];

	public string FragDemand5 => DC.StringArray[_stringOffset + 20];

	public string Level6 => DC.StringArray[_stringOffset + 21];

	public string Demand6 => DC.StringArray[_stringOffset + 22];

	public string FragBonus6 => DC.StringArray[_stringOffset + 23];

	public string FragDemand6 => DC.StringArray[_stringOffset + 24];

	public GDEProductEvoData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
