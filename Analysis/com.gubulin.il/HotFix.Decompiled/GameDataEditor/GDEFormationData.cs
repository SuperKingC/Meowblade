using GameMaths;

namespace GameDataEditor;

public class GDEFormationData
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

	public bool UnlockedAtBegin => DC.BoolArray[_boolOffset];

	public bool PlayerUsable => DC.BoolArray[_boolOffset + 1];

	public string Description => DC.StringArray[_stringOffset + 2];

	public string Icon => DC.StringArray[_stringOffset + 3];

	public Vector2 Slot1 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset]);

	public Vector2 Size1 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 1]);

	public float VisionRadius1 => DC.FloatArray[_floatOffset];

	public Vector2 Slot2 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 2]);

	public Vector2 Size2 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 3]);

	public float VisionRadius2 => DC.FloatArray[_floatOffset + 1];

	public Vector2 Slot3 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 4]);

	public Vector2 Size3 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 5]);

	public float VisionRadius3 => DC.FloatArray[_floatOffset + 2];

	public Vector2 Slot4 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 6]);

	public Vector2 Size4 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 7]);

	public float VisionRadius4 => DC.FloatArray[_floatOffset + 3];

	public Vector2 Slot5 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 8]);

	public Vector2 Size5 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 9]);

	public float VisionRadius5 => DC.FloatArray[_floatOffset + 4];

	public Vector2 Slot6 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 10]);

	public Vector2 Size6 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 11]);

	public float VisionRadius6 => DC.FloatArray[_floatOffset + 5];

	public Vector2 Slot7 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 12]);

	public Vector2 Size7 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 13]);

	public float VisionRadius7 => DC.FloatArray[_floatOffset + 6];

	public Vector2 Slot8 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 14]);

	public Vector2 Size8 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 15]);

	public float VisionRadius8 => DC.FloatArray[_floatOffset + 7];

	public Vector2 Slot9 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 16]);

	public Vector2 Size9 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 17]);

	public float VisionRadius9 => DC.FloatArray[_floatOffset + 8];

	public Vector2 Slot10 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 18]);

	public Vector2 Size10 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 19]);

	public float VisionRadius10 => DC.FloatArray[_floatOffset + 9];

	public Vector2 Slot11 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 20]);

	public Vector2 Size11 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 21]);

	public float VisionRadius11 => DC.FloatArray[_floatOffset + 10];

	public Vector2 Slot12 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 22]);

	public Vector2 Size12 => DataContainer.Vector2(DC.Vector2Array[_vector2Offset + 23]);

	public float VisionRadius12 => DC.FloatArray[_floatOffset + 11];

	public GDEFormationData(int stringOffset, int intOffset, int floatOffset, int boolOffset, int vector2Offset, int listStringOffset, int listIntOffset)
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
