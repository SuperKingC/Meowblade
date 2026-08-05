namespace HotFix.Sources.Base.Scripts.UserTrack;

public class UserTrackData_CodeVersionDiff : UserTrackData
{
	public bool IsSame { get; set; }

	public string LocalMd5 { get; set; }

	public string ServerMd5 { get; set; }
}
