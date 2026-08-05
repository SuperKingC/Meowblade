namespace HotFix.Sources.Base.Scripts.Managers;

public class EventParams
{
	public string ContentType { get; set; } = "";

	public string ContentId { get; set; } = "";

	public string Content { get; set; } = "";

	public bool PaymentInfoAvailable { get; set; } = true;

	public double ValueToSum { get; set; }

	public int NumItems { get; set; } = 0;

	public string Currency { get; set; } = "";

	public string Description { get; set; } = "";

	public string Level { get; set; } = "";

	public string OrderId { get; set; } = "";

	public string RegistrationMethod { get; set; } = "";
}
