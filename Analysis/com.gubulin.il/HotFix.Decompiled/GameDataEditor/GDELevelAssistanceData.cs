using System.Collections.Generic;

namespace GameDataEditor;

public class GDELevelAssistanceData
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

	public string ChapterId => DC.StringArray[_stringOffset + 1];

	public bool EnableAssistance => DC.BoolArray[_boolOffset];

	public List<string> AssistanceSoldier => DC.GetListStringArray(_listStringOffset);

	public List<int> AssistanceQty => DC.GetListIntArray(_listIntOffset);

	public List<int> AssistancePosition => DC.GetListIntArray(_listIntOffset + 1);

	public string AssistanceFormation => DC.StringArray[_stringOffset + 2];

	public List<int> LockPosition => DC.GetListIntArray(_listIntOffset + 2);

	public string Context => DC.StringArray[_stringOffset + 3];

	public int Difficult => DC.IntArray[_intOffset];

	public float EnemyPowerModifier => DC.FloatArray[_floatOffset];

	public string LevelFilters => DC.StringArray[_stringOffset + 4];

	public string SoldierFilters => DC.StringArray[_stringOffset + 5];

	public string ParentLevelId => DC.StringArray[_stringOffset + 6];

	public string SubLevels => DC.StringArray[_stringOffset + 7];

	public string Name => DC.StringArray[_stringOffset + 8];

	public string Desc => DC.StringArray[_stringOffset + 9];

	public string Icon => DC.StringArray[_stringOffset + 10];

	public float Refresh => DC.FloatArray[_floatOffset + 1];

	public int UpperLimit => DC.IntArray[_intOffset + 1];

	public bool Staging => DC.BoolArray[_boolOffset + 1];

	public int RedTeamBattleMode => DC.IntArray[_intOffset + 2];

	public int BlueTeamBattleMode => DC.IntArray[_intOffset + 3];

	public string RedTeamBoss => DC.StringArray[_stringOffset + 11];

	public string BlueTeamBoss => DC.StringArray[_stringOffset + 12];

	public string RedTeamCampImage => DC.StringArray[_stringOffset + 13];

	public string BlueTeamCampImage => DC.StringArray[_stringOffset + 14];

	public bool DynamicEnemy => DC.BoolArray[_boolOffset + 2];

	public string FromEnemyTemplatePool => DC.StringArray[_stringOffset + 15];

	public string Enemy1 => DC.StringArray[_stringOffset + 16];

	public int Number1 => DC.IntArray[_intOffset + 4];

	public int ExpGain1 => DC.IntArray[_intOffset + 5];

	public int TechGain1 => DC.IntArray[_intOffset + 6];

	public string Enemy2 => DC.StringArray[_stringOffset + 17];

	public int Number2 => DC.IntArray[_intOffset + 7];

	public int ExpGain2 => DC.IntArray[_intOffset + 8];

	public int TechGain2 => DC.IntArray[_intOffset + 9];

	public string Enemy3 => DC.StringArray[_stringOffset + 18];

	public int Number3 => DC.IntArray[_intOffset + 10];

	public int ExpGain3 => DC.IntArray[_intOffset + 11];

	public int TechGain3 => DC.IntArray[_intOffset + 12];

	public string Enemy4 => DC.StringArray[_stringOffset + 19];

	public int Number4 => DC.IntArray[_intOffset + 13];

	public int ExpGain4 => DC.IntArray[_intOffset + 14];

	public int TechGain4 => DC.IntArray[_intOffset + 15];

	public string Enemy5 => DC.StringArray[_stringOffset + 20];

	public int Number5 => DC.IntArray[_intOffset + 16];

	public string Enemy6 => DC.StringArray[_stringOffset + 21];

	public int Number6 => DC.IntArray[_intOffset + 17];

	public string Enemy7 => DC.StringArray[_stringOffset + 22];

	public int Number7 => DC.IntArray[_intOffset + 18];

	public string Enemy8 => DC.StringArray[_stringOffset + 23];

	public int Number8 => DC.IntArray[_intOffset + 19];

	public string Enemy9 => DC.StringArray[_stringOffset + 24];

	public int Number9 => DC.IntArray[_intOffset + 20];

	public string Enemy10 => DC.StringArray[_stringOffset + 25];

	public int Number10 => DC.IntArray[_intOffset + 21];

	public string Enemy11 => DC.StringArray[_stringOffset + 26];

	public int Number11 => DC.IntArray[_intOffset + 22];

	public string Enemy12 => DC.StringArray[_stringOffset + 27];

	public int Number12 => DC.IntArray[_intOffset + 23];

	public string RedFormationId => DC.StringArray[_stringOffset + 28];

	public string BlueFormationId => DC.StringArray[_stringOffset + 29];

	public float Length => DC.FloatArray[_floatOffset + 2];

	public string Obstacles => DC.StringArray[_stringOffset + 30];

	public float PositionX => DC.FloatArray[_floatOffset + 3];

	public string AutoProduceBonus => DC.StringArray[_stringOffset + 31];

	public bool AutoLottery => DC.BoolArray[_boolOffset + 3];

	public string TitleBonus => DC.StringArray[_stringOffset + 32];

	public string BonusDesc => DC.StringArray[_stringOffset + 33];

	public string LevelModifier => DC.StringArray[_stringOffset + 34];

	public string UnlockChapter => DC.StringArray[_stringOffset + 35];

	public string MapIdentifier => DC.StringArray[_stringOffset + 36];

	public string PlayAfterClaim => DC.StringArray[_stringOffset + 37];

	public string PlayAfterComplete => DC.StringArray[_stringOffset + 38];

	public string PlayAfterComplete_GuideForeign => DC.StringArray[_stringOffset + 39];

	public string Unlock => DC.StringArray[_stringOffset + 40];

	public string Lottery => DC.StringArray[_stringOffset + 41];

	public string Bonus => DC.StringArray[_stringOffset + 42];

	public string RepeatBonus => DC.StringArray[_stringOffset + 43];

	public string RepeatLottery => DC.StringArray[_stringOffset + 44];

	public GDELevelAssistanceData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
