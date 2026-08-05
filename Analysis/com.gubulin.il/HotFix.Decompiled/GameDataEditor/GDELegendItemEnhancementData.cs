namespace GameDataEditor;

public class GDELegendItemEnhancementData
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

	public string EnhanceConfigId => DC.StringArray[_stringOffset + 1];

	public int EnhanceLevel => DC.IntArray[_intOffset];

	public int ExpRequire => DC.IntArray[_intOffset + 1];

	public int SubPropertiesUnlock => DC.IntArray[_intOffset + 2];

	public string MainProperiesPayload => DC.StringArray[_stringOffset + 2];

	public GDELegendItemEnhancementData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
