using System.Collections.Generic;

namespace GameDataEditor;

public class GDEGvGMode3CampMissionData
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

	public string Desc => DC.StringArray[_stringOffset + 2];

	public string Type => DC.StringArray[_stringOffset + 3];

	public string SubType => DC.StringArray[_stringOffset + 4];

	public string SubTypeData => DC.StringArray[_stringOffset + 5];

	public string Icon => DC.StringArray[_stringOffset + 6];

	public int EventIconIdx => DC.IntArray[_intOffset];

	public string UiIcon => DC.StringArray[_stringOffset + 7];

	public int GroupId => DC.IntArray[_intOffset + 1];

	public int Progress => DC.IntArray[_intOffset + 2];

	public int Step => DC.IntArray[_intOffset + 3];

	public List<string> Tags => DC.GetListStringArray(_listStringOffset);

	public string MissionCost => DC.StringArray[_stringOffset + 8];

	public int Timer => DC.IntArray[_intOffset + 4];

	public string CheckValueOnCreate => DC.StringArray[_stringOffset + 9];

	public string TriggerOnCreate => DC.StringArray[_stringOffset + 10];

	public string CheckValueOnAccept => DC.StringArray[_stringOffset + 11];

	public string TriggerOnAccept => DC.StringArray[_stringOffset + 12];

	public string SucessCheckRole => DC.StringArray[_stringOffset + 13];

	public string SucessCheckValue => DC.StringArray[_stringOffset + 14];

	public string TriggerOnSucess => DC.StringArray[_stringOffset + 15];

	public string FailedCheckRole => DC.StringArray[_stringOffset + 16];

	public string FailedCheckValue => DC.StringArray[_stringOffset + 17];

	public string TriggerOnFailed => DC.StringArray[_stringOffset + 18];

	public string TriggerOnFinish => DC.StringArray[_stringOffset + 19];

	public string MissionBonus => DC.StringArray[_stringOffset + 20];

	public string ShowBonus => DC.StringArray[_stringOffset + 21];

	public GDEGvGMode3CampMissionData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
