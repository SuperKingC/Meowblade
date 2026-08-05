using System.Collections.Generic;

namespace GameDataEditor;

public class GDEGvGCampMissionData
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

	public string Icon => DC.StringArray[_stringOffset + 2];

	public string Desc => DC.StringArray[_stringOffset + 3];

	public List<string> Tags => DC.GetListStringArray(_listStringOffset);

	public string TriggerEvent => DC.StringArray[_stringOffset + 4];

	public string TriggerType => DC.StringArray[_stringOffset + 5];

	public string TriggerCondition => DC.StringArray[_stringOffset + 6];

	public string Bonus => DC.StringArray[_stringOffset + 7];

	public string DisplayBonus => DC.StringArray[_stringOffset + 8];

	public string SendBonusWay => DC.StringArray[_stringOffset + 9];

	public string SendBonusWayContent => DC.StringArray[_stringOffset + 10];

	public string MarqueeContent => DC.StringArray[_stringOffset + 11];

	public GDEGvGCampMissionData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
