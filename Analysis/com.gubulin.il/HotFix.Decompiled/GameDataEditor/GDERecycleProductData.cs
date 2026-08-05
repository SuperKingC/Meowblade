namespace GameDataEditor;

public class GDERecycleProductData
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

	public string Production => DC.StringArray[_stringOffset + 1];

	public string Requirement => DC.StringArray[_stringOffset + 2];

	public int ProduceWeight => DC.IntArray[_intOffset];

	public int Time => DC.IntArray[_intOffset + 1];

	public float Multiplier => DC.FloatArray[_floatOffset];

	public int Level1Weight => DC.IntArray[_intOffset + 2];

	public int Level2Weight => DC.IntArray[_intOffset + 3];

	public int Level3Weight => DC.IntArray[_intOffset + 4];

	public int Level4Weight => DC.IntArray[_intOffset + 5];

	public int Level5Weight => DC.IntArray[_intOffset + 6];

	public string LevelFilter => DC.StringArray[_stringOffset + 3];

	public GDERecycleProductData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
