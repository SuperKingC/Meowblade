namespace Shift.Legion.Common.Sources.Enums;

public static class MissionStatusExtension
{
	public static int GetSortOrder(this MissionStatus status)
	{
		return status switch
		{
			MissionStatus.Disabled => 6, 
			MissionStatus.Pending => 5, 
			MissionStatus.Undergoing => 2, 
			MissionStatus.Failed => 4, 
			MissionStatus.Completed => 1, 
			MissionStatus.Claimed => 3, 
			_ => 100, 
		};
	}
}
