namespace GameDataEditor;

public class GDEInvitingConfigData
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

	public int UserLevel => DC.IntArray[_intOffset];

	public int InvitedWorkerLifeTime => DC.IntArray[_intOffset + 1];

	public float WorkerProduceEfficiencyModifier => DC.FloatArray[_floatOffset];

	public string InvitingBonus => DC.StringArray[_stringOffset + 1];

	public string InvitedBonus => DC.StringArray[_stringOffset + 2];

	public GDEInvitingConfigData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
