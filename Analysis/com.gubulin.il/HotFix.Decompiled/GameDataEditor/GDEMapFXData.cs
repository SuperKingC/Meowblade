namespace GameDataEditor;

public class GDEMapFXData
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

	public string MapIdentifier => DC.StringArray[_stringOffset + 1];

	public string BackgroundMusic => DC.StringArray[_stringOffset + 2];

	public string TopFx => DC.StringArray[_stringOffset + 3];

	public float TopFxOffset => DC.FloatArray[_floatOffset];

	public string MainFx => DC.StringArray[_stringOffset + 4];

	public float MainFxOffset => DC.FloatArray[_floatOffset + 1];

	public string CloseFx => DC.StringArray[_stringOffset + 5];

	public float CloseFxOffset => DC.FloatArray[_floatOffset + 2];

	public string FarFx => DC.StringArray[_stringOffset + 6];

	public float FarFxOffset => DC.FloatArray[_floatOffset + 3];

	public GDEMapFXData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
