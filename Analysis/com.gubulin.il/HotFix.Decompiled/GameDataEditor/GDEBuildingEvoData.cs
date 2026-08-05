namespace GameDataEditor;

public class GDEBuildingEvoData
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

	public string BuildingType => DC.StringArray[_stringOffset + 1];

	public int EvoLevel => DC.IntArray[_intOffset];

	public string EvoRequire => DC.StringArray[_stringOffset + 2];

	public int Slot => DC.IntArray[_intOffset + 1];

	public string Modifiers => DC.StringArray[_stringOffset + 3];

	public int UpgradeTime => DC.IntArray[_intOffset + 2];

	public GDEBuildingEvoData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
