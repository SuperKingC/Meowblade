namespace Shift.Legion.GvGServer.Models.Map;

public class GvGMode3IZInfo
{
	public int Create { get; set; }

	public int Display { get; set; }

	public int NotDisplay { get; set; }

	public int Start { get; set; }

	public int Settlement { get; set; }

	public int Stop { get; set; }

	public string ShowName { get; set; }

	public bool TestServer { get; set; }

	public int SignUp_Start { get; set; }

	public int SignUp_CancellationForbidden { get; set; }

	public int SignUp_Stop { get; set; }

	public bool IsStarted(int now)
	{
		return now > Start;
	}

	public bool CanSignUp(int now)
	{
		return now > SignUp_Start && now < SignUp_Stop;
	}

	public bool CanCancelSignUp(int now)
	{
		return CanSignUp(now) && now < SignUp_CancellationForbidden;
	}
}
