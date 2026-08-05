namespace GameDataEditor;

public class GDEGvGAmplifierConfigData
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

	public int Idx => DC.IntArray[_intOffset];

	public int Quality => DC.IntArray[_intOffset + 1];

	public int NextQualityIdx => DC.IntArray[_intOffset + 2];

	public int tag => DC.IntArray[_intOffset + 3];

	public int Type => DC.IntArray[_intOffset + 4];

	public string Icon => DC.StringArray[_stringOffset + 1];

	public string Name => DC.StringArray[_stringOffset + 2];

	public string EffectRangeDesc => DC.StringArray[_stringOffset + 3];

	public string Desc => DC.StringArray[_stringOffset + 4];

	public string AffectedFaction => DC.StringArray[_stringOffset + 5];

	public string AffectedSoldier => DC.StringArray[_stringOffset + 6];

	public string Effect => DC.StringArray[_stringOffset + 7];

	public int Score => DC.IntArray[_intOffset + 5];

	public float ContributionPoint => DC.FloatArray[_floatOffset];

	public float ContributionPoint_1 => DC.FloatArray[_floatOffset + 1];

	public float SettlementScore => DC.FloatArray[_floatOffset + 2];

	public GDEGvGAmplifierConfigData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
