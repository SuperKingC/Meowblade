namespace GameDataEditor;

public class GDERankGameConfigData
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

	public int SeasonId => DC.IntArray[_intOffset];

	public string Name => DC.StringArray[_stringOffset + 1];

	public string RankBonusDesc => DC.StringArray[_stringOffset + 2];

	public string ScoreRankBonusDesc => DC.StringArray[_stringOffset + 3];

	public string StartAt => DC.StringArray[_stringOffset + 4];

	public string FinishAt => DC.StringArray[_stringOffset + 5];

	public string RankSettlementRange1 => DC.StringArray[_stringOffset + 6];

	public string RankSettlementBonus1 => DC.StringArray[_stringOffset + 7];

	public string RankSettlementDisplay1 => DC.StringArray[_stringOffset + 8];

	public string RankSettlementRange2 => DC.StringArray[_stringOffset + 9];

	public string RankSettlementBonus2 => DC.StringArray[_stringOffset + 10];

	public string RankSettlementDisplay2 => DC.StringArray[_stringOffset + 11];

	public string RankSettlementRange3 => DC.StringArray[_stringOffset + 12];

	public string RankSettlementBonus3 => DC.StringArray[_stringOffset + 13];

	public string RankSettlementDisplay3 => DC.StringArray[_stringOffset + 14];

	public string RankSettlementRange4 => DC.StringArray[_stringOffset + 15];

	public string RankSettlementBonus4 => DC.StringArray[_stringOffset + 16];

	public string RankSettlementDisplay4 => DC.StringArray[_stringOffset + 17];

	public string RankSettlementRange5 => DC.StringArray[_stringOffset + 18];

	public string RankSettlementBonus5 => DC.StringArray[_stringOffset + 19];

	public string RankSettlementDisplay5 => DC.StringArray[_stringOffset + 20];

	public string RankSettlementRange6 => DC.StringArray[_stringOffset + 21];

	public string RankSettlementBonus6 => DC.StringArray[_stringOffset + 22];

	public string RankSettlementDisplay6 => DC.StringArray[_stringOffset + 23];

	public string RankSettlementRange7 => DC.StringArray[_stringOffset + 24];

	public string RankSettlementBonus7 => DC.StringArray[_stringOffset + 25];

	public string RankSettlementDisplay7 => DC.StringArray[_stringOffset + 26];

	public string RankSettlementRange8 => DC.StringArray[_stringOffset + 27];

	public string RankSettlementBonus8 => DC.StringArray[_stringOffset + 28];

	public string RankSettlementDisplay8 => DC.StringArray[_stringOffset + 29];

	public string ScoreRankSettlementRange1 => DC.StringArray[_stringOffset + 30];

	public string ScoreRankSettlementBonus1 => DC.StringArray[_stringOffset + 31];

	public string ScoreRankSettlementDisplay1 => DC.StringArray[_stringOffset + 32];

	public string ScoreRankSettlementRange2 => DC.StringArray[_stringOffset + 33];

	public string ScoreRankSettlementBonus2 => DC.StringArray[_stringOffset + 34];

	public string ScoreRankSettlementDisplay2 => DC.StringArray[_stringOffset + 35];

	public string ScoreRankSettlementRange3 => DC.StringArray[_stringOffset + 36];

	public string ScoreRankSettlementBonus3 => DC.StringArray[_stringOffset + 37];

	public string ScoreRankSettlementDisplay3 => DC.StringArray[_stringOffset + 38];

	public string ScoreRankSettlementRange4 => DC.StringArray[_stringOffset + 39];

	public string ScoreRankSettlementBonus4 => DC.StringArray[_stringOffset + 40];

	public string ScoreRankSettlementDisplay4 => DC.StringArray[_stringOffset + 41];

	public string ScoreRankSettlementRange5 => DC.StringArray[_stringOffset + 42];

	public string ScoreRankSettlementBonus5 => DC.StringArray[_stringOffset + 43];

	public string ScoreRankSettlementDisplay5 => DC.StringArray[_stringOffset + 44];

	public string ScoreRankSettlementRange6 => DC.StringArray[_stringOffset + 45];

	public string ScoreRankSettlementBonus6 => DC.StringArray[_stringOffset + 46];

	public string ScoreRankSettlementDisplay6 => DC.StringArray[_stringOffset + 47];

	public string ScoreRankSettlementRange7 => DC.StringArray[_stringOffset + 48];

	public string ScoreRankSettlementBonus7 => DC.StringArray[_stringOffset + 49];

	public string ScoreRankSettlementDisplay7 => DC.StringArray[_stringOffset + 50];

	public string ScoreRankSettlementRange8 => DC.StringArray[_stringOffset + 51];

	public string ScoreRankSettlementBonus8 => DC.StringArray[_stringOffset + 52];

	public string ScoreRankSettlementDisplay8 => DC.StringArray[_stringOffset + 53];

	public string ScoreRankSettlementRange9 => DC.StringArray[_stringOffset + 54];

	public string ScoreRankSettlementBonus9 => DC.StringArray[_stringOffset + 55];

	public string ScoreRankSettlementDisplay9 => DC.StringArray[_stringOffset + 56];

	public string ScoreRankSettlementRange10 => DC.StringArray[_stringOffset + 57];

	public string ScoreRankSettlementBonus10 => DC.StringArray[_stringOffset + 58];

	public string ScoreRankSettlementDisplay10 => DC.StringArray[_stringOffset + 59];

	public GDERankGameConfigData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
