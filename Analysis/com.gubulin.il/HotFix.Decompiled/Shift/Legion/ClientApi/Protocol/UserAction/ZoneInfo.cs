namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class ZoneInfo
{
	public string RSName;

	public string ShowName;

	public float Load;

	public double AverageCompbatPower;

	public int GetZoneBtnType()
	{
		if (Load <= 0.375f)
		{
			return 0;
		}
		if (Load <= 0.625f)
		{
			return 1;
		}
		if (Load < 1f)
		{
			return 2;
		}
		return 3;
	}
}
