using System.Collections.Generic;

namespace GameDataEditor;

public class GDEMissionData
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

	public bool Enabled => DC.BoolArray[_boolOffset];

	public string Name => DC.StringArray[_stringOffset + 1];

	public string Desc => DC.StringArray[_stringOffset + 2];

	public string Icon => DC.StringArray[_stringOffset + 3];

	public List<string> Tags => DC.GetListStringArray(_listStringOffset);

	public int Type => DC.IntArray[_intOffset];

	public string JumpContext => DC.StringArray[_stringOffset + 4];

	public string JumpContextParams => DC.StringArray[_stringOffset + 5];

	public string GameLevelFilter => DC.StringArray[_stringOffset + 6];

	public int UserLevelFilter => DC.IntArray[_intOffset + 1];

	public int DungeonLevelFilter => DC.IntArray[_intOffset + 2];

	public string OwnedItemFilter => DC.StringArray[_stringOffset + 7];

	public string PurchaseFilter => DC.StringArray[_stringOffset + 8];

	public string MissionFilter => DC.StringArray[_stringOffset + 9];

	public string StoryLineNodeVersionFilter => DC.StringArray[_stringOffset + 10];

	public string CompleteTrigger => DC.StringArray[_stringOffset + 11];

	public string TriggerPayload => DC.StringArray[_stringOffset + 12];

	public string ClaimFilter_Purchase => DC.StringArray[_stringOffset + 13];

	public string ProgressFilter_MissionClaimed => DC.StringArray[_stringOffset + 14];

	public string Bonus => DC.StringArray[_stringOffset + 15];

	public string DisplayBonus => DC.StringArray[_stringOffset + 16];

	public string Extra => DC.StringArray[_stringOffset + 17];

	public string KickOffAt => DC.StringArray[_stringOffset + 18];

	public string ExpireAt => DC.StringArray[_stringOffset + 19];

	public string NextMission => DC.StringArray[_stringOffset + 20];

	public string StoryNodeNextMission => DC.StringArray[_stringOffset + 21];

	public GDEMissionData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
