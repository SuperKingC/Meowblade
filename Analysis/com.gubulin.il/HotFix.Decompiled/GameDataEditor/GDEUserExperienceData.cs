using System.Collections.Generic;

namespace GameDataEditor;

public class GDEUserExperienceData
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

	public int Level => DC.IntArray[_intOffset];

	public int Exp => DC.IntArray[_intOffset + 1];

	public string Bonus => DC.StringArray[_stringOffset + 1];

	public string Modifier => DC.StringArray[_stringOffset + 2];

	public string UIUnlock => DC.StringArray[_stringOffset + 3];

	public string BuildingMaxLevel => DC.StringArray[_stringOffset + 4];

	public string ItemMaxLevel => DC.StringArray[_stringOffset + 5];

	public int SoldierMaxEvoLevel => DC.IntArray[_intOffset + 2];

	public int SoldierMaxStars => DC.IntArray[_intOffset + 3];

	public int FormationSlots => DC.IntArray[_intOffset + 4];

	public int InvitingSlots => DC.IntArray[_intOffset + 5];

	public List<string> Desc => DC.GetListStringArray(_listStringOffset);

	public List<string> Icon => DC.GetListStringArray(_listStringOffset + 1);

	public List<string> Tag => DC.GetListStringArray(_listStringOffset + 2);

	public GDEUserExperienceData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
