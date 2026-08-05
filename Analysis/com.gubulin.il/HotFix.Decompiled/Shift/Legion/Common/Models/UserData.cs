namespace Shift.Legion.Common.Models;

public class UserData
{
	public int UserId { get; set; }

	public string Key { get; set; }

	public int Type { get; set; }

	public int Version { get; set; }

	public string Data { get; set; }

	public object Clone()
	{
		return MemberwiseClone();
	}
}
