using System.Threading.Tasks;

namespace Shift.Legion.Common.Models;

public class CustomTaskCompletionSource<T> : TaskCompletionSource<T>
{
	public string Id { get; set; }

	public bool IsAsync { get; set; }

	public bool Skip { get; set; }

	public bool CanSkip { get; set; }
}
