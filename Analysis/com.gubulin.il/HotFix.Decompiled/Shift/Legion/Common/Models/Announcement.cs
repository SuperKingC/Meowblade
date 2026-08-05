namespace Shift.Legion.Common.Models;

public class Announcement
{
	public int Id { get; set; }

	public string Content { get; set; }

	public int Status { get; set; } = 1;

	public int SortOrder { get; set; }

	public int Type { get; set; }

	public int From { get; set; }
}
