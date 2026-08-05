using System.Collections.Generic;

namespace GameDataEditor;

public class GDEGvGIslandMapConfigData
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

	public int IslandProcessLoad => DC.IntArray[_intOffset];

	public float MapWidth => DC.FloatArray[_floatOffset];

	public float MapHeight => DC.FloatArray[_floatOffset + 1];

	public string Image => DC.StringArray[_stringOffset + 1];

	public string PrefabName => DC.StringArray[_stringOffset + 2];

	public string Zone => DC.StringArray[_stringOffset + 3];

	public int CampMaxShipCount => DC.IntArray[_intOffset + 1];

	public float BaseCollectingEfficiency => DC.FloatArray[_floatOffset + 2];

	public List<string> NormalCollectingGroup => DC.GetListStringArray(_listStringOffset);

	public List<string> HiddenCollectingGroup => DC.GetListStringArray(_listStringOffset + 1);

	public string ExtraCollectingGroup => DC.StringArray[_stringOffset + 4];

	public int FoodCost_Attack => DC.IntArray[_intOffset + 2];

	public int FoodCost_Collect => DC.IntArray[_intOffset + 3];

	public int FoodCost_SuppressRebellion => DC.IntArray[_intOffset + 4];

	public int Type => DC.IntArray[_intOffset + 5];

	public int REIslandCD => DC.IntArray[_intOffset + 6];

	public string Supplies => DC.StringArray[_stringOffset + 5];

	public string SweepReward => DC.StringArray[_stringOffset + 6];

	public int EnergyEfficiency => DC.IntArray[_intOffset + 7];

	public int DiscoveryLevel => DC.IntArray[_intOffset + 8];

	public int DiscoveryTime => DC.IntArray[_intOffset + 9];

	public int DiscoveryCoolDown => DC.IntArray[_intOffset + 10];

	public bool IsVisible => DC.BoolArray[_boolOffset];

	public int MinDiscoveryTimeToDetect => DC.IntArray[_intOffset + 11];

	public int ShieldValue => DC.IntArray[_intOffset + 12];

	public string Reward => DC.StringArray[_stringOffset + 7];

	public string DefenderZone => DC.StringArray[_stringOffset + 8];

	public string ZoneConfigs => DC.StringArray[_stringOffset + 9];

	public string TriggerType_1 => DC.StringArray[_stringOffset + 10];

	public string TriggerCondition_1 => DC.StringArray[_stringOffset + 11];

	public string TriggerType_2 => DC.StringArray[_stringOffset + 12];

	public string TriggerCondition_2 => DC.StringArray[_stringOffset + 13];

	public string TriggerType_3 => DC.StringArray[_stringOffset + 14];

	public string TriggerCondition_3 => DC.StringArray[_stringOffset + 15];

	public string TriggerType_4 => DC.StringArray[_stringOffset + 16];

	public string TriggerCondition_4 => DC.StringArray[_stringOffset + 17];

	public string TriggerType_5 => DC.StringArray[_stringOffset + 18];

	public string TriggerCondition_5 => DC.StringArray[_stringOffset + 19];

	public string TriggerType_6 => DC.StringArray[_stringOffset + 20];

	public string TriggerCondition_6 => DC.StringArray[_stringOffset + 21];

	public string TriggerType_7 => DC.StringArray[_stringOffset + 22];

	public string TriggerCondition_7 => DC.StringArray[_stringOffset + 23];

	public string TriggerType_8 => DC.StringArray[_stringOffset + 24];

	public string TriggerCondition_8 => DC.StringArray[_stringOffset + 25];

	public string TriggerType_9 => DC.StringArray[_stringOffset + 26];

	public string TriggerCondition_9 => DC.StringArray[_stringOffset + 27];

	public string DisplayReward => DC.StringArray[_stringOffset + 28];

	public bool CanUseFireSupport => DC.BoolArray[_boolOffset + 1];

	public GDEGvGIslandMapConfigData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
