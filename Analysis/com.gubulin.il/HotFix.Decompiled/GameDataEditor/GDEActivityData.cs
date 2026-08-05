using System.Collections.Generic;

namespace GameDataEditor;

public class GDEActivityData
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

	public int Status => DC.IntArray[_intOffset];

	public bool Singleton => DC.BoolArray[_boolOffset];

	public string Parent => DC.StringArray[_stringOffset + 1];

	public string SubActivity => DC.StringArray[_stringOffset + 2];

	public string LevelCase => DC.StringArray[_stringOffset + 3];

	public string SoldierCase => DC.StringArray[_stringOffset + 4];

	public string PurchaseCase => DC.StringArray[_stringOffset + 5];

	public int DifficultyLevel => DC.IntArray[_intOffset + 1];

	public string FormationTag => DC.StringArray[_stringOffset + 6];

	public string Name => DC.StringArray[_stringOffset + 7];

	public string Desc => DC.StringArray[_stringOffset + 8];

	public string ImgUrl => DC.StringArray[_stringOffset + 9];

	public string Background => DC.StringArray[_stringOffset + 10];

	public int Type => DC.IntArray[_intOffset + 2];

	public string ScoreItem => DC.StringArray[_stringOffset + 11];

	public string TicketItem => DC.StringArray[_stringOffset + 12];

	public bool AutoFillTicket => DC.BoolArray[_boolOffset + 1];

	public int TicketFillPeriod => DC.IntArray[_intOffset + 3];

	public int TicketFillQuantity => DC.IntArray[_intOffset + 4];

	public int TicketLimit => DC.IntArray[_intOffset + 5];

	public string TicketPrice => DC.StringArray[_stringOffset + 13];

	public List<string> BonusExhibition => DC.GetListStringArray(_listStringOffset);

	public string BonusProgress => DC.StringArray[_stringOffset + 14];

	public int ContentType => DC.IntArray[_intOffset + 6];

	public int ContentUnlockType => DC.IntArray[_intOffset + 7];

	public string UI => DC.StringArray[_stringOffset + 15];

	public bool CanReset => DC.BoolArray[_boolOffset + 2];

	public string ResetCost => DC.StringArray[_stringOffset + 16];

	public string ContentPayload => DC.StringArray[_stringOffset + 17];

	public bool DynamicBeginTime => DC.BoolArray[_boolOffset + 3];

	public int Period => DC.IntArray[_intOffset + 8];

	public List<string> BeginTime => DC.GetListStringArray(_listStringOffset + 1);

	public List<string> EndTime => DC.GetListStringArray(_listStringOffset + 2);

	public int SettleTime => DC.IntArray[_intOffset + 9];

	public GDEActivityData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
