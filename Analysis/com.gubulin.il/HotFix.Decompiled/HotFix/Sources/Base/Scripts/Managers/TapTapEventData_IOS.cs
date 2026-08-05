namespace HotFix.Sources.Base.Scripts.Managers;

public class TapTapEventData_IOS
{
	public int UserId { get; set; }

	public int EventType { get; set; }

	public long EventTimestamp { get; set; }

	public string IDFA { get; set; }

	public string Ip { get; set; }

	public string Ipv6 { get; set; }

	public string Model { get; set; }

	public string Ua { get; set; }

	public string Device { get; set; }

	public int Amount { get; set; }

	public string DeviceUniqueIdentifier { get; set; }
}
