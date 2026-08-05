namespace GameDataEditor;

public class GDEBuildingData
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

	public string Prefab => DC.StringArray[_stringOffset + 2];

	public string Feature => DC.StringArray[_stringOffset + 3];

	public string PrefabConfig => DC.StringArray[_stringOffset + 4];

	public string FeatureConfig => DC.StringArray[_stringOffset + 5];

	public string Desc => DC.StringArray[_stringOffset + 6];

	public int Status => DC.IntArray[_intOffset];

	public GDEBuildingData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
