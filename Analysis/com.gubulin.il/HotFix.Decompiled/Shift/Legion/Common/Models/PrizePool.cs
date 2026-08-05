using System.ComponentModel.DataAnnotations;

namespace Shift.Legion.Common.Models;

public class PrizePool
{
	public string BonusConfig;

	public string UnlockConfig;

	[Key]
	public string Id { get; set; }
}
