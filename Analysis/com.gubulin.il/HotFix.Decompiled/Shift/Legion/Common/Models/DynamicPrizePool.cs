using System.ComponentModel.DataAnnotations;

namespace Shift.Legion.Common.Models;

public class DynamicPrizePool : PrizePool
{
	public string Content;

	public string Schedule;

	[Key]
	public new string Id { get; set; }
}
