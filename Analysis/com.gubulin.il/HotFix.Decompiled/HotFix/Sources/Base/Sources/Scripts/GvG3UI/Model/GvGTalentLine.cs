namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGTalentLine
{
	public float Length;

	public float Rotation;

	public string Id { get; }

	public int SmallerIdx { get; }

	public int LargerIdx { get; }

	public float X { get; }

	public float Y { get; }

	public GvGTalentLine(string lineId, int smallerIdx, int largerIdx, float length, float rotation, float x, float y)
	{
		Id = lineId;
		Length = length;
		Rotation = rotation;
		SmallerIdx = smallerIdx;
		LargerIdx = largerIdx;
		X = x;
		Y = y;
	}
}
